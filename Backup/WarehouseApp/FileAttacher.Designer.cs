namespace WarehouseApp
{
    partial class FileAttacher
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
            this.components = new System.ComponentModel.Container();
            this.btnAttach = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFileExample = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(8, 3);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(35, 25);
            this.btnAttach.TabIndex = 13;
            this.btnAttach.Values.Image = global::WarehouseApp.Properties.Resources.attach;
            this.btnAttach.Values.Text = "";
            // 
            // btnFileExample
            // 
            this.btnFileExample.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom1;
            this.btnFileExample.Location = new System.Drawing.Point(48, 3);
            this.btnFileExample.Name = "btnFileExample";
            this.btnFileExample.OverrideDefault.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnFileExample.OverrideDefault.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnFileExample.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFileExample.Size = new System.Drawing.Size(78, 25);
            this.btnFileExample.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnFileExample.StateNormal.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnFileExample.StateNormal.Border.Color1 = System.Drawing.Color.Transparent;
            this.btnFileExample.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFileExample.TabIndex = 10;
            this.btnFileExample.Values.Image = global::WarehouseApp.Properties.Resources.page_attach;
            this.btnFileExample.Values.Text = "file.txt";
            this.btnFileExample.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnFileExample);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(128, 31);
            this.flowLayoutPanel1.TabIndex = 12;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 26);
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Image = global::WarehouseApp.Properties.Resources.cross;
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(114, 22);
            this.tsmiRemove.Text = "Remove";
            // 
            // FileAttacher
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(128, 33);
            this.Name = "FileAttacher";
            this.Size = new System.Drawing.Size(128, 33);
            this.Load += new System.EventHandler(this.FileAttacher_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAttach;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton btnFileExample;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemove;

    }
}
