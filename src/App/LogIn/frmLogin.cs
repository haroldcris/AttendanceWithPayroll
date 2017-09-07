using AiTech.LiteOrm.Database;
using AiTech.Security;
using AiTech.Tools.Winform;
using System;
using System.Windows.Forms;

namespace Winform
{
    public sealed partial class frmLogin : DevComponents.DotNetBar.Metro.MetroForm //DevComponents.DotNetBar.OfficeForm
    {
        public frmLogin()
        {
            InitializeComponent();
            Text = @"Megabyte College";

            lblStatus.Text = "";
            //lblStatus.Text = "Version : " + My.App.CurrentVersion();

            this.ConvertEnterToTab();
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnConnectingProcess(bool status)
        {
            pbLogin.Visible = status;
            pbLogin.Refresh();

            lblUsername.Enabled = !status;
            txtUsername.Enabled = !status;

            lblPassword.Enabled = !status;
            txtPassword.Enabled = !status;

            btnLogIn.Enabled = !status;
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {

                lblError.Text = @"<b>Connecting to Server.</b><br/>Please Wait...";
                OnConnectingProcess(true);

                var loginService = new AuthenticationService(Connection.CreateConnection().ConnectionString);

                var user = await loginService.AuthenticateAsync(txtUsername.Text, txtPassword.Text);

                if (user == null)
                {
                    OnConnectingProcess(false);
                    lblError.Text = @"<font color='Red'><b>Invalid Credential.</b><br/>Username or Password is Invalid</font>";
                    txtUsername.Focus(); txtUsername.SelectAll();
                    txtPassword.SelectAll();
                    return;
                }


                var token = loginService.GetCredentialToken(user.Username);

                App.CurrentUser.User = user;
                App.CurrentUser.Token = token;


                App.CurrentUser.User.RoleClass.RolePrivileges.LoadItemsFromDb();

                App.LogAction("Account", "Logged In");

                pbLogin.Visible = false;
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                OnConnectingProcess(false);
                lblError.Text = $@"<font color='Red'>{ex.GetBaseException().Message}</font>";// ex.GetBaseException().Message;
                txtUsername.Focus();
            }
        }


    }
}
