using System;
using System.Windows.Forms;
using AiTech.Security;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;

namespace Idms
{
    public partial class frmChangePassword : Office2007Form
    {
        public frmChangePassword()
        {
            InitializeComponent();

            this.ConvertEnterToTab();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataIsValid()) return;

                App.CurrentUser.User.Password = txtPassword.Text;

                var writer = new UserAccountDataWriter(App.CurrentUser.User.Username, App.CurrentUser.User);
                writer.SaveChanges();

                App.LogAction("Account", "Changed Password");

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }


        private bool DataIsValid()
        {
            if (App.CurrentUser.User.Password != txtOldPassword.Text)
            {
                MessageDialog.ShowValidationError(txtOldPassword, "Invalid Old Password");
                return false;
            }

            if (txtPassword.Text.Length == 0)
            {
                MessageDialog.ShowValidationError(txtPassword, "Enter Valid Password");
                return false;
            }

            if (txtPassword.Text != txtPassword2.Text)
            {
                MessageDialog.ShowValidationError(txtPassword2, "Password do not match");
                return false;
            }

            return true;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
        }
    }
}