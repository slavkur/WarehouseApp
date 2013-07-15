using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Windows.Forms;

///targetdir="[TARGETDIR]\"
namespace WarehouseApp
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary stateSaver)
        {
            File.Delete(System.IO.Path.Combine(Context.Parameters["targetdir"].ToString(), "whouse.mdb"));
            base.Commit(stateSaver);
        }

        public override void Uninstall(IDictionary stateSaver)
        {
            File.Delete(System.IO.Path.Combine(Context.Parameters["targetdir"].ToString(), "whouse.mdb"));
            base.Uninstall(stateSaver);
        }
    }
}
