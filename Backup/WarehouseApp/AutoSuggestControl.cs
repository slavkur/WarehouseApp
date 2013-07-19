using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class AutoSuggestControl : UserControl
    {
        private DataSet dataSet;
        private String tableName;
        private OleDbConnection conn;
        private TextBox[] textBoxes;

        public AutoSuggestControl(OleDbConnection conn, String tableName, TextBox[] textBoxes)
        {
            Visible = false;
            this.conn = conn;
            this.dataSet = new DataSet();
            this.InitializeComponent();
            this.textBoxes = textBoxes;
            this.tableName = tableName;
            foreach (TextBox textBox in textBoxes)
            {
                textBox.TextChanged += new EventHandler(tb_TextChanged);
                textBox.KeyDown += new KeyEventHandler(tb_KeyUpDown);
                textBox.KeyUp += new KeyEventHandler(tb_KeyUpDown);
            }
            this.klbSuggest.Items.Clear();
        }

        private void klbSuggest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String value = klbSuggest.Items[klbSuggest.SelectedIndex].ToString();
                TextBox field = (TextBox)klbSuggest.Tag;
                field.Tag = value;
                field.Text = value;
                Hide();
            }
        }

        private void tb_KeyUpDown(object sender, KeyEventArgs e)
        {
            if (klbSuggest.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Down)
                {
                    klbSuggest.Focus();
                    if (klbSuggest.Items.Count > 0)
                        klbSuggest.SetSelected(1, true);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    klbSuggest_KeyUp(klbSuggest, new KeyEventArgs(Keys.Enter));
                }
                if (e.KeyCode == Keys.Escape)
                {
                    Hide();
                }
            }
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adapter;
            DataTable table;
            String[] values;
            int i = 0;
            TextBox field = (TextBox)sender;

            Width = field.Width;
            Height = field.Height * 2;
            Location = new Point(field.Location.X, field.Location.Y + field.Height - 3);
            klbSuggest.Tag = field;
            klbSuggest.TabIndex = field.TabIndex++;

            adapter = new OleDbDataAdapter("Select [value] from " + tableName + " where field like @field and [value] like '%" + field.Text.Replace("'", "''") + "%' group by [value]", conn);
            adapter.SelectCommand.Parameters.Add("@field", OleDbType.VarWChar).Value = field.Name;
            dataSet.Clear();
            adapter.Fill(dataSet, tableName + "_" + field.Name);
            table = dataSet.Tables[tableName + "_" + field.Name];

            values = new String[table.Rows.Count];
            foreach (DataRow row in table.Rows)
            {
                values[i++] = row.ItemArray[0].ToString();
            }

            klbSuggest.Items.Clear();
            if (Visible = (values.Length > 0 && field.Text.Length > 0))
            {
                klbSuggest.Items.AddRange(values);
                klbSuggest.SetSelected(0, true);
            }
            conn.Close();
        }

        private bool isDirty(TextBox textBox)
        {
            if (textBox.Tag == null) return true;
            return !textBox.Text.Equals(textBox.Tag.ToString());
        }

        public void saveFields()
        {
            conn.Open();
            foreach (TextBox box in textBoxes)
            {
                if (isDirty(box) && box.Text.Length > 0)
                {
                    OleDbCommand command = new OleDbCommand("insert into " + tableName + " (field, [value]) values ('" + box.Name + "','" + box.Text.Replace("'", "''") + "')", conn);
                    command.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
    }
}
