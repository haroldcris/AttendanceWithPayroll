using AiTech.Account;
using System.Diagnostics;

namespace My
{
    public static partial class App
    {
        public static string CurrentVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }


        public static class CurrentUser
        {
            internal static AccountUser User { get; set; }
            internal static AccountToken Token { get; set; }
        }

        public static Winform.frmMain MainForm;

    }
}