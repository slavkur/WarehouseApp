namespace WarehouseApp
{
    partial class EditForm
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
            this.dataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnDescription = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnInfo = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnMain = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.checkSet = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileAttacher = new WarehouseApp.FileAttacher();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSet)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.fileAttacher);
            this.kryptonPanel.Controls.Add(this.dataGridView);
            this.kryptonPanel.Controls.Add(this.btnDescription);
            this.kryptonPanel.Controls.Add(this.btnInfo);
            this.kryptonPanel.Controls.Add(this.btnMain);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonPanel.Size = new System.Drawing.Size(603, 386);
            this.kryptonPanel.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.Location = new System.Drawing.Point(10, 36);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 100;
            this.dataGridView.Size = new System.Drawing.Size(585, 311);
            this.dataGridView.StateCommon.Background.Color1 = System.Drawing.Color.LightSteelBlue;
            this.dataGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dataGridView.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellLeave);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            this.dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
            // 
            // btnDescription
            // 
            this.btnDescription.Location = new System.Drawing.Point(188, 14);
            this.btnDescription.Name = "btnDescription";
            this.btnDescription.Size = new System.Drawing.Size(90, 25);
            this.btnDescription.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescription.TabIndex = 6;
            this.btnDescription.Values.Text = "Description";
            this.btnDescription.Click += new System.EventHandler(this.btnDescription_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(99, 14);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(90, 25);
            this.btnInfo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.TabIndex = 5;
            this.btnInfo.Values.Text = "Info";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnMain
            // 
            this.btnMain.Checked = true;
            this.btnMain.Location = new System.Drawing.Point(10, 12);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(90, 25);
            this.btnMain.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.TabIndex = 4;
            this.btnMain.Values.Text = "Main";
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // checkSet
            // 
            this.checkSet.CheckButtons.Add(this.btnMain);
            this.checkSet.CheckButtons.Add(this.btnInfo);
            this.checkSet.CheckButtons.Add(this.btnDescription);
            this.checkSet.CheckedButton = this.btnMain;
            this.checkSet.CheckedButtonChanged += new System.EventHandler(this.checkSet_CheckedButtonChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileAttacher
            // 
            this.fileAttacher.BackColor = System.Drawing.Color.Transparent;
            this.fileAttacher.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileAttacher.Location = new System.Drawing.Point(0, 353);
            this.fileAttacher.MinimumSize = new System.Drawing.Size(128, 33);
            this.fileAttacher.Name = "fileAttacher";
            this.fileAttacher.Size = new System.Drawing.Size(603, 33);
            this.fileAttacher.TabIndex = 8;
            this.fileAttacher.AttachFile += new WarehouseApp.FileAttacher.Event(this.fileAttacher_AttachFile);
            this.fileAttacher.RemoveFile += new WarehouseApp.FileAttacher.Event(this.fileAttacher_RemoveFile);
            this.fileAttacher.Resize += new System.EventHandler(this.fileAttacher_Resize);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Values";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 278;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 386);
            this.Controls.Add(this.kryptonPanel);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 420);
            this.Name = "EditForm";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.Text = "Edit entry";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnMain;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet checkSet;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnDescription;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private WarehouseApp.FileAttacher fileAttacher;
    }
}