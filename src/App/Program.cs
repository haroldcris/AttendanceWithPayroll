using AiTech.Tools.Winform;
using System;
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

                    App.LogAction("Main", "Closed Application");
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, null);
                }
        }
    }
}
