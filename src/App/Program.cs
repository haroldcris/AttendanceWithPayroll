using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var login = new frmLogin();
            var response = login.ShowDialog();

            if (response == DialogResult.OK)
                try
                {
                    Application.Run(new frmMain());
                }
                catch (Exception ex)
                {
                    App.Message.ShowError(ex, null);
                }
        }
    }
}
