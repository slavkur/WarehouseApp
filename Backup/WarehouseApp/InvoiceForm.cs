using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace WarehouseApp
{
    public partial class InvoiceForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private const int DAYS = 10;
        private OleDbDataAdapter adapter;
        private OleDbConnection conn;
        private DataSet dataSet = new DataSet();

        //todo: simplify with datarow
        private int stockId;
        private int cll;
        private int daysFree;
        private double kg;
        private double m3;
        private String ccsNumber;
        private String whNumber;
        private String invoiceNumber;
        private String bookingNumber;
        private String consignor;
        private String status;
        private DateTime departure;
        private DateTime entryArrived;

        private AutoSuggestControl autoSuggestControl;
        private Boolean invoiceNumberChanged;

        private const decimal minAmount = 15.00M;

        public event InvoiceEventHandler invoiceNumberCreated;
        public delegate void InvoiceEventHandler(String invoiceNumber);

        private DataTable InvoiceDetails
        {
            get
            {
                return dataSet.Tables["InvoiceDetails"];
            }
        }

        private int DaysBetween
        {
            get
            {
                return departure.Subtract(entryArrived).Days + 1;
            }
        }

        private DateTime After10Days
        {
            get
            {
                return (dtpInvoice.Value + TimeSpan.FromDays(DAYS));
            }
        }

        private void blankInitialize()
        {
            this.tbSummary.Text = "";
            adapter = new OleDbDataAdapter("Select * from Invoice_View", conn);
            adapter.Fill(dataSet, "Invoice_View");
            dataGridView.DataSource = dataSet.Tables["Invoice_View"];
            conn.Close();
        }

        public InvoiceForm(DataRow item, int stockId)
        {
            InitializeComponent();
            this.formHeight = MinimumSize.Height;

            this.item = item;
            this.dataTable = item.Table;

            this.conn = new OleDbConnection(Program.connectionString);
            this.stockId = stockId;
            this.blankInitialize();
        }

        private DataRow item;
        public DataTable dataTable;
        public InvoiceForm(OleDbConnection conn, DataRow item, int stockId, int cll, double kg, double m3, String ccsNumber, String whNumber, String bookingNumber, String invoiceNumber, String consignor, DateTime departure, DateTime entryArrived, String status)
        {
            InitializeComponent();
            this.formHeight = MinimumSize.Height;

            this.item = item;
            this.dataTable = item.Table;

            this.conn = conn;

            this.stockId = stockId;
            this.m3 = m3;
            this.kg = kg;
            this.cll = cll;
            this.ccsNumber = ccsNumber;
            this.whNumber = whNumber;
            this.bookingNumber = bookingNumber;
            this.invoiceNumber = invoiceNumber;
            this.consignor = consignor;
            this.departure = departure;
            this.entryArrived = entryArrived;
            this.status = status;

            this.tbSummary.Text = whNumber + "/" + bookingNumber + "\r\n" + cll + "cll/" + kg + "kg/" + m3 + "m3\r\n" + consignor;
        }

        private int IndexOf(String name)
        {
            return dataTable.Columns.IndexOf(name);
        }

        private Boolean statusT1()
        {
            return status.ToLower().StartsWith("t1");
        }

        private void invoiceDetails()
        {
            adapter = new OleDbDataAdapter("select * from InvoiceDetails", conn);
            adapter.Fill(dataSet, "InvoiceDetails");
            DataRow row = InvoiceDetails.Rows[0];
            DataColumnCollection columns = InvoiceDetails.Columns;
            tbCompanyInfo.Text = row.ItemArray[columns.IndexOf("company_info")].ToString();
            tbAddress.Text = row.ItemArray[columns.IndexOf("address")].ToString();
            tbBankDetails.Text = row.ItemArray[columns.IndexOf("bank_details")].ToString();
            cbTax.Tag = row.ItemArray[columns.IndexOf("tax")].ToString();
            cbTax.Text = "Finnish tax " + (int)float.Parse(cbTax.Tag.ToString()) + "%";
            daysFree = int.Parse(row.ItemArray[columns.IndexOf("days_free")].ToString());

            if (invoiceNumber != null && invoiceNumber.Length > 0)
            {
                this.Text += tbInvoiceNumber.Text = invoiceNumber;
            }
            else
            {
                this.Text += tbInvoiceNumber.Text = newInvoiceNumber();
            }

            this.invoiceNumberChanged = !tbInvoiceNumber.Text.Equals(invoiceNumber);
            if (invoiceNumberCreated != null && invoiceNumberChanged)
            {
                invoiceNumberCreated(tbInvoiceNumber.Text);
            }
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            this.tbReceiver.Text = "";
            this.dtpInvoice.Value = System.DateTime.Now;
            this.dtpInvoiceDue.Value = After10Days;
            this.Text = "Invoice ";
            invoiceDetails();

            if (invoiceNumber != null && invoiceNumber.Length > 0)
            {
                String fields = "service, quantity, unit, a_price, total, vat";
                adapter = new OleDbDataAdapter("Select " + fields + ", hasTax, invoice_date, due_date, receiver, summary, company_info, address, bank_details from InvoiceLog where invoice_number = @invoice_number", conn);
                adapter.SelectCommand.Parameters.Add("@invoice_number", OleDbType.VarWChar).Value = invoiceNumber;
                adapter.Fill(dataSet, "Invoice_View");
                DataTable invoiceLog = dataSet.Tables["Invoice_View"];

                if (invoiceLog.Rows.Count > 0)
                {
                    Object[] itemArray = invoiceLog.Rows[0].ItemArray;
                    DataColumnCollection columns1 = invoiceLog.Columns;
                    cbTax.Checked = Boolean.Parse(itemArray[columns1.IndexOf("hasTax")].ToString());
                    tbReceiver.Text = itemArray[columns1.IndexOf("receiver")].ToString();
                    tbSummary.Text = itemArray[columns1.IndexOf("summary")].ToString();
                    tbCompanyInfo.Text = itemArray[columns1.IndexOf("company_info")].ToString();
                    tbAddress.Text = itemArray[columns1.IndexOf("address")].ToString();
                    tbBankDetails.Text = itemArray[columns1.IndexOf("bank_details")].ToString();
                    try
                    {
                        dtpInvoice.Value = DateTime.Parse(itemArray[columns1.IndexOf("invoice_date")].ToString());
                    }
                    catch { }
                    try
                    {
                        dtpInvoiceDue.Value = DateTime.Parse(itemArray[columns1.IndexOf("due_date")].ToString());

                    }
                    catch { }
                    MainWindow.DataGridView_Serialize(dataGridView, invoiceLog, fields);
                }
                else
                {
                    loadDefault();
                    invoiceNumberChanged = true;
                }
            }
            else if (ccsNumber != null)
            {
                loadDefault();
            }
            conn.Close();

            MainWindow.DataGridView_LockColumn(dataGridView, "vat");
            MainWindow.DataGridView_LockColumn(dataGridView, "total");

            cbTax_CheckedChanged(cbTax, new EventArgs());
            autoSuggestControl = new AutoSuggestControl(conn, "InvoiceData", new TextBox[] { tbReceiver, tbAddress, tbBankDetails, tbCompanyInfo });
            kryptonPanel1.Controls.Add(autoSuggestControl);
            autoSuggestControl.BringToFront();

            fileAttacher.displayAttached(item[IndexOf("attached")].ToString().Split(','));
        }

        private void loadDefault()
        {
            dataSet = new DataSet();
            adapter = new OleDbDataAdapter("select * from InvoiceDefault_View", conn);
            adapter.Fill(dataSet, "Invoice_View");
            dataGridView.DataSource = dataSet.Tables["Invoice_View"];
        }

        private String replaceBaseOnMatch(String invoicePattern, String replacement, String pattern)
        {
            Regex regex = new Regex(pattern);
            MatchCollection collection = regex.Matches(invoicePattern);
            foreach (Match match in collection)
            {
                if (match.Value.Length > replacement.Length)
                {
                    int diff = match.Value.Length - replacement.Length;
                    while (diff-- > 0)
                    {
                        replacement = 0 + replacement;
                    }
                }
                invoicePattern = invoicePattern.Replace(match.Value, replacement.Substring(replacement.Length - match.Value.Length));
            }

            return invoicePattern;
        }

        private String newInvoiceNumber(int lastIndex)
        {
            OleDbCommand command;
            String invoicePattern = WarehouseApp.Properties.Settings.Default.InvoicePattern;
            invoicePattern = replaceBaseOnMatch(invoicePattern, DateTime.Now.Year.ToString(), "y+");
            invoicePattern = replaceBaseOnMatch(invoicePattern, DateTime.Now.Day.ToString(), "d+");
            invoicePattern = replaceBaseOnMatch(invoicePattern, DateTime.Now.Month.ToString(), "M+");

            if (WarehouseApp.Properties.Settings.Default.InvoiceReset)
            {
                String invoiceResetType = WarehouseApp.Properties.Settings.Default.InvoiceResetType;
                String dateNow = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                String template = "created > DateValue('" + dateNow + "') and created < DateAdd('" + invoiceResetType + "', 1, DateValue('" + dateNow + "'))";
                if (invoiceResetType.Equals("y"))
                {
                    int year = DateTime.Now.Year;
                    template = "created >= DateValue('1/1/" + year + "') and created <= DateValue('12/31/" + year + "')";
                }
                command = new OleDbCommand("select count(*) + 1 from InvoiceLog where " + template, conn);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    lastIndex = reader.GetInt32(0);
                }
            }
            //else if (updatedAt.Year.Equals(DateTime.Now.Year))
            //{
            lastIndex++; //TODO: find out
            //}

            if (lastIndex.Equals(0))
            {
                lastIndex = 1;
            }

            invoicePattern = replaceBaseOnMatch(invoicePattern, lastIndex.ToString(), "n+");
            /*command = new OleDbCommand("update InvoiceDetails set [number]=@number, updated_at=@updated_at", conn);
            command.Parameters.Add("@number", OleDbType.Integer).Value = lastIndex;
            command.Parameters.Add("@updated_at", OleDbType.DBDate).Value = DateTime.Now;
            command.ExecuteNonQuery();*/
            return invoicePattern;
        }

        private String newInvoiceNumber()
        {
            String invoiceNumberFinal;
            conn.Open();
            /*OleDbCommand command = new OleDbCommand("Select invoice_number from InvoiceNumbersFree", conn);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows && WarehouseApp.Properties.Settings.Default.InvoiceResetType.Equals("y"))
            {
                //TODO: check and specific
                invoiceNumberFinal = reader.GetString(0);
                command = new OleDbCommand("Delete from InvoiceNumbersFree where invoice_number = @invoiceNumber", conn);
                command.Parameters.Add("@invoiceNumber", OleDbType.VarWChar).Value = invoiceNumberFinal;
                command.ExecuteNonQuery();
            }
            else
            {*/
            OleDbCommand command = new OleDbCommand("Select invoice_number from InvoiceLog order by created desc", conn);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows && WarehouseApp.Properties.Settings.Default.InvoiceResetType.Equals("d"))
            {
                String[] values = reader.GetString(0).Split('-');
                String number = values[values.Length - 1];
                invoiceNumberFinal = newInvoiceNumber(int.Parse(number));
                Console.WriteLine(invoiceNumberFinal);
            }
            else
            {
                // TODO: probably no use
                // use available numbers
                //DataRow row = InvoiceDetails.Rows[0];
                //DataColumnCollection columns = InvoiceDetails.Columns;
                //invoiceNumberFinal = newInvoiceNumber(int.Parse(row.ItemArray[columns.IndexOf("number")].ToString()));
                invoiceNumberFinal = newInvoiceNumber(0);
            }
            //}
            conn.Close();
            return invoiceNumberFinal;//"000000-0000";
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView.Columns[Columns.IndexOf("Service")].Width = 280;
            dataGridView.Columns[Columns.IndexOf("Unit")].Width = 50;

            DataGridViewColumn aPrice = dataGridView.Columns[Columns.IndexOf("a_price")];
            aPrice.Width = 80;
            aPrice.HeaderCell.Value = "A-Price, EUR";
            aPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            DataGridViewColumn totalColumn = dataGridView.Columns[Columns.IndexOf("total")];
            totalColumn.Width = aPrice.Width;
            totalColumn.HeaderCell.Value = "Total, EUR";
            totalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            DataGridViewColumn vat = dataGridView.Columns[Columns.IndexOf("vat")];
            vat.HeaderCell.Value = "Vat, %";
            vat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceForm_FormClosed(this, new FormClosedEventArgs(CloseReason.None));
            Close();
        }

        private DataColumnCollection Columns
        {
            get
            {
                return dataSet.Tables["Invoice_View"].Columns;
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Columns.IndexOf("total") == e.ColumnIndex || Columns.IndexOf("a_price") == e.ColumnIndex)
            {
                decimal number = 0;
                decimal.TryParse(dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString(), out number);
                dataGridView[e.ColumnIndex, e.RowIndex].Value = decimal.Round(number * 1.00M, 2).ToString();
            }

            int days = 1;
            int serviceIndex = Columns.IndexOf("Service");
            int totalIndex = Columns.IndexOf("total");
            bool isWarehousing = dataGridView[serviceIndex, e.RowIndex].Value.ToString().Equals("Warehousing");
            bool isInOut = dataGridView[serviceIndex, e.RowIndex].Value.ToString().StartsWith("In/Out");
            bool isHandling = dataGridView[serviceIndex, e.RowIndex].Value.ToString().Equals("Handling");
            if (e.ColumnIndex != totalIndex)
            {
                double quantity = 0.0;
                decimal aPrice = 0.00M;
                int quantityService = 1;
                int quantityIndex = Columns.IndexOf("Quantity");
                int unitIndex = Columns.IndexOf("unit");
                int vatIndex = Columns.IndexOf("vat");
                int aPriceIndex = Columns.IndexOf("a_price");

                DataGridViewCell vatCell = dataGridView[vatIndex, e.RowIndex];
                if (vatCell.Value == null || vatCell.Value.ToString().Length == 0)
                {
                    vatCell.Value = 0;
                }
                if (isInOut)
                {
                    quantityService = 2;
                }
                if (isHandling || isWarehousing)
                {
                    object value = dataGridView[quantityIndex, e.RowIndex].Value;
                    dataGridView[quantityIndex, e.RowIndex].Value = (value.ToString().Length > 0) ? value : m3;

                    value = dataGridView[unitIndex, e.RowIndex].Value;
                    dataGridView[unitIndex, e.RowIndex].Value = (value.ToString().Length > 0) ? value : "m3";

                    //Check if this still needed
                    //value = dataGridView[aPriceIndex, e.RowIndex].Value;
                    //dataGridView[aPriceIndex, e.RowIndex].Value = (e.ColumnIndex == aPriceIndex) ? value : decimal.Parse(value.ToString()).Equals(0.0M) ? 7.90 : value;
                }
                if (isWarehousing)
                {
                    days = (DaysBetween > daysFree) ? DaysBetween : 0;
                }

                double.TryParse(dataGridView[quantityIndex, e.RowIndex].Value.ToString(), out quantity);
                decimal.TryParse(dataGridView[aPriceIndex, e.RowIndex].Value.ToString(), out aPrice);
                DataGridViewCell totalCell = dataGridView[totalIndex, e.RowIndex];
                totalCell.Value = decimal.Parse(quantity.ToString()) * aPrice * 1.00M;

                if (isWarehousing)
                {
                    decimal totalValue = decimal.Parse(totalCell.Value.ToString()) * decimal.Parse(days.ToString());
                    if (isWarehousing && totalValue < minAmount && DaysBetween > daysFree)
                    {
                        totalValue = minAmount;
                    }
                    totalCell.Value = totalValue;
                }
                totalCell.Value = decimal.Round(decimal.Parse(totalCell.Value.ToString()), 2) * quantityService;
            }

            totalNetLbl.Text = calculateSum("total").ToString();
            cbTax_CheckedChanged(cbTax, new EventArgs());
            calculateTotal();
        }

        private void calculateTotal()
        {
            lblTotal.Text = decimal.Round(calculateSum("total") + decimal.Parse(lblVat.Text.ToString()), 2).ToString();
        }

        private decimal calculateSum(String name)
        {
            decimal sum = 0.00M;
            int index = Columns.IndexOf(name);
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if (dataGridView.Rows[i].Visible)
                {
                    decimal number = 0.00M;
                    decimal.TryParse(((DataRowView)dataGridView.Rows[i].DataBoundItem).Row.ItemArray[index].ToString(), out number);
                    sum += number;
                }
            }

            return decimal.Round(sum, 2);
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = 1;
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                if (row.Cells[Columns.IndexOf("Service")].Value != null &&
                    row.Cells[Columns.IndexOf("Service")].Value.ToString().ToLower().StartsWith("in/out"))
                {
                    row.Visible = statusT1();
                }

                if (!row.Visible)
                {
                    index--;
                }

                for (int j = 0; j < row.Cells.Count; j++)
                {
                    try
                    {
                        dataGridView_CellEndEdit(dataGridView, new DataGridViewCellEventArgs(j, i));
                    }
                    catch (Exception e2)
                    {
                        Console.WriteLine(e2.StackTrace);
                    }
                }
                row.HeaderCell.Value = index.ToString();
                index++;
            }
        }

        //todo: remove, use Views from MainForm datagrid and update using dataTable
        private void addParemeters(OleDbParameterCollection parameters)
        {
            parameters.Add("@stock_id", OleDbType.Integer).Value = stockId;
            parameters.Add("@invoice_number", OleDbType.VarWChar).Value = tbInvoiceNumber.Text;
            parameters.Add("@hasTax", OleDbType.Boolean).Value = cbTax.Checked;
            parameters.Add("@invoice_date", OleDbType.DBTimeStamp).Value = DateTime.Parse(dtpInvoice.Value.ToString());
            parameters.Add("@due_date", OleDbType.DBTimeStamp).Value = DateTime.Parse(dtpInvoiceDue.Value.ToString());
            parameters.Add("@ccs_number", OleDbType.VarWChar).Value = (ccsNumber == null) ? "" : ccsNumber;
            parameters.Add("@receiver", OleDbType.VarWChar).Value = tbReceiver.Text;
            parameters.Add("@summary", OleDbType.VarWChar).Value = tbSummary.Text;
            parameters.Add("@company_info", OleDbType.VarWChar).Value = tbCompanyInfo.Text;
            parameters.Add("@address", OleDbType.VarWChar).Value = tbAddress.Text;
            parameters.Add("@bank_details", OleDbType.VarWChar).Value = tbBankDetails.Text;
            parameters.Add("@cll_doc", OleDbType.Integer).Value = cll;
            parameters.Add("@kg_doc", OleDbType.Double).Value = kg;
            parameters.Add("@m3", OleDbType.Double).Value = m3;
            parameters.Add("@attached", OleDbType.VarWChar).Value = item.ItemArray[IndexOf("attached")].ToString();
            MainWindow.DataGridView_Deserialize(dataGridView, parameters);
        }

        private void InvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OleDbCommand command;
            //TODO: allocate it to single method
            if (conn.State.Equals(System.Data.ConnectionState.Closed))
                conn.Open();

            if (invoiceNumberChanged)
            {
                command = new OleDbCommand("Insert into InvoiceLog (stock_id, invoice_number, hasTax, invoice_date, due_date, ccs_number, receiver, summary, company_info, address, bank_details, cll_doc, kg_doc, m3, attached, service, quantity, unit, a_price, total, vat) values(@stock_id, @invoice_number, @hasTax, @invoice_date, @due_date, @ccs_number, @receiver, @summary, @company_info, @address, @bank_details, @cll_doc, @kg_doc, @m3, @attached, @service, @quantity, @unit, @aprice, @total, @vat)", conn);
            }
            else
            {
                command = new OleDbCommand("Update InvoiceLog set stock_id = @stock_id, invoice_number = @invoice_number, hasTax = @hasTax, invoice_date = @invoice_date, due_date = @due_date, ccs_number = @ccs_number, receiver = @receiver, summary = @summary, company_info = @company_info, address = @address, bank_details = @bank_details, cll_doc = @cll_doc, kg_doc = @kg_doc, m3 = @m3, attached = @attached, service = @service, quantity = @quantity, unit = @unit, a_price = @aprice, total = @total, vat = @vat where invoice_number = @invoice_number", conn);
            }

            addParemeters(command.Parameters);
            command.ExecuteNonQuery();
            //TODO: allocate it to single method            
            if (conn.State.Equals(System.Data.ConnectionState.Open))
                conn.Close();
            autoSuggestControl.saveFields();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((ShowPrintDialog()) != null)
            {
                printDocument.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((ShowPrintDialog()) != null)
            {
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = printDocument;
                dialog.ShowDialog();
            }
        }

        private PrintDialog ShowPrintDialog()
        {
            PrintDialog dialog = SetupDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return null;
            return dialog;
        }

        private PrintDialog SetupDialog()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.AllowCurrentPage = false;
            dialog.AllowPrintToFile = false;
            dialog.AllowSelection = false;
            dialog.AllowSomePages = true;
            dialog.PrintToFile = false;
            dialog.ShowHelp = false;
            dialog.ShowNetwork = false;

            printDocument.DocumentName = Text;
            printDocument.PrinterSettings = dialog.PrinterSettings;
            printDocument.DefaultPageSettings = dialog.PrinterSettings.DefaultPageSettings;
            printDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            return dialog;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Margins margins = printDocument.DefaultPageSettings.Margins;
            PaperSize size = printDocument.DefaultPageSettings.PaperSize;
            int pageWidth = size.Width - margins.Left;
            int pageHeight = size.Height - margins.Top - margins.Bottom;
            Pen borderPen = new Pen(Color.Black, 2);
            Pen singlePen = new Pen(Color.Black, 1);
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat TitleFormat = new StringFormat();
            StringFormat DescriptionFormat = new StringFormat();
            Font titleLabelFont = new Font("Segoe UI", 20, FontStyle.Bold);
            Font boldLabelFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font normalBoldLabelFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font normalLabelFont = new Font("Segoe UI", 12, FontStyle.Regular);
            Font companyLabelFont = new Font("Segoe UI", 10, FontStyle.Regular);

            TitleFormat.Trimming = StringTrimming.Word;
            TitleFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            DescriptionFormat.Trimming = StringTrimming.Word;
            DescriptionFormat.FormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            string text = "ORIGINAL INVOICE";

            Bitmap logo = new Bitmap("logo.Image.tif");
            g.DrawImage(logo, new Point(pageWidth - (140), margins.Top));


            // title
            RectangleF TitleColumn1 = new RectangleF(margins.Left, margins.Top + 140 - g.MeasureString(text, titleLabelFont).Height + 50, pageWidth, g.MeasureString(text, titleLabelFont).Height);
            g.DrawString(text, titleLabelFont, brush, TitleColumn1, TitleFormat);

            float invoiceSummaryPosition = TitleColumn1.X;
            float timeBoxPosition = 343;
            string _invoiceSummaryPosition = Properties.Settings.Default.InvoiceSummaryPosition;
            if (_invoiceSummaryPosition != null)
            {
                invoiceSummaryPosition = float.Parse(_invoiceSummaryPosition);
                timeBoxPosition = TitleColumn1.X + 20;
            }

            // left column
            g.DrawLine(borderPen, new Point((int)TitleColumn1.X, (int)(TitleColumn1.Y + TitleColumn1.Height)), new Point(pageWidth, (int)(TitleColumn1.Y + TitleColumn1.Height)));

            RectangleF receiver = new RectangleF(TitleColumn1.X, TitleColumn1.Y + TitleColumn1.Height + 5, 340, tbReceiver.Height);
            g.DrawString(tbReceiver.Text, normalLabelFont, brush, receiver, DescriptionFormat);


            // right column
            RectangleF companyInfo = new RectangleF(pageWidth - g.MeasureString(tbCompanyInfo.Text, companyLabelFont).Width - 140, TitleColumn1.Y + TitleColumn1.Height + 9, pageWidth, g.MeasureString(tbCompanyInfo.Text, companyLabelFont).Height);
            g.DrawString(tbCompanyInfo.Text, companyLabelFont, brush, companyInfo, TitleFormat);

            String[] addreses = Regex.Split(tbAddress.Text, "\r\n\r\n");
            if (addreses.Length < 2)
            {
                addreses = new String[] { tbAddress.Text, "" };
            }

            RectangleF address1 = new RectangleF(companyInfo.X, companyInfo.Y + companyInfo.Height + 5, pageWidth, g.MeasureString(addreses[0], companyLabelFont).Height);
            g.DrawString(addreses[0], companyLabelFont, brush, address1, TitleFormat);

            RectangleF address2 = new RectangleF(address1.X, address1.Y + address1.Height + 2, pageWidth, g.MeasureString(addreses[1], companyLabelFont).Height);
            g.DrawString(addreses[1], companyLabelFont, brush, address2, TitleFormat);

            RectangleF bankDetails = new RectangleF(address2.X, address2.Y + address2.Height + 5, pageWidth, g.MeasureString(tbBankDetails.Text, companyLabelFont).Height);
            g.DrawString(tbBankDetails.Text, companyLabelFont, brush, bankDetails, TitleFormat);


            // left column
            RectangleF summary = new RectangleF(invoiceSummaryPosition, bankDetails.Y + bankDetails.Height + 50, 340, g.MeasureString(tbSummary.Text, normalLabelFont).Height);
            g.DrawString(tbSummary.Text, normalLabelFont, brush, summary, DescriptionFormat);



            RectangleF dateTextLabel = new RectangleF(timeBoxPosition, summary.Y, g.MeasureString(invoiceDateTextLbl.Text, boldLabelFont).Width, g.MeasureString(invoiceDateTextLbl.Text, boldLabelFont).Height);
            g.DrawString(invoiceDateTextLbl.Text, boldLabelFont, brush, dateTextLabel, TitleFormat);

            RectangleF date = new RectangleF(dateTextLabel.X, dateTextLabel.Y + dateTextLabel.Height + 2, g.MeasureString(dtpInvoice.Text, normalLabelFont).Width, g.MeasureString(dtpInvoice.Text, normalLabelFont).Height);
            g.DrawString(dtpInvoice.Text, normalLabelFont, brush, date, TitleFormat);

            RectangleF dateDueTextLabel = new RectangleF(date.X + date.Width + 70, dateTextLabel.Y, g.MeasureString(invoiceDueDateTextLbl.Text, boldLabelFont).Width, g.MeasureString(invoiceDueDateTextLbl.Text, boldLabelFont).Height);
            g.DrawString(invoiceDueDateTextLbl.Text, boldLabelFont, brush, dateDueTextLabel, TitleFormat);

            RectangleF dateDue = new RectangleF(date.X + date.Width + 70, dateDueTextLabel.Y + dateDueTextLabel.Height + 2, g.MeasureString(dtpInvoiceDue.Text, normalLabelFont).Width, g.MeasureString(dtpInvoiceDue.Text, normalLabelFont).Height);
            g.DrawString(dtpInvoiceDue.Text, normalLabelFont, brush, dateDue, TitleFormat);

            RectangleF invoiceNumberTextLabel = new RectangleF(dateDue.X + dateDue.Width + 70, summary.Y, g.MeasureString(invoiceNumberTextLbl.Text, boldLabelFont).Width, g.MeasureString(invoiceNumberTextLbl.Text, boldLabelFont).Height);
            g.DrawString(invoiceNumberTextLbl.Text, boldLabelFont, brush, invoiceNumberTextLabel, TitleFormat);

            RectangleF invoiceNumber = new RectangleF(dateDue.X + dateDue.Width + 70, invoiceNumberTextLabel.Y + invoiceNumberTextLabel.Height + 2, g.MeasureString(tbInvoiceNumber.Text, normalLabelFont).Width, g.MeasureString(tbInvoiceNumber.Text, normalLabelFont).Height);
            g.DrawString(tbInvoiceNumber.Text, normalLabelFont, brush, invoiceNumber, TitleFormat);

            float summaryHeight = summary.Height;
            summaryHeight = (summaryHeight < 60 ? 60 : summaryHeight);
            summaryHeight += summary.Y;
            g.DrawRectangle(singlePen, new Rectangle((int)dateTextLabel.X - 20, (int)dateTextLabel.Y - 5, (int)(invoiceNumberTextLabel.X - dateTextLabel.X + invoiceNumberTextLabel.Width + 40), (int)(summaryHeight + 15 - invoiceNumberTextLabel.Y)));

            // ---
            g.DrawLine(borderPen, new Point((int)TitleColumn1.X, (int)(summaryHeight) + 10), new Point(pageWidth, (int)(summaryHeight) + 10));

            float columnHeaderY = 0;
            float gap = 0;
            float[] x = new float[dataGridView.Columns.Count];
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                DataGridViewColumn column = dataGridView.Columns[i];
                int width = (pageWidth - 240) * (column.Width + 20) / (dataGridView.Width + 20);
                text = dataGridView.Columns[i].HeaderCell.Value.ToString() + ":";
                RectangleF columnHeader = new RectangleF(TitleColumn1.X + gap, (summaryHeight) + 10, g.MeasureString(text, boldLabelFont).Width, g.MeasureString(text, boldLabelFont).Height);
                g.DrawString(text, boldLabelFont, brush, columnHeader, TitleFormat);
                gap += width;
                x[i] = columnHeader.X + ((i == 0) ? 0 : g.MeasureString(text, boldLabelFont).Width);
                columnHeaderY = columnHeader.Height + columnHeader.Y;
                gap += 30;
            }

            gap = columnHeaderY + 5;
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                if (row.Visible)
                {
                    for (int j = 0; j < x.Length; j++)
                    {
                        text = row.Cells[j].Value.ToString();
                        RectangleF cellValue = new RectangleF(x[j] - ((j == 0) ? 0 : g.MeasureString(text, normalLabelFont).Width), gap, g.MeasureString(text, normalLabelFont).Width, g.MeasureString(text, normalLabelFont).Height);
                        g.DrawString(text, normalLabelFont, brush, cellValue, TitleFormat);
                    }

                    gap += g.MeasureString(text, normalLabelFont).Height + 5;
                }
            }

            // ---
            g.DrawLine(borderPen, new Point((int)TitleColumn1.X, (int)gap + 5), new Point(pageWidth, (int)gap + 5));

            text = totalNetTextLbl.Text;
            RectangleF totalNextTextLable = new RectangleF(pageWidth - 300, gap + 10, g.MeasureString(text, boldLabelFont).Width, g.MeasureString(text, boldLabelFont).Height);
            g.DrawString(text, boldLabelFont, brush, totalNextTextLable, TitleFormat);

            text = totalNetLbl.Text;
            RectangleF totalNextLable = new RectangleF(pageWidth - g.MeasureString(text, normalLabelFont).Width, totalNextTextLable.Y, g.MeasureString(text, normalLabelFont).Width, g.MeasureString(text, normalLabelFont).Height);
            g.DrawString(text, normalLabelFont, brush, totalNextLable, TitleFormat);

            text = vatTextLbl.Text;
            RectangleF vatTextLable = new RectangleF(totalNextTextLable.X, totalNextTextLable.Y + totalNextTextLable.Height + 5, g.MeasureString(text, boldLabelFont).Width, g.MeasureString(text, boldLabelFont).Height);
            g.DrawString(text, boldLabelFont, brush, vatTextLable, TitleFormat);

            text = lblVat.Text;
            RectangleF vatLable = new RectangleF(pageWidth - g.MeasureString(text, normalLabelFont).Width, vatTextLable.Y, g.MeasureString(text, normalLabelFont).Width, g.MeasureString(text, normalLabelFont).Height);
            g.DrawString(text, normalLabelFont, brush, vatLable, TitleFormat);

            text = totalTextLbl.Text;
            RectangleF totalTextLable = new RectangleF(totalNextTextLable.X, vatTextLable.Y + vatTextLable.Height + 5, g.MeasureString(text, boldLabelFont).Width, g.MeasureString(text, boldLabelFont).Height);
            g.DrawString(text, boldLabelFont, brush, totalTextLable, TitleFormat);

            text = lblTotal.Text;
            RectangleF totalLable = new RectangleF(pageWidth - g.MeasureString(text, normalLabelFont).Width, totalTextLable.Y, g.MeasureString(text, normalBoldLabelFont).Width, g.MeasureString(text, normalLabelFont).Height);
            g.DrawString(text, normalBoldLabelFont, brush, totalLable, TitleFormat);
        }

        private void invoiceDueDtp_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                dataGridView_CellEndEdit(dataGridView, new DataGridViewCellEventArgs(0, i));
            }
        }

        private void invoiceDtp_ValueChanged(object sender, EventArgs e)
        {
            dtpInvoiceDue.Value = After10Days;
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            foreach (String printerName in PrinterSettings.InstalledPrinters)
            {
                if (printerName.ToLower().StartsWith("cutepdf"))
                {
                    SetupDialog();
                    printDocument.PrinterSettings.PrinterName = printerName;
                    printDocument.Print();
                    break;
                }
            }
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView_RowsAdded(dataGridView, new DataGridViewRowsAddedEventArgs(0, 0));
        }

        private void cbTax_CheckedChanged(object sender, EventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkbox = (ComponentFactory.Krypton.Toolkit.KryptonCheckBox)sender;
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                row.Cells[Columns.IndexOf("vat")].Value = (checkbox.Checked) ? decimal.Parse(checkbox.Tag.ToString()) : 0.00m;
            }
            calculateTax(cbTax);
        }

        private void calculateTax(ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkbox)
        {
            lblVat.Tag = (checkbox.Checked) ? checkbox.Tag.ToString() : (0.00m).ToString();
            lblVat.Text = calculateProcentAmount().ToString();
        }

        private decimal calculateProcentAmount()
        {
            return decimal.Round(calculateSum("total") * decimal.Parse((String)lblVat.Tag) / 100, 2);
        }

        private void lblVat_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void makeDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand("Update InvoiceDetails set " + cmsInfo.SourceControl.Tag + " = @text", conn);
            command.Parameters.Add("@text", OleDbType.VarWChar).Value = cmsInfo.SourceControl.Text;
            command.ExecuteNonQuery();
            conn.Close();
        }

        private int formHeight;
        private void fileAttacher_Resize(object sender, EventArgs e)
        {
            MinimumSize = new Size(MinimumSize.Width, formHeight + fileAttacher.Height);
        }

        private void fileAttacher_RemoveFile(object sender, EventArgs e)
        {
            if (DialogResult.Yes == KryptonMessageBox.Show(string.Format("Remove {0}?", fileAttacher.btnFileClicked.Text), "Removing attached file", MessageBoxButtons.YesNo))
            {
                item[IndexOf("attached")] = item[IndexOf("attached")].ToString().Replace(fileAttacher.btnFileClicked.Text + ",", "");
                fileAttacher.removeCurrentFileButton();
            }
        }

        private void fileAttacher_AttachFile(object sender, EventArgs e)
        {
            DialogResult result = MainWindow.OpenFileDialog(openFileDialog1);
            if (result == DialogResult.OK) // Test result. 
            {
                string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (item[IndexOf("attached")].ToString().IndexOf(fileName) == -1)
                {
                    item[IndexOf("attached")] += fileName + ",";
                    fileAttacher.createFileButton(fileName);
                }
                else
                {
                    KryptonMessageBox.Show(string.Format("File {0} exists", fileName), "File exists", MessageBoxButtons.OK);
                }
            }
        }
    }
}
