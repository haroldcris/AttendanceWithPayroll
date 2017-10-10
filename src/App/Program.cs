using AiTech.Tools.Winform;
using System;
using System.Windows.Forms;

namespace Winform
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //var frm = new Winform.SchoolYear.Section.frmSectionSelector();
            //frm.ShowDialog();

            //return;


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
                    Application.ExitThread();
                }
        }
    }
}