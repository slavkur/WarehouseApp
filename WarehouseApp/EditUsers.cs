using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace WarehouseApp
{
    public partial class EditUsers : Form
    {
        private OleDbConnection conn;
        private OleDbDataAdapter adapter;
        private DataSet dataSet;

        public EditUsers()
        {
            InitializeComponent();
            conn = new OleDbConnection(Program.connectionString);
        }

        private void btnOk_Click(object sender, EventArgs args)
        {
            try
            {
                adapter.Update((DataTable)dataGridView.DataSource);
                DialogResult = DialogResult.OK;
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Validate();
        }

        private DataTable UserTable
        {
            get
            {
                return dataSet.Tables["User_View"];
            }
        }

        private void addParameters(OleDbParameterCollection parameters)
        {
            parameters.Add("@fullname", OleDbType.VarChar, 50, "fullname");
            parameters.Add("@username", OleDbType.VarChar, 24, "_username");
            parameters.Add("@password", OleDbType.VarChar, 24, "_password");

            parameters.Add("@admin", OleDbType.Boolean, 2, "admin");
            parameters.Add("@blocked", OleDbType.Boolean, 2, "blocked");
            parameters.Add("@id", OleDbType.Integer, 4, "id");
        }

        private void EditUsers_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            adapter = new OleDbDataAdapter("Select * from User_View;", conn);
            adapter.InsertCommand = new OleDbCommand("Insert into [User] ([fullname], [username], [password], [admin], [blocked], id) values(@fullname, @username, @password, @admin, @blocked, @id);", conn);
            adapter.UpdateCommand = new OleDbCommand("Update [User] set [fullname]=@fullname, [username]=@username, [password]=@password, [admin]=@admin, [blocked]=@blocked, id=@id where id=@id", conn);
            adapter.DeleteCommand = new OleDbCommand("Delete from [User] where id = @id;", conn);
            adapter.DeleteCommand.Parameters.Add("@id", OleDbType.Integer, 4, "id");
            addParameters(adapter.InsertCommand.Parameters);
            addParameters(adapter.UpdateCommand.Parameters);
            adapter.Fill(dataSet, "User_View");
            dataGridView.DataSource = UserTable;
            UserTable.PrimaryKey = new DataColumn[] { UserTable.Columns[3] };
            conn.Close();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Index < Int32.Parse(dataGridView.Columns[0].Name))
                {
                    column.Visible = false;
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1) + "";
            }
            dataGridView.Columns[UserTable.Columns.IndexOf("created_at")].ReadOnly = true;
            dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            String value;
            if (e.ColumnIndex == UserTable.Columns.IndexOf("password") && row.Cells[e.ColumnIndex].Value.GetType() != DBNull.Value.GetType())
            {
                value = (string)row.Cells[e.ColumnIndex].Value;
                row.Cells[UserTable.Columns.IndexOf("_password")].Value = Encoder.HashString(value);
            }

            if (e.ColumnIndex == UserTable.Columns.IndexOf("username") && row.Cells[e.ColumnIndex].Value != null)
            {
                value = (string)row.Cells[e.ColumnIndex].Value;
                row.Cells[UserTable.Columns.IndexOf("_username")].Value = Encoder.HashString(value);
            }
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index == 0)
            {
                MessageBox.Show("This user can not be deleted");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = (DialogResult.No == MessageBox.Show("Are you sure you want to delete " + e.Row.Cells[UserTable.Columns.IndexOf("fullname")] + "?", "Deleting user", MessageBoxButtons.YesNo));
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Cancel = true;
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            int idIndex = UserTable.Columns.IndexOf("id");
            dataGridView.Rows[e.Row.Index - 1].Cells[idIndex].Value = ((int)dataGridView.Rows[e.Row.Index - 2].Cells[idIndex].Value) + 1;
        }
    }
}
