using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Idms
{
    public partial class frmChangePassword : DevComponents.DotNetBar.Office2007Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            //var response = App.CurrentUser.ChangePassword(txtOldPassword.Text, txtPassword.Text);

            //if (!response)
            //{
            //    App.Message.ShowValidationError(txtPassword, "Password Change NOT successful");
            //    return;
            //}

            DialogResult = DialogResult.OK;
        }


        private bool IsValidInput()
        {
            if(App.CurrentUser.Password != txtOldPassword.Text)
            {
                App.Message.ShowValidationError(txtOldPassword, "Invalid Old Password");
                return false;
            }

            if(txtPassword.Text.Length == 0)
            {
                App.Message.ShowValidationError(txtPassword, "Enter Valid Password");
                return false;
            }

            if(txtPassword.Text != txtPassword2.Text)
            {
                App.Message.ShowValidationError(txtPassword2, "Password do not match");
                return false;
            }

            return true;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
           
        }

        private void frmChangePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.Helper.HandleEnterKey(this, e);
        }
    }
}
