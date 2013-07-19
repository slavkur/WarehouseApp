using System;
using System.Windows.Forms;

namespace WarehouseApp
{
    static class Program
    {
        public static String connectionString;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Properties.Settings settings = Properties.Settings.Default;
# if(DEBUG)
            connectionString = settings.Debug + "";
# else
            connectionString = settings.Release;
# endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
