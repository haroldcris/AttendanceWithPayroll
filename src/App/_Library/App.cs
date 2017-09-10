using System.Diagnostics;
using System.Reflection;
using AiTech.Security;
using Dll;
using Winform;

public static partial class App
{
    public static frmMain MdiMainForm;

    public static string CurrentVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
        var version = fvi.FileVersion;
        return version;
    }


    public static void LogAction(string module, string action)
    {
        ActionLog.Log(module, action, CurrentUser.User.Username);
    }


    public static class CurrentUser
    {
        internal static UserAccount User { get; set; }
        internal static CredentialToken Token { get; set; }
    }
}