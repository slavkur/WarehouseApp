using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
//using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;

namespace WarehouseApp
{
    public partial class MainWindow : KryptonForm
    {
        private OleDbConnection conn;

        private DataGridViewPrinter dataGridViewPrinter;
        private DataGridView printDataGridView;

        private readonly String NumberUpdateLine = "kg_doc=@kg_doc, kg_rcvd=@kg_rcvd, m3=@m3, cll_doc=@cll_doc, cll_rcvd=@cll_rcvd, ";
        private readonly String CommonUpdateString = "booking_number=@booking_number, arrival=@arrival, status=@status, consignor=@consignor, consignee=@consignee, description=@description, ccs_number=@ccs_number, damage=@damage, wh_number=@wh_number, wh_pl=@wh_pl, manager=@manager, documents=@documents, situation=@situation, codes=@codes, comments=@comments, [container]=@container, attached=@attached where id Like @id";

        // ???
        private int flowLayoutPanelHeight;
        private int dataGridViewHeight;

        public DataGridViewProperties dgvp;
        public readonly OleDbDataAdapter adapter;

        public class DataGridViewProperties
        {
            public delegate String DeleteMessage();
            private ContextMenuStrip[] cmsTargets;
            private CancelEventHandler[] eventsOpening;
            public DataGridView dataGridView;
            public DataSet dataSet = new DataSet();
            public System.Collections.Hashtable searchHash = new System.Collections.Hashtable();
            public DataGridViewCell selectedCell;

            // ???
            public String enteredCellName;
            public String changedCellName;

            public int enteredRowIndex = -1;
            public int enteredColumnIndex = -1;
            public int changedRowIndex = -1;
            //public int changedColumnIndex = -1;

            public string CurrentCellName
            {
                get
                {
                    return dataGridView.Columns[enteredColumnIndex].Name;
                }
            }

            public DataGridViewProperties(DataGridView dataGridView)
            {
                this.dataGridView = dataGridView;
            }

            public void bindEvents()
            {
                this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
                this.dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
                this.dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
                this.dataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
            }

            private void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
            {
                int hiddenAmount = 0;
                if (int.TryParse(dataGridView.Columns[0].Name, out hiddenAmount) && e.Column.Index < hiddenAmount)
                {
                    e.Column.Visible = false;
                }
                else if (DataTable != null && searchHash.ContainsKey(e.Column.Name + "-" + DataTable.TableName))
                {
                    e.Column.HeaderCell.Style.BackColor = Color.Pink;
                    e.Column.HeaderCell.Style.Font = new Font(e.Column.InheritedStyle.Font, FontStyle.Italic);
                    e.Column.HeaderCell.Value = e.Column.Name + "=" + searchHash[e.Column.Name + "-" + DataTable.TableName];
                }

                // short long fields
                if (e.Column.Name.Equals("receiver") ||
                    e.Column.Name.Equals("summary") ||
                    e.Column.Name.Equals("bank_details") ||
                    e.Column.Name.Equals("address"))
                {
                    e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    e.Column.Width = 150;
                }
            }

            public static int HideInfoColumns(DataGridView dataGridView)
            {
                int hiddenAmount = 0;
                if (int.TryParse(dataGridView.Columns[0].Name, out hiddenAmount))
                {
                    int index = 0;
                    while (index < hiddenAmount)
                    {
                        dataGridView.Columns[index].Visible = false;
                        index++;
                    }
                }
                //DataGridViewColumn visibleColumn = dataGridView.Columns[0];
                /*foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (int.TryParse(dataGridView.Columns[0].Name, out hiddenAmount) && column.Index < hiddenAmount)
                    {
                        column.Visible = false;
                        //visibleColumn = dataGridView.Columns[column.Index + 1];
                    }
                }*/
                return hiddenAmount;
            }

            public DataTable DataTable
            {
                get
                {
                    return (DataTable)dataGridView.DataSource;
                }
            }

            public void LoadTable(OleDbDataAdapter adapter, String name)
            {
                Clear();
                sourcePopulate(adapter, name);
            }

            private void dataGridView_CurrentCellChanged(object sender, EventArgs args)
            {
                changedCellName = enteredCellName;
                changedRowIndex = enteredRowIndex;
            }

            /*
            public object cell(String name)
            {
                return SelectedDataRow[IndexOf(name)];
            }*/

            public object item(String name)
            {
                return SelectedDataRow[IndexOf(name)];
            }

            private void sourcePopulate(OleDbDataAdapter adapter, String name)
            {
                adapter.Fill(dataSet, name);
                dataGridView.Tag = name;
                dataGridView.DataSource = dataSet.Tables[name];
                dataGridView.ContextMenuStrip = CombineItems_ContextMenu();
            }

            private void Clear()
            {
                dataGridView.Tag = null;
                dataGridView.Columns.Clear();
                dataSet = new DataSet();
                dataGridView.DataSource = null;
            }

            public void Reset(OleDbDataAdapter adapter)
            {
                Console.WriteLine(dataGridView.Tag.ToString());
                Console.WriteLine(adapter.SelectCommand.CommandText);

                LoadTable(adapter, dataGridView.Tag.ToString());
            }

            public void Populate(OleDbDataAdapter adapter, String tableName)
            {
                Clear();
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
                //HideInfoColumns();
            }

            public int IndexOf(String name)
            {
                if (DataTable == null)
                {
                    return dataSet.Tables[dataGridView.Tag.ToString()].Columns.IndexOf(name);
                }
                else
                {
                    return DataTable.Columns.IndexOf(name);
                }
            }

            public void ContextMenuStrip(ContextMenuStrip[] cmsTargets, CancelEventHandler[] eventsOpening)
            {
                this.cmsTargets = cmsTargets;
                this.eventsOpening = eventsOpening;
            }

            /*EVENT*/
            private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                enteredCellName = dataGridView.Columns[e.ColumnIndex].Name;
                enteredRowIndex = e.RowIndex;
                enteredColumnIndex = e.ColumnIndex;
            }

            /*EVENT*/
            private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                try
                {
                    int changedColumnIndex;
                    Console.WriteLine(changedCellName);
                    if (dataGridView.Rows.Count > 0 &&
                        (changedColumnIndex = IndexOf(changedCellName)) > -1)
                    {
                        changedColumnIndex = (changedColumnIndex < dataGridView.Columns.Count) ? changedColumnIndex : 0;
                        int rowIndex = (changedRowIndex > 0 && changedRowIndex < dataGridView.Rows.Count) ? changedRowIndex : 0;
                        DataGridViewCell cell = dataGridView[changedColumnIndex, rowIndex];
                        if (cell.Visible && MainWindow.editForm == null)
                        {
                            dataGridView.ClearSelection();
                            (selectedCell = cell).Selected = true;
                            dataGridView.CurrentCell = selectedCell;
                            //dataGridView.Rows[selectedCell.RowIndex].Selected = true;
                        }
                    }
                }
                catch (InvalidOperationException e2)
                {
                    Console.WriteLine(e2.StackTrace);
                }
                // enable if needed
                //dataGridView_headerAddTotal("cll_doc");
                //dataGridView_headerAddTotal("kg_doc");
                //dataGridView_headerAddTotal("cll_rcvd");
                //dataGridView_headerAddTotal("kg_rcvd");
                //dataGridView_headerAddTotal("m3");
            }

            public ContextMenuStrip CombineItems_ContextMenu()
            {
                return CombineItems_ContextMenu(cmsTargets, eventsOpening);
            }

            public static ContextMenuStrip CombineItems_ContextMenu(ContextMenuStrip[] cmsTargets, CancelEventHandler[] eventsOpening)
            {
                ContextMenuStrip cmsBlank = new ContextMenuStrip();//components
                cmsBlank.Font = new System.Drawing.Font("Segoe UI", 8.25F);
                cmsBlank.Name = "cmsBlank";
                cmsBlank.Size = new System.Drawing.Size(153, 26);
                if (eventsOpening != null)
                {

                    cmsBlank.Opening += delegate(object sender, CancelEventArgs e)
                    {
                        foreach (CancelEventHandler eventOpening in eventsOpening)
                        {
                            if (!e.Cancel)
                            {
                                eventOpening(sender, e);
                            }
                            else
                            {
                                break;
                            }
                        }
                    };

                }

                foreach (ContextMenuStrip strip in cmsTargets)
                {
                    if (strip.Tag == null)
                    {
                        strip.Tag = new ToolStripItem[strip.Items.Count];
                        strip.Items.CopyTo((ToolStripItem[])strip.Tag, 0);
                    }
                    ToolStripItemCollection stripItems = new ToolStripItemCollection(strip, ((ToolStripItem[])strip.Tag));
                    ToolStripItem[] items = new ToolStripItem[stripItems.Count];
                    if (items.Length == 0 && strip.Tag != null)
                    {
                        items = (ToolStripItem[])strip.Tag;
                    }

                    stripItems.CopyTo(items, 0);
                    strip.Tag = items;
                    cmsBlank.Items.AddRange(items);
                    cmsBlank.Tag = items;
                }
                return cmsBlank;
            }

            public DataRow SelectedDataRow
            {
                get
                {
                    return (SelectedRow != null) ? ((DataRowView)SelectedRow.DataBoundItem).Row : null;
                }
            }

            public DataGridViewRow SelectedRow
            {
                get
                {
                    if (dataGridView.SelectedCells.Count > 0)
                    {
                        return dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex];
                    }
                    else
                    {
                        return null;
                    }
                }
            }


        }

        private ToolStripMenuItem checkedMenuItem;
        public ToolStripMenuItem CheckedMenuItem
        {
            get
            {
                return checkedMenuItem;
            }

            set
            {
                if (checkedMenuItem != null)
                    MainWindow.tsmi_ToggleFont(false, checkedMenuItem);
                checkedMenuItem = value;
                Text = ((ToolStripDropDownMenu)CheckedMenuItem.Owner).OwnerItem.Text + " (" + CheckedMenuItem.Text + ")";// (!CheckedMenuItem.Name.StartsWith("tsmiStock")) ? tsmiStock.Text + " > " + CheckedMenuItem.Text : CheckedMenuItem.Text;
                MainWindow.tsmi_ToggleFont(true, checkedMenuItem);

                //dataGridView.CurrentCell = null;
                //changedCellName = null;
                //enteredCellName = null;
                dgvp.changedCellName = dgvp.enteredCellName = null;

                //improve to keep the history
                dgvp.searchHash.Clear();
            }
        }

        public static void tsmi_ToggleFont(Boolean condition, ToolStripMenuItem item)
        {
            item.Font = (condition) ? new Font(item.Font, FontStyle.Bold) : new Font(item.Font, FontStyle.Regular);
        }

        /*EVENT*/
        private void dataGridView_CurrentCellChanged(object sender, EventArgs args)
        {

        }

        /*Debugging method*/
        /*EVENT*/
        private void __btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells[5].Value = row.Cells[5].Value.ToString();
                adapter.Update((DataTable)row.DataGridView.DataSource);
            }
        }

        /*EVENT*/
        public Boolean dataGridView_ChangeRowColor(DataGridViewRow row)
        {
            bool status = false;
            int situationIndex = dgvp.IndexOf("situation");
            int bookingIndex = dgvp.IndexOf("booking_number");
            int documentsIndex = dgvp.IndexOf("documents");

            if (documentsIndex > -1 && documentsIndex < row.Cells.Count && row.Cells[documentsIndex].Value != null)
            {
                status = row.Cells[documentsIndex].Value.ToString().ToLower().IndexOf("no") > -1;
                if (status)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
            }

            if (situationIndex > -1 && situationIndex < row.Cells.Count && row.Cells[situationIndex].Value != null)
            {
                status = !row.Cells[situationIndex].Value.ToString().ToLower().Equals("ok");
                if (status)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
                else if (row.DefaultCellStyle.BackColor.Equals(Color.LightPink))
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
            }

            if (bookingIndex > -1 && bookingIndex < row.Cells.Count && (row.Cells[bookingIndex].Value == null || row.Cells[bookingIndex].Value.ToString().Length == 0))
            {
                row.Cells[bookingIndex].Style.BackColor = Color.LightSalmon;
            }
            else if (bookingIndex > -1 && bookingIndex < row.Cells.Count && !row.DefaultCellStyle.BackColor.Equals(Color.LightSkyBlue))
            {
                row.Cells[bookingIndex].Style.BackColor = Color.Empty;
            }

            return status;
        }


        private void dataGridView_headerAddTotal(String columnName)
        {
            int index;
            if ((index = dgvp.IndexOf(columnName)) > -1)
            {
                dataGridView.Columns[index].HeaderCell.Value = columnName + "=" + dataGridView_ColumnSum(columnName);
            }
        }

        public static void DataGridView_LockColumn(DataGridViewProperties dataGridViewProperties, String name)
        {
            int index = dataGridViewProperties.IndexOf(name);
            if (index > -1 && index < dataGridViewProperties.dataGridView.Columns.Count)
            {
                DataGridViewColumn readOnlyColumn = dataGridViewProperties.dataGridView.Columns[index];
                readOnlyColumn.ReadOnly = true;
                readOnlyColumn.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
        }

        public static void DataGridView_LockColumn(DataGridView dataGridView, String name)
        {
            DataGridView_LockColumn(new DataGridViewProperties(dataGridView), name);
        }

        public void DataGridView_LockColumn(String name)
        {
            DataGridView_LockColumn(dgvp, name);
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



        //
        // Printing
        //

        /*EVENT*/
        private void tsmiPrintPreviewTable_Click(object sender, EventArgs e)
        {
            if (SetupPrinting())
            {
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = printTableDocument;
                dialog.ShowDialog();
                restoreGridAfterPrinting();
            }
        }

        /*EVENT*/
        private void tsmiPrintTable_Click(object sender, EventArgs e)
        {
            if (SetupPrinting())
            {
                printTableDocument.Print();
                restoreGridAfterPrinting();
            }
        }

        /*EVENT*/
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private PrintDialog SetupDialog()
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

            //printDocument.DocumentName = "Customers Report";
            printTableDocument.PrinterSettings = dialog.PrinterSettings;
            printTableDocument.DefaultPageSettings = dialog.PrinterSettings.DefaultPageSettings;
            printTableDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

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
            printDataGridView.DataError += dataGridView_DataError;
            kryptonPanel.Controls.Add(printDataGridView);

            if (csLoadingList.CheckedButton != null)
            {
                printDataGridView.Font = printDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 13);

                if (!tsmiGoodsList.Font.Bold && !tsmiT1.Font.Bold && !tsmiCustoms.Font.Bold)
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from LoadingPlan_View", conn);
                    adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = (long)csLoadingList.CheckedButton.Tag;
                    adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
                    DataTable dataTable = dgvp.dataSet.Tables["LoadingPlan_View"];
                    if (dataTable != null)
                    {
                        dataTable.Clear();
                    }
                    printDataGridView.DataSource = null;
                    adapter.Fill(dgvp.dataSet, "LoadingPlan_View");
                    printDataGridView.DataSource = dgvp.dataSet.Tables["LoadingPlan_View"];
                    conn.Close();
                }
            }

            DataGridViewProperties.HideInfoColumns(printDataGridView);
        }

        private bool SetupPrinting()
        {
            SetupDataGrid();

            PrintDialog dialog;
            if ((dialog = SetupDialog()) == null)
            {
                return false;
            }
            dialog.PrinterSettings.DefaultPageSettings.Landscape = true;

            //if (MessageBox.Show("Do you want the report to be centered on the page", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //   MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView, MyPrintDocument, true, true, "Customers", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            //else

            dataGridViewPrinter = new DataGridViewPrinter(printDataGridView, printTableDocument, false, true, Text, new Font("Segoe UI", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            if (csLoadingList.CheckedButton != null)
            {
                dataGridViewPrinter.TruckText = dataGridView.Rows[0].Cells[dgvp.IndexOf("truck")].Value.ToString();

                if (!tsmiT1.Font.Bold && !tsmiGoodsList.Font.Bold && !tsmiCustoms.Font.Bold)
                {
                    dataGridViewPrinter.TotalCll = (int)dataGridView_ColumnSum("cll_rcvd");
                    dataGridViewPrinter.TotalKg = dataGridView_ColumnSum("kg_rcvd");
                    dataGridViewPrinter.TotalM3 = dataGridView_ColumnSum("m3");
                }

                if (tsmiGoodsList.Font.Bold)
                {
                    dataGridViewPrinter.TotalCll = (int)dataGridView_ColumnSum("Pkgs");
                    dataGridViewPrinter.TotalKg = dataGridView_ColumnSum("Paino");
                }
            }
            return true;
        }

        private void restoreGridAfterPrinting()
        {
            if (dataGridView != printDataGridView)
            {
                kryptonPanel.Controls.Remove(printDataGridView);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            conn = new OleDbConnection(Program.connectionString);
            adapter = new OleDbDataAdapter("", conn);
            runTableUpdates();
        }

        private float dataGridView_ColumnSum(String name)
        {
            return dataGridView_ColumnSum(dgvp, name);
        }

        public static float dataGridView_ColumnSum(DataGridViewProperties properties, String name)
        {
            float sum = 0F;
            foreach (DataGridViewRow row in properties.dataGridView.Rows)
            {
                float number = 0;
                float.TryParse(row.Cells[properties.IndexOf(name)].Value.ToString(), out number);
                sum += number;
            }
            return sum;
        }

        public static void Entry_AddParameters(OleDbParameterCollection parameters)
        {
            parameters.Add("@kg_doc", OleDbType.Double, 8, "kg_doc");
            parameters.Add("@kg_rcvd", OleDbType.Double, 8, "kg_rcvd");
            parameters.Add("@m3", OleDbType.Double, 8, "m3");
            parameters.Add("@cll_doc", OleDbType.Integer, 4, "cll_doc");
            parameters.Add("@cll_rcvd", OleDbType.Integer, 4, "cll_rcvd");
            addCommonParameters(parameters);
        }

        private static void addCommonParameters(OleDbParameterCollection parameters)
        {
            parameters.Add("@booking_number", OleDbType.Integer, 4, "booking_number");
            parameters.Add("@arrival", OleDbType.DBTimeStamp, 4, "arrival");
            parameters.Add("@status", OleDbType.VarWChar, 2, "status");
            parameters.Add("@consignor", OleDbType.VarWChar, 50, "consignor");
            parameters.Add("@consignee", OleDbType.VarWChar, 50, "consignee");
            parameters.Add("@description", OleDbType.VarWChar, 500, "description");
            parameters.Add("@ccs_number", OleDbType.VarWChar, 11, "ccs_number");
            parameters.Add("@damage", OleDbType.VarWChar, 50, "damage");
            parameters.Add("@wh_number", OleDbType.VarWChar, 50, "wh_number");
            parameters.Add("@wh_pl", OleDbType.VarWChar, 50, "wh_pl");
            parameters.Add("@manager", OleDbType.VarWChar, 50, "manager");
            parameters.Add("@documents", OleDbType.VarWChar, 100, "documents");
            parameters.Add("@situation", OleDbType.VarWChar, 100, "situation");
            parameters.Add("@codes", OleDbType.VarWChar, 500, "codes");
            parameters.Add("@comments", OleDbType.VarWChar, 500, "comments");
            parameters.Add("@container", OleDbType.VarWChar, 255, "container");
            parameters.Add("@attached", OleDbType.VarWChar, 255, "attached");

            parameters.Add("@id", OleDbType.Integer, 4, "id");
        }

        private int DBSelect_LoadingLists_Reset()
        {
            DataTable openedLists = new DataTable();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from LoadingListOpened_View", conn))
            {
                adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
                adapter.Fill(openedLists);
            }
            openedLists.PrimaryKey = new DataColumn[] { openedLists.Columns[openedLists.Columns.IndexOf("id")] };

            //checking for contained buttons, remove not existing in db
            KryptonCheckButton[] buttons = new KryptonCheckButton[openedLists.Rows.Count];
            ToolStripMenuItem[] items = new ToolStripMenuItem[openedLists.Rows.Count];
            foreach (DataRow row in openedLists.Rows)
            {
                long listId = long.Parse(row.ItemArray[openedLists.Columns.IndexOf("id")].ToString());
                string index = (string)row.ItemArray[openedLists.Columns.IndexOf("index")];
                KryptonCheckButton button = CreateLoadingListButton(listId, index);

                if (!flpControls.Controls.ContainsKey(button.Name))
                {
                    //buttons[openedLists.Rows.IndexOf(row)] = button;
                    flpControls.Controls.Add(button);
                    tsmiLL.DropDownItems.Insert(tsmiLL.DropDownItems.IndexOf(tsmiHistorySeparator), newLoadingListMenuItem(listId, index));
                    newLoadingListToolStripItem(listId, index);
                }
            }

            ToolStripItemCollection col2 = new ToolStripItemCollection(cmsLoadingLists, ((ToolStripItem[])cmsLoadingLists.Tag));
            foreach (Control control in flpControls.Controls)
            {
                if (!openedLists.Rows.Contains(control.Tag))
                {
                    flpControls.Controls.RemoveAt(flpControls.Controls.IndexOfKey(control.Name));

                    col2.RemoveAt(col2.IndexOfKey(csLoadingList.CheckedButton.Name));
                    col2.CopyTo((ToolStripItem[])cmsLoadingLists.Tag, 0);

                    tsmiLL.DropDownItems.RemoveAt(tsmiLL.DropDownItems.IndexOfKey(control.Name));
                }
            }

            //flpControls.Controls.AddRange(buttons);
            return openedLists.Rows.Count;
        }

        private void tb_setTruckNumber(Control truckTb, String listId, DataSet dataSet)
        {
            OleDbDataAdapter extraAdapter = new OleDbDataAdapter("Select truck from LoadingList where id = @id", conn);
            extraAdapter.SelectCommand.Parameters.Add("@id", OleDbType.VarWChar).Value = listId;
            extraAdapter.Fill(dataSet, "LoadingList");
            DataTable table = dataSet.Tables["LoadingList"];
            DataColumnCollection columns = table.Columns;
            Object[] items = table.Rows[0].ItemArray;
            truckTb.Text = items[columns.IndexOf("truck")].ToString();
        }

        // found 3 places
        private String DBSelect_LoadingListIndex()
        {
            OleDbCommand command = new OleDbCommand("Select amount from LoadingListToday_View", conn);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            int newIndex = 1;
            if (reader.HasRows)
                newIndex += reader.GetInt32(0);

            return DateTime.Now.ToString("ddMM-" + ((newIndex.ToString().Length == 1) ? "0" : "") + newIndex);
        }

        // found 2 places
        private void Events_LoadingListButton(ToolStripMenuItem item)
        {
            item.MouseEnter += new EventHandler(item_MouseEnter);
            item.MouseLeave += new EventHandler(item_MouseLeave);
        }

        // found 7 places
        private String LL_DeserializeName(String index)
        {
            return "LL " + index;
        }

        // found 3 places
        private KryptonCheckButton CreateLoadingListButton(long listId, String index)
        {
            KryptonCheckButton button = new KryptonCheckButton();
            //button.ContextMenuStrip = cmsLoadingListBtn;
            button.Tag = listId;
            button.Name = "l" + listId;
            button.Text = LL_DeserializeName(index);

            button.CheckedChanged += new System.EventHandler(LoadingListItem_CheckedChanged);
            csLoadingList.CheckButtons.Add(button);

            return button;
        }

        private ToolStripItem newLoadingListToolStripItem(long listId, String index)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(LL_DeserializeName(index), WarehouseApp.Properties.Resources.table, null, "l" + listId);
            item.Tag = listId;
            item.Click += new System.EventHandler(LoadingList_MoveToSelected_Click);
            Events_LoadingListButton(item);

            if (cmsLoadingLists.Tag != null)
            {
                ToolStripItemCollection col2 = new ToolStripItemCollection(cmsLoadingLists, ((ToolStripItem[])cmsLoadingLists.Tag));
                if (col2.IndexOfKey(item.Name) == -1)
                {
                    col2.Insert(col2.IndexOf(tsmiNewLL), item);
                    cmsLoadingLists.Tag = new ToolStripItem[col2.Count];
                    col2.CopyTo((ToolStripItem[])cmsLoadingLists.Tag, 0);
                }
            }

            return item;
        }

        private ToolStripMenuItem newLoadingListMenuItem(long listId, String index)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(LL_DeserializeName(index), WarehouseApp.Properties.Resources.table, null, "l" + listId);
            item.Tag = listId;
            item.Click += new System.EventHandler(LLControl_Open_Click);

            Events_LoadingListButton(item);

            return item;
        }

        // found 2 places
        private long DBInsert_LoadingList()
        {
            String index = DBSelect_LoadingListIndex();
            long listId = Math.Abs(DateTime.Now.ToBinary());

            using (OleDbCommand cmd = new OleDbCommand("Insert into LoadingList ([id], [index], stock_id) values(@list_id, @index, @stock_id)", conn))
            {
                cmd.Parameters.Add("@list_id", OleDbType.VarWChar).Value = listId;
                cmd.Parameters.Add("@index", OleDbType.VarWChar).Value = index;
                cmd.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
                cmd.ExecuteNonQuery();
            }

            return listId;
        }

        private void DBInsert_LoadingListEntries(long listId)
        {
            // delete existing loading list if entries were moved from it
            if (csLoadingList.CheckedButton != null)
            {
                using (OleDbCommand cmd = new OleDbCommand("Delete from LoadingEntry le where le.list_id = @list_id and le.id = @id;", conn))
                {
                    cmd.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = long.Parse(dgvp.item("list_id").ToString());
                    cmd.Parameters.Add("@id", OleDbType.Integer).Value = dgvp.item("id");
                    cmd.ExecuteNonQuery();
                }
            }

            // TODO: convert to multiple insert
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                Object entryId = dataRow.ItemArray[dgvp.IndexOf("entry_id")];
                using (OleDbCommand cmd = new OleDbCommand("Insert into LoadingListEntry_Query (list_id, entry_id, kg_doc, kg_rcvd, m3, cll_doc, cll_rcvd) values(@list_id, @entry_id, @kg_doc, @kg_rcvd, @m3, @cll_doc, @cll_rcvd)", conn))
                {
                    cmd.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = listId;
                    cmd.Parameters.Add("@entry_id", OleDbType.Integer).Value = entryId;
                    cmd.Parameters.Add("@kg_doc", OleDbType.Double).Value = dataRow.ItemArray[dgvp.IndexOf("kg_doc")];
                    cmd.Parameters.Add("@kg_rcvd", OleDbType.Double).Value = dataRow.ItemArray[dgvp.IndexOf("kg_rcvd")];
                    cmd.Parameters.Add("@m3", OleDbType.Double).Value = dataRow.ItemArray[dgvp.IndexOf("m3")];
                    cmd.Parameters.Add("@cll_doc", OleDbType.Integer).Value = dataRow.ItemArray[dgvp.IndexOf("cll_doc")];
                    cmd.Parameters.Add("@cll_rcvd", OleDbType.Integer).Value = dataRow.ItemArray[dgvp.IndexOf("cll_rcvd")];
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Download_Progress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DBCacheStock()
        {
            OleDbCommand command;
            using (DataTable t = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, "StockCache", "TABLE" }))
            {
                if (t.Rows.Count > 0)
                {
                    command = new OleDbCommand("DROP table StockCache", conn);
                    command.ExecuteNonQuery();
                }
                command = new OleDbCommand("SELECT Stock_View.* INTO StockCache FROM Stock_View", conn);
                command.ExecuteNonQuery();
            }
        }

        private void runTableUpdates()
        {
            OleDbCommand command;

            //todo delete in next verison
            conn.ConnectionString = conn.ConnectionString.Replace(".mdb", "_be.mdb");
            conn.Open();
            using (DataTable t = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, "InvoiceDetails", "tax" }))
            {
                if (t.Rows.Count == 0)
                {
                    command = new OleDbCommand("Alter table InvoiceDetails add column tax decimal(4,2)", conn);
                    command.ExecuteNonQuery();
                    command = new OleDbCommand("Update InvoiceDetails set tax = 24", conn);
                    command.ExecuteNonQuery();
                }
                //command = new OleDbCommand("Alter table LoadingEntry alter column invoices varchar(255)", conn);
                //command.ExecuteNonQuery();
            }
            conn.Close();
            conn.ConnectionString = conn.ConnectionString.Replace("_be.mdb", ".mdb");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //new RemoteXMLReader();
            //Downloader.DownloadFile("http://www.rimtengg.com/coit2007/proceedings/pdfs/108.pdf", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Download_Progress);

            conn.Open();

            flowLayoutPanelHeight = flpControls.Height;
            dataGridViewHeight = dataGridView.Height;

            dgvp = new DataGridViewProperties(dataGridView);

            // refactor
            dgvp.bindEvents();
            dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);

            adapter.SelectCommand = new OleDbCommand("Select * from Stock", conn);
            adapter.Fill(dgvp.dataSet, "Stocks");


            conn.Close();

            DataColumnCollection columns = dgvp.dataSet.Tables["Stocks"].Columns;
            foreach (DataRow dataRow in dgvp.dataSet.Tables["Stocks"].Rows)
            {
                String text = dataRow.ItemArray[columns.IndexOf("text")].ToString();
                String name = text.Replace(" ", "");
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text, tsmiStock.Image, tsmiStock_Click, "tsmiStock" + name);
                tsmi.Tag = dataRow.ItemArray[columns.IndexOf("id")].ToString();

                ToolStripItem[] items = new ToolStripItem[tsmiStock.DropDownItems.Count];
                tsmiStock.DropDownItems.CopyTo(items, 0);
                foreach (ToolStripItem c in items)
                {
                    tsmi.DropDownItems.Add(c);
                }

                if (tsmiStock.Tag == null)
                {
                    setCurrentStock(tsmi);

                    conn.Open();
                    DBSelect_LoadingLists_Reset();
                    conn.Close();

                    tsmiStock_Click(tsmi, new EventArgs());
                }
                tsmiStock1.DropDownItems.Insert(tsmiStock1.DropDownItems.IndexOf(tsmiStock), tsmi);
            }

            /*
            CalendarCell datePicker = new CalendarCell();
            int index = dataSet.Tables["TestTable"].Columns.IndexOf("added_at");
            dataGridView.Columns[index].Visible = false;
            dataGridView.Columns.Insert(index, DataGridViewDat);
            dataGridView.Columns[index].DataPropertyName = "added_at";

            
            DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
            comboBox.HeaderText = "Type";
            comboBox.DropDownWidth = 90;
            comboBox.Width = 90;
            comboBox.MaxDropDownItems = 5;
            comboBox.Items.AddRange("77", "88", "99");
            int index = dataSet.Tables["TestTable"].Columns.IndexOf("wh_number");
            dataGridView.Columns[index].Visible = false;
            dataGridView.Columns.Insert(index, comboBox);
            dataGridView.Columns[index].DataPropertyName = "wh_number";
            */
        }

        private void LLControl_Open_Click(object sender, EventArgs e)
        {
            CheckedMenuItem = (ToolStripMenuItem)sender;
            KryptonCheckButton button = (KryptonCheckButton)flpControls.Controls.Find(CheckedMenuItem.Name, true)[0];
            if (button.Checked)
            {
                flpControls_CheckedChanged(csLoadingList, new EventArgs());
            }
            button.Checked = true;
        }

        /*EVENT*/
        private void LoadingList_MoveToSelected_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            conn.Open();
            DBInsert_LoadingListEntries((long)item.Tag);
            DBSelect_LoadingLists_Reset();
            conn.Close();

            dataGridView.CurrentRow.HeaderCell.Value = "LL";

            // in case it is LoadingList
            if (csLoadingList.CheckedButton != null)
            {
                dgvp.Reset(adapter);
            }
        }

        /*EVENT*/
        private void LoadingList_MoveToNew_Click(object sender, EventArgs e)
        {
            conn.Open();
            long listId = DBInsert_LoadingList();
            DBInsert_LoadingListEntries(listId);
            DBSelect_LoadingLists_Reset();
            conn.Close();

            dataGridView.CurrentRow.HeaderCell.Value = "LL";
            //dgvp.Reset(adapter);
        }

        private void item_MouseLeave(object sender, EventArgs e)
        {
            dataGridView.Focus();
        }

        private void item_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Control[] controls = flpControls.Controls.Find(item.Name, true);
            if (controls.Length == 1)
            {
                ((KryptonCheckButton)controls[0]).Focus();
            }
        }

        /*EVENT*/
        private void LoadingListItem_CheckedChanged(object sender, EventArgs args)
        {
            dgvp.ContextMenuStrip(new ContextMenuStrip[] { cmsSearch, cmsTitlePage, cmsEntry, cmsAttach, cmsLoadingLists }, new CancelEventHandler[] { selectRow_Opening, cmsTitlePage_Opening, cmsAttach_Opening, cmsLoadingLists_Opening });
            KryptonCheckButton button = ((KryptonCheckButton)sender);
            if (button != null)
            {
                ToolStripItem[] items = tsmiLL.DropDownItems.Find(button.Name, true);
                if (items.Length == 1)
                {
                    CheckedMenuItem = (ToolStripMenuItem)items[0];
                }
            }
        }

        private void flpControls_CheckedChanged(object sender, EventArgs args)
        {
            KryptonCheckButton button = ((KryptonCheckSet)sender).CheckedButton;
            loadingListEntries.Visible = button != null && button.Checked;

            //If no button checked
            if (button != null && button.Checked)
            {
                dataGridView.UserDeletingRow -= new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_LoadingListDeletingRow);
                dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_LoadingListDeletingRow);

                conn.Close();//ensure to close connection
                conn.Open();

                adapter.SelectCommand = new OleDbCommand("Select * from LoadingListParameter_View", conn);
                adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = (long)button.Tag;
                adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
                adapter.UpdateCommand = new OleDbCommand("Update LoadingList_Query set [+]=@important, truck=@truck, " + NumberUpdateLine + CommonUpdateString, conn);
                adapter.UpdateCommand.Parameters.Add("@important", OleDbType.Boolean, 2, "+");
                adapter.UpdateCommand.Parameters.Add("@truck", OleDbType.VarWChar, 50, "truck");
                Entry_AddParameters(adapter.UpdateCommand.Parameters);

                adapter.DeleteCommand = new OleDbCommand("Delete from LoadingEntry where id=@id", conn);
                adapter.DeleteCommand.Parameters.Add("@id", OleDbType.Integer, 4, "id");

                dgvp.LoadTable(adapter, "LoadingListParameter_View");

                tb_setTruckNumber(truckTb, button.Tag.ToString(), dgvp.dataSet);

                this.truckTb.TextChanged -= new System.EventHandler(this.truckTb_TextChanged);
                this.truckTb.TextChanged += new System.EventHandler(this.truckTb_TextChanged);

                conn.Close();
            }
            else if (CheckedMenuItem.Name.StartsWith("l"))
            {
                conn.Close();//ensure to close connection
                tsmiStock_Click(tsmiStock, new EventArgs());
            }
        }

        //todo fix
        public static EditForm editForm;
        private void tsmiAdd_Click(object sender, System.EventArgs e)
        {
            //CheckedMenuItem = (ToolStripMenuItem)sender;
            editForm = new EditForm("Add entry", dgvp.DataTable.NewRow(), dataGridView.Columns, conn);
            editForm.ShowDialog();

            adapter.Update(editForm.dataTable);
            conn.Open();
            DBCacheStock();
            conn.Close();
            dgvp.Reset(adapter);
            editForm = null;
        }

        private void tsmiEdit_Click(object sender, System.EventArgs e)
        {
            //CheckedMenuItem = (ToolStripMenuItem)sender;
            DataTable dataTable = (DataTable)dataGridView.DataSource;
            editForm = new EditForm("Edit entry", dgvp.SelectedDataRow, dataGridView.Columns, conn);
            //editForm.UpdateEntry += new EditForm.Event(dataGridView_CurrentCellChanged);
            editForm.ShowDialog();

            adapter.Update(editForm.dataTable);
            //dgvp.Reset(adapter);
            editForm = null;
        }

        public static void adapter_UpdateEvent(object sender, OleDbRowUpdatingEventArgs e)
        {
            //Console.WriteLine("adapter updates");
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // do nothing
            Console.Write(e.Exception.StackTrace);
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // !important
            Console.WriteLine(Validate());


            if (!tsmiCustoms.Font.Bold &&
                !tsmiT1.Font.Bold &&
                !tsmiGoodsList.Font.Bold)
            {
                try
                {
                    if ((DataTable)dataGridView.DataSource != null &&
                        (adapter.UpdateCommand != null || adapter.DeleteCommand != null))
                    {
                        Console.WriteLine("updates cell");
                        adapter.Update((DataTable)dataGridView.DataSource);
                    }
                }
                catch (Exception e2)
                {
                    //do nothing
                    Console.WriteLine(e2.StackTrace);
                    // ExceptionMessageBox(e, ExceptionMessageBoxButtons.OK).Show(this);
                }
            }
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView.AllowUserToDeleteRows = adapter.DeleteCommand != null;

            //DataGridView_LockColumn(dataGridView, "invoice_number");
            DataGridView_LockColumn("ccs_number");
            DataGridView_LockColumn("invoices");
            DataGridView_LockColumn("LL");
            DataGridView_LockColumn("created");
            DataGridView_LockColumn("created_at"); // TODO: rename

            //Console.WriteLine("rows added");
            // Color rows
            int index;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if ((index = dgvp.IndexOf("_ll")) > 0 && index < row.Cells.Count) // If entry in LL
                {
                    row.HeaderCell.Value = row.Cells[index].Value;
                }
                dataGridView_ChangeRowColor(row);
            }
        }

        private void tsmiLEHistory_Click(object sender, EventArgs e)
        {
            CheckedMenuItem = (ToolStripMenuItem)sender;
            csLoadingList.CheckedButton = null;
            dgvp.ContextMenuStrip(new ContextMenuStrip[] { cmsSearch, cmsTitlePage, cmsHistory, cmsEntry, cmsAttach, cmsInvoice }, new CancelEventHandler[] { selectRow_Opening, cmsTitlePage_Opening, cmsAttach_Opening, cmsInvoice_Opening });

            //!mportant where @stock_id
            adapter.SelectCommand = new OleDbCommand("Select * from LoadingEntryHistory_View where stock_id=@stock_id", conn);
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
            adapter.UpdateCommand = new OleDbCommand("Update LoadingEntryHistory_View set invoices = @invoices, chess = @chess, " + NumberUpdateLine + CommonUpdateString, conn);
            adapter.UpdateCommand.Parameters.Add("@invoiceNumber", OleDbType.VarWChar, 255, "invoices");
            adapter.UpdateCommand.Parameters.Add("@chess", OleDbType.VarWChar, 32, "chess");
            Entry_AddParameters(adapter.UpdateCommand.Parameters);
            dgvp.LoadTable(adapter, "LoadingEntryHistory_View");
            conn.Close();
        }

        private void flpControls_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            //throw new System.NotImplementedException();
            //Console.WriteLine("control added");
            //conn.Close();
            //tsmiStock_Click(tsmiStock, new EventArgs());
        }

        private void flpControls_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            //throw new System.NotImplementedException();
            //Console.WriteLine("control removed");
            //tsmiStock_Click(tsmiStock, new EventArgs());
        }

        private void tsmiStock_Click(object sender, EventArgs e)
        {
            // delete previous instance
            dataGridView.UserDeletingRow -= new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_StockDeletingRow);
            dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_StockDeletingRow);

            conn.Open();
            DBCacheStock();

            CheckedMenuItem = tsmiStock;
            setCurrentStock((ToolStripMenuItem)sender);
            csLoadingList.CheckedButton = null;

            DBSelect_StockView();
            conn.Close();

            dgvp.ContextMenuStrip(new ContextMenuStrip[] { cmsSearch, cmsTitlePage, cmsEntry, cmsAttach, cmsLoadingLists }, new CancelEventHandler[] { selectRow_Opening, cmsTitlePage_Opening, cmsAttach_Opening, cmsLoadingLists_Opening });
            dgvp.LoadTable(adapter, "Stock_View");
        }

        private void setCurrentStock(ToolStripMenuItem tsmi)
        {
            tsmiStock.Tag = getStockId(tsmi);
            tsmiStock.Text = tsmi.Text;
        }

        private int getStockId()
        {
            return getStockId(tsmiStock);
        }

        private int getStockId(ToolStripMenuItem tsmi)
        {
            return int.Parse(tsmi.Tag.ToString());
        }

        private void DBSelect_StockView()
        {
            adapter.SelectCommand = new OleDbCommand("Select * from StockCache sv where stock_id=@stock_id", conn);
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
            adapter.RowUpdating += new OleDbRowUpdatingEventHandler(adapter_UpdateEvent);

            adapter.InsertCommand = new OleDbCommand("Insert into LogEntry_Query ([stock],      stock_id,  _kg_doc,  kg_doc, _kg_rcvd,  kg_rcvd, _m3,  m3, _cll_doc,  cll_doc, _cll_rcvd,  cll_rcvd, _booking_number,  booking_number, _arrival,  arrival, _status,  status, _consignor,  consignor, _consignee,  consignee, _description,  description, _ccs_number,  ccs_number, _damage,  damage, _wh_number,  wh_number, _wh_pl,  wh_pl, _manager,  manager, _documents,  documents, _situation,  situation, _codes,  codes, _comments,  comments, _container,  [container], _attached, [attached]) " +
                                                                               "values('" + tsmiStock.Text + "', @stock_id, @kg_doc, @kg_doc, @kg_rcvd, @kg_rcvd, @m3, @m3, @cll_doc, @cll_doc, @cll_rcvd, @cll_rcvd, @booking_number, @booking_number, @arrival, @arrival, @status, @status, @consignor, @consignor, @consignee, @consignee, @description, @description, @ccs_number, @ccs_number, @damage, @damage, @wh_number, @wh_number, @wh_pl, @wh_pl, @manager, @manager, @documents, @documents, @situation, @situation, @codes, @codes, @comments, @comments, @container, @container, @attached, @attached);", conn);

            adapter.InsertCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
            Entry_AddParameters(adapter.InsertCommand.Parameters);

            adapter.DeleteCommand = new OleDbCommand("Delete from Entry where id = @id", conn);
            adapter.DeleteCommand.Parameters.Add("@id", OleDbType.Integer, 4, "id");

            adapter.UpdateCommand = new OleDbCommand("Update Entry set kg_doc=iif(isnull(@_kg_doc-(@kg_doc2-@kg_doc)), @kg_doc, @_kg_doc-(@kg_doc2-@kg_doc)), kg_rcvd=iif(isnull(@_kg_rcvd-(@kg_rcvd2-@kg_rcvd)), @kg_rcvd, @_kg_rcvd-(@kg_rcvd2-@kg_rcvd)), m3=iif(isnull(@_m3-(@m32-@m3)), @m3, @_m3-(@m32-@m3)), cll_doc=iif(isnull(@_cll_doc-(@cll_doc2-@cll_doc)), @cll_doc, @_cll_doc-(@cll_doc2-@cll_doc)), cll_rcvd=iif(isnull(@_cll_rcvd-(@cll_rcvd2-@cll_rcvd)), @cll_rcvd, @_cll_rcvd-(@cll_rcvd2-@cll_rcvd)), " + CommonUpdateString, conn); ;
            adapter.UpdateCommand.Parameters.Add("@_kg_doc", OleDbType.Double, 8, "_kg_doc");
            adapter.UpdateCommand.Parameters.Add("@kg_doc2", OleDbType.Double, 8, "kg_doc2");
            adapter.UpdateCommand.Parameters.Add("@kg_doc", OleDbType.Double, 8, "kg_doc");

            adapter.UpdateCommand.Parameters.Add("@_kg_rcvd", OleDbType.Double, 8, "_kg_rcvd");
            adapter.UpdateCommand.Parameters.Add("@kg_rcvd2", OleDbType.Double, 8, "kg_rcvd2");
            adapter.UpdateCommand.Parameters.Add("@kg_rcvd", OleDbType.Double, 8, "kg_rcvd");
            adapter.UpdateCommand.Parameters.Add("@_m3", OleDbType.Double, 8, "_m3");
            adapter.UpdateCommand.Parameters.Add("@m32", OleDbType.Double, 8, "m32");
            adapter.UpdateCommand.Parameters.Add("@m3", OleDbType.Double, 8, "m3");

            adapter.UpdateCommand.Parameters.Add("@_cll_doc", OleDbType.Integer, 4, "_cll_doc");
            adapter.UpdateCommand.Parameters.Add("@cll_doc2", OleDbType.Integer, 4, "cll_doc2");
            adapter.UpdateCommand.Parameters.Add("@cll_doc", OleDbType.Integer, 4, "cll_doc");
            adapter.UpdateCommand.Parameters.Add("@_cll_rcvd", OleDbType.Integer, 4, "_cll_rcvd");
            adapter.UpdateCommand.Parameters.Add("@cll_rcvd2", OleDbType.Integer, 4, "cll_rcvd2");
            adapter.UpdateCommand.Parameters.Add("@cll_rcvd", OleDbType.Integer, 4, "cll_rcvd");
            addCommonParameters(adapter.UpdateCommand.Parameters);
        }

        private void tsmiNewList_Click(object sender, EventArgs e)
        {
            conn.Open();
            DBInsert_LoadingList();
            DBSelect_LoadingLists_Reset();
            conn.Close();

            //dgvp.Reset(adapter);
        }

        private void Log_Opening(object sender, CancelEventArgs e)
        {
            tsmiAttach.Enabled = !tsmiLogBook.Equals(CheckedMenuItem);
        }

        private void tsmiLogList_Click(object sender, EventArgs e)
        {
            conn.Open();

            CheckedMenuItem = (ToolStripMenuItem)sender;
            dgvp.ContextMenuStrip(new ContextMenuStrip[] { cmsSearch, cmsAttach }, new CancelEventHandler[] { selectRow_Opening, cmsAttach_Opening, Log_Opening });
            adapter.SelectCommand = new OleDbCommand("Select * from Log_View", conn);
            new OleDbCommandBuilder(adapter);
            dgvp.LoadTable(adapter, "Log_View");

            conn.Close();
        }

        private void tsmiLL_DropDownOpening(object sender, EventArgs e)
        {
            conn.Open();

            tsmiDemolish.Visible = !tsmiHistory.Font.Bold;

            Boolean enabled = tsmiRemove.Enabled = tsmiGoodsList.Enabled = tsmiCustoms.Enabled = tsmiT1.Enabled = tsmiDemolish.Enabled = csLoadingList.CheckedButton != null;
            tsmiClear.Enabled = tsmiDemolish.Enabled = (enabled) ? dataGridView.Rows.Count > 0 : enabled;
            tsmiNewList.Text = "Create " + LL_DeserializeName(DBSelect_LoadingListIndex());

            conn.Close();
        }

        /*EVENT*/
        private void tsmiGoodsList_Click(object sender, EventArgs e)
        {
            conn.Open();

            dataGridView.ContextMenuStrip = null;
            CheckedMenuItem = (ToolStripMenuItem)sender;
            adapter.SelectCommand = new OleDbCommand("Select * from LoadingListGoods_View", conn);
            adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = (long)csLoadingList.CheckedButton.Tag;
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
            dgvp.Populate(adapter, "LoadingListGoods_View");

            conn.Close();
        }

        /*EVENT*/
        private void tsmiCustoms_Click(object sender, EventArgs e)
        {
            conn.Open();

            dataGridView.ContextMenuStrip = null;
            CheckedMenuItem = (ToolStripMenuItem)sender;
            adapter.SelectCommand = new OleDbCommand("Select * from LoadingListCustoms_View", conn);
            adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = (long)csLoadingList.CheckedButton.Tag;
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
            dgvp.Populate(adapter, "LoadingListCustoms_View");

            conn.Close();
        }

        /*EVENT*/
        private void tsmiT1_Click(object sender, EventArgs e)
        {
            conn.Open();

            dataGridView.ContextMenuStrip = null;
            CheckedMenuItem = (ToolStripMenuItem)sender;

            adapter.SelectCommand = new OleDbCommand("Select * from LoadingListT1_View", conn);
            adapter.SelectCommand.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = (long)csLoadingList.CheckedButton.Tag;
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();

            dgvp.Populate(adapter, "LoadingListT1_View");

            conn.Close();
        }

        /*EVENT*/
        private void tsmiDemolish_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (DialogResult.Yes == KryptonMessageBox.Show(string.Format("Demolish {0}?", csLoadingList.CheckedButton.Text), "Demolishing", MessageBoxButtons.YesNo))
            {
                OleDbCommand demolish = new OleDbCommand("Insert into LoadingListHistory (list_id) values(@list_id)", conn);
                demolish.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = csLoadingList.CheckedButton.Tag;
                demolish.ExecuteNonQuery();

                DBSelect_LoadingLists_Reset();
                tsmiLEHistory_Click(tsmiHistory, new EventArgs());
            }
            conn.Close();
        }

        /*EVENT*/
        private void tsmiClearLoadingEntries_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (DialogResult.Yes == KryptonMessageBox.Show(string.Format("Clear {0}?", csLoadingList.CheckedButton.Text), "Clearing", MessageBoxButtons.YesNo))
            {
                OleDbCommand clear = new OleDbCommand("Delete from LoadingEntry where list_id = @list_id", conn);
                clear.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = csLoadingList.CheckedButton.Tag;
                clear.ExecuteNonQuery();

                dgvp.Reset(adapter);
            }
            conn.Close();
        }

        /*EVENT*/
        private void tsmiRemoveList_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == KryptonMessageBox.Show(string.Format("Remove {0}?", csLoadingList.CheckedButton.Text), "Removing list", MessageBoxButtons.YesNo))
            {
                conn.Open();

                OleDbCommand clear = new OleDbCommand("Delete from LoadingList where id = @list_id", conn);
                clear.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = (long)csLoadingList.CheckedButton.Tag;
                clear.ExecuteNonQuery();

                DBSelect_LoadingLists_Reset();
                conn.Close();

                tsmiStock_Click(tsmiStock, null);
            }
        }

        /*EVENT*/
        private void tsmiRebuildList_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (DialogResult.Yes == KryptonMessageBox.Show(string.Format("Rebuild {0}?", dgvp.item("LL")), "Rebuilding", MessageBoxButtons.YesNo))
            {
                OleDbCommand recreate = new OleDbCommand("Delete from LoadingListHistory where list_id = @list_id", conn);
                recreate.Parameters.Add("@list_id", OleDbType.VarWChar, 19).Value = long.Parse(dgvp.item("list_id").ToString());
                recreate.ExecuteNonQuery();

                DBSelect_LoadingLists_Reset();
            }
            conn.Close();
        }

        /*EVENT*/
        private void tsmiLogOut_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == KryptonMessageBox.Show("Log out from the program?", "Logging out", MessageBoxButtons.YesNo))
            {
                Application.Restart();
            }
        }

        /*EVENT*/
        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView.CurrentCell;
            if (cell != null)
            {
                Rectangle rect = dataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, false);
                //dataGridView.Columns[cell.ColumnIndex].HeaderCell.Style.BackColor = Color.Pink;
                tbSearch.Visible = true;
                string cellName = dgvp.CurrentCellName + "-" + dgvp.DataTable.TableName;
                if (dgvp.searchHash.ContainsKey(cellName))
                {
                    tbSearch.Text = dgvp.searchHash[cellName].ToString();
                }
                tbSearch.Location = new Point(rect.X + rect.Width - 15, rect.Y + 15);
                tbSearch.BringToFront();
                if (sender != null)
                    tbSearch.SelectAll();
                tbSearch.Focus();
            }
        }

        /*EVENT*/
        private void tbSearch_Leave(object sender, EventArgs e)
        {
            tbSearch.Visible = false;
        }


        /*EVENT*/
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvp.CurrentCellName != null)
            {
                TextBox searchBox = (TextBox)sender;
                string selectCommand = adapter.SelectCommand.CommandText;
                string columns = "";
                string ending = " group by #group# having"; //first(" + enteredCellName + ") like '%" + searchBox.Text + "%'
                int index;

                string cellName = dgvp.CurrentCellName + "-" + dgvp.DataTable.TableName;
                if (!dgvp.searchHash.ContainsKey(cellName))
                {
                    dgvp.searchHash.Add(cellName, tbSearch.Text);
                }
                else
                {
                    dgvp.searchHash[cellName] = tbSearch.Text;
                }

                foreach (String key in dgvp.searchHash.Keys)
                {
                    if (key.IndexOf(dgvp.DataTable.TableName) > -1)
                    {
                        ending += " first(" + key.Substring(0, key.IndexOf("-")) + ") like '%" + dgvp.searchHash[key] + "%' and";
                    }
                }
                ending = ending.Substring(0, ending.Length - 3);
                //Console.WriteLine(ending);

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    columns += "[" + column.Name + "],";
                }
                if ((index = selectCommand.IndexOf("*")) > -1)
                {
                    selectCommand = selectCommand.Replace("*", columns.Substring(0, columns.Length - 1));
                }

                if ((index = selectCommand.IndexOf(" order by", StringComparison.OrdinalIgnoreCase)) > -1)
                {
                    ending += selectCommand.Substring(index);
                    selectCommand = selectCommand.Replace(selectCommand.Substring(index), "");
                }
                if ((index = selectCommand.IndexOf(" group", StringComparison.OrdinalIgnoreCase)) > -1)
                {
                    selectCommand = selectCommand.Replace(selectCommand.Substring(index), "");
                }
                selectCommand += ending;


                selectCommand = selectCommand.Replace("#group#", columns.Substring(0, columns.Length - 1));

                if (searchBox.Text.Length == 0)// && hash.Count < 2)
                {
                    dgvp.searchHash.Remove(dgvp.CurrentCellName + "-" + dgvp.DataTable.TableName);
                    dataGridView.Columns[dgvp.enteredColumnIndex].HeaderCell.Style.BackColor = Color.Empty;

                    index = selectCommand.IndexOf(" group");
                    if (index > -1)
                    {
                        selectCommand = selectCommand.Substring(0, index);
                    }
                }

                adapter.SelectCommand.CommandText = selectCommand;
                dgvp.Reset(adapter);
                tsmiSearch_Click(null, null);
            }
        }

        //DCOMCNFG
        /*EVENT*/
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = Text.Replace(" >", "").Replace(" ", "-");

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
                    xlWorkSheet.Cells[1, 1] = csLoadingList.CheckedButton.Text;
                    xlWorkSheet.Cells[1, 3] = "Truck:";
                    xlWorkSheet.Cells[1, 4] = truckTb.Text;
                }
                xlWorkSheet.Cells[1, 7] = "Date:";
                xlWorkSheet.Cells[1, 8] = DateTime.Now.ToString("dd.MM.yyyy hh:mm");

                xlWorkSheet.Cells[2, 1] = "Total:";
                xlWorkSheet.Cells[2, 2] = dataGridView_ColumnSum("cll_doc") + " Pkgs";
                xlWorkSheet.Cells[2, 3] = dataGridView_ColumnSum("kg_doc") + " Kgs";

                xlWorkSheet.Cells[2, 9] = dataGridView_ColumnSum("m3") + " M3";

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
                            try
                            {
                                xlWorkSheet.Cells[rowIndex + 1, columnIndex + 1] = cell.Value;
                                columnIndex++;
                            }
                            catch
                            {
                                //System.Runtime.InteropServices.COMException
                            }
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

        /*EVENT*/
        private void form_invoiceNumberCreated(String invoiceNumber)
        {
            if (tsmiHistory.Font.Bold)
            {
                dgvp.SelectedDataRow[dgvp.IndexOf("invoices")] += (dgvp.item("invoices").ToString().Length == 0) ? invoiceNumber : "," + invoiceNumber;
            }
        }

        /*EVENT*/
        private void truckTb_TextChanged(object sender, EventArgs e)
        {
            conn.Close();//close just in case
            conn.Open();
            if (csLoadingList.CheckedButton != null)
            {

                long listId = (long)csLoadingList.CheckedButton.Tag;
                OleDbCommand updateCommand = new OleDbCommand("Update LoadingList set truck = @truck where id = @id", conn);
                updateCommand.Parameters.Add("@truck", OleDbType.VarWChar).Value = ((TextBox)sender).Text;
                updateCommand.Parameters.Add("@id", OleDbType.VarWChar).Value = listId;
                updateCommand.ExecuteNonQuery();

            }
            conn.Close();
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                int index = dataGridView.CurrentCell.ColumnIndex;
                DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;
                control.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                control.AutoCompleteSource = AutoCompleteSource.CustomSource;
                control.AutoCompleteCustomSource.Clear();

                if (index.Equals(dgvp.IndexOf("manager")) ||
                    index.Equals(dgvp.IndexOf("consignor")) ||
                    index.Equals(dgvp.IndexOf("consignee")) ||
                    index.Equals(dgvp.IndexOf("description")))
                {
                    String tableName = "Stock_View_AutoComplete";
                    String columnName = dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].Name;
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select " + columnName + " from Log group by " + columnName, conn);
                    if (dgvp.dataSet.Tables[tableName] != null)
                        dgvp.dataSet.Tables[tableName].Reset();

                    adapter.Fill(dgvp.dataSet, tableName);
                    DataTable table = dgvp.dataSet.Tables[tableName];
                    String[] values = new String[table.Rows.Count];
                    int i = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        values[i++] = row.ItemArray[0].ToString();
                    }
                    control.AutoCompleteCustomSource.AddRange(values);
                }
            }
        }

        /*EVENT*/
        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            dataGridView.Height = kryptonPanel.Height - menuStrip.Height - flpControls.Height;
        }

        /*EVENT*/
        private void dataGridView_Resize(object sender, EventArgs e)
        {
            dataGridView.Width = kryptonPanel.Width - dataGridView.Margin.Left - dataGridView.Margin.Right;
        }

        /*EVENT*/
        private void tsmiTitlePage_Click(object sender, EventArgs e)
        {
            TitlePageForm form = new TitlePageForm(dgvp.SelectedDataRow);
            form.DBUpdate += new TitlePageForm.Save_Fields(DBUpdate_TitlePage);
            form.FormClosed += new FormClosedEventHandler(summaryForm_FormClosed);
            form.Show();
        }

        void DBUpdate_TitlePage(Control[] fields)
        {
            OleDbCommand command = new OleDbCommand("Update Entry set " + NumberUpdateLine + CommonUpdateString, conn);
            Entry_AddParameters(command.Parameters);
            int deleterIndex = 0;
            for (int i = 0; i < command.Parameters.Count; i++)
            {
                OleDbParameter parameter = command.Parameters[i];
                if (fields[i + deleterIndex] == null)
                {
                    command.CommandText = command.CommandText.Replace(parameter.SourceColumn + "=" + parameter.ParameterName + ",", "");
                    command.Parameters.RemoveAt(i);
                    i--;
                    deleterIndex++;
                }
                else
                {
                    parameter.SourceColumn = null;
                    String text = fields[i + deleterIndex].Text;
                    // TODO: fix this with newer version
                    if (parameter.OleDbType.Equals(OleDbType.Double))
                    {
                        double value = 0;
                        double.TryParse(text, out value);
                        parameter.Value = value;
                    }
                    else if (parameter.OleDbType.Equals(OleDbType.Integer))
                    {
                        int value = 0;
                        int.TryParse(text, out value);
                        parameter.Value = value;
                    }
                    else if (parameter.OleDbType.Equals(OleDbType.DBTimeStamp))
                    {
                        parameter.Value = DateTime.Parse(text);
                    }
                    else
                    {
                        parameter.Value = text;
                    }
                }
            }

            conn.Open();
            command.ExecuteNonQuery();
            //todo improve
            if (CheckedMenuItem.Equals(tsmiStock))
            {
                DBCacheStock();
            }
            conn.Close();


            dgvp.Reset(adapter);
        }

        /*EVENT*/
        private void summaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TitlePageForm form = (TitlePageForm)sender;
            //SelectedRow.Cells[dataColumn_IndexOf("comments")].Value = form.CommentText;
            //dataGridView.CurrentCell = dataGridView[dataGridView.Rows[0].Cells.Count - 1, 0];
        }

        /*EVENT*/
        private void tsmiCMR_Click(object sender, EventArgs e)
        {
            CMRForm form = new CMRForm(conn);
            form.FormClosed += new FormClosedEventHandler(CMR_FormClosed);
            form.Show();
        }

        /*EVENT*/
        private void tsmiInvoiceBlank_Click(object sender, EventArgs e)
        {
            InvoiceForm form = new InvoiceForm(getInvoiceLogBlank().NewRow(), getStockId());
            form.FormClosed += new FormClosedEventHandler(Invoice_FormClosed);
            form.Show();
        }

        /*EVENT*/
        private void tsmiInvoiceLog_Click(object sender, EventArgs e)
        {
            // delete previous instance
            dataGridView.UserDeletingRow -= new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_InvoiceLogUserDeletingRow);
            dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_InvoiceLogUserDeletingRow);

            conn.Open();

            csLoadingList.CheckedButton = null;
            dgvp.ContextMenuStrip(new ContextMenuStrip[] { cmsSearch, cmsAttach, cmsInvoice }, new CancelEventHandler[] { selectRow_Opening, cmsAttach_Opening, cmsInvoice_Opening });
            CheckedMenuItem = (ToolStripMenuItem)sender;

            adapter.SelectCommand = new OleDbCommand("Select * from InvoiceLog_View", conn);
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
            adapter.DeleteCommand = new OleDbCommand("Delete from [InvoiceLog] where id = @id;", conn);
            adapter.DeleteCommand.Parameters.Add("@id", OleDbType.Integer, 4, "_id");
            adapter.UpdateCommand = new OleDbCommand("Update InvoiceLog set invoice_number = @invoice_number, invoice_date = @invoice_date, due_date = @due_date, ccs_number = @ccs_number, cll_doc = @cll_doc, kg_doc = @kg_doc, m3 = @m3, attached = @attached where id = @id", conn);
            adapter.UpdateCommand.Parameters.Add("@invoice_number", OleDbType.VarWChar, 12, "invoice_number");
            adapter.UpdateCommand.Parameters.Add("@invoice_date", OleDbType.DBTimeStamp, 4, "invoice_date");
            adapter.UpdateCommand.Parameters.Add("@due_date", OleDbType.DBTimeStamp, 4, "due_date");
            adapter.UpdateCommand.Parameters.Add("@ccs_number", OleDbType.VarWChar, 11, "ccs_number");
            adapter.UpdateCommand.Parameters.Add("@cll_doc", OleDbType.Integer, 4, "cll_doc");
            adapter.UpdateCommand.Parameters.Add("@kg_doc", OleDbType.Double, 8, "kg_doc");
            adapter.UpdateCommand.Parameters.Add("@m3", OleDbType.Double, 8, "m3");
            adapter.UpdateCommand.Parameters.Add("@attached", OleDbType.VarWChar, 255, "attached");
            adapter.UpdateCommand.Parameters.Add("@id", OleDbType.Integer, 4, "_id");

            dgvp.LoadTable(adapter, "InvoiceLog_View");
            dataGridView.Sort(dataGridView.Columns[dgvp.IndexOf("created")], ListSortDirection.Descending);

            conn.Close();
        }

        /*EVENT*/
        private void dataGridView_StockDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (tsmiStock.Equals(CheckedMenuItem))
            {
                e.Cancel = (DialogResult.No == KryptonMessageBox.Show("Delete " + dgvp.item("ccs_number") + "?", "Deleting", MessageBoxButtons.YesNo));
            }
        }

        /*EVENT*/
        private void dataGridView_LoadingListDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (csLoadingList.CheckedButton != null)
            {
                e.Cancel = (DialogResult.No == KryptonMessageBox.Show("Delete " + dgvp.item("ccs_number") + "?", "Deleting", MessageBoxButtons.YesNo));
            }
        }

        /*EVENT*/
        private void dataGridView_CMRDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (tsmiCMR.Equals(CheckedMenuItem))
            {
                e.Cancel = (DialogResult.No == KryptonMessageBox.Show("Delete " + dgvp.item("reference_number") + "?", "Deleting", MessageBoxButtons.YesNo));
            }
        }

        /*EVENT*/
        private void dataGridView_InvoiceLogUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            conn.Open();

            if (tsmiInvoiceLog.Equals(CheckedMenuItem))
            {
                e.Cancel = (DialogResult.No == KryptonMessageBox.Show("Delete " + dgvp.item("invoice_number") + "?", "Deleting", MessageBoxButtons.YesNo));
                if (!e.Cancel && !WarehouseApp.Properties.Settings.Default.InvoiceResetType.Equals("d"))
                {
                    String invoiceNumber = e.Row.Cells[dgvp.IndexOf("invoice_number")].Value.ToString();
                    //not used
                    /*OleDbCommand command = new OleDbCommand("insert into InvoiceNumbersFree (invoice_number) values(@invoiceNumber)", conn);
                    command.Parameters.Add("@invoiceNumber", OleDbType.VarWChar).Value = invoiceNumber;
                    command.ExecuteNonQuery();*/
                    OleDbCommand command = new OleDbCommand("Select invoices from LoadingEntry_Query where ccs_number like @ccs_number", conn);
                    command.Parameters.Add("@ccs_number", OleDbType.VarWChar).Value = e.Row.Cells[dgvp.IndexOf("ccs_number")].Value.ToString();
                    command.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        String invoices = reader.GetString(0).Replace(invoiceNumber + ",", "").Replace(invoiceNumber, "");
                        command = new OleDbCommand("Update LoadingEntry_Query set invoices = @invoices where ccs_number like @ccs_number", conn);
                        command.Parameters.Add("@invoices", OleDbType.VarWChar).Value = invoices;
                        command.Parameters.Add("@ccs_number", OleDbType.VarWChar).Value = e.Row.Cells[dgvp.IndexOf("ccs_number")].Value.ToString();
                        command.ExecuteNonQuery();
                    }
                }
            }

            conn.Close();
        }

        /*EVENT*/
        private void cmsInvoice_Opening(object sender, CancelEventArgs e)
        {
            int index;
            String[] numbers;
            ContextMenuStrip cms = (ContextMenuStrip)sender;
            ToolStripItem[] items = cms.Items.Find("invoice", true);

            foreach (ToolStripItem item in items)
            {
                cms.Items.Remove(item);
            }

            if ((index = dgvp.IndexOf("invoices")) > -1)
            {
                numbers = dgvp.item("invoices").ToString().Split(',');
            }
            else
            {
                numbers = new String[] { dgvp.item("invoice_number").ToString() };
            }

            foreach (String number in numbers)
            {
                if (number.Trim().Length > 0)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem("Invoice " + number.Trim(), WarehouseApp.Properties.Resources.table_edit);

                    item.Click += delegate(object sender2, EventArgs e2)
                    {
                        Console.WriteLine(CheckedMenuItem.Text);
                        if (CheckedMenuItem.Equals(tsmiInvoiceLog))
                        {
                            
                            tsmiInvoiceEdit_Click(sender2, e2);
                        }
                        else
                        {
                            tsmiInvoiceOpen_Click(sender2, e2);
                        }
                    };
                    
                    item.Tag = number.Trim();
                    item.Name = "invoice";
                    cms.Items.Insert(cms.Items.IndexOf(tsmiInvoiceNew), item);
                }
            }

            tsmiInvoiceNew.Visible = dgvp.SelectedDataRow[dgvp.IndexOf("ccs_number")] != null && dgvp.SelectedDataRow[dgvp.IndexOf("ccs_number")].ToString().Length > 0;
        }

        private DataTable getInvoiceLogBlank()
        {
            DataSet dt = new DataSet();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from InvoiceLog_View where invoice_number = null", conn))
            {
                adapter.Fill(dt, "InvoiceLog_View");
            }
            return dt.Tables["InvoiceLog_View"];
        }

        /*EVENT*/
        private void tsmiInvoiceNew_Click(object sender, EventArgs e)
        {
            newInvoice(sender, getInvoiceLogBlank().NewRow());
        }

        /*EVENT*/
        private void tsmiInvoiceEdit_Click(object sender, EventArgs e)
        {
            newInvoice(sender, dgvp.SelectedDataRow);//dgvp.SelectedDataRow
        }

        /*EVENT*/
        private void tsmiInvoiceOpen_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from InvoiceLog_View where invoice_number = @invoice_number", conn))
            {
                Console.WriteLine(((ToolStripMenuItem)sender).Tag.ToString());
                adapter.SelectCommand.Parameters.Add("@invoice_number", OleDbType.VarWChar).Value = ((ToolStripMenuItem)sender).Tag.ToString();
                adapter.Fill(dt, "InvoiceLog_View");
            }
            newInvoice(sender, dt.Tables["InvoiceLog_View"].Rows[0]);//dgvp.SelectedDataRow
        }

        private void newInvoice(object sender, DataRow item)
        {
            int cll = 0;
            double kg = 0;
            double m3 = 0;
            DateTime departure;
            DateTime arrival;
            ToolStripMenuItem invoiceItem = (ToolStripMenuItem)sender;

            String consignor = dgvp.item("consignor").ToString();
            String whNumber = dgvp.item("wh_number").ToString();
            String ccsNumber = dgvp.item("ccs_number").ToString();
            String status = dgvp.item("status").ToString();
            String bookingNumber = dgvp.item("booking_number").ToString();
            String invoiceNumber = (invoiceItem.Tag != null) ? invoiceItem.Tag.ToString() : null;
            DateTime.TryParse(dgvp.item("departure").ToString(), out departure);
            DateTime.TryParse(dgvp.item("arrival").ToString(), out arrival);
            int.TryParse(dgvp.item("cll_doc").ToString(), out cll);
            double.TryParse(dgvp.item("kg_doc").ToString(), out kg);
            double.TryParse(dgvp.item("m3").ToString(), out m3);

            InvoiceForm form = new InvoiceForm(conn, item, getStockId(), cll, kg, m3, ccsNumber, whNumber, bookingNumber, invoiceNumber, consignor, departure, arrival, status);
            form.invoiceNumberCreated += new InvoiceForm.InvoiceEventHandler(form_invoiceNumberCreated);
            form.FormClosed += new FormClosedEventHandler(Invoice_FormClosed);
            form.Show();
        }

        /*EVENT*/
        private void Invoice_FormClosed(object sender, EventArgs e)
        {
            if (tsmiInvoiceLog.Font.Bold)
            {
                dgvp.Reset(adapter);
            }

            adapter.Update(dgvp.DataTable);
        }

        private void selectRow_Opening(object sender, CancelEventArgs e)
        {
            if (dgvp.selectedCell != null && dgvp.selectedCell.RowIndex > -1 && dgvp.SelectedDataRow != null)
            {
                dataGridView.ClearSelection();
                dataGridView.Rows[dgvp.selectedCell.RowIndex].Selected = true;
                dgvp.selectedCell = null;
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        /*EVENT*/
        private void tsmiLoadingListHistory_Click(object sender, EventArgs e)
        {
            conn.Open();

            csLoadingList.CheckedButton = null;
            dgvp.ContextMenuStrip(new ContextMenuStrip[] { cmsSearch, cmsLL, cmsHistory }, new CancelEventHandler[] { selectRow_Opening });
            CheckedMenuItem = (ToolStripMenuItem)sender;

            adapter.SelectCommand = new OleDbCommand("Select * from LoadingListHistory_View", conn);
            adapter.SelectCommand.Parameters.Add("@stock_id", OleDbType.Integer).Value = getStockId();
            adapter.UpdateCommand = new OleDbCommand("Update LoadingListHistory_View set LL = @LL, truck = @truck, departure = @departure where list_id Like @list_id", conn);
            adapter.UpdateCommand.Parameters.Add("@LL", OleDbType.VarWChar, 7, "LL");
            adapter.UpdateCommand.Parameters.Add("@truck", OleDbType.VarWChar, 50, "truck");
            adapter.UpdateCommand.Parameters.Add("@departure", OleDbType.DBTimeStamp, 4, "departure");
            adapter.UpdateCommand.Parameters.Add("@list_id", OleDbType.VarWChar, 19, "list_id");
            dgvp.LoadTable(adapter, "LoadingListHistory_View");

            conn.Close();
        }

        /*EVENT*/
        private void tsmiLoadingListOpen_Click(object sender, EventArgs e)
        {
            //get it from SetectedButton
            LoadingListForm form = new LoadingListForm(getStockId(), dgvp.item("LL").ToString(), dgvp.item("list_id").ToString(), NumberUpdateLine + CommonUpdateString);
            form.SetTruckNumber += new LoadingListForm.SetTruckNumberEvent(tb_setTruckNumber);
            //form.FormClosed += new FormClosedEventHandler(dataGridViewProperties.dataGridView_Reset);
            //form.UpdateParameters += new LoadingListForm.UpdateParametersEvent(form_LoadingListAdapterParameters);
            form.Show();
        }

        public static void DataGridView_Serialize(DataGridView dataGridView, DataTable srcTable, String fields)
        {
            DataTable table = new DataTable();
            foreach (String name in fields.Split(','))
            {
                table.Columns.Add(name.Trim().Substring(0, 1).ToUpper() + name.Trim().Substring(1));
            }

            Object[] tempArray;
            Object[] columns = srcTable.Rows[0].ItemArray;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                String field = columns[srcTable.Columns.IndexOf(table.Columns[i].ColumnName)].ToString();
                String[] values = field.Split('|');

                if (table.Rows.Count == 0)
                    foreach (String value in values)
                    {
                        table.Rows.Add(new Object[table.Columns.Count]);
                    }
                for (int j = 0; j < values.Length; j++)
                {
                    tempArray = new object[table.Rows[j].ItemArray.Length];
                    table.Rows[j].ItemArray.CopyTo(tempArray, 0);
                    tempArray[i] = values[j];
                    table.Rows[j].ItemArray = tempArray;
                }
            }

            if (dataGridView.Columns.Count > 0)
            {
                foreach (DataRow datarow in table.Rows)
                {
                    int index = dataGridView.Rows.Add(new DataGridViewRow());
                    DataGridViewRow row = dataGridView.Rows[index];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = datarow.ItemArray[cell.ColumnIndex];
                    }
                }
            }
            else
            {
                dataGridView.DataSource = table;
            }
        }

        public static void DataGridView_Deserialize(DataGridView dataGridView, OleDbParameterCollection parameters)
        {
            Object[] cellsInColumns = new Object[dataGridView.Columns.Count];

            for (var i = 0; i < cellsInColumns.Length; i++)
            {
                cellsInColumns[i] = "";
            }

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cellsInColumns[cell.ColumnIndex] += "|" + ((cell.Value != null) ? cell.Value.ToString() : "");
                }
            }

            for (var i = 0; i < cellsInColumns.Length; i++)
            {
                parameters.Add("@" + dataGridView.Columns[i].Name.ToLower(), OleDbType.VarWChar).Value = (cellsInColumns[i].ToString().Length > 0) ? cellsInColumns[i].ToString().Substring(1) : "";
            }
        }

        /*EVENT*/
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /*EVENT*/
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            MainWindow_FormClosed(this, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void tsmiFileAttached_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            FileOpen(tsmi.Text);
        }

        public static string FileGet(String fileName)
        {
            string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            filePath = System.IO.Path.Combine(filePath, "files");
            return System.IO.Path.Combine(filePath, fileName);
        }

        public static void FileOpen(String fileName)
        {
            fileName = FileGet(fileName);
            if (System.IO.File.Exists(fileName))
            {
                System.Diagnostics.Process.Start(fileName);
            }
            else
            {
                KryptonMessageBox.Show("File " + System.IO.Path.GetFileName(fileName) + " not found", "Not file exist");
            }
        }

        private void cmsTitlePage_Opening(object sender, CancelEventArgs e)
        {
            tsmiTitlePage.Visible = dataGridView.SelectedRows.Count > 0;
        }

        /*EVENT*/
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                ((Control)sender).Text = "";
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                tbSearch_Leave(sender, new EventArgs());
                dataGridView.Focus();
            }
        }

        /*EVENT*/
        private void tsmiCMRHistory_Click(object sender, EventArgs e)
        {
            // delete previous instance
            dataGridView.UserDeletingRow -= new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_CMRDeletingRow);
            dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(dataGridView_CMRDeletingRow);

            csLoadingList.CheckedButton = null;
            CheckedMenuItem = (ToolStripMenuItem)sender;

            conn.Open();
            adapter.SelectCommand = new OleDbCommand("Select * from CMRHistory_View", conn);
            adapter.UpdateCommand = new OleDbCommand("Update CMRHistory where id = @id", conn);
            adapter.UpdateCommand.Parameters.Add("@id", OleDbType.Integer, 4, "id");
            adapter.DeleteCommand = new OleDbCommand("Delete from CMRHistory where id = @id", conn);
            adapter.DeleteCommand.Parameters.Add("@id", OleDbType.Integer, 4, "id");
            conn.Close();

            dgvp.ContextMenuStrip(new ContextMenuStrip[] { cmsSearch, cmsCMR }, new CancelEventHandler[] { selectRow_Opening, cmsCMR_Opening });
            dgvp.LoadTable(adapter, "CMRHistory");
        }

        /*EVENT*/
        private void cmsCMR_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)sender;
            tsmiCMREdit.Text = "CMR " + dgvp.item("reference_number").ToString();
            //tsmiCMRNew.Visible = SelectedDataRow[dataColumn_IndexOf("ccs_number")] != null && SelectedDataRow[dataColumn_IndexOf("ccs_number")].ToString().Length > 0;
        }

        /*EVENT*/
        private void tsmiCMREdit_Click(object sender, EventArgs e)
        {
            CMRForm form = new CMRForm(dgvp.item("reference_number").ToString());
            form.FormClosed += new FormClosedEventHandler(CMR_FormClosed);
            form.Show();
        }

        /*EVENT*/
        private void CMR_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tsmiCMRHistory.Font.Bold)
            {
                dgvp.Reset(adapter);
            }
        }

        private delegate void CopyFileDelegate(string filePath);
        public static void CopyFile(string filePath)
        {
            string sourcePath = System.IO.Path.GetDirectoryName(filePath);
            string targetPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string destFile = System.IO.Path.Combine(targetPath, "files");

            System.IO.Directory.CreateDirectory(destFile);
            System.IO.File.Copy(filePath, System.IO.Path.Combine(destFile, System.IO.Path.GetFileName(filePath)), true);
        }

        public static DialogResult OpenFileDialog(OpenFileDialog openFileDialog1)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                //CopyFileDelegate worker = new CopyFileDelegate(CopyFile);
                //AsyncOperation async = AsyncOperationManager.CreateOperation(null);
                //worker.BeginInvoke(openFileDialog1.FileName, null, async);
                CopyFile(openFileDialog1.FileName);
            }

            return result;
        }

        /*
         * EVENT
         * Attaches files to the entry
         * Gets one file per select
         * Uses "attached" field (255 chars)
         * Updates Entry straight away
         */
        private void tsmiAttach_Click(object sender, EventArgs e)
        {
            DialogResult result = OpenFileDialog(openFileDialog1);
            if (result == DialogResult.OK) // Test result. 
            {
                string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (dgvp.item("attached").ToString().IndexOf(fileName) == -1)
                {
                    dgvp.SelectedDataRow[dgvp.IndexOf("attached")] += fileName + ",";

                    //not used, get updated from table
                    /*conn.Open();
                    OleDbCommand attachFiles = new OleDbCommand("Update Entry set attached=@attached where id=@id", conn);
                    attachFiles.Parameters.Add("@attached", OleDbType.VarWChar).Value = attached;
                    attachFiles.Parameters.Add("@id", OleDbType.Integer).Value = dataGridViewProperties.item("entry_id");
                    attachFiles.ExecuteNonQuery();
                    conn.Close();*/

                    adapter.Update(dgvp.DataTable);
                    //Console.WriteLine("updates " + dgvp.DataTable.TableName);
                    //dgvp.Reset(adapter);
                }
                else
                {
                    KryptonMessageBox.Show(string.Format("File {0} exists", fileName), "File exists", MessageBoxButtons.OK);
                }
            }
        }

        /*EVENT*/
        private void cmsAttach_Opening(object sender, CancelEventArgs e)
        {
            string attachedStr = dgvp.item("attached").ToString();
            string[] attached = attachedStr.Split(',');
            Image page_attach = WarehouseApp.Properties.Resources.page_attach;
            ContextMenuStrip cms = dataGridView.ContextMenuStrip;

            ToolStripItemCollection stripItems = new ToolStripItemCollection(cmsAttach, ((ToolStripItem[])cmsAttach.Tag));

            foreach (ToolStripItem item in cms.Items)
            {
                if (item.Name.StartsWith("btnAttach"))
                {
                    item.Visible = attachedStr.IndexOf(item.Name) > -1;
                }
            }

            foreach (string fileName in attached)
            {
                if (fileName.Length > 0)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(fileName, page_attach, new System.EventHandler(tsmiFileAttached_Click));
                    tsmi.Name = "btnAttach" + cms.Items.IndexOf(tsmiAttach) + 1;
                    if (cms.Items.IndexOf(tsmi) == -1)
                    {
                        cms.Items.Insert(cms.Items.IndexOf(tsmiAttach) + 1, tsmi);
                    }
                }
            }
        }

        private ToolStripItem loadingItemDisabled;
        private void cmsLoadingLists_Opening(object sender, CancelEventArgs e)
        {
            tsmiAdd.Enabled = tsmiStock.Name.Equals(CheckedMenuItem.Name);

            conn.Open();
            tsmiNewLL.Text = LL_DeserializeName(DBSelect_LoadingListIndex());
            conn.Close();

            if (loadingItemDisabled != null)
            {
                loadingItemDisabled.Enabled = true;
            }

            if (csLoadingList.CheckedButton != null)
            {
                ToolStripItem[] items = dataGridView.ContextMenuStrip.Items.Find(csLoadingList.CheckedButton.Name, true);
                if (items.Length == 1)
                {
                    loadingItemDisabled = items[0];
                    items[0].Enabled = false;
                }
            }
        }

        // attach image for the items that have attachments
        /*EVENT*/
        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int index;
            if (e.ColumnIndex == -1 && e.RowIndex >= 0 && (index = dgvp.IndexOf("attached")) > -1 &&
                dataGridView.Rows[e.RowIndex].Cells[index].Value.ToString().Length > 0)
            {
                e.Graphics.DrawImage(WarehouseApp.Properties.Resources.attach, new Point(e.CellBounds.Right - WarehouseApp.Properties.Resources.attach.Width - 2, e.CellBounds.Location.Y + 3));
                e.Handled = true;
            }
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                (dgvp.selectedCell = dataGridView[dataGridView.CurrentCell.ColumnIndex, e.RowIndex]).Selected = true;
                //dataGridView.ContextMenuStrip.Show(dataGridView, e.Location);
                /*
                DataGridView.HitTestInfo hitTestInfo = dataGridView.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    dataGridView.ContextMenuStrip.Show(dataGridView, e.Location);
                }*/
            }
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.Button.Equals(MouseButtons.Right))
            {
                int columnIndex = (e.ColumnIndex > -1) ? e.ColumnIndex : dataGridView.CurrentCell.ColumnIndex;
                (dgvp.selectedCell = dataGridView.CurrentCell = dataGridView[columnIndex, e.RowIndex]).Selected = true;
            }
        }
    }
}
