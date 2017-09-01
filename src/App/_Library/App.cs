using AiTech.Security;
using Dll;
using System.Diagnostics;

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
        internal static UserAccount User { get; set; }
        internal static CredentialToken Token { get; set; }
    }


    public static void LogAction(string module, string action)
    {
        ActionLog.Log(module, action, CurrentUser.User.Username);
    }

    public static Winform.frmMain MdiMainForm;

}
