using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SmartData;
using SmartData.Account;
using System.Linq;

namespace SmartApp
{
    public partial class frmUserAccounts_Add : DevComponents.DotNetBar.OfficeForm
    {
        public new frmUserAccounts ParentForm { get; set; }
        public UserAccount CurrentUserAccount { get; set; }

        private UserAccountEmployee CurrentAssociateEmployee = null;

        public bool InEditMode { get; set; }

        public Batch Batch { get; set; }

        public frmUserAccounts_Add(frmUserAccounts parent)
        {
            InitializeComponent();

            ParentForm = parent;
            Batch = null;
            
            highlighter1.SetHighlightOnFocus(txtUsername, true);
            highlighter1.SetHighlightOnFocus(txtPassword, true);
            highlighter1.SetHighlightOnFocus(txtPassword, true);
            highlighter1.SetHighlightOnFocus(txtPassword2, true);
            highlighter1.SetHighlightOnFocus(cboLevel, true);

        }


        private bool DeleteAssociate;

        private void form_Load(object sender, EventArgs e)
        {
            if (CurrentUserAccount == null) return;

            ShowData();
        }

        private void ShowData()
        {
            txtUsername.Text = CurrentUserAccount.Username;

            cboLevel.Text = CurrentUserAccount.SecurityLevel;

            var associate = CurrentUserAccount.AssociatedEmployee;
            if(associate != null && associate.RecordStatus != Aitech.Crud.RecordStatus.DeletedRecord)
                if(associate.Employee != null)
                    txtEmpTin.Text = associate.Employee.Tin;

            txtPassword.Text = CurrentUserAccount.Password;
            txtPassword2.Text = CurrentUserAccount.Password;
        }

        private void frmBatch_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Enter) || (e.KeyChar == (int)Keys.Return))
            {
                this.SelectNextControl(this.ActiveControl, true, false, true, true);
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidInputs()) return;

            Cursor.Current = Cursors.WaitCursor;

            CurrentUserAccount.Username = txtUsername.Text;
            CurrentUserAccount.Password = txtPassword.Text;
            CurrentUserAccount.SecurityLevel = cboLevel.Text;

            if (DeleteAssociate)
            {
                //CurrentUserAccount.AssociatedEmployee.RecordStatus = Aitech.Crud.RecordStatus.DeletedRecord;                
                CurrentUserAccount.RemoveAssociate();
            }

            //Add
            if (CurrentAssociateEmployee != null)
                CurrentUserAccount.SetAssociate(CurrentAssociateEmployee);

            CurrentUserAccount.RecordStatus = Aitech.Crud.RecordStatus.ModifiedRecord;
            DialogResult = DialogResult.OK;
        }

   

        private bool ValidInputs()
        {
            
            App.ClearErrorDisplay(txtUsername, errorProvider1, highlighterError);
            if (txtUsername.Text.Length == 0)
            {
                App.Message.ShowValidationError(txtUsername, "Enter Username", errorProvider1, highlighterError);
                return false;
            }


            App.ClearErrorDisplay(txtPassword, errorProvider1, highlighterError);
            if (txtPassword.Text.Length == 0)
            {
                App.Message.ShowValidationError(txtPassword2, "Enter Password for this user", errorProvider1, highlighterError);
                return false;
            }

            App.ClearErrorDisplay(txtPassword, errorProvider1, highlighterError);
            if(txtPassword.Text != txtPassword2.Text)
            {
                App.Message.ShowValidationError(txtPassword2, "Password and Re-Enter Password do not match!", errorProvider1, highlighterError);
                return false;
            }

            App.ClearErrorDisplay(cboLevel, errorProvider1, highlighterError);
            if (cboLevel.Text.Length == 0)
            {
                App.Message.ShowValidationError(cboLevel, "Select Level", errorProvider1, highlighterError);
                return false;
            }


            if (CurrentAssociateEmployee != null)
            {
                App.ClearErrorDisplay(txtEmpTin, errorProvider1, highlighterError);
                if (txtEmpTin.Text.Length != 0)
                {
                    if (!CurrentUserAccount.CanAssociateWithEmployee(CurrentAssociateEmployee.EmployeeId))
                    {
                        App.Message.ShowValidationError(txtEmpTin, "Employee has already an associated username", errorProvider1, highlighterError);
                        return false;
                    }
                }
            }

            return true;
        }

        private void cmdOpenEmployee_Click(object sender, EventArgs e)
        {
            var fOpen = new frmOpenEmployee();

            var result = fOpen.ShowDialog();
            var selected = fOpen.SelectedEmployee;
            if (result != DialogResult.OK)
            {
                fOpen.Dispose();
                return;
            }

            fOpen.Dispose();

            CurrentAssociateEmployee = new UserAccountEmployee();
            CurrentAssociateEmployee.EmployeeId = selected.Id;
            CurrentAssociateEmployee.Employee = selected;            
            txtEmpTin.Text = selected.Tin;
            DeleteAssociate = false;

        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            DeleteAssociate = true;
            txtEmpTin.Text = "";
        }
    }
}