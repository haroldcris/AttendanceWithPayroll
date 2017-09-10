using System;
using System.Diagnostics;
using System.Windows.Forms;
using AiTech.Security;
using AiTech.Tools.Winform;
using Library.Tools;

namespace Winform.Accounts
{
    public partial class frmAccount_Add : FormWithHeader, ISave
    {
        public frmAccount_Add()
        {
            InitializeComponent();

            LoadRoles();


            #region Initialize DirtyHandler

            DirtyStatus = new DirtyFormHandler(this);

            this.AskToSaveOnDirtyClosing();
            this.ConvertEnterToTab();
            Load += (s, e) =>
            {
                ShowData();
                DirtyStatus.Clear();
            };

            CancelButton = btnCancel;
            btnOk.Click += (s, e) => FileSave();

            #endregion
        }

        public UserAccount ItemData { get; set; }
        public DirtyFormHandler DirtyStatus { get; }


        public bool FileSave()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!DataIsValid()) return false;

                ItemData.Username = txtUsername.Text.Trim();
                ItemData.Password = txtPassword.Text;
                ItemData.RoleClass = (Role) cboRole.SelectedItem;
                ItemData.RoleId = ((Role) cboRole.SelectedItem).Id;


                var dataWriter = new UserAccountDataWriter(App.CurrentUser.User.Username, ItemData);
                dataWriter.SaveChanges();

                DirtyStatus.Clear();

                DialogResult = DialogResult.OK;

                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
                return false;
            }
        }

        private void LoadRoles()
        {
            var roleReader = new RoleDataReader();
            var roles = roleReader.GetAllRoleNames();

            InputControls.LoadToComboBox(cboRole, roles);
        }

        private void ShowData()
        {
            if (ItemData == null) return;
            txtUsername.Text = ItemData.Username;

            txtPassword.Text = ItemData.Password;
            txtConfirmPassword.Text = ItemData.Password;

            Debug.WriteLine(cboRole.Items.Count);

            foreach (var item in cboRole.Items)
            {
                if (item.ToString() != ItemData.RoleClass.RoleName) continue;
                cboRole.SelectedItem = item;
                break;
            }
            cboRole.SelectedText = ItemData.RoleClass.RoleName;
        }


        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageDialog.ShowValidationError(txtUsername, "Username must not be blank");
                return false;
            }

            if (cboRole.SelectedIndex == -1)
            {
                MessageDialog.ShowValidationError(cboRole, "Select Role for this user");
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageDialog.ShowValidationError(txtPassword, "Password must not be blank");
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageDialog.ShowValidationError(txtPassword, "Passwords do not match");
                return false;
            }


            var reader = new UserAccountDataReader();
            var item = reader.GetItemWithUsername(txtUsername.Text.Trim());

            if (item != null && item.Id != ItemData.Id)
            {
                MessageDialog.ShowValidationError(txtUsername, "Duplicate Position Code Exist!");
                return false;
            }

            return true;
        }
    }
}