using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class CMRForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private OleDbConnection conn;
        private AutoSuggestControl autoSuggestControl;
        private DataSet dataSet;
        private OleDbDataAdapter adapter;
        private Boolean isNew = true;

        private String createReferenceNumber()
        {
            OleDbCommand command = new OleDbCommand("Select referenceNumber from [CMRInfo]", conn);
            conn.Open();
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            int newIndex = reader.GetInt32(0) + 1;
            command = new OleDbCommand("Update [CMRInfo] set referenceNumber = @referenceNumber", conn);
            command.Parameters.Add("@referenceNumber", OleDbType.Integer).Value = newIndex;
            command.ExecuteNonQuery();
            conn.Close();
            return "CMR" + DateTime.Now.ToString("ddMMyy-" + ((newIndex.ToString().Length == 1) ? "000" : (newIndex.ToString().Length == 2) ? "00" : (newIndex.ToString().Length == 3) ? "0" : "") + newIndex);
        }

        private enum CMRHistory_string
        {
            consignor, consignee, trade_access, carrier, notify_address, trailer_number,
            place_loading, place_discharge, border_crossing, terms_delivery, final_destination,
            special_instruction, issued_at, sender_signature, carrier_instruction, reference_number
        }

        private enum CMRHistory_date { date, date_signed }

        private void __clearFields()
        {
            foreach (Control component in new Control[] { tbReference, tbTradeAccessRef, tbConsignor, 
                                                          tbConsignee, tbNotifyDeliveryAddr, tbCarrier,
                                                          tbTerms, tbTrailerNum, tbBorderCrossing,
                                                          tbPlaceOfLoading, tbPlaceOfDischarge, tbIssuedAt,
                                                          tbFinalDestination, tbSpecialInstruction, tbCarrierInstruction,
                                                          tbSenderSignature })
            {
                component.Text = "";
            };
        }

        private DataTable Table
        {
            get
            {
                return dataSet.Tables["CMRHistory"];
            }
        }

        private DataColumnCollection Columns
        {
            get
            {
                return Table.Columns;
            }
        }

        private String Row_ValueByColumnName(CMRHistory_string name)
        {
            return Row_ValueByColumnName(name.ToString());
        }

        private String Row_ValueByColumnName(CMRHistory_date name)
        {
            return Row_ValueByColumnName(name.ToString());
        }

        private String Row_ValueByColumnName(String name)
        {
            return Table.Rows[0].ItemArray[Columns.IndexOf(name)].ToString();
        }

        public CMRForm(String referenceNumber)
        {
            this.conn = new OleDbConnection(Program.connectionString);
            this.InitializeComponent();
            __clearFields();
            isNew = false;
            dataSet = new DataSet();
            tbReference.Text = referenceNumber;
        }

        public CMRForm(OleDbConnection conn)
        {
            this.conn = conn;
            this.InitializeComponent();
            this.__clearFields();

            this.tbReference.Text = createReferenceNumber();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String text;
            Graphics g = e.Graphics;
            RectangleF textRect;
            Margins margins = printDocument.DefaultPageSettings.Margins;
            PaperSize size = printDocument.DefaultPageSettings.PaperSize;
            int pageWidth = size.Width - margins.Left - margins.Right;
            int pageHeight = size.Height - margins.Top - margins.Bottom;
            Pen borderPen = new Pen(Color.Black, 2);
            Pen singlePen = new Pen(Color.Black, 1);
            Pen redPen = new Pen(Color.Red, 1);
            Pen bluePen = new Pen(Color.Blue, 1);
            Pen pinkPen = new Pen(Color.Pink, 1);
            Pen greenPen = new Pen(Color.Green, 1);
            SolidBrush brush = new SolidBrush(Color.Black);

            int labelGapHeight = 20;
            int textMargin = 3;
            int textTopMargin = labelGapHeight - textMargin;
            double k = pageWidth * 1.00 / (tbTradeAccessRef.Width + tbConsignor.Width);
            StringFormat labelFormat = new StringFormat();
            StringFormat normalFormat = new StringFormat();
            Font labelFont = new Font("Segoe UI", 7, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", float.Parse((tbConsignor.Font.Size * k).ToString()), FontStyle.Regular);
            Font labelCapitalFont = new Font("Segoe UI", 8, FontStyle.Bold);
            Font cmrFont = new Font("Arial", 11, FontStyle.Regular);
            Font titleFont = new Font("Segoe UI", 12, FontStyle.Regular);
            Font bigFont = new Font("Arial", 34, FontStyle.Regular);

            labelFormat.Trimming = StringTrimming.Word;
            labelFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            normalFormat.Trimming = StringTrimming.Word;
            normalFormat.FormatFlags = StringFormatFlags.LineLimit;

            int Top = margins.Top + 35;
            pageHeight -= Top - margins.Top;

            Rectangle topLogoRect = new Rectangle(margins.Left + pageWidth - 45, margins.Top, 45, 30);
            g.DrawEllipse(borderPen, topLogoRect);
            text = "cmr".ToUpper();
            textRect = new RectangleF(topLogoRect.X + textMargin, topLogoRect.Y + topLogoRect.Height / 4, g.MeasureString(text, cmrFont).Width, g.MeasureString(text, cmrFont).Height);
            g.DrawString(text, cmrFont, brush, textRect, normalFormat);

            text = "International waybill".ToUpper();
            textRect = new RectangleF(margins.Left + (int)(tbConsignor.Width * k), textRect.Y, g.MeasureString(text, titleFont).Width, g.MeasureString(text, titleFont).Height);
            g.DrawString(text, titleFont, brush, textRect, normalFormat);

            g.DrawRectangle(borderPen, new Rectangle(margins.Left, Top, pageWidth, pageHeight));

            // Consignor
            Rectangle consignorRect = new Rectangle(margins.Left, Top, (int)(tbConsignor.Width * k), (int)(tbConsignor.Height * k) + labelGapHeight);
            g.DrawRectangle(singlePen, consignorRect);
            text = lblConsignor.Text.Replace(":", "");
            textRect = new RectangleF(consignorRect.X + textMargin, consignorRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbConsignor.Text;
            textRect = new RectangleF(margins.Left + textMargin, Top + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Date
            Rectangle dateRect = new Rectangle(consignorRect.X + consignorRect.Width, consignorRect.Y, 0, 0);
            text = "Date";
            textRect = new RectangleF(dateRect.X + textMargin, dateRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = dtpDate.Text;
            textRect = new RectangleF(dateRect.X + textMargin, dateRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Reference No.
            Rectangle referenceRect = new Rectangle(consignorRect.X + consignorRect.Width + (int)(tbTradeAccessRef.Width * k) / 2, consignorRect.Y, 0, 0);
            text = lblReference.Text;
            textRect = new RectangleF(referenceRect.X + textMargin, referenceRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbReference.Text;
            textRect = new RectangleF(referenceRect.X + textMargin, referenceRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Trade access
            Rectangle tradeAccessRect = new Rectangle((int)(margins.Left + tbConsignor.Width * k), (int)(Top + ((tbConsignor.Height - tbTradeAccessRef.Height) * k)), (int)(tbTradeAccessRef.Width * k) + 1, (int)(tbTradeAccessRef.Height * k) + labelGapHeight);
            g.DrawRectangle(singlePen, tradeAccessRect);
            text = lblTradeAccessRef.Text.Replace(":", "");
            textRect = new RectangleF(tradeAccessRect.X + textMargin, tradeAccessRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbTradeAccessRef.Text;
            textRect = new RectangleF(tradeAccessRect.X + textMargin, tradeAccessRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Consignee
            Rectangle consigneeRect = new Rectangle(consignorRect.X, consignorRect.Y + consignorRect.Height, consignorRect.Width, 0);
            text = lblConsignee.Text.Replace(":", "");
            textRect = new RectangleF(consigneeRect.X + textMargin, consigneeRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbConsignee.Text;
            textRect = new RectangleF(consigneeRect.X + textMargin, consigneeRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Carrier
            Rectangle carrierRect = new Rectangle((int)(margins.Left + tbConsignor.Width * k), (int)(Top + tbConsignor.Height * k) + labelGapHeight, (int)(tbCarrier.Width * k) + 1, (int)((tbConsignee.Height + tbNotifyDeliveryAddr.Height) * k) + labelGapHeight * 2);
            g.DrawRectangle(singlePen, carrierRect);
            text = lblCarrier.Text.Replace(":", "");
            textRect = new RectangleF(carrierRect.X + textMargin, carrierRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbCarrier.Text;
            textRect = new RectangleF(carrierRect.X + textMargin, carrierRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);


            // Notify/Delivery address
            Rectangle notifyDeliveryRect = new Rectangle(margins.Left, (int)(Top + (tbConsignor.Height + tbConsignee.Height) * k) + labelGapHeight * 2, (int)(tbNotifyDeliveryAddr.Width * k), (int)(tbNotifyDeliveryAddr.Height * k) + labelGapHeight);
            g.DrawRectangle(singlePen, notifyDeliveryRect);
            text = lblNotifyAddress.Text.Replace(":", "");
            textRect = new RectangleF(notifyDeliveryRect.X + textMargin, notifyDeliveryRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbNotifyDeliveryAddr.Text;
            textRect = new RectangleF(notifyDeliveryRect.X + textMargin, notifyDeliveryRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Terms of delivery
            Rectangle termsOfDeliveryRect = new Rectangle((int)(margins.Left + tbNotifyDeliveryAddr.Width * k), (int)(Top + (tbConsignor.Height + tbConsignee.Height + tbNotifyDeliveryAddr.Height) * k) + labelGapHeight * 3, (int)(tbCarrier.Width * k) + 1, (int)((tbPlaceOfLoading.Height + tbBorderCrossing.Height + tbFinalDestination.Height) * k) + labelGapHeight * 3);
            g.DrawRectangle(singlePen, termsOfDeliveryRect);
            text = lblTerms.Text.Replace(":", "");
            textRect = new RectangleF(termsOfDeliveryRect.X + textMargin, termsOfDeliveryRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbTerms.Text;
            textRect = new RectangleF(termsOfDeliveryRect.X + textMargin, termsOfDeliveryRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Trailer number
            Rectangle trailerNumRect = new Rectangle(margins.Left, notifyDeliveryRect.Y + notifyDeliveryRect.Height, 0, 0);
            text = lblTrailerNum.Text.Replace(":", "");
            textRect = new RectangleF(trailerNumRect.X + textMargin, trailerNumRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbTrailerNum.Text;
            textRect = new RectangleF(trailerNumRect.X + textMargin, trailerNumRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Place of loading
            Rectangle placeOfLoadingRect = new Rectangle((int)(margins.Left + (tbConsignor.Width - tbBorderCrossing.Width) * k), (int)(Top + (tbConsignor.Height + tbConsignee.Height + tbNotifyDeliveryAddr.Height) * k) + labelGapHeight * 3, (int)(tbPlaceOfLoading.Width * k) + 1, (int)(tbPlaceOfLoading.Height * k) + labelGapHeight);
            g.DrawRectangle(singlePen, placeOfLoadingRect);
            text = lblPlaceOfLoading.Text.Replace(":", "");
            textRect = new RectangleF(placeOfLoadingRect.X + textMargin, placeOfLoadingRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbPlaceOfLoading.Text;
            textRect = new RectangleF(placeOfLoadingRect.X + textMargin, placeOfLoadingRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Border crossing
            Rectangle borderCrossingRect = new Rectangle(placeOfLoadingRect.X, (int)(Top + (tbConsignor.Height + tbConsignee.Height + tbNotifyDeliveryAddr.Height + tbPlaceOfLoading.Height) * k) + labelGapHeight * 4, (int)(tbBorderCrossing.Width * k) + 1, (int)((tbBorderCrossing.Height + tbFinalDestination.Height) * k) + labelGapHeight * 2);
            g.DrawRectangle(singlePen, borderCrossingRect);
            text = lblBorderCrossing.Text.Replace(":", "");
            textRect = new RectangleF(borderCrossingRect.X + textMargin, borderCrossingRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbBorderCrossing.Text;
            textRect = new RectangleF(borderCrossingRect.X + textMargin, borderCrossingRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Place of discharge
            Rectangle placeOfDischargeRect = new Rectangle(margins.Left, (int)(Top + (tbConsignor.Height + tbConsignee.Height + tbNotifyDeliveryAddr.Height + tbPlaceOfLoading.Height + tbBorderCrossing.Height) * k) + labelGapHeight * 5, (int)(tbConsignor.Width * k), (int)(tbPlaceOfDischarge.Height * k) + labelGapHeight);
            g.DrawRectangle(singlePen, placeOfDischargeRect);
            text = lblPlaceOfDischarge.Text.Replace(":", "");
            textRect = new RectangleF(placeOfDischargeRect.X + textMargin, placeOfDischargeRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbPlaceOfDischarge.Text;
            textRect = new RectangleF(placeOfDischargeRect.X + textMargin, placeOfDischargeRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Final destination
            Rectangle finalDestinationRect = new Rectangle(borderCrossingRect.X, borderCrossingRect.Y + borderCrossingRect.Height - placeOfDischargeRect.Height, 0, 0);
            text = lblFinalDestination.Text.Replace(":", "");
            textRect = new RectangleF(finalDestinationRect.X + textMargin, finalDestinationRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbFinalDestination.Text;
            textRect = new RectangleF(finalDestinationRect.X + textMargin, finalDestinationRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            //

            int left = 0;
            int[] columnWidth = new int[dataGridView.Columns.Count];
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                left += textMargin;
                columnWidth[column.Index] = left;
                text = column.HeaderText;
                textRect = new RectangleF(margins.Left + left, termsOfDeliveryRect.Y + termsOfDeliveryRect.Height + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
                g.DrawString(text, labelFont, brush, textRect, labelFormat);
                left += column.Width;
            }

            int ysum = termsOfDeliveryRect.Y + termsOfDeliveryRect.Height + textTopMargin;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        text = cell.Value.ToString();
                        textRect = new RectangleF(margins.Left + columnWidth[cell.ColumnIndex], ysum, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
                        g.DrawString(text, normalFont, brush, textRect, normalFormat);
                    }
                }

                ysum += (int)(row.Height * k) + textMargin;
            }

            // Carriers unstructions
            Rectangle carriersInstructionsRect = new Rectangle((int)(margins.Left + tbConsignor.Width * k), (int)(Top + pageHeight - (tbSenderSignature.Height * 3 + tbIssuedAt.Height) * k) - labelGapHeight * 3, (int)(tbCarrier.Width * k) + 1, (int)(tbSenderSignature.Height * k * 2) + 1 + labelGapHeight);
            text = lblCarrierInstruction.Text;
            textRect = new RectangleF(carriersInstructionsRect.X + textMargin, carriersInstructionsRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbCarrierInstruction.Text;
            textRect = new RectangleF(carriersInstructionsRect.X + textMargin, carriersInstructionsRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Special instruction
            Rectangle specialInstructionRect = new Rectangle(margins.Left, carriersInstructionsRect.Y - (int)(tbSpecialInstruction.Height * k) - labelGapHeight, 0, 0);
            text = lblSpecialInstruction.Text.Replace(":", "");
            textRect = new RectangleF(specialInstructionRect.X + textMargin, specialInstructionRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbSpecialInstruction.Text;
            textRect = new RectangleF(specialInstructionRect.X + textMargin, specialInstructionRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // CMR
            Rectangle cmrRect = new Rectangle(margins.Left, carriersInstructionsRect.Y, (int)(tbConsignor.Width * k), 70);
            Rectangle cmrLogoRect = new Rectangle(cmrRect.X + cmrRect.Width / 3, cmrRect.Y + 2, cmrRect.Width / 3, cmrRect.Height - 5);
            g.DrawEllipse(borderPen, cmrLogoRect);
            text = "cmr".ToUpper();
            textRect = new RectangleF(cmrLogoRect.X - 5, cmrLogoRect.Y + 5, g.MeasureString(text, bigFont).Width, g.MeasureString(text, bigFont).Height);
            g.DrawString(text, bigFont, brush, textRect, normalFormat);

            // Agreement
            Rectangle agreementRect = new Rectangle(margins.Left, carriersInstructionsRect.Y + cmrRect.Height, cmrRect.Width, carriersInstructionsRect.Height - cmrRect.Height);
            text = "This consignment will be carried in accordance with carrier's General\r\nTransport and Liability Conditions. The carrier is liable to CMR.\r\nThe transport liability is covered by carrier's insurance company.";
            textRect = new RectangleF(agreementRect.X + textMargin, agreementRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);

            // Receiver Date
            Rectangle receiverDateRect = new Rectangle(margins.Left, (int)(Top + pageHeight - (tbSenderSignature.Height + tbIssuedAt.Height) * k) - labelGapHeight * 2, pageWidth / 3, (int)(tbIssuedAt.Height * k) + labelGapHeight);
            text = "Date";
            textRect = new RectangleF(receiverDateRect.X + textMargin, receiverDateRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);

            // Driver Date 
            Rectangle driverDateRect = new Rectangle(margins.Left + (pageWidth - (pageWidth / 3) * 2), receiverDateRect.Y, 0, 0);
            text = "Date";
            textRect = new RectangleF(driverDateRect.X + textMargin, driverDateRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = dtpDate2.Text;
            textRect = new RectangleF(driverDateRect.X + textMargin, driverDateRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Issued at
            Rectangle issuedAtRect = new Rectangle(margins.Left + pageWidth - pageWidth / 3, (int)(Top + pageHeight - (tbSenderSignature.Height + tbIssuedAt.Height) * k) - labelGapHeight * 2, pageWidth / 3, (int)(tbIssuedAt.Height * k) + labelGapHeight);
            text = lblIssuedAt.Text.Replace(":", "");
            textRect = new RectangleF(issuedAtRect.X + textMargin, issuedAtRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbIssuedAt.Text;
            textRect = new RectangleF(issuedAtRect.X + textMargin, issuedAtRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            // Receiver Signature
            Rectangle receiverSignatureRect = new Rectangle(margins.Left, (int)(pageHeight + Top - tbSenderSignature.Height * k) - labelGapHeight, 0, 0);
            text = "Receiver's signature";
            textRect = new RectangleF(receiverSignatureRect.X + textMargin, receiverSignatureRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);

            // Driver Signature
            Rectangle driverSignatureRect = new Rectangle(margins.Left + pageWidth / 3, (int)(pageHeight + Top - tbSenderSignature.Height * k) - labelGapHeight, pageWidth / 3, (int)(tbSenderSignature.Height * k) + 1 + labelGapHeight);
            text = "Driver/terminal signature";
            textRect = new RectangleF(driverSignatureRect.X + textMargin, driverSignatureRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);

            // Sender Signature
            Rectangle senderSignatureRect = new Rectangle(margins.Left + pageWidth - (pageWidth / 3), driverSignatureRect.Y, driverSignatureRect.Width, driverSignatureRect.Height);
            text = lblSenderSignature.Text.Replace(":", "");
            textRect = new RectangleF(senderSignatureRect.X + textMargin, senderSignatureRect.Y + textMargin, g.MeasureString(text, labelFont).Width, g.MeasureString(text, labelFont).Height);
            g.DrawString(text, labelFont, brush, textRect, labelFormat);
            text = tbSenderSignature.Text;
            textRect = new RectangleF(senderSignatureRect.X + textMargin, senderSignatureRect.Y + textTopMargin, g.MeasureString(text, normalFont).Width, g.MeasureString(text, normalFont).Height);
            g.DrawString(text, normalFont, brush, textRect, normalFormat);

            text = "As agent only".ToUpper();
            textRect = new RectangleF(senderSignatureRect.X + textMargin, senderSignatureRect.Y + senderSignatureRect.Height - g.MeasureString(text, labelCapitalFont).Height, g.MeasureString(text, labelCapitalFont).Width, g.MeasureString(text, labelCapitalFont).Height);
            g.DrawString(text, labelCapitalFont, brush, textRect, normalFormat);

            g.DrawRectangles(singlePen, new Rectangle[] { cmrRect, agreementRect, carriersInstructionsRect, driverSignatureRect, receiverDateRect, issuedAtRect });
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

            printDocument.PrinterSettings = dialog.PrinterSettings;
            printDocument.DefaultPageSettings = dialog.PrinterSettings.DefaultPageSettings;
            printDocument.DefaultPageSettings.Margins = new Margins(38, 38, 20, 40);

            return dialog;
        }

        private void CMRForm_Load(object sender, EventArgs e)
        {
            if (!isNew)
            {
                adapter = new OleDbDataAdapter("select * from CMRHistory where reference_number like @referenceNumber", conn);
                adapter.SelectCommand.Parameters.Add("@referenceNumber", OleDbType.VarWChar).Value = tbReference.Text;
                adapter.Fill(dataSet, "CMRHistory");
                conn.Close();

                tbConsignor.Text = Row_ValueByColumnName(CMRHistory_string.consignor);
                tbConsignee.Text = Row_ValueByColumnName(CMRHistory_string.consignee);
                dtpDate.Value = DateTime.Parse(Row_ValueByColumnName(CMRHistory_date.date));
                tbTradeAccessRef.Text = Row_ValueByColumnName(CMRHistory_string.trade_access);
                tbCarrier.Text = Row_ValueByColumnName(CMRHistory_string.carrier);
                tbNotifyDeliveryAddr.Text = Row_ValueByColumnName(CMRHistory_string.notify_address);
                tbTrailerNum.Text = Row_ValueByColumnName(CMRHistory_string.trailer_number);
                tbPlaceOfLoading.Text = Row_ValueByColumnName(CMRHistory_string.place_loading);
                tbPlaceOfDischarge.Text = Row_ValueByColumnName(CMRHistory_string.place_discharge);
                tbBorderCrossing.Text = Row_ValueByColumnName(CMRHistory_string.border_crossing);
                tbTerms.Text = Row_ValueByColumnName(CMRHistory_string.terms_delivery);
                tbFinalDestination.Text = Row_ValueByColumnName(CMRHistory_string.final_destination);
                tbSpecialInstruction.Text = Row_ValueByColumnName(CMRHistory_string.special_instruction);
                dtpDate2.Value = DateTime.Parse(Row_ValueByColumnName(CMRHistory_date.date_signed));
                tbIssuedAt.Text = Row_ValueByColumnName(CMRHistory_string.issued_at);
                tbSenderSignature.Text = Row_ValueByColumnName(CMRHistory_string.sender_signature);
                tbCarrierInstruction.Text = Row_ValueByColumnName(CMRHistory_string.carrier_instruction);

                MainWindow.DataGridView_Serialize(dataGridView, Table, "packages_kind,gross_weight");
            }

            this.autoSuggestControl = new AutoSuggestControl(conn, "CMRData", new TextBox[] { tbConsignor, 
                tbConsignee, tbCarrier, tbNotifyDeliveryAddr, tbTrailerNum,
                tbPlaceOfLoading, tbPlaceOfDischarge, tbBorderCrossing, tbTerms,
                tbFinalDestination, tbIssuedAt, tbSenderSignature });
            this.kryptonPanel.Controls.Add(autoSuggestControl);
            autoSuggestControl.BringToFront();
        }

        private String StringArray_join(String[] CMRHistory_string_names, String preface, String afterface, String[] values)
        {
            String final = "";
            int i = 0;
            foreach (String str in CMRHistory_string_names)
            {
                String value = (values != null && values.Length > 0 && values[i] != null) ? values[i] : "";
                final += preface + str + afterface + value + ",";
                i++;
            }

            return final.Substring(0, final.Length - 1);
        }

        private void CMRForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            autoSuggestControl.saveFields();
            conn.Open();
            String[] CMRHistory_string_names = Enum.GetNames(typeof(CMRHistory_string));
            String[] CMRHistory_date_names = Enum.GetNames(typeof(CMRHistory_date));
            OleDbCommand saveCommand;
            String[] CMRHistory_string_values = new String[] { tbConsignor.Text, tbConsignee.Text, tbTradeAccessRef.Text, tbCarrier.Text,
                                                               tbNotifyDeliveryAddr.Text, tbTrailerNum.Text, tbPlaceOfLoading.Text, tbPlaceOfDischarge.Text,
                                                               tbBorderCrossing.Text, tbTerms.Text, tbFinalDestination.Text, tbSpecialInstruction.Text, 
                                                               tbIssuedAt.Text, tbSenderSignature.Text, tbCarrierInstruction.Text, tbReference.Text};
            String[] CMRHistory_date_values = new String[] { dtpDate.Value.ToString(), dtpDate2.Value.ToString() };

            if (isNew)
                saveCommand = new OleDbCommand("insert into CMRHistory (" + StringArray_join(CMRHistory_string_names, "[", "]", null) + "," + StringArray_join(CMRHistory_date_names, "[", "]", null) + ",packages_kind,gross_weight) values(" + StringArray_join(CMRHistory_string_names, "@", "", null) + "," + StringArray_join(CMRHistory_date_names, "@", "", null) + ",@packages_kind,@gross_weight)", conn);
            else
                saveCommand = new OleDbCommand("update CMRHistory set " + StringArray_join(CMRHistory_string_names, "[", "]=@", CMRHistory_string_names) + "," + StringArray_join(CMRHistory_date_names, "[", "]=@", CMRHistory_date_names) + ",packages_kind=@packages_kind,gross_weight=@gross_weight where reference_number = @reference_number", conn);
            for (int i = 0; i < CMRHistory_string_names.Length; i++)
            {
                String name = CMRHistory_string_names[i];
                saveCommand.Parameters.Add("@" + name, OleDbType.VarWChar).Value = CMRHistory_string_values[i];
            }
            for (int i = 0; i < CMRHistory_date_names.Length; i++)
            {
                String name = CMRHistory_date_names[i];
                saveCommand.Parameters.Add("@" + name, OleDbType.DBTimeStamp).Value = DateTime.Parse(CMRHistory_date_values[i]);
            }

            MainWindow.DataGridView_Deserialize(dataGridView, saveCommand.Parameters);
            saveCommand.ExecuteNonQuery();
            conn.Close();
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
    }
}
