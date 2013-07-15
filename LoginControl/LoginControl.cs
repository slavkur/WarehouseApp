using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class LoginControl : UserControl
    {
        public string UsernameHash = null;
        public string PasswordHash = null;
        public event System.EventHandler Successful;
        public event System.EventHandler Failed;
        public event System.EventHandler CheckCredentials;
        public event System.EventHandler ActivateEdit;

        public LoginControl()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '\u25CF';
        }

        public string InputUsernameHash
        {
            get
            {
                return Encoder.HashString(tbUsername.Text);
            }

        }

        public string InputPasswordHash
        {
            get
            {
                return Encoder.HashString(tbPassword.Text);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckCredentials(this, new System.EventArgs());
            if (InputUsernameHash == UsernameHash && InputPasswordHash == PasswordHash)
            {
                Successful(this, new System.EventArgs());
            }
            else
            {
                Failed(this, new System.EventArgs());
                errorProvider.SetError(btnLogin, "wrong username or password");
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            ActivateEdit(sender, e);
        }
    }
}
