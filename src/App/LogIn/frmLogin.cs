using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AiTech.Account;

namespace Winform
{
    public partial class frmLogin : DevComponents.DotNetBar.Metro.MetroForm //DevComponents.DotNetBar.OfficeForm
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Text = "Megabyte College";

            lblStatus.Text = "";
            //lblStatus.Text = "Version : " + My.App.CurrentVersion();
        }


        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.HandleEnterKey(this, e);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnConnectingProcess(bool status )
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

                var user =  await Credential.AuthenticateAsync(txtUsername.Text, txtPassword.Text );

                if (user == null)
                {
                    OnConnectingProcess(false);
                    lblError.Text = @"<font color='Red'><b>Invalid Credential.</b><br/>Username or Password is Invalid</font>";
                    txtUsername.Focus(); txtUsername.SelectAll();
                    txtPassword.SelectAll();
                    return;
                }

                pbLogin.Visible = false;

                var token = Credential.GetAppToken(user);
                
                My.App.CurrentUser.User = user;
                My.App.CurrentUser.Token = token;
                
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                OnConnectingProcess(false);
                lblError.Text = $"<font color='Red'>{ex.GetBaseException().Message}</font>";// ex.GetBaseException().Message;
                //App.Message.ShowError(ex, this);
            }
        }

       
    }
}
