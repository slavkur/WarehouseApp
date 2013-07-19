namespace WarehouseApp
{
    partial class InvoiceForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cbTax = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpInvoiceDue = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpInvoice = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.tbBankDetails = new System.Windows.Forms.TextBox();
            this.cmsInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makeDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCompanyInfo = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.tbSummary = new System.Windows.Forms.TextBox();
            this.tbReceiver = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.totalNetLbl = new System.Windows.Forms.Label();
            this.totalTextLbl = new System.Windows.Forms.Label();
            this.vatTextLbl = new System.Windows.Forms.Label();
            this.invoiceNumberTextLbl = new System.Windows.Forms.Label();
            this.invoiceDueDateTextLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.invoiceDateTextLbl = new System.Windows.Forms.Label();
            this.totalNetTextLbl = new System.Windows.Forms.Label();
            this.dataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileAttacher = new WarehouseApp.FileAttacher();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.cmsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cbTax);
            this.kryptonPanel1.Controls.Add(this.dtpInvoiceDue);
            this.kryptonPanel1.Controls.Add(this.dtpInvoice);
            this.kryptonPanel1.Controls.Add(this.tbBankDetails);
            this.kryptonPanel1.Controls.Add(this.tbCompanyInfo);
            this.kryptonPanel1.Controls.Add(this.tbAddress);
            this.kryptonPanel1.Controls.Add(this.tbInvoiceNumber);
            this.kryptonPanel1.Controls.Add(this.tbSummary);
            this.kryptonPanel1.Controls.Add(this.tbReceiver);
            this.kryptonPanel1.Controls.Add(this.lblTotal);
            this.kryptonPanel1.Controls.Add(this.lblVat);
            this.kryptonPanel1.Controls.Add(this.totalNetLbl);
            this.kryptonPanel1.Controls.Add(this.totalTextLbl);
            this.kryptonPanel1.Controls.Add(this.vatTextLbl);
            this.kryptonPanel1.Controls.Add(this.invoiceNumberTextLbl);
            this.kryptonPanel1.Controls.Add(this.invoiceDueDateTextLbl);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.invoiceDateTextLbl);
            this.kryptonPanel1.Controls.Add(this.totalNetTextLbl);
            this.kryptonPanel1.Controls.Add(this.dataGridView);
            this.kryptonPanel1.Controls.Add(this.menuStrip);
            this.kryptonPanel1.Controls.Add(this.fileAttacher);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(672, 636);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cbTax
            // 
            this.cbTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTax.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.cbTax.Location = new System.Drawing.Point(559, 347);
            this.cbTax.Name = "cbTax";
            this.cbTax.Size = new System.Drawing.Size(101, 19);
            this.cbTax.TabIndex = 7;
            this.cbTax.Tag = "23,00";
            this.cbTax.Text = "Finnish tax 23%";
            this.cbTax.Values.Text = "Finnish tax 23%";
            this.cbTax.CheckedChanged += new System.EventHandler(this.cbTax_CheckedChanged);
            // 
            // dtpInvoiceDue
            // 
            this.dtpInvoiceDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoiceDue.CalendarTodayFormat = "dd.MM.yyyy";
            this.dtpInvoiceDue.CustomFormat = "dd.MM.yyyy";
            this.dtpInvoiceDue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDue.Location = new System.Drawing.Point(457, 291);
            this.dtpInvoiceDue.Name = "dtpInvoiceDue";
            this.dtpInvoiceDue.Size = new System.Drawing.Size(100, 20);
            this.dtpInvoiceDue.TabIndex = 6;
            this.dtpInvoiceDue.ValueNullable = new System.DateTime(2010, 5, 21, 18, 46, 0, 0);
            this.dtpInvoiceDue.ValueChanged += new System.EventHandler(this.invoiceDueDtp_ValueChanged);
            // 
            // dtpInvoice
            // 
            this.dtpInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoice.CalendarTodayFormat = "dd.MM.yyyy";
            this.dtpInvoice.CustomFormat = "dd.MM.yyyy";
            this.dtpInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoice.Location = new System.Drawing.Point(347, 291);
            this.dtpInvoice.Name = "dtpInvoice";
            this.dtpInvoice.Size = new System.Drawing.Size(100, 20);
            this.dtpInvoice.TabIndex = 6;
            this.dtpInvoice.ValueChanged += new System.EventHandler(this.invoiceDtp_ValueChanged);
            // 
            // tbBankDetails
            // 
            this.tbBankDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBankDetails.ContextMenuStrip = this.cmsInfo;
            this.tbBankDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbBankDetails.Location = new System.Drawing.Point(344, 201);
            this.tbBankDetails.Multiline = true;
            this.tbBankDetails.Name = "tbBankDetails";
            this.tbBankDetails.Size = new System.Drawing.Size(316, 65);
            this.tbBankDetails.TabIndex = 5;
            this.tbBankDetails.Tag = "bank_details";
            this.tbBankDetails.Text = "Sampo Bank                       SWIFT: PSPBFIHH\r\nAcc.: 800013-70796360    IBAN: " +
                "FIN2580001370796360";
            // 
            // cmsInfo
            // 
            this.cmsInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmsInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeDefaultToolStripMenuItem});
            this.cmsInfo.Name = "cmsInfo";
            this.cmsInfo.Size = new System.Drawing.Size(145, 26);
            // 
            // makeDefaultToolStripMenuItem
            // 
            this.makeDefaultToolStripMenuItem.Image = global::WarehouseApp.Properties.Resources.table;
            this.makeDefaultToolStripMenuItem.Name = "makeDefaultToolStripMenuItem";
            this.makeDefaultToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.makeDefaultToolStripMenuItem.Text = "Set as default";
            this.makeDefaultToolStripMenuItem.Click += new System.EventHandler(this.makeDefaultToolStripMenuItem_Click);
            // 
            // tbCompanyInfo
            // 
            this.tbCompanyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCompanyInfo.ContextMenuStrip = this.cmsInfo;
            this.tbCompanyInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbCompanyInfo.Location = new System.Drawing.Point(344, 47);
            this.tbCompanyInfo.Multiline = true;
            this.tbCompanyInfo.Name = "tbCompanyInfo";
            this.tbCompanyInfo.Size = new System.Drawing.Size(316, 40);
            this.tbCompanyInfo.TabIndex = 5;
            this.tbCompanyInfo.Tag = "company_info";
            this.tbCompanyInfo.Text = "Custom Consulting & Service Oy\r\nY-tunnus 1702409-2";
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress.ContextMenuStrip = this.cmsInfo;
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbAddress.Location = new System.Drawing.Point(344, 90);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(316, 109);
            this.tbAddress.TabIndex = 5;
            this.tbAddress.Tag = "address";
            this.tbAddress.Text = resources.GetString("tbAddress.Text");
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInvoiceNumber.Location = new System.Drawing.Point(347, 337);
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.ReadOnly = true;
            this.tbInvoiceNumber.Size = new System.Drawing.Size(94, 22);
            this.tbInvoiceNumber.TabIndex = 5;
            this.tbInvoiceNumber.Text = "V20100001";
            // 
            // tbSummary
            // 
            this.tbSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSummary.Location = new System.Drawing.Point(10, 308);
            this.tbSummary.Multiline = true;
            this.tbSummary.Name = "tbSummary";
            this.tbSummary.Size = new System.Drawing.Size(233, 51);
            this.tbSummary.TabIndex = 5;
            this.tbSummary.Text = "REV 112\r\n3cll/12Kg/0.2m3\r\nWeifang";
            // 
            // tbReceiver
            // 
            this.tbReceiver.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbReceiver.Location = new System.Drawing.Point(10, 47);
            this.tbReceiver.Multiline = true;
            this.tbReceiver.Name = "tbReceiver";
            this.tbReceiver.Size = new System.Drawing.Size(233, 152);
            this.tbReceiver.TabIndex = 5;
            this.tbReceiver.Text = "CCS OY\r\nVANHA PORVOONTIE 231 A\r\n03180 VANTAA\r\nFINLAND";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(510, 587);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(150, 16);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVat
            // 
            this.lblVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVat.BackColor = System.Drawing.Color.Transparent;
            this.lblVat.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVat.Location = new System.Drawing.Point(510, 567);
            this.lblVat.Name = "lblVat";
            this.lblVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVat.Size = new System.Drawing.Size(150, 16);
            this.lblVat.TabIndex = 3;
            this.lblVat.Tag = "0,00";
            this.lblVat.Text = "0,00";
            this.lblVat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblVat.TextChanged += new System.EventHandler(this.lblVat_TextChanged);
            // 
            // totalNetLbl
            // 
            this.totalNetLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalNetLbl.BackColor = System.Drawing.Color.Transparent;
            this.totalNetLbl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNetLbl.Location = new System.Drawing.Point(510, 548);
            this.totalNetLbl.Name = "totalNetLbl";
            this.totalNetLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.totalNetLbl.Size = new System.Drawing.Size(150, 16);
            this.totalNetLbl.TabIndex = 3;
            this.totalNetLbl.Text = "0,00";
            this.totalNetLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalTextLbl
            // 
            this.totalTextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTextLbl.AutoSize = true;
            this.totalTextLbl.BackColor = System.Drawing.Color.Transparent;
            this.totalTextLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextLbl.Location = new System.Drawing.Point(400, 589);
            this.totalTextLbl.Name = "totalTextLbl";
            this.totalTextLbl.Size = new System.Drawing.Size(60, 13);
            this.totalTextLbl.TabIndex = 2;
            this.totalTextLbl.Text = "Total EUR:";
            // 
            // vatTextLbl
            // 
            this.vatTextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vatTextLbl.AutoSize = true;
            this.vatTextLbl.BackColor = System.Drawing.Color.Transparent;
            this.vatTextLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vatTextLbl.Location = new System.Drawing.Point(400, 568);
            this.vatTextLbl.Name = "vatTextLbl";
            this.vatTextLbl.Size = new System.Drawing.Size(31, 13);
            this.vatTextLbl.TabIndex = 2;
            this.vatTextLbl.Text = "VAT:";
            // 
            // invoiceNumberTextLbl
            // 
            this.invoiceNumberTextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceNumberTextLbl.AutoSize = true;
            this.invoiceNumberTextLbl.BackColor = System.Drawing.Color.Transparent;
            this.invoiceNumberTextLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceNumberTextLbl.Location = new System.Drawing.Point(347, 321);
            this.invoiceNumberTextLbl.Name = "invoiceNumberTextLbl";
            this.invoiceNumberTextLbl.Size = new System.Drawing.Size(93, 13);
            this.invoiceNumberTextLbl.TabIndex = 2;
            this.invoiceNumberTextLbl.Text = "Invoice Number:";
            // 
            // invoiceDueDateTextLbl
            // 
            this.invoiceDueDateTextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceDueDateTextLbl.AutoSize = true;
            this.invoiceDueDateTextLbl.BackColor = System.Drawing.Color.Transparent;
            this.invoiceDueDateTextLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceDueDateTextLbl.Location = new System.Drawing.Point(457, 275);
            this.invoiceDueDateTextLbl.Name = "invoiceDueDateTextLbl";
            this.invoiceDueDateTextLbl.Size = new System.Drawing.Size(58, 13);
            this.invoiceDueDateTextLbl.TabIndex = 2;
            this.invoiceDueDateTextLbl.Text = "Due Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Receiver:";
            // 
            // invoiceDateTextLbl
            // 
            this.invoiceDateTextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceDateTextLbl.AutoSize = true;
            this.invoiceDateTextLbl.BackColor = System.Drawing.Color.Transparent;
            this.invoiceDateTextLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceDateTextLbl.Location = new System.Drawing.Point(347, 275);
            this.invoiceDateTextLbl.Name = "invoiceDateTextLbl";
            this.invoiceDateTextLbl.Size = new System.Drawing.Size(74, 13);
            this.invoiceDateTextLbl.TabIndex = 2;
            this.invoiceDateTextLbl.Text = "Invoice Date:";
            // 
            // totalNetTextLbl
            // 
            this.totalNetTextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalNetTextLbl.AutoSize = true;
            this.totalNetTextLbl.BackColor = System.Drawing.Color.Transparent;
            this.totalNetTextLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNetTextLbl.Location = new System.Drawing.Point(400, 548);
            this.totalNetTextLbl.Name = "totalNetTextLbl";
            this.totalNetTextLbl.Size = new System.Drawing.Size(104, 13);
            this.totalNetTextLbl.TabIndex = 2;
            this.totalNetTextLbl.Text = "Total Net Amount:";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.Location = new System.Drawing.Point(10, 372);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(650, 166);
            this.dataGridView.StateCommon.Background.Color1 = System.Drawing.Color.LightSteelBlue;
            this.dataGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dataGridView.TabIndex = 0;
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserDeletedRow);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(672, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.tsmiSave,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::WarehouseApp.Properties.Resources.application_form;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.fileToolStripMenuItem.Text = "&Invoice";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::WarehouseApp.Properties.Resources.printer;
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = global::WarehouseApp.Properties.Resources.page_white_magnify;
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Image = global::WarehouseApp.Properties.Resources.page_white_acrobat;
            this.tsmiSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(140, 22);
            this.tsmiSave.Text = "&PDF";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileAttacher1
            // 
            this.fileAttacher.BackColor = System.Drawing.Color.Transparent;
            this.fileAttacher.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileAttacher.Location = new System.Drawing.Point(0, 603);
            this.fileAttacher.MinimumSize = new System.Drawing.Size(128, 33);
            this.fileAttacher.Name = "fileAttacher1";
            this.fileAttacher.Size = new System.Drawing.Size(672, 33);
            this.fileAttacher.TabIndex = 8;
            this.fileAttacher.AttachFile += new WarehouseApp.FileAttacher.Event(this.fileAttacher_AttachFile);
            this.fileAttacher.RemoveFile += new FileAttacher.Event(this.fileAttacher_RemoveFile);
            this.fileAttacher.Resize += new System.EventHandler(this.fileAttacher_Resize);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 636);
            this.Controls.Add(this.kryptonPanel1);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(680, 640);
            this.Name = "InvoiceForm";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InvoiceForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.cmsInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Label totalNetLbl;
        private System.Windows.Forms.Label totalTextLbl;
        private System.Windows.Forms.Label vatTextLbl;
        private System.Windows.Forms.Label totalNetTextLbl;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox tbReceiver;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbBankDetails;
        private System.Windows.Forms.TextBox tbCompanyInfo;
        private System.Windows.Forms.TextBox tbSummary;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.Label invoiceNumberTextLbl;
        private System.Windows.Forms.Label invoiceDueDateTextLbl;
        private System.Windows.Forms.Label invoiceDateTextLbl;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpInvoice;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpInvoiceDue;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbTax;
        private System.Windows.Forms.ContextMenuStrip cmsInfo;
        private System.Windows.Forms.ToolStripMenuItem makeDefaultToolStripMenuItem;
        private FileAttacher fileAttacher;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}