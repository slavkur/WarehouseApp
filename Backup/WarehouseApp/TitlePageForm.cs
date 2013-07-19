using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class TitlePageForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private OleDbConnection conn;

        private DataRow row;

        private float x;
        private float y;
        private SolidBrush brush;
        private StringFormat labelFormat;
        private StringFormat textFormat;

        public event Save_Fields DBUpdate;
        public delegate void Save_Fields(Control[] fields);

        private TextBox tbId;

        private int findColumnIndex(String name)
        {
            return row.Table.Columns.IndexOf(name);
        }

        private void setupPrintDocument()
        {
            PrintDialog dialog = new PrintDialog();
            printDocument.DocumentName = Text;
            printDocument.PrinterSettings = dialog.PrinterSettings;
            printDocument.DefaultPageSettings = dialog.PrinterSettings.DefaultPageSettings;
            printDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
        }

        private PrintDialog SetupDialog()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.AllowCurrentPage = false;
            dialog.AllowPrintToFile = false;
            dialog.AllowSelection = false;
            dialog.AllowSomePages = false;
            dialog.PrintToFile = false;
            dialog.ShowHelp = false;
            dialog.ShowNetwork = false;

            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            setupPrintDocument();

            return dialog;
        }

        public TitlePageForm(DataRow row)
        {
            this.conn = new OleDbConnection(Program.connectionString);
            this.InitializeComponent();
            this.row = row;
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            String arrival = null;
            if (findColumnIndex("arrival") > -1)
                arrival = row[findColumnIndex("arrival")].ToString();

            tbId = new TextBox();
            tbId.Name = "tbId";

            Control[] fields = new Control[] { tbKg, tbM3, tbPkgs, tbComments, tbManager, tbWhNumber, 
                                               tbBookingNumber, tbCcs, tbDescription,
                                               cbStatus, tbConsignor, tbConsignee, tbSituation,
                                               tbDocuments, tbDamage, tbCodes, tbWhPlace, tbContainer, tbId };
            String[] labels = new String[] { "kg_doc", "m3", "cll_doc", "comments", "manager", "wh_number", 
                                             "booking_number", "ccs_number", "description",
                                             "status", "consignor", "consignee", "situation",
                                             "documents", "damage", "codes", "wh_pl", "container", "id" };

            for (int i = 0; i < fields.Length; i++)
            {
                Control control = fields[i];
                control.Tag = row[findColumnIndex(labels[i])];
                control.Text = row[findColumnIndex(labels[i])].ToString();
            }

            if (arrival != null && arrival.Length > 0)
            {
                DateTime arrivalDate;
                DateTime.TryParse(arrival, out arrivalDate);
                this.dtpArrival.Value = arrivalDate;
            }
            else
            {
                this.dtpArrival.Value = DateTime.Now;
            }

            this.dtpArrival.Tag = row[findColumnIndex("arrival")];
        }

        public String CommentText
        {
            get
            {
                return tbComments.Text;
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            foreach (String printerName in PrinterSettings.InstalledPrinters)
            {
                if (printerName.ToLower().StartsWith("cutepdf"))
                {
                    setupPrintDocument();
                    printDocument.PrinterSettings.PrinterName = printerName;
                    printDocument.Print();
                    break;
                }
            }
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            if ((SetupDialog()) != null)
            {
                printDocument.Print();
            }
        }

        private void tsmiPrintPreview_Click(object sender, EventArgs e)
        {
            if ((SetupDialog()) != null)
            {
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = printDocument;
                dialog.ShowDialog();
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void drawString(Graphics g, Control label, ComponentFactory.Krypton.Toolkit.KryptonTextBox textLabel)
        {
            Margins margins = printDocument.DefaultPageSettings.Margins;
            String text = label.Text;
            Font font = new Font(label.Font.FontFamily, label.Font.Size * x, label.Font.Style);
            RectangleF rect = new RectangleF(label.Location.X * x + margins.Left, label.Location.Y * y + margins.Top, g.MeasureString(text, font).Width * x, g.MeasureString(text, font).Height * y);
            g.DrawString(text, font, brush, rect, labelFormat);
            text = textLabel.Text;
            font = new Font(textLabel.StateCommon.Content.Font.FontFamily, textLabel.StateCommon.Content.Font.Size * x, textLabel.StateCommon.Content.Font.Style);
            rect = new RectangleF(textLabel.Location.X * x + margins.Left + textLabel.StateCommon.Content.Padding.All, textLabel.Location.Y * y + margins.Top, g.MeasureString(text, font).Width * x, g.MeasureString(text, font).Height * y);
            g.DrawString(text, font, brush, rect, textFormat);
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Margins margins = printDocument.DefaultPageSettings.Margins;
            PaperSize size = printDocument.DefaultPageSettings.PaperSize;

            this.brush = new SolidBrush(Color.Black);
            this.labelFormat = new StringFormat();
            this.textFormat = new StringFormat();
            this.labelFormat.Trimming = StringTrimming.Word;
            this.labelFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            this.textFormat.Trimming = StringTrimming.Word;
            this.textFormat.FormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            float pageWidth = (float)size.Width - (float)margins.Right - (float)margins.Left;
            float pageHeight = (float)size.Height - (float)margins.Top - (float)margins.Bottom;

            // X/Y cooficients
            this.x = pageWidth / Width;
            this.y = pageHeight / Height;

            // whNumber
            String text = tbWhNumber.Text + "/" + tbBookingNumber.Text;
            Font font = new Font(tbWhNumber.StateCommon.Content.Font.FontFamily, tbWhNumber.StateCommon.Content.Font.Size * x, tbWhNumber.StateCommon.Content.Font.Style);
            RectangleF label = new RectangleF(tbWhNumber.Location.X * x + margins.Left - 6, tbWhNumber.Location.Y * y + margins.Top, g.MeasureString(text, font).Width * x, g.MeasureString(text, font).Height * y);
            g.DrawString(text, font, brush, label, labelFormat);

            // measurer
            text = tbPkgs.Text + "cll/" + tbKg.Text + "kg/" + tbM3.Text + "m3"; ;
            font = new Font(tbPkgs.StateCommon.Content.Font.FontFamily, tbPkgs.StateCommon.Content.Font.Size * x, tbPkgs.StateCommon.Content.Font.Style);
            label = new RectangleF(tbPkgs.Location.X * x + margins.Left - 5, tbPkgs.Location.Y * y + margins.Top - 20, g.MeasureString(text, font).Width * x, g.MeasureString(text, font).Height * y);
            g.DrawString(text, font, brush, label, labelFormat);

            // CCS
            drawString(g, lbCcs, tbCcs);

            // Status
            ComponentFactory.Krypton.Toolkit.KryptonTextBox textbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            textbox.Text = cbStatus.Text;
            textbox.StateCommon.Content.Font = cbStatus.StateCommon.ComboBox.Content.Font;
            textbox.Location = cbStatus.Location;
            drawString(g, lbStatus, textbox);

            // Consignor
            drawString(g, lbConsignor, tbConsignor);

            // Consignee
            drawString(g, lbConsignee, tbConsignee);

            // Comments
            font = new Font(lbComments.Font.FontFamily, lbComments.Font.Size * x, lbComments.Font.Style);
            int pointY = (int)((lbComments.Location.Y + g.MeasureString(lbComments.Text, font).Height) * y);
            g.DrawLine(new Pen(brush), new Point((int)(lbComments.Location.X * x) + margins.Left, pointY), new Point((int)pageWidth, pointY));
            drawString(g, lbComments, tbComments);

            // Arrival
            textbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            textbox.Text = dtpArrival.Text;
            textbox.StateCommon.Content.Font = dtpArrival.StateCommon.Content.Font;
            textbox.StateCommon.Content.Padding = dtpArrival.StateCommon.Content.Padding;
            textbox.Location = dtpArrival.Location;
            drawString(g, lbArrival, textbox);

            // Manager
            drawString(g, lbManager, tbManager);

            // Situation
            drawString(g, lbSituation, tbSituation);

            // Documents
            drawString(g, lbDocuments, tbDocuments);

            // Description
            drawString(g, lbDescription, tbDescription);

            // Damage
            drawString(g, lbDamage, tbDamage);

            // Codes
            drawString(g, lbCodes, tbCodes);

            // Country consignor
            //drawString(g, lbCountryConsignor, lbCountryConsignorValue, x, y, brush, labelFormat, textFormat);

            // Country consignee
            //drawString(g, lbCountryConsignee, lbCountryConsigneeValue, x, y, brush, labelFormat, textFormat);

            // whPlace
            drawString(g, lbWhPlace, tbWhPlace);

            // Container
            drawString(g, lbContainer, tbContainer);
        }

        private void TitlePageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Open();
            DBUpdate(new Control[] { tbKg, null, tbM3, tbPkgs, null, tbBookingNumber, dtpArrival, 
                                               cbStatus, tbConsignor, tbConsignee, tbDescription, tbCcs, tbDamage, 
                                               tbWhNumber, tbWhPlace, tbManager, tbDocuments,
                                               tbSituation, tbCodes, tbComments, tbContainer, 
                                               new Control(row.ItemArray[findColumnIndex("attached")].ToString()), tbId });
            conn.Close();

        }
    }
}
