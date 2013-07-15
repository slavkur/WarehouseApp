using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WarehouseApp
{
    public partial class LoadingListForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private OleDbConnection conn;
        private OleDbDataAdapter adapter;
        private DataSet dataSet;

        private int stockId;
        private String listId;
        private String updateString;

        private ToolStripMenuItem checkedMenuItem;

        public event SetTruckNumberEvent SetTruckNumber;
        public delegate void UpdateParametersEvent(OleDbParameterCollection parameters);
        public delegate void SetTruckNumberEvent(Control truckTb, String listId, DataSet dataSet);
        
        private DataGridViewPrinter dataGridViewPrinter;
        private DataGridView printDataGridView;

        private ToolStripMenuItem CheckedMenuItem
        {
            get
            {
                return (checkedMenuItem == null) ? tsmiLoadingList : checkedMenuItem;
            }

            set
            {
                MainWindow.tsmi_ToggleFont(false, CheckedMenuItem);
                checkedMenuItem = value;
                Text = CheckedMenuItem.Text;
                MainWindow.tsmi_ToggleFont(true, CheckedMenuItem);
            }
        }

        public LoadingListForm(int stockId, String title, String listId, String updateString)
        {
            this.InitializeComponent();
            this.tsmiLoadingList.Text = title;
            this.conn = new OleDbConnection(Program.connectionString);
            this.stockId = stockId;
            this.listId = listId;
            this.updateString = updateString;
        }

        private void LoadingListForm_Load(object sender, EventArgs e)
        {
            tsmiLoadingList_Click(tsmiLoadingList, new EventArgs());
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            MainWindow.DataGridViewProperties.HideInfoColumns(dataGridView);
        }

        private float calculateSum(String name)
        {
            return calculateSum(dataGridView, name);
        }

        private float calculateSum(DataGridView dataGridView, String name)
        {
            float sum = 0F;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                float number = 0;
                float.TryParse(row.Cells[findColumnIndex(name)].Value.ToString(), out number);
                sum += number;
            }
            return sum;
        }

        private int findColumnIndex(String name)
        {
            DataTable dataTable = ((DataTable)dataGridView.DataSource);
            if (dataTable == null)
            {
                return dataSet.Tables[dataGridView.Tag.ToString()].Columns.IndexOf(name);
            }
            else
            {
                return dataTable.Columns.IndexOf(name);
            }
        }

        private void truckTb_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand updateCommand = new OleDbCommand("update LoadingList set truck = @truck where id = @id", conn);
            updateCommand.Parameters.Add("@truck", OleDbType.VarWChar).Value = ((TextBox)sender).Text;
            updateCommand.Parameters.Add("@id", OleDbType.VarWChar).Value = listId;
            updateCommand.ExecuteNonQuery();
            conn.Close();
        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (adapter.UpdateCommand != null)
            {
                adapter.Update((DataTable)dataGridView.DataSource);
            }
        }

        private void tsmiPdf_Click(object sender, EventArgs e)
        {
            foreach (String printerName in PrinterSettings.InstalledPrinters)
            {
                if (printerName.ToLower().StartsWith("cutepdf"))
                {
                    PrintDialog dialog = new PrintDialog();
                    SetupDataGrid();
                    setupDefaultPrinting(dialog);
                    setupDocument(dialog);
                    printDocument.PrinterSettings.PrinterName = printerName;
                    printDocument.Print();
                    break;
                }
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //
        // Printing
        //

        private void tsmiPrintPreview_Click(object sender, EventArgs e)
        {
            if (SetupPrinting())
            {
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = printDocument;
                dialog.ShowDialog();
                restoreGridAfterPrinting();
            }
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            if (SetupPrinting())
            {
                printDocument.Print();
                restoreGridAfterPrinting();
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void setupDocument(PrintDialog dialog)
        {
            //printDocument.DocumentName = "Customers Report";
            printDocument.DocumentName = Text;
            printDocument.PrinterSettings = dialog.PrinterSettings;
            printDocument.DefaultPageSettings = dialog.PrinterSettings.DefaultPageSettings;
            printDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
        }

        private PrintDialog ShowPrintDialog()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.AllowCurrentPage = false;
            dialog.AllowPrintToFile = false;
            dialog.AllowSelection = false;
            dialog.AllowSomePages = false;
            dialog.PrintToFile = false;
            dialog.ShowHelp = false;
            dialog.ShowNetwork = false;

            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            setupDocument(dialog);

            return dialog;
        }

        private void SetupDataGrid()
        {
            printDataGridView = new DataGridView();
            if ((printDataGridView.DataSource = dataGridView.DataSource) == null)
            {
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    printDataGridView.Columns.Add(column.Name, column.Name);
                }
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    object[] itemArray = new object[row.Cells.Count];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        itemArray[cell.ColumnIndex] = cell.Value;
                    }
                    printDataGridView.Rows.Add(itemArray);
                }
            }
            printDataGridView.Tag = dataGridView.Tag;
            printDataGridView.AllowUserToAddRows = false;
            printDataGridView.Location = new Point(-1000, 0);
            //printDataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            printDataGridView.DataError += dataGridView_DataError;
            //printDataGridView.Font = printDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            panel.Controls.Add(printDataGridView);

            printDataGridView.Font = printDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 13);

            if (!tsmiGoodsList.Font.Bold && !tsmiT1.Font.Bold && !tsmiCustoms.Font.Bold)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from LoadingPlan_View", conn);
                adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar).Value = listId;
                adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = stockId;
                DataTable dataTable = dataSet.Tables["LoadingPlan_View"];
                if (dataTable != null)
                {
                    dataTable.Clear();
                }
                printDataGridView.DataSource = null;
                adapter.Fill(dataSet, "LoadingPlan_View");
                printDataGridView.DataSource = dataSet.Tables["LoadingPlan_View"];
                conn.Close();
            }

            MainWindow.DataGridViewProperties.HideInfoColumns(printDataGridView);
        }

        private void setupDefaultPrinting(PrintDialog dialog)
        {
            dialog.PrinterSettings.DefaultPageSettings.Landscape = true;
            dataGridViewPrinter = new DataGridViewPrinter(printDataGridView, printDocument, false, true, Text, new Font("Segoe UI", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            dataGridViewPrinter.TruckText = dataGridView.Rows[0].Cells[findColumnIndex("truck")].Value.ToString();

            if (!tsmiT1.Font.Bold && !tsmiGoodsList.Font.Bold && !tsmiCustoms.Font.Bold)
            {
                dataGridViewPrinter.TotalCll = (int)calculateSum("cll_rcvd");
                dataGridViewPrinter.TotalKg = calculateSum("kg_rcvd");
                dataGridViewPrinter.TotalM3 = calculateSum("m3");
            }

            if (tsmiGoodsList.Font.Bold)
            {
                dataGridViewPrinter.TotalCll = (int)calculateSum("PKGS");
                dataGridViewPrinter.TotalKg = calculateSum("Paino");
            }
        }

        private bool SetupPrinting()
        {
            SetupDataGrid();

            PrintDialog dialog;
            if ((dialog = ShowPrintDialog()) == null)
            {
                return false;
            }

            setupDefaultPrinting(dialog);
            return true;
        }

        private void restoreGridAfterPrinting()
        {
            if (dataGridView != printDataGridView)
            {
                panel.Controls.Remove(printDataGridView);
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // do nothing
            Console.Write(e.Exception.StackTrace);
        }

        private void tsmiLoadingList_Click(object sender, EventArgs e)
        {
            clearDataSource();
            CheckedMenuItem = (ToolStripMenuItem)sender;
            adapter = new OleDbDataAdapter("Select * from LoadingListParameter_View", conn);
            adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar).Value = listId;
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = stockId;
            
            adapter.UpdateCommand = new OleDbCommand("Update LoadingList_Query set [+]=@important, truck=@truck, " + updateString, conn);
            adapter.UpdateCommand.Parameters.Add("@important", OleDbType.Boolean, 2, "+");
            adapter.UpdateCommand.Parameters.Add("@truck", OleDbType.VarWChar, 50, "truck");
            MainWindow.Entry_AddParameters(adapter.UpdateCommand.Parameters);
            
            adapter.Fill(dataSet, "LoadingListParameter_View");
            dataGridView.DataSource = dataSet.Tables["LoadingListParameter_View"];
            
            SetTruckNumber(truckTb, listId, dataSet);
            conn.Close();
        }

        private void tsmiGoodsList_Click(object sender, EventArgs e)
        {
            dataGridView.ContextMenuStrip = null;
            CheckedMenuItem = (ToolStripMenuItem)sender;
            adapter = new OleDbDataAdapter("Select * from LoadingListGoods_View", conn);
            adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar).Value = listId;
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = stockId;
            populateDataGridView("LoadingListGoods_View");
            
            conn.Close();
        }

        public void tsmiCustoms_Click(object sender, EventArgs e)
        {
            dataGridView.ContextMenuStrip = null;
            CheckedMenuItem = (ToolStripMenuItem)sender;
            adapter = new OleDbDataAdapter("Select * from LoadingListCustoms_View", conn);
            adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar).Value = listId;
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = stockId;
            
            populateDataGridView("LoadingListCustoms_View");
            conn.Close();
        }

        private void tsmiT1_Click(object sender, EventArgs e)
        {
            dataGridView.ContextMenuStrip = null;
            CheckedMenuItem = (ToolStripMenuItem)sender;
            adapter = new OleDbDataAdapter("Select * from LoadingListT1_View", conn);
            adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar).Value = listId;
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = stockId;
            
            populateDataGridView("LoadingListT1_View");
            conn.Close();
        }

        private void populateDataGridView(String tableName)
        {
            clearDataSource();
            dataGridView.Tag = tableName;
            adapter.Fill(dataSet, tableName);
            DataTable tbl = dataSet.Tables[tableName];
            int index = tbl.Columns.IndexOf("Pos");
            foreach (DataColumn column in tbl.Columns)
            {
                dataGridView.Columns.Add(column.ColumnName, column.ColumnName);
            }
            for (var i = 0; i < tbl.Rows.Count; i++)
            {
                object[] list = tbl.Rows[i].ItemArray;
                list[index] = (i + 1) + "";
                dataGridView.Rows.Add(list);
            }
            MainWindow.DataGridViewProperties.HideInfoColumns(dataGridView);
        }

        private void clearDataSource()
        {
            dataGridView.Tag = null;
            dataGridView.Columns.Clear();
            dataSet = new DataSet();
            dataGridView.DataSource = null;
        }

        private void tsmiSaveExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = Text;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog.FileName.Length > 0)
            {
                SetupDataGrid();
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlApp = new Excel.ApplicationClass();
                xlApp.DisplayAlerts = false;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkBook.CheckCompatibility = false;
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                int rowIndex = 4;
                if (truckTb.Visible)
                {
                    xlWorkSheet.Cells[1, 1] = Text;
                    xlWorkSheet.Cells[1, 3] = "Truck:";
                    xlWorkSheet.Cells[1, 4] = truckTb.Text;
                }
                xlWorkSheet.Cells[1, 7] = "Date:";
                xlWorkSheet.Cells[1, 8] = DateTime.Now.ToString("dd.MM.yyyy hh:mm");

                xlWorkSheet.Cells[2, 1] = "Total:";
                xlWorkSheet.Cells[2, 2] = calculateSum("cll_doc") + " Pkgs";
                xlWorkSheet.Cells[2, 3] = calculateSum("kg_doc") + " Kgs";

                xlWorkSheet.Cells[2, 9] = calculateSum("m3") + " M3";

                int columnIndex = 0;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    columnIndex = 0;
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        DataGridViewCell cell = dataGridView[column.Index, row.Index];
                        if (dataGridView.Columns[cell.ColumnIndex].Visible == true)
                        {
                            xlWorkSheet.Cells[4, columnIndex + 1] = dataGridView.Columns[cell.ColumnIndex].Name;
                            xlWorkSheet.Cells[rowIndex + 1, columnIndex + 1] = cell.Value;
                            columnIndex++;
                        }
                    }
                    rowIndex++;
                }

                Excel.Range workSheet_range = xlWorkSheet.get_Range(xlWorkSheet.Cells[4, 1], xlWorkSheet.Cells[4, columnIndex]);
                workSheet_range.Interior.Color = System.Drawing.Color.LightGray.ToArgb();
                workSheet_range.Font.Bold = true;
                workSheet_range = xlWorkSheet.get_Range(xlWorkSheet.Cells[4, 1], xlWorkSheet.Cells[rowIndex, columnIndex]);
                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                workSheet_range.Font.Size = 16;
                xlWorkSheet.Columns.AutoFit();

                string tmpName = System.IO.Path.GetTempFileName();
                System.IO.File.Delete(tmpName);
                xlWorkBook.SaveAs(tmpName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                try
                {
                    System.IO.File.Delete(saveFileDialog.FileName);
                    System.IO.File.Move(tmpName, saveFileDialog.FileName);
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.ToString());
                }

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                restoreGridAfterPrinting();
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Validate();
        }
    }
}
