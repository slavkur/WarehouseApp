using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Drawing;

namespace WarehouseApp
{
    public partial class FileAttacher : UserControl
    {
        public delegate void Event(object sender, EventArgs e);
        
        public event Event AttachFile;
        public event Event RemoveFile;

        public FileAttacher()
        {
            InitializeComponent();
        }

        void FileAttacher_RemoveFile(object sender, EventArgs e)
        {
            //
        }

        void FileAttacher_AttachFile(object sender, EventArgs e)
        {
            //
        }

        void fileBtn_Click(object sender, EventArgs e)
        {
            MainWindow.FileOpen(((KryptonDropButton)sender).Text);
        }

        public void removeCurrentFileButton()
        {
            flowLayoutPanel1.Controls.RemoveByKey(btnFileClicked.Name);
        }

        public void createFileButton(String fileName)
        {
            KryptonDropButton button = new KryptonDropButton();
            button.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom1;
            button.ContextMenuStrip = this.contextMenuStrip1;
            button.OverrideDefault.Back.Color1 = System.Drawing.Color.Transparent;
            button.OverrideDefault.Back.Color2 = System.Drawing.Color.Transparent;
            button.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            button.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            button.StateNormal.Back.Color2 = System.Drawing.Color.Transparent;
            button.StateNormal.Border.Color1 = System.Drawing.Color.Transparent;
            button.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            button.Values.Image = global::WarehouseApp.Properties.Resources.page_attach;
            button.DropDown += new EventHandler<ContextPositionMenuArgs>(btnFile_DropDown);

            button.Text = fileName;
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
                //Console.WriteLine((int)graphics.MeasureString(button.Text, button.StateCommon.BackFont).Width);
                button.MinimumSize = new System.Drawing.Size((int)graphics.MeasureString(button.Text, new Font(button.Font.FontFamily, button.Font.Size, GraphicsUnit.Pixel)).Width + 60, 25);
            }

            button.Click += new EventHandler(fileBtn_Click);
            flowLayoutPanel1.Controls.Add(button);
            button.Name = "btnFile" + flowLayoutPanel1.Controls.IndexOf(button).ToString();
        }

        public KryptonDropButton btnFileClicked;
        private void btnFile_DropDown(object sender, ContextPositionMenuArgs e)
        {
            KryptonDropButton button = (KryptonDropButton)sender;
            btnFileClicked = button;
        }

        public void displayAttached(string[] attachedFiles)
        {
            foreach (String fileName in attachedFiles)
            {
                if (fileName.Length > 0)
                {
                    createFileButton(fileName);
                }
            }
        }

        private void FileAttacher_Load(object sender, EventArgs e)
        {
            try
            {
                btnAttach.Click += new EventHandler(AttachFile);
                tsmiRemove.Click += new EventHandler(RemoveFile);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.StackTrace);
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            Size = new Size(flowLayoutPanel1.Width, flowLayoutPanel1.Height);
        }
    }
}
