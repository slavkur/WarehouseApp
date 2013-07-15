namespace WarehouseApp
{
    partial class LoadingListForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.loadingListEntries = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.truckTb = new System.Windows.Forms.TextBox();
            this.truckLbl = new System.Windows.Forms.Label();
            this.dataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.lLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLoadingList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoodsList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCustoms = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiT1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.tsmiSaveExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingListEntries)).BeginInit();
            this.loadingListEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.loadingListEntries);
            this.panel.Controls.Add(this.dataGridView);
            this.panel.Controls.Add(this.menuStrip);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.panel.Size = new System.Drawing.Size(692, 323);
            this.panel.TabIndex = 0;
            // 
            // loadingListEntries
            // 
            this.loadingListEntries.Controls.Add(this.pictureBox1);
            this.loadingListEntries.Controls.Add(this.truckTb);
            this.loadingListEntries.Controls.Add(this.truckLbl);
            this.loadingListEntries.Location = new System.Drawing.Point(51, 0);
            this.loadingListEntries.Name = "loadingListEntries";
            this.loadingListEntries.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.loadingListEntries.Size = new System.Drawing.Size(184, 22);
            this.loadingListEntries.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WarehouseApp.Properties.Resources.lorry;
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // truckTb
            // 
            this.truckTb.Location = new System.Drawing.Point(62, 2);
            this.truckTb.Name = "truckTb";
            this.truckTb.Size = new System.Drawing.Size(100, 20);
            this.truckTb.TabIndex = 7;
            this.truckTb.TextChanged += new System.EventHandler(this.truckTb_TextChanged);
            // 
            // truckLbl
            // 
            this.truckLbl.AutoSize = true;
            this.truckLbl.BackColor = System.Drawing.Color.Transparent;
            this.truckLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truckLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.truckLbl.Location = new System.Drawing.Point(21, 5);
            this.truckLbl.Name = "truckLbl";
            this.truckLbl.Size = new System.Drawing.Size(37, 13);
            this.truckLbl.TabIndex = 5;
            this.truckLbl.Text = "Truck:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.Location = new System.Drawing.Point(10, 24);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(670, 287);
            this.dataGridView.StateCommon.Background.Color1 = System.Drawing.Color.LightSteelBlue;
            this.dataGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lLToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(692, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // lLToolStripMenuItem
            // 
            this.lLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrint,
            this.tsmiPrintPreview,
            this.tsmiPdf,
            this.tsmiSaveExcel,
            this.toolStripSeparator1,
            this.tsmiLoadingList,
            this.tsmiGoodsList,
            this.tsmiCustoms,
            this.tsmiT1,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.lLToolStripMenuItem.Image = global::WarehouseApp.Properties.Resources.table;
            this.lLToolStripMenuItem.Name = "lLToolStripMenuItem";
            this.lLToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.lLToolStripMenuItem.Text = "&LL";
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Image = global::WarehouseApp.Properties.Resources.printer;
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPrint.Size = new System.Drawing.Size(152, 22);
            this.tsmiPrint.Text = "&Print";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiPrintPreview
            // 
            this.tsmiPrintPreview.Image = global::WarehouseApp.Properties.Resources.page_white_magnify;
            this.tsmiPrintPreview.Name = "tsmiPrintPreview";
            this.tsmiPrintPreview.Size = new System.Drawing.Size(152, 22);
            this.tsmiPrintPreview.Text = "Print Pre&view";
            this.tsmiPrintPreview.Click += new System.EventHandler(this.tsmiPrintPreview_Click);
            // 
            // tsmiPdf
            // 
            this.tsmiPdf.Image = global::WarehouseApp.Properties.Resources.page_white_acrobat;
            this.tsmiPdf.Name = "tsmiPdf";
            this.tsmiPdf.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiPdf.Size = new System.Drawing.Size(152, 22);
            this.tsmiPdf.Text = "PDF";
            this.tsmiPdf.Click += new System.EventHandler(this.tsmiPdf_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiLoadingList
            // 
            this.tsmiLoadingList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiLoadingList.Image = global::WarehouseApp.Properties.Resources.table;
            this.tsmiLoadingList.Name = "tsmiLoadingList";
            this.tsmiLoadingList.Size = new System.Drawing.Size(152, 22);
            this.tsmiLoadingList.Text = "Loading List";
            this.tsmiLoadingList.Click += new System.EventHandler(this.tsmiLoadingList_Click);
            // 
            // tsmiGoodsList
            // 
            this.tsmiGoodsList.Image = global::WarehouseApp.Properties.Resources.table;
            this.tsmiGoodsList.Name = "tsmiGoodsList";
            this.tsmiGoodsList.Size = new System.Drawing.Size(152, 22);
            this.tsmiGoodsList.Text = "Goods List";
            this.tsmiGoodsList.Click += new System.EventHandler(this.tsmiGoodsList_Click);
            // 
            // tsmiCustoms
            // 
            this.tsmiCustoms.Image = global::WarehouseApp.Properties.Resources.table;
            this.tsmiCustoms.Name = "tsmiCustoms";
            this.tsmiCustoms.Size = new System.Drawing.Size(152, 22);
            this.tsmiCustoms.Text = "Customs List";
            this.tsmiCustoms.Click += new System.EventHandler(this.tsmiCustoms_Click);
            // 
            // tsmiT1
            // 
            this.tsmiT1.Image = global::WarehouseApp.Properties.Resources.table;
            this.tsmiT1.Name = "tsmiT1";
            this.tsmiT1.Size = new System.Drawing.Size(152, 22);
            this.tsmiT1.Text = "T1 List";
            this.tsmiT1.Click += new System.EventHandler(this.tsmiT1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // tsmiSaveExcel
            // 
            this.tsmiSaveExcel.Image = global::WarehouseApp.Properties.Resources.page_white_excel;
            this.tsmiSaveExcel.Name = "tsmiSaveExcel";
            this.tsmiSaveExcel.Size = new System.Drawing.Size(152, 22);
            this.tsmiSaveExcel.Text = "&Save to Excel";
            this.tsmiSaveExcel.Click += new System.EventHandler(this.tsmiSaveExcel_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xls";
            this.saveFileDialog.Filter = "xls files (*xls) | *xls";
            // 
            // LoadingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 323);
            this.Controls.Add(this.panel);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "LoadingListForm";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.Text = "LL ?";
            this.Load += new System.EventHandler(this.LoadingListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingListEntries)).EndInit();
            this.loadingListEntries.ResumeLayout(false);
            this.loadingListEntries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel panel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Drawing.Printing.PrintDocument printDocument;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem lLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmiPdf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel loadingListEntries;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox truckTb;
        private System.Windows.Forms.Label truckLbl;
        private System.Windows.Forms.ToolStripMenuItem tsmiCustoms;
        private System.Windows.Forms.ToolStripMenuItem tsmiGoodsList;
        private System.Windows.Forms.ToolStripMenuItem tsmiT1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadingList;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}