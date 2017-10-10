using System;
using System.Windows.Forms;
using Winform;

namespace BiometricMonitor
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



            using (var frm = new frmOption())
            {
                var optionSelected = 0;
                if (frm.ShowDialog() != DialogResult.OK) return;

                optionSelected = frm.OptionSelected;
                if (optionSelected == 1)
                {
                    Application.Run(new Form1());
                    //Application.Run(new frmSmsMonitor());
                }
                else
                {
                    Application.Run(new frmOutputWindow());
                }

            }


        }
    }
}
