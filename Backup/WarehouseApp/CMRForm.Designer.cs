namespace WarehouseApp
{
    partial class CMRForm
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
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblCarrierInstruction = new System.Windows.Forms.Label();
            this.tbCarrierInstruction = new System.Windows.Forms.TextBox();
            this.dataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.packages_kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFinalDestination = new System.Windows.Forms.TextBox();
            this.tbPlaceOfDischarge = new System.Windows.Forms.TextBox();
            this.tbBorderCrossing = new System.Windows.Forms.TextBox();
            this.tbIssuedAt = new System.Windows.Forms.TextBox();
            this.tbPlaceOfLoading = new System.Windows.Forms.TextBox();
            this.tbTrailerNum = new System.Windows.Forms.TextBox();
            this.tbTradeAccessRef = new System.Windows.Forms.TextBox();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.dtpDate2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtpDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblTradeAccessRef = new System.Windows.Forms.Label();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSenderSignature = new System.Windows.Forms.Label();
            this.lblIssuedAt = new System.Windows.Forms.Label();
            this.lblSpecialInstruction = new System.Windows.Forms.Label();
            this.lblPlaceOfDischarge = new System.Windows.Forms.Label();
            this.lblFinalDestination = new System.Windows.Forms.Label();
            this.lblBorderCrossing = new System.Windows.Forms.Label();
            this.lblTerms = new System.Windows.Forms.Label();
            this.lblPlaceOfLoading = new System.Windows.Forms.Label();
            this.lblTrailerNum = new System.Windows.Forms.Label();
            this.lblNotifyAddress = new System.Windows.Forms.Label();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.lblConsignee = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblConsignor = new System.Windows.Forms.Label();
            this.tbSenderSignature = new System.Windows.Forms.TextBox();
            this.tbSpecialInstruction = new System.Windows.Forms.TextBox();
            this.tbNotifyDeliveryAddr = new System.Windows.Forms.TextBox();
            this.tbCarrier = new System.Windows.Forms.TextBox();
            this.tbTerms = new System.Windows.Forms.TextBox();
            this.tbConsignee = new System.Windows.Forms.TextBox();
            this.tbConsignor = new System.Windows.Forms.TextBox();
            this.ms = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.ms.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.AutoScroll = true;
            this.kryptonPanel.Controls.Add(this.lblCarrierInstruction);
            this.kryptonPanel.Controls.Add(this.tbCarrierInstruction);
            this.kryptonPanel.Controls.Add(this.dataGridView);
            this.kryptonPanel.Controls.Add(this.tbFinalDestination);
            this.kryptonPanel.Controls.Add(this.tbPlaceOfDischarge);
            this.kryptonPanel.Controls.Add(this.tbBorderCrossing);
            this.kryptonPanel.Controls.Add(this.tbIssuedAt);
            this.kryptonPanel.Controls.Add(this.tbPlaceOfLoading);
            this.kryptonPanel.Controls.Add(this.tbTrailerNum);
            this.kryptonPanel.Controls.Add(this.tbTradeAccessRef);
            this.kryptonPanel.Controls.Add(this.tbReference);
            this.kryptonPanel.Controls.Add(this.dtpDate2);
            this.kryptonPanel.Controls.Add(this.dtpDate);
            this.kryptonPanel.Controls.Add(this.lblTradeAccessRef);
            this.kryptonPanel.Controls.Add(this.lblDate2);
            this.kryptonPanel.Controls.Add(this.lblDate);
            this.kryptonPanel.Controls.Add(this.lblSenderSignature);
            this.kryptonPanel.Controls.Add(this.lblIssuedAt);
            this.kryptonPanel.Controls.Add(this.lblSpecialInstruction);
            this.kryptonPanel.Controls.Add(this.lblPlaceOfDischarge);
            this.kryptonPanel.Controls.Add(this.lblFinalDestination);
            this.kryptonPanel.Controls.Add(this.lblBorderCrossing);
            this.kryptonPanel.Controls.Add(this.lblTerms);
            this.kryptonPanel.Controls.Add(this.lblPlaceOfLoading);
            this.kryptonPanel.Controls.Add(this.lblTrailerNum);
            this.kryptonPanel.Controls.Add(this.lblNotifyAddress);
            this.kryptonPanel.Controls.Add(this.lblCarrier);
            this.kryptonPanel.Controls.Add(this.lblConsignee);
            this.kryptonPanel.Controls.Add(this.lblReference);
            this.kryptonPanel.Controls.Add(this.lblConsignor);
            this.kryptonPanel.Controls.Add(this.tbSenderSignature);
            this.kryptonPanel.Controls.Add(this.tbSpecialInstruction);
            this.kryptonPanel.Controls.Add(this.tbNotifyDeliveryAddr);
            this.kryptonPanel.Controls.Add(this.tbCarrier);
            this.kryptonPanel.Controls.Add(this.tbTerms);
            this.kryptonPanel.Controls.Add(this.tbConsignee);
            this.kryptonPanel.Controls.Add(this.tbConsignor);
            this.kryptonPanel.Controls.Add(this.ms);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(694, 735);
            this.kryptonPanel.TabIndex = 12;
            // 
            // lblCarrierInstruction
            // 
            this.lblCarrierInstruction.AutoSize = true;
            this.lblCarrierInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblCarrierInstruction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrierInstruction.Location = new System.Drawing.Point(12, 631);
            this.lblCarrierInstruction.Name = "lblCarrierInstruction";
            this.lblCarrierInstruction.Size = new System.Drawing.Size(178, 13);
            this.lblCarrierInstruction.TabIndex = 18;
            this.lblCarrierInstruction.Text = "Carrier\'s instruction and remarks:";
            // 
            // tbCarrierInstruction
            // 
            this.tbCarrierInstruction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCarrierInstruction.Location = new System.Drawing.Point(9, 646);
            this.tbCarrierInstruction.Multiline = true;
            this.tbCarrierInstruction.Name = "tbCarrierInstruction";
            this.tbCarrierInstruction.Size = new System.Drawing.Size(310, 77);
            this.tbCarrierInstruction.TabIndex = 19;
            this.tbCarrierInstruction.Text = "TIR CARNET: RX62787010\r\nInvoice: 2957/MK\r\n1\r\n1\r\n1";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.packages_kind,
            this.gross_weight});
            this.dataGridView.Location = new System.Drawing.Point(8, 418);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(674, 126);
            this.dataGridView.StateCommon.Background.Color1 = System.Drawing.Color.LightSteelBlue;
            this.dataGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dataGridView.TabIndex = 13;
            // 
            // packages_kind
            // 
            this.packages_kind.FillWeight = 380F;
            this.packages_kind.HeaderText = "Number and kind of packages";
            this.packages_kind.Name = "packages_kind";
            // 
            // gross_weight
            // 
            this.gross_weight.HeaderText = "Gross weight, kg";
            this.gross_weight.Name = "gross_weight";
            // 
            // tbFinalDestination
            // 
            this.tbFinalDestination.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFinalDestination.Location = new System.Drawing.Point(332, 390);
            this.tbFinalDestination.Name = "tbFinalDestination";
            this.tbFinalDestination.Size = new System.Drawing.Size(146, 22);
            this.tbFinalDestination.TabIndex = 12;
            this.tbFinalDestination.Text = "S.Petersburg";
            // 
            // tbPlaceOfDischarge
            // 
            this.tbPlaceOfDischarge.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlaceOfDischarge.Location = new System.Drawing.Point(9, 390);
            this.tbPlaceOfDischarge.Name = "tbPlaceOfDischarge";
            this.tbPlaceOfDischarge.Size = new System.Drawing.Size(146, 22);
            this.tbPlaceOfDischarge.TabIndex = 10;
            this.tbPlaceOfDischarge.Text = "S.Petersburg";
            // 
            // tbBorderCrossing
            // 
            this.tbBorderCrossing.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBorderCrossing.Location = new System.Drawing.Point(173, 390);
            this.tbBorderCrossing.Name = "tbBorderCrossing";
            this.tbBorderCrossing.Size = new System.Drawing.Size(146, 22);
            this.tbBorderCrossing.TabIndex = 11;
            this.tbBorderCrossing.Text = "Vaalimaa";
            // 
            // tbIssuedAt
            // 
            this.tbIssuedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbIssuedAt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIssuedAt.Location = new System.Drawing.Point(462, 565);
            this.tbIssuedAt.Name = "tbIssuedAt";
            this.tbIssuedAt.Size = new System.Drawing.Size(220, 22);
            this.tbIssuedAt.TabIndex = 16;
            this.tbIssuedAt.Text = "VANTAA";
            // 
            // tbPlaceOfLoading
            // 
            this.tbPlaceOfLoading.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlaceOfLoading.Location = new System.Drawing.Point(173, 347);
            this.tbPlaceOfLoading.Name = "tbPlaceOfLoading";
            this.tbPlaceOfLoading.Size = new System.Drawing.Size(146, 22);
            this.tbPlaceOfLoading.TabIndex = 8;
            this.tbPlaceOfLoading.Text = "VANTAA";
            // 
            // tbTrailerNum
            // 
            this.tbTrailerNum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTrailerNum.Location = new System.Drawing.Point(9, 347);
            this.tbTrailerNum.Name = "tbTrailerNum";
            this.tbTrailerNum.Size = new System.Drawing.Size(146, 22);
            this.tbTrailerNum.TabIndex = 7;
            this.tbTrailerNum.Text = "B021KY98/AT581378";
            // 
            // tbTradeAccessRef
            // 
            this.tbTradeAccessRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTradeAccessRef.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTradeAccessRef.Location = new System.Drawing.Point(332, 108);
            this.tbTradeAccessRef.Name = "tbTradeAccessRef";
            this.tbTradeAccessRef.Size = new System.Drawing.Size(350, 22);
            this.tbTradeAccessRef.TabIndex = 3;
            this.tbTradeAccessRef.Text = "FGHJDFGJLKJT";
            // 
            // tbReference
            // 
            this.tbReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReference.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReference.Location = new System.Drawing.Point(462, 56);
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(220, 22);
            this.tbReference.TabIndex = 2;
            this.tbReference.Text = "CMR240510-02";
            // 
            // dtpDate2
            // 
            this.dtpDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate2.Location = new System.Drawing.Point(335, 565);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(100, 20);
            this.dtpDate2.TabIndex = 15;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(332, 56);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // lblTradeAccessRef
            // 
            this.lblTradeAccessRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTradeAccessRef.AutoSize = true;
            this.lblTradeAccessRef.BackColor = System.Drawing.Color.Transparent;
            this.lblTradeAccessRef.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeAccessRef.Location = new System.Drawing.Point(330, 93);
            this.lblTradeAccessRef.Name = "lblTradeAccessRef";
            this.lblTradeAccessRef.Size = new System.Drawing.Size(125, 13);
            this.lblTradeAccessRef.TabIndex = 1;
            this.lblTradeAccessRef.Text = "Trade access reference:";
            // 
            // lblDate2
            // 
            this.lblDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate2.AutoSize = true;
            this.lblDate2.BackColor = System.Drawing.Color.Transparent;
            this.lblDate2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate2.Location = new System.Drawing.Point(334, 550);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(34, 13);
            this.lblDate2.TabIndex = 1;
            this.lblDate2.Text = "Date:";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(331, 41);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date:";
            // 
            // lblSenderSignature
            // 
            this.lblSenderSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSenderSignature.AutoSize = true;
            this.lblSenderSignature.BackColor = System.Drawing.Color.Transparent;
            this.lblSenderSignature.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderSignature.Location = new System.Drawing.Point(464, 592);
            this.lblSenderSignature.Name = "lblSenderSignature";
            this.lblSenderSignature.Size = new System.Drawing.Size(98, 13);
            this.lblSenderSignature.TabIndex = 1;
            this.lblSenderSignature.Text = "Sender signature:";
            // 
            // lblIssuedAt
            // 
            this.lblIssuedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIssuedAt.AutoSize = true;
            this.lblIssuedAt.BackColor = System.Drawing.Color.Transparent;
            this.lblIssuedAt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuedAt.Location = new System.Drawing.Point(462, 550);
            this.lblIssuedAt.Name = "lblIssuedAt";
            this.lblIssuedAt.Size = new System.Drawing.Size(56, 13);
            this.lblIssuedAt.TabIndex = 1;
            this.lblIssuedAt.Text = "Issued at:";
            // 
            // lblSpecialInstruction
            // 
            this.lblSpecialInstruction.AutoSize = true;
            this.lblSpecialInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecialInstruction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialInstruction.Location = new System.Drawing.Point(11, 550);
            this.lblSpecialInstruction.Name = "lblSpecialInstruction";
            this.lblSpecialInstruction.Size = new System.Drawing.Size(105, 13);
            this.lblSpecialInstruction.TabIndex = 1;
            this.lblSpecialInstruction.Text = "Special instruction:";
            // 
            // lblPlaceOfDischarge
            // 
            this.lblPlaceOfDischarge.AutoSize = true;
            this.lblPlaceOfDischarge.BackColor = System.Drawing.Color.Transparent;
            this.lblPlaceOfDischarge.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaceOfDischarge.Location = new System.Drawing.Point(12, 374);
            this.lblPlaceOfDischarge.Name = "lblPlaceOfDischarge";
            this.lblPlaceOfDischarge.Size = new System.Drawing.Size(104, 13);
            this.lblPlaceOfDischarge.TabIndex = 1;
            this.lblPlaceOfDischarge.Text = "Place of discharge:";
            // 
            // lblFinalDestination
            // 
            this.lblFinalDestination.AutoSize = true;
            this.lblFinalDestination.BackColor = System.Drawing.Color.Transparent;
            this.lblFinalDestination.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalDestination.Location = new System.Drawing.Point(334, 374);
            this.lblFinalDestination.Name = "lblFinalDestination";
            this.lblFinalDestination.Size = new System.Drawing.Size(97, 13);
            this.lblFinalDestination.TabIndex = 1;
            this.lblFinalDestination.Text = "Final destination:";
            // 
            // lblBorderCrossing
            // 
            this.lblBorderCrossing.AutoSize = true;
            this.lblBorderCrossing.BackColor = System.Drawing.Color.Transparent;
            this.lblBorderCrossing.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorderCrossing.Location = new System.Drawing.Point(171, 374);
            this.lblBorderCrossing.Name = "lblBorderCrossing";
            this.lblBorderCrossing.Size = new System.Drawing.Size(91, 13);
            this.lblBorderCrossing.TabIndex = 1;
            this.lblBorderCrossing.Text = "Border crossing:";
            // 
            // lblTerms
            // 
            this.lblTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTerms.AutoSize = true;
            this.lblTerms.BackColor = System.Drawing.Color.Transparent;
            this.lblTerms.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerms.Location = new System.Drawing.Point(333, 320);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(99, 13);
            this.lblTerms.TabIndex = 1;
            this.lblTerms.Text = "Terms of delivery:";
            // 
            // lblPlaceOfLoading
            // 
            this.lblPlaceOfLoading.AutoSize = true;
            this.lblPlaceOfLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblPlaceOfLoading.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaceOfLoading.Location = new System.Drawing.Point(171, 332);
            this.lblPlaceOfLoading.Name = "lblPlaceOfLoading";
            this.lblPlaceOfLoading.Size = new System.Drawing.Size(94, 13);
            this.lblPlaceOfLoading.TabIndex = 1;
            this.lblPlaceOfLoading.Text = "Place of loading:";
            // 
            // lblTrailerNum
            // 
            this.lblTrailerNum.AutoSize = true;
            this.lblTrailerNum.BackColor = System.Drawing.Color.Transparent;
            this.lblTrailerNum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrailerNum.Location = new System.Drawing.Point(11, 332);
            this.lblTrailerNum.Name = "lblTrailerNum";
            this.lblTrailerNum.Size = new System.Drawing.Size(86, 13);
            this.lblTrailerNum.TabIndex = 1;
            this.lblTrailerNum.Text = "Trailer number:";
            // 
            // lblNotifyAddress
            // 
            this.lblNotifyAddress.AutoSize = true;
            this.lblNotifyAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifyAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifyAddress.Location = new System.Drawing.Point(12, 228);
            this.lblNotifyAddress.Name = "lblNotifyAddress";
            this.lblNotifyAddress.Size = new System.Drawing.Size(133, 13);
            this.lblNotifyAddress.TabIndex = 1;
            this.lblNotifyAddress.Text = "Notify/Delivery address:";
            // 
            // lblCarrier
            // 
            this.lblCarrier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.BackColor = System.Drawing.Color.Transparent;
            this.lblCarrier.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrier.Location = new System.Drawing.Point(334, 134);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(44, 13);
            this.lblCarrier.TabIndex = 1;
            this.lblCarrier.Text = "Carrier:";
            // 
            // lblConsignee
            // 
            this.lblConsignee.AutoSize = true;
            this.lblConsignee.BackColor = System.Drawing.Color.Transparent;
            this.lblConsignee.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignee.Location = new System.Drawing.Point(12, 134);
            this.lblConsignee.Name = "lblConsignee";
            this.lblConsignee.Size = new System.Drawing.Size(65, 13);
            this.lblConsignee.TabIndex = 1;
            this.lblConsignee.Text = "Consignee:";
            // 
            // lblReference
            // 
            this.lblReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReference.AutoSize = true;
            this.lblReference.BackColor = System.Drawing.Color.Transparent;
            this.lblReference.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.Location = new System.Drawing.Point(461, 41);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(83, 13);
            this.lblReference.TabIndex = 1;
            this.lblReference.Text = "Reference No.:";
            // 
            // lblConsignor
            // 
            this.lblConsignor.AutoSize = true;
            this.lblConsignor.BackColor = System.Drawing.Color.Transparent;
            this.lblConsignor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignor.Location = new System.Drawing.Point(12, 41);
            this.lblConsignor.Name = "lblConsignor";
            this.lblConsignor.Size = new System.Drawing.Size(64, 13);
            this.lblConsignor.TabIndex = 1;
            this.lblConsignor.Text = "Consignor:";
            // 
            // tbSenderSignature
            // 
            this.tbSenderSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderSignature.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSenderSignature.Location = new System.Drawing.Point(462, 608);
            this.tbSenderSignature.Multiline = true;
            this.tbSenderSignature.Name = "tbSenderSignature";
            this.tbSenderSignature.Size = new System.Drawing.Size(220, 47);
            this.tbSenderSignature.TabIndex = 17;
            this.tbSenderSignature.Text = "ccs oy\r\nAleksandr Tihonov\r\n1";
            // 
            // tbSpecialInstruction
            // 
            this.tbSpecialInstruction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpecialInstruction.Location = new System.Drawing.Point(8, 565);
            this.tbSpecialInstruction.Multiline = true;
            this.tbSpecialInstruction.Name = "tbSpecialInstruction";
            this.tbSpecialInstruction.Size = new System.Drawing.Size(310, 60);
            this.tbSpecialInstruction.TabIndex = 14;
            this.tbSpecialInstruction.Text = "TIR CARNET: RX62787010\r\nInvoice: 2957/MK\r\n1\r\n1";
            // 
            // tbNotifyDeliveryAddr
            // 
            this.tbNotifyDeliveryAddr.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotifyDeliveryAddr.Location = new System.Drawing.Point(9, 243);
            this.tbNotifyDeliveryAddr.Multiline = true;
            this.tbNotifyDeliveryAddr.Name = "tbNotifyDeliveryAddr";
            this.tbNotifyDeliveryAddr.Size = new System.Drawing.Size(310, 74);
            this.tbNotifyDeliveryAddr.TabIndex = 6;
            this.tbNotifyDeliveryAddr.Text = "CUSTOMS POST \"KRASNOSELSKY\" code 10210050\r\nKrasnoe selo, ul. Svobody, d.57 lir.E\r" +
                "\nSVH VENTA-TERMINAL St.Petersburg Russia\r\n1\r\n1";
            // 
            // tbCarrier
            // 
            this.tbCarrier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCarrier.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCarrier.Location = new System.Drawing.Point(332, 149);
            this.tbCarrier.Multiline = true;
            this.tbCarrier.Name = "tbCarrier";
            this.tbCarrier.Size = new System.Drawing.Size(350, 152);
            this.tbCarrier.TabIndex = 5;
            this.tbCarrier.Text = "JV JSC \"BALTCOM LINES\"\r\nKamennoostrovski pr.26/28 of.112\r\n197101 ST.PETERSBURG\r\nR" +
                "USSIA\r\n1\r\nRUS/053/04834\r\nINN 7805010251\r\n1\r\n1\r\n1\r\n1";
            // 
            // tbTerms
            // 
            this.tbTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTerms.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTerms.Location = new System.Drawing.Point(331, 335);
            this.tbTerms.Multiline = true;
            this.tbTerms.Name = "tbTerms";
            this.tbTerms.Size = new System.Drawing.Size(350, 34);
            this.tbTerms.TabIndex = 9;
            this.tbTerms.Text = "CPT-S.Petersburg\r\n1";
            // 
            // tbConsignee
            // 
            this.tbConsignee.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsignee.Location = new System.Drawing.Point(9, 149);
            this.tbConsignee.Multiline = true;
            this.tbConsignee.Name = "tbConsignee";
            this.tbConsignee.Size = new System.Drawing.Size(310, 74);
            this.tbConsignee.TabIndex = 4;
            this.tbConsignee.Text = "OOO \"Viaprom\"\r\nB.Sampsonievsky 32, of.304/1\r\n194044 St.Petersburg, Russia\r\nNN 781" +
                "3418693\r\n1";
            // 
            // tbConsignor
            // 
            this.tbConsignor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsignor.Location = new System.Drawing.Point(9, 56);
            this.tbConsignor.Multiline = true;
            this.tbConsignor.Name = "tbConsignor";
            this.tbConsignor.Size = new System.Drawing.Size(310, 74);
            this.tbConsignor.TabIndex = 0;
            this.tbConsignor.Text = "Sirius global LLP\r\nSuite 2, 23-24 Great James\r\nLondon WC1N 3ES, UK\r\n1\r\n1";
            // 
            // ms
            // 
            this.ms.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(694, 24);
            this.ms.TabIndex = 5;
            this.ms.Text = "menuStrip1";
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fileToolStripMenuItem.Text = "&CMR";
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // cms
            // 
            this.cms.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.cms.Name = "contextMenuStrip1";
            this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cms.ShowImageMargin = false;
            this.cms.Size = new System.Drawing.Size(69, 26);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.testToolStripMenuItem.Text = "test";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 380F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Marks and numbers";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 212;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 380F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Number and kind of packages";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 213;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Gross weight, kg";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 213;
            // 
            // CMRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 735);
            this.Controls.Add(this.kryptonPanel);
            this.MainMenuStrip = this.ms;
            this.Name = "CMRForm";
            this.Text = "International waybill";
            this.Load += new System.EventHandler(this.CMRForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CMRForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.TextBox tbConsignor;
        private System.Windows.Forms.Label lblConsignor;
        private System.Windows.Forms.TextBox tbReference;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblConsignee;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox tbConsignee;
        private System.Windows.Forms.TextBox tbTrailerNum;
        private System.Windows.Forms.Label lblPlaceOfLoading;
        private System.Windows.Forms.Label lblTrailerNum;
        private System.Windows.Forms.Label lblNotifyAddress;
        private System.Windows.Forms.TextBox tbNotifyDeliveryAddr;
        private System.Windows.Forms.TextBox tbFinalDestination;
        private System.Windows.Forms.TextBox tbPlaceOfDischarge;
        private System.Windows.Forms.TextBox tbBorderCrossing;
        private System.Windows.Forms.TextBox tbPlaceOfLoading;
        private System.Windows.Forms.TextBox tbTradeAccessRef;
        private System.Windows.Forms.Label lblTradeAccessRef;
        private System.Windows.Forms.Label lblPlaceOfDischarge;
        private System.Windows.Forms.Label lblFinalDestination;
        private System.Windows.Forms.Label lblBorderCrossing;
        private System.Windows.Forms.Label lblCarrier;
        private System.Windows.Forms.TextBox tbCarrier;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.TextBox tbTerms;
        private System.Windows.Forms.Label lblSpecialInstruction;
        private System.Windows.Forms.TextBox tbSpecialInstruction;
        private System.Windows.Forms.Label lblSenderSignature;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView;
        private System.Windows.Forms.TextBox tbSenderSignature;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpDate2;
        private System.Windows.Forms.Label lblDate2;
        private System.Windows.Forms.Label lblIssuedAt;
        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox tbIssuedAt;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Label lblCarrierInstruction;
        private System.Windows.Forms.TextBox tbCarrierInstruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn packages_kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_weight;
    }
}