using AiTech.Tools.Winform;
using Dll.Payroll;
using System;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmDeduction_Add : FormWithHeader, ISave
    {
        public Deduction ItemData { get; set; }

        public DirtyFormHandler DirtyStatus { get; }

        public frmDeduction_Add()
        {
            InitializeComponent();

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

        private void ShowData()
        {
            if (ItemData == null) return;

            txtCode.Text = ItemData.Code;
            txtDescription.Text = ItemData.Description;

            swMandatory.Value = ItemData.Mandatory;
            swPriority.Value = ItemData.Priority > 0;
            swActive.Value = ItemData.Active;
        }


        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageDialog.ShowValidationError(txtCode, "Code must not be blank");
                return false;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageDialog.ShowValidationError(txtDescription, "Description must not be blank");
                return false;
            }


            var reader = new DeductionDataReader();

            var findItem = reader.GetItemWithCode(txtCode.Text.Trim());
            if (findItem != null && findItem.Id != ItemData.Id)
            {
                MessageDialog.ShowValidationError(txtCode, "Duplicate Deduction Code Already Exist!");
                return false;
            }


            return true;
        }

        public bool FileSave()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DataIsValid()) return false;

                ItemData.Code = txtCode.Text.Trim();
                ItemData.Description = txtDescription.Text.Trim();

                ItemData.Mandatory = swMandatory.Value;
                ItemData.Priority = swPriority.Value ? 1 : 0;
                ItemData.Active = swActive.Value;

                //Save to Database
                var dataWriter = new DeductionDataWriter(App.CurrentUser.User.Username, ItemData);
                var isSaved = dataWriter.SaveChanges();

                DirtyStatus.Clear();

                DialogResult = DialogResult.OK;

                return isSaved;

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
                return false;
            }
        }


    }
}
