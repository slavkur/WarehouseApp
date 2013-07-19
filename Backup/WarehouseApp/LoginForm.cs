using System.Windows.Forms;
using System.Data.OleDb;

namespace WarehouseApp
{
    public partial class LoginForm : Form
    {
        private OleDbConnection conn;
        private OleDbCommand loginCommand;
        private OleDbCommand adminCommand;

        private void loginControl_CheckCredentials(object sender, System.EventArgs args)
        {
            conn.Open();
            loginCommand.Parameters.Clear();
            loginCommand.Parameters.Add("@username", OleDbType.VarWChar).Value = loginControl.InputUsernameHash;
            loginCommand.Parameters.Add("@password", OleDbType.VarWChar).Value = loginControl.InputPasswordHash;
            object blocked = loginCommand.ExecuteScalar();
            if (blocked != null && (bool)blocked == false)
            {
                loginControl.UsernameHash = loginControl.InputUsernameHash;
                loginControl.PasswordHash = loginControl.InputPasswordHash;
            }
            conn.Close();
        }

        private void Failed(object sender, System.EventArgs args)
        {
        }

        private void Successful(object sender, System.EventArgs args)
        {
            if (chbEdit.Checked && chbEdit.Enabled)
            {
                new EditUsers().ShowDialog();
            }
            else
            {
                Hide();
                new MainWindow().Show();
            }
        }

        private void ActivateEdit(object sender, System.EventArgs args)
        {
            conn.Open();
            adminCommand.Parameters.Clear();
            adminCommand.Parameters.Add("@username", OleDbType.VarWChar).Value = loginControl.InputUsernameHash;
            object blocked = adminCommand.ExecuteScalar();
            chbEdit.Enabled = (blocked != null && (bool)blocked == false);
            conn.Close();
        }

        public LoginForm()
        {
            InitializeComponent();
            this.conn = new OleDbConnection(Program.connectionString);

            //conn.Open();
            //OleDbCommand create = new OleDbCommand("Create table tblTest (test_id Integer Not Null)", conn);
            //create.ExecuteNonQuery();
            //create = new OleDbCommand("Alter table tblTest Add Column Notes Text(50) Not Null", conn);
            //create.ExecuteNonQuery();
            //conn.Close();

            //Version vrs = new Version(Application.ProductVersion);
            //MessageBox.Show(Application.ProductVersion + "\r\nMajor: " + vrs.Major + "\r\nMinor: " + vrs.Minor + "\r\nBuild: " + vrs.Build + "\r\nRevision: " + vrs.Revision);
            adminCommand = new OleDbCommand("Select blocked from [User] where admin = True and username like @username;", conn);
            loginCommand = new OleDbCommand("Select blocked from [User] where username like @username and password like @password;", conn);

            //throw new Exception("test exception");
        }
    }
}
