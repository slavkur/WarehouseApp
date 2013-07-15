namespace WarehouseApp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private LoginControl loginControl;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginControl = new WarehouseApp.LoginControl();
            this.AcceptButton = this.loginControl.BtnLogin;
            this.chbEdit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // loginControl
            // 
            this.loginControl.Location = new System.Drawing.Point(0, 0);
            this.loginControl.Name = "loginControl";
            this.loginControl.Size = new System.Drawing.Size(380, 262);
            this.loginControl.TabIndex = 0;
            this.loginControl.ActivateEdit += new System.EventHandler(this.ActivateEdit);
            this.loginControl.CheckCredentials += new System.EventHandler(this.loginControl_CheckCredentials);
            this.loginControl.Successful += new System.EventHandler(this.Successful);
            this.loginControl.Failed += new System.EventHandler(this.Failed);
            // 
            // chbEdit
            // 
            this.chbEdit.AutoSize = true;
            this.chbEdit.Enabled = false;
            this.chbEdit.Location = new System.Drawing.Point(124, 188);
            this.chbEdit.Name = "chbEdit";
            this.chbEdit.Size = new System.Drawing.Size(72, 17);
            this.chbEdit.TabIndex = 1;
            this.chbEdit.Text = "Edit users";
            this.chbEdit.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 253);
            this.Controls.Add(this.chbEdit);
            this.Controls.Add(this.loginControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 280);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbEdit;
    }
}