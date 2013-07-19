namespace WarehouseApp
{
    partial class TitlePageForm
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
            this.cbStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.dtpArrival = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.tbCodes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbDamage = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbDocuments = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbComments = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbDescription = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbSituation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbManager = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbCcs = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbBookingNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbWhNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbPkgs = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbKg = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbM3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbConsignor = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbConsignee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbWhPlace = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbContainer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbCcs = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbWarehouse = new System.Windows.Forms.Label();
            this.lbBooking = new System.Windows.Forms.Label();
            this.lbConsignee = new System.Windows.Forms.Label();
            this.lbContainer = new System.Windows.Forms.Label();
            this.lbWhPlace = new System.Windows.Forms.Label();
            this.lbCodes = new System.Windows.Forms.Label();
            this.lbDamage = new System.Windows.Forms.Label();
            this.lbSituation = new System.Windows.Forms.Label();
            this.lbDocuments = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbConsignor = new System.Windows.Forms.Label();
            this.lbManager = new System.Windows.Forms.Label();
            this.lbArrival = new System.Windows.Forms.Label();
            this.lbComments = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ms = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus)).BeginInit();
            this.ms.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cbStatus);
            this.panel.Controls.Add(this.dtpArrival);
            this.panel.Controls.Add(this.tbCodes);
            this.panel.Controls.Add(this.tbDamage);
            this.panel.Controls.Add(this.tbDocuments);
            this.panel.Controls.Add(this.tbComments);
            this.panel.Controls.Add(this.tbDescription);
            this.panel.Controls.Add(this.tbSituation);
            this.panel.Controls.Add(this.tbManager);
            this.panel.Controls.Add(this.tbCcs);
            this.panel.Controls.Add(this.tbBookingNumber);
            this.panel.Controls.Add(this.tbWhNumber);
            this.panel.Controls.Add(this.tbPkgs);
            this.panel.Controls.Add(this.tbKg);
            this.panel.Controls.Add(this.tbM3);
            this.panel.Controls.Add(this.tbConsignor);
            this.panel.Controls.Add(this.tbConsignee);
            this.panel.Controls.Add(this.tbWhPlace);
            this.panel.Controls.Add(this.tbContainer);
            this.panel.Controls.Add(this.lbCcs);
            this.panel.Controls.Add(this.lbStatus);
            this.panel.Controls.Add(this.lbWarehouse);
            this.panel.Controls.Add(this.lbBooking);
            this.panel.Controls.Add(this.lbConsignee);
            this.panel.Controls.Add(this.lbContainer);
            this.panel.Controls.Add(this.lbWhPlace);
            this.panel.Controls.Add(this.lbCodes);
            this.panel.Controls.Add(this.lbDamage);
            this.panel.Controls.Add(this.lbSituation);
            this.panel.Controls.Add(this.lbDocuments);
            this.panel.Controls.Add(this.lbDescription);
            this.panel.Controls.Add(this.lbConsignor);
            this.panel.Controls.Add(this.lbManager);
            this.panel.Controls.Add(this.lbArrival);
            this.panel.Controls.Add(this.lbComments);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.ms);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(672, 723);
            this.panel.TabIndex = 0;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownWidth = 66;
            this.cbStatus.Items.AddRange(new object[] {
            "C",
            "T1"});
            this.cbStatus.Location = new System.Drawing.Point(510, 161);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(66, 29);
            this.cbStatus.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.TabIndex = 7;
            // 
            // dtpArrival
            // 
            this.dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpArrival.Location = new System.Drawing.Point(20, 163);
            this.dtpArrival.Name = "dtpArrival";
            this.dtpArrival.Size = new System.Drawing.Size(153, 27);
            this.dtpArrival.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpArrival.TabIndex = 6;
            // 
            // tbCodes
            // 
            this.tbCodes.Location = new System.Drawing.Point(20, 592);
            this.tbCodes.Multiline = true;
            this.tbCodes.Name = "tbCodes";
            this.tbCodes.Size = new System.Drawing.Size(633, 65);
            this.tbCodes.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodes.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2);
            this.tbCodes.TabIndex = 5;
            this.tbCodes.Text = "919019, 289128, 23413\r\n289128, 23413\r\n289128\r\n";
            // 
            // tbDamage
            // 
            this.tbDamage.Location = new System.Drawing.Point(20, 501);
            this.tbDamage.Multiline = true;
            this.tbDamage.Name = "tbDamage";
            this.tbDamage.Size = new System.Drawing.Size(311, 65);
            this.tbDamage.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDamage.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2);
            this.tbDamage.TabIndex = 5;
            this.tbDamage.Text = "1cll damaged\r\n1\r\n1";
            // 
            // tbDocuments
            // 
            this.tbDocuments.Location = new System.Drawing.Point(20, 410);
            this.tbDocuments.Multiline = true;
            this.tbDocuments.Name = "tbDocuments";
            this.tbDocuments.Size = new System.Drawing.Size(311, 65);
            this.tbDocuments.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDocuments.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2);
            this.tbDocuments.TabIndex = 5;
            this.tbDocuments.Text = "Waiting\r\n1\r\n1";
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(345, 319);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(307, 247);
            this.tbComments.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComments.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2);
            this.tbComments.TabIndex = 5;
            this.tbComments.Text = "RV890/REU890/1675\r\n20.15cll/56.19kg/70.88m3";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(20, 319);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(311, 65);
            this.tbDescription.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2);
            this.tbDescription.TabIndex = 5;
            this.tbDescription.Text = "rare  packages\r\n1\r\n1";
            // 
            // tbSituation
            // 
            this.tbSituation.Location = new System.Drawing.Point(20, 265);
            this.tbSituation.Name = "tbSituation";
            this.tbSituation.Size = new System.Drawing.Size(311, 29);
            this.tbSituation.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSituation.TabIndex = 5;
            this.tbSituation.Text = "Waiting";
            // 
            // tbManager
            // 
            this.tbManager.Location = new System.Drawing.Point(20, 214);
            this.tbManager.Name = "tbManager";
            this.tbManager.Size = new System.Drawing.Size(311, 29);
            this.tbManager.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbManager.TabIndex = 5;
            this.tbManager.Text = "Morozova Anna";
            // 
            // tbCcs
            // 
            this.tbCcs.Enabled = false;
            this.tbCcs.Location = new System.Drawing.Point(345, 161);
            this.tbCcs.Name = "tbCcs";
            this.tbCcs.Size = new System.Drawing.Size(138, 29);
            this.tbCcs.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCcs.TabIndex = 5;
            this.tbCcs.Text = "270410-0011";
            // 
            // tbBookingNumber
            // 
            this.tbBookingNumber.Location = new System.Drawing.Point(304, 43);
            this.tbBookingNumber.Name = "tbBookingNumber";
            this.tbBookingNumber.Size = new System.Drawing.Size(141, 52);
            this.tbBookingNumber.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBookingNumber.TabIndex = 5;
            this.tbBookingNumber.Text = "1675";
            // 
            // tbWhNumber
            // 
            this.tbWhNumber.Location = new System.Drawing.Point(20, 43);
            this.tbWhNumber.Name = "tbWhNumber";
            this.tbWhNumber.Size = new System.Drawing.Size(278, 52);
            this.tbWhNumber.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWhNumber.TabIndex = 5;
            this.tbWhNumber.Text = "RV890/REU890";
            // 
            // tbPkgs
            // 
            this.tbPkgs.Location = new System.Drawing.Point(21, 102);
            this.tbPkgs.Name = "tbPkgs";
            this.tbPkgs.Size = new System.Drawing.Size(100, 37);
            this.tbPkgs.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPkgs.TabIndex = 5;
            this.tbPkgs.Text = "20.15";
            // 
            // tbKg
            // 
            this.tbKg.Location = new System.Drawing.Point(189, 102);
            this.tbKg.Name = "tbKg";
            this.tbKg.Size = new System.Drawing.Size(109, 37);
            this.tbKg.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKg.TabIndex = 5;
            this.tbKg.Text = "15.19";
            // 
            // tbM3
            // 
            this.tbM3.Location = new System.Drawing.Point(345, 101);
            this.tbM3.Name = "tbM3";
            this.tbM3.Size = new System.Drawing.Size(100, 37);
            this.tbM3.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbM3.TabIndex = 5;
            this.tbM3.Text = "70.83";
            // 
            // tbConsignor
            // 
            this.tbConsignor.Location = new System.Drawing.Point(345, 214);
            this.tbConsignor.Name = "tbConsignor";
            this.tbConsignor.Size = new System.Drawing.Size(307, 29);
            this.tbConsignor.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsignor.TabIndex = 5;
            this.tbConsignor.Text = "VEREDUS";
            // 
            // tbConsignee
            // 
            this.tbConsignee.Location = new System.Drawing.Point(345, 267);
            this.tbConsignee.Name = "tbConsignee";
            this.tbConsignee.Size = new System.Drawing.Size(307, 29);
            this.tbConsignee.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsignee.TabIndex = 5;
            this.tbConsignee.Text = "VENTA";
            // 
            // tbWhPlace
            // 
            this.tbWhPlace.Location = new System.Drawing.Point(20, 682);
            this.tbWhPlace.Name = "tbWhPlace";
            this.tbWhPlace.Size = new System.Drawing.Size(311, 29);
            this.tbWhPlace.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWhPlace.TabIndex = 5;
            this.tbWhPlace.Text = "VANTAA";
            // 
            // tbContainer
            // 
            this.tbContainer.Location = new System.Drawing.Point(348, 682);
            this.tbContainer.Name = "tbContainer";
            this.tbContainer.Size = new System.Drawing.Size(304, 29);
            this.tbContainer.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContainer.TabIndex = 5;
            this.tbContainer.Text = "VANTAA";
            // 
            // lbCcs
            // 
            this.lbCcs.AutoSize = true;
            this.lbCcs.BackColor = System.Drawing.Color.Transparent;
            this.lbCcs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCcs.Location = new System.Drawing.Point(344, 143);
            this.lbCcs.Name = "lbCcs";
            this.lbCcs.Size = new System.Drawing.Size(31, 15);
            this.lbCcs.TabIndex = 4;
            this.lbCcs.Text = "CCS:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(508, 143);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(45, 15);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "Status:";
            // 
            // lbWarehouse
            // 
            this.lbWarehouse.AutoSize = true;
            this.lbWarehouse.BackColor = System.Drawing.Color.Transparent;
            this.lbWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWarehouse.Location = new System.Drawing.Point(21, 26);
            this.lbWarehouse.Name = "lbWarehouse";
            this.lbWarehouse.Size = new System.Drawing.Size(73, 15);
            this.lbWarehouse.TabIndex = 4;
            this.lbWarehouse.Text = "Warehouse:";
            // 
            // lbBooking
            // 
            this.lbBooking.AutoSize = true;
            this.lbBooking.BackColor = System.Drawing.Color.Transparent;
            this.lbBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBooking.Location = new System.Drawing.Point(304, 26);
            this.lbBooking.Name = "lbBooking";
            this.lbBooking.Size = new System.Drawing.Size(56, 15);
            this.lbBooking.TabIndex = 4;
            this.lbBooking.Text = "Booking:";
            // 
            // lbConsignee
            // 
            this.lbConsignee.AutoSize = true;
            this.lbConsignee.BackColor = System.Drawing.Color.Transparent;
            this.lbConsignee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConsignee.Location = new System.Drawing.Point(343, 249);
            this.lbConsignee.Name = "lbConsignee";
            this.lbConsignee.Size = new System.Drawing.Size(67, 15);
            this.lbConsignee.TabIndex = 2;
            this.lbConsignee.Text = "Consignee:";
            // 
            // lbContainer
            // 
            this.lbContainer.AutoSize = true;
            this.lbContainer.BackColor = System.Drawing.Color.Transparent;
            this.lbContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContainer.Location = new System.Drawing.Point(347, 664);
            this.lbContainer.Name = "lbContainer";
            this.lbContainer.Size = new System.Drawing.Size(64, 15);
            this.lbContainer.TabIndex = 2;
            this.lbContainer.Text = "Container:";
            // 
            // lbWhPlace
            // 
            this.lbWhPlace.AutoSize = true;
            this.lbWhPlace.BackColor = System.Drawing.Color.Transparent;
            this.lbWhPlace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhPlace.Location = new System.Drawing.Point(19, 664);
            this.lbWhPlace.Name = "lbWhPlace";
            this.lbWhPlace.Size = new System.Drawing.Size(44, 15);
            this.lbWhPlace.TabIndex = 2;
            this.lbWhPlace.Text = "Wh_pl:";
            // 
            // lbCodes
            // 
            this.lbCodes.AutoSize = true;
            this.lbCodes.BackColor = System.Drawing.Color.Transparent;
            this.lbCodes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodes.Location = new System.Drawing.Point(19, 573);
            this.lbCodes.Name = "lbCodes";
            this.lbCodes.Size = new System.Drawing.Size(43, 15);
            this.lbCodes.TabIndex = 2;
            this.lbCodes.Text = "Codes:";
            // 
            // lbDamage
            // 
            this.lbDamage.AutoSize = true;
            this.lbDamage.BackColor = System.Drawing.Color.Transparent;
            this.lbDamage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDamage.Location = new System.Drawing.Point(18, 482);
            this.lbDamage.Name = "lbDamage";
            this.lbDamage.Size = new System.Drawing.Size(56, 15);
            this.lbDamage.TabIndex = 2;
            this.lbDamage.Text = "Damage:";
            // 
            // lbSituation
            // 
            this.lbSituation.AutoSize = true;
            this.lbSituation.BackColor = System.Drawing.Color.Transparent;
            this.lbSituation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSituation.Location = new System.Drawing.Point(19, 249);
            this.lbSituation.Name = "lbSituation";
            this.lbSituation.Size = new System.Drawing.Size(60, 15);
            this.lbSituation.TabIndex = 2;
            this.lbSituation.Text = "Situation:";
            // 
            // lbDocuments
            // 
            this.lbDocuments.AutoSize = true;
            this.lbDocuments.BackColor = System.Drawing.Color.Transparent;
            this.lbDocuments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDocuments.Location = new System.Drawing.Point(17, 391);
            this.lbDocuments.Name = "lbDocuments";
            this.lbDocuments.Size = new System.Drawing.Size(74, 15);
            this.lbDocuments.TabIndex = 2;
            this.lbDocuments.Text = "Documents:";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.BackColor = System.Drawing.Color.Transparent;
            this.lbDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(18, 300);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(74, 15);
            this.lbDescription.TabIndex = 2;
            this.lbDescription.Text = "Description:";
            // 
            // lbConsignor
            // 
            this.lbConsignor.AutoSize = true;
            this.lbConsignor.BackColor = System.Drawing.Color.Transparent;
            this.lbConsignor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConsignor.Location = new System.Drawing.Point(344, 196);
            this.lbConsignor.Name = "lbConsignor";
            this.lbConsignor.Size = new System.Drawing.Size(65, 15);
            this.lbConsignor.TabIndex = 2;
            this.lbConsignor.Text = "Consignor:";
            // 
            // lbManager
            // 
            this.lbManager.AutoSize = true;
            this.lbManager.BackColor = System.Drawing.Color.Transparent;
            this.lbManager.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManager.Location = new System.Drawing.Point(19, 196);
            this.lbManager.Name = "lbManager";
            this.lbManager.Size = new System.Drawing.Size(59, 15);
            this.lbManager.TabIndex = 2;
            this.lbManager.Text = "Manager:";
            // 
            // lbArrival
            // 
            this.lbArrival.AutoSize = true;
            this.lbArrival.BackColor = System.Drawing.Color.Transparent;
            this.lbArrival.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArrival.Location = new System.Drawing.Point(19, 143);
            this.lbArrival.Name = "lbArrival";
            this.lbArrival.Size = new System.Drawing.Size(47, 15);
            this.lbArrival.TabIndex = 2;
            this.lbArrival.Text = "Arrival:";
            // 
            // lbComments
            // 
            this.lbComments.AutoSize = true;
            this.lbComments.BackColor = System.Drawing.Color.Transparent;
            this.lbComments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComments.Location = new System.Drawing.Point(344, 301);
            this.lbComments.Name = "lbComments";
            this.lbComments.Size = new System.Drawing.Size(70, 15);
            this.lbComments.TabIndex = 2;
            this.lbComments.Text = "Comments:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "m3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pkgs";
            // 
            // ms
            // 
            this.ms.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(672, 24);
            this.ms.TabIndex = 3;
            this.ms.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrint,
            this.tsmiPrintPreview,
            this.tsmiSave,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.fileToolStripMenuItem.Image = global::WarehouseApp.Properties.Resources.page;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.fileToolStripMenuItem.Text = "&Title Page";
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Image = global::WarehouseApp.Properties.Resources.printer;
            this.tsmiPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(140, 22);
            this.tsmiPrint.Text = "&Print";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiPrintPreview
            // 
            this.tsmiPrintPreview.Image = global::WarehouseApp.Properties.Resources.page_white_magnify;
            this.tsmiPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiPrintPreview.Name = "tsmiPrintPreview";
            this.tsmiPrintPreview.Size = new System.Drawing.Size(140, 22);
            this.tsmiPrintPreview.Text = "Print Pre&view";
            this.tsmiPrintPreview.Click += new System.EventHandler(this.tsmiPrintPreview_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Image = global::WarehouseApp.Properties.Resources.page_white_acrobat;
            this.tsmiSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(140, 22);
            this.tsmiSave.Text = "&PDF";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(140, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // TitlePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 723);
            this.Controls.Add(this.panel);
            this.MainMenuStrip = this.ms;
            this.Name = "TitlePageForm";
            this.Text = "Title Page";
            this.Load += new System.EventHandler(this.SummaryForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TitlePageForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus)).EndInit();
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel panel;
        private System.Windows.Forms.Label lbComments;
        private System.Windows.Forms.Label lbArrival;
        private System.Windows.Forms.Label lbManager;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.Label lbBooking;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbConsignee;
        private System.Windows.Forms.Label lbConsignor;
        private System.Windows.Forms.Label lbWhPlace;
        private System.Windows.Forms.Label lbCodes;
        private System.Windows.Forms.Label lbDamage;
        private System.Windows.Forms.Label lbSituation;
        private System.Windows.Forms.Label lbDocuments;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbConsignor;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbConsignee;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbCodes;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbDamage;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbDocuments;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbSituation;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbManager;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbCcs;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbWhPlace;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpArrival;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbBookingNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbWhNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbPkgs;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbKg;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbM3;
        private System.Windows.Forms.Label lbWarehouse;
        private System.Windows.Forms.Label lbCcs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbComments;
    }
}