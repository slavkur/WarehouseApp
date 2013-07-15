using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace WarehouseApp
{
    public partial class EditForm : KryptonForm
    {
        private DataRow item;
        private DataSet dataSet;
        //todo: remove
        private DataGridViewColumnCollection columns;
        public DataTable dataTable;
        private DataGridViewCell visibleCell;
        private OleDbConnection conn;

        private int dataGridViewHeight;

        public EditForm(string Label, DataRow item, DataGridViewColumnCollection columns, OleDbConnection conn)
        {
            InitializeComponent();

            this.dataGridViewHeight = dataGridView.Height;
            this.dataSet = new DataSet();
            this.Text = Label;
            this.item = item;
            //todo: remove
            this.columns = columns;
            this.dataTable = item.Table;
            this.conn = conn;
        }

        private int IndexOf(String name)
        {
            return dataTable.Columns.IndexOf(name);
        }

        private bool hideInternal(DataGridViewRow row)
        {
            bool hideCell = false;
            int index;
            if (int.TryParse(dataGridView.Rows[0].HeaderCell.Value.ToString(), out index) && row.Index < index)
            {
                hideCell = true;
                dataGridView.CurrentCell = null;
                row.Visible = false;
            }

            return hideCell;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "Trans";
            dataTable.Columns.Add("Values");

            for (var i = 0; i < this.columns.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                if (item.ItemArray.Length > 0)
                    dataRow.ItemArray = new object[] { item.ItemArray[i] };
                dataTable.Rows.Add(dataRow);
            }

            dataGridView.DataSource = dataTable;
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (var i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = this.columns[i].Name;
                if (!hideInternal(dataGridView.Rows[i]) && visibleCell == null)
                {
                    visibleCell = dataGridView.CurrentCell = dataGridView.Rows[i].Cells[0];
                }

                if (this.columns[i].ReadOnly)
                {
                    dataGridView.Rows[i].Cells[0].Style.BackColor = Color.WhiteSmoke;
                    dataGridView.Rows[i].Cells[0].ReadOnly = true;
                }

                if (this.columns[i].Name == "ccs_number" && dataGridView.Rows[i].Cells[0].Value.ToString().Length == 0)
                {
                    dataGridView.Rows[i].Cells[0].Value = "(generated)";
                }
            }

            btnMain_Click(btnMain, new EventArgs());

            // create buttons for attached files
            string[] attachedFiles = dataGridView.Rows[IndexOf("attached")].Cells[0].Value.ToString().Split(',');
            fileAttacher.displayAttached(attachedFiles);

            dataGridView_DataBindingComplete();
        }

        private String Entry_CreateCcsNumber()
        {
            OleDbConnection conn = new OleDbConnection(Program.connectionString);
            conn.Open();
            OleDbCommand command = new OleDbCommand("Select ccs_number from [EntryReserved]", conn);
            command.Transaction = conn.BeginTransaction();
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            int newIndex = int.Parse(reader.GetString(0).Substring(3)) + 1;
            reader.Close();
            command.CommandText = "Update [EntryReserved] set ccs_number = @ccs_number";
            String ccsNumber = DateTime.Now.ToString("yy-" + ((newIndex.ToString().Length == 1) ? "000" : (newIndex.ToString().Length == 2) ? "00" : (newIndex.ToString().Length == 3) ? "0" : "") + newIndex);
            command.Parameters.Add("@ccs_number", OleDbType.VarWChar).Value = ccsNumber;
            command.ExecuteNonQuery();
            command.Transaction.Commit();
            conn.Close();
            return ccsNumber;
        }

        private void dataGridView_DataBindingComplete()
        {
            Regex bigCells = new Regex("description|ready_comments|documents");
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (bigCells.IsMatch((String)row.HeaderCell.Value))
                {
                    row.Height = 100;
                }
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("value changed");
            DataGridViewRow currentRow = dataGridView.Rows[e.RowIndex];
            if (new Regex("kg_doc|cll_doc").IsMatch((String)currentRow.HeaderCell.Value))
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if ((((string)currentRow.HeaderCell.Value == "kg_doc" && (string)row.HeaderCell.Value == "kg_rcvd") ||
                        ((string)currentRow.HeaderCell.Value == "cll_doc" && (string)row.HeaderCell.Value == "cll_rcvd")) &&
                        row.Cells[0].Value.ToString().Length == 0) //&& row.Cells[1].Value == null)
                    {
                        row.Cells[0].Value = currentRow.Cells[0].Value;
                        break;
                    }
                }
            }
        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("cell changed");
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("end edit");
            Validate();
            SyncDataTable();
        }

        private void dataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void SyncDataTable()
        {
            //check
            Object[] rows = new Object[this.columns.Count];
            for (var j = 0; j < dataGridView.Rows.Count; j++)
            {
                if (this.columns[j].Name == "ccs_number" && dataGridView.Rows[j].Cells[0].Value.Equals("(generated)"))
                {
                    dataGridView.Rows[j].Cells[0].Value = Entry_CreateCcsNumber();
                }
                rows[j] = dataGridView.Rows[j].Cells[0].Value;
            }

            try
            {
                this.item.ItemArray = rows;
                if (this.dataTable.Rows.IndexOf(this.item) == -1)
                {
                    this.dataTable.Rows.Add(this.item);
                }
            }
            catch (Exception e)
            {
                // when wrong value comes
                Console.WriteLine(e.StackTrace);
                dataGridView.CurrentCell.Value = dataTable.Rows[dataTable.Rows.IndexOf(item)].ItemArray[dataGridView.CurrentCell.RowIndex];
            }
        }

        private void hideCellsRange(String startName, String endName, bool reset)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (reset)
                    row.Visible = !hideInternal(row);
                if (row.HeaderCell.Value.ToString() == startName)
                {
                    int breakIndex = dataGridView.Rows.Count;
                    for (var i = row.Index; i < dataGridView.Rows.Count; i++)
                    {
                        dataGridView.Rows[i].Visible = false;
                        if (dataGridView.Rows[i].HeaderCell.Value.ToString() == endName)
                        {
                            breakIndex = i;
                            break;
                        }
                    }

                    if (reset)
                        for (var i = breakIndex + 1; i < dataGridView.Rows.Count; i++)
                        {
                            dataGridView.Rows[i].Visible = true;
                        }

                    break;
                }
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            hideCellsRange("damage", null, true);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            hideCellsRange("cll_doc", "m3", true);
            hideCellsRange("situation", null, false);
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            hideCellsRange("cll_doc", "situation", true);
        }

        private void checkSet_CheckedButtonChanged(object sender, EventArgs e)
        {
            KryptonCheckSet checkSet = ((KryptonCheckSet)sender);
            foreach (KryptonCheckButton button in checkSet.CheckButtons)
            {
                button.Location = new Point(button.Location.X, 15);
            }
            checkSet.CheckedButton.Location = new Point(checkSet.CheckedButton.Location.X, 13);
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                String name = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].HeaderCell.Value.ToString();
                DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;
                control.AutoCompleteMode = AutoCompleteMode.Suggest;
                control.AutoCompleteSource = AutoCompleteSource.CustomSource;
                control.AutoCompleteCustomSource.Clear();

                if (name.Equals("manager") || 
                    name.Equals("consignor") || 
                    name.Equals("consignee") || 
                    name.Equals("description"))
                {
                    String tableName = "Stock_View_AutoComplete";
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select " + name + " from Log group by " + name, conn);
                    if (dataSet.Tables[tableName] != null)
                        dataSet.Tables[tableName].Reset();
                    adapter.Fill(dataSet, tableName);
                    DataTable table = dataSet.Tables[tableName];
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

        private void fileAttacher_AttachFile(object sender, EventArgs e)
        {
            DialogResult result = MainWindow.OpenFileDialog(openFileDialog1);
            if (result == DialogResult.OK) // Test result. 
            {
                string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (item[IndexOf("attached")].ToString().IndexOf(fileName) == -1)
                {
                    item[IndexOf("attached")] += fileName + ",";
                    //SyncDataTable();

                    fileAttacher.createFileButton(fileName);
                }
                else
                {
                    KryptonMessageBox.Show(string.Format("File {0} exists", fileName), "File exists", MessageBoxButtons.OK);
                }
                /*string[] attachedFiles = attached.Split(',');
                foreach (String fileName in attachedFiles)
                {
                    if (fileName.Length > 0)
                    {
                        KryptonDropButton button = createFileButton();
                        button.Text = fileName;
                        button.Click += new EventHandler(fileBtn_Click);
                        flowLayoutPanel1.Controls.Add(button);
                    }
                }*/
            }
        }

        private void fileAttacher_RemoveFile(object sender, EventArgs e)
        {
            if (DialogResult.Yes == KryptonMessageBox.Show(string.Format("Remove {0}?", fileAttacher.btnFileClicked.Text), "Removing attached file", MessageBoxButtons.YesNo))
            {
                item[IndexOf("attached")] = item[IndexOf("attached")].ToString().Replace(fileAttacher.btnFileClicked.Text + ",", "");
                fileAttacher.removeCurrentFileButton();
                //SyncDataTable();
            }
        }

        private void fileAttacher_Resize(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(kryptonPanel.Width, dataGridViewHeight + fileAttacher.Height + btnMain.Height + 50);        
        }
    }
}
