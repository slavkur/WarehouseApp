namespace WarehouseApp
{
    partial class AutoSuggestControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.klbSuggest = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.SuspendLayout();
            // 
            // klbSuggest
            // 
            this.klbSuggest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klbSuggest.Items.AddRange(new object[] {
            "1",
            "2"});
            this.klbSuggest.Location = new System.Drawing.Point(0, 0);
            this.klbSuggest.Name = "klbSuggest";
            this.klbSuggest.Size = new System.Drawing.Size(120, 47);
            this.klbSuggest.StateActive.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.klbSuggest.StateActive.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounded;
            this.klbSuggest.TabIndex = 3;
            this.klbSuggest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.klbSuggest_KeyUp);
            // 
            // AutoSuggestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.klbSuggest);
            this.Name = "AutoSuggestControl";
            this.Size = new System.Drawing.Size(120, 47);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox klbSuggest;
    }
}
