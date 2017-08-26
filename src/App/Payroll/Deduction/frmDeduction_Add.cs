using Dll.Payroll;
using Library.Tools;
using System;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmDeduction_Add : FormWithHeader, ISave
    {
        public Deduction ItemData { get; set; }

        public DirtyChecker DirtyStatus { get; }

        public frmDeduction_Add()
        {
            InitializeComponent();
            DirtyStatus = new DirtyChecker(this);

            Load += (s, e) => { ShowData(); DirtyStatus.Clear(); };
            FormClosing += (s, e) => InputControls.Form.AskToSaveOnDirtyClosing(this, e);

            InputControls.Form.ConvertEnterToTab(this);

            CancelButton = btnCancel;
            btnOk.Click += (s, e) => { FileSave(); };
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
                App.Message.ShowValidationError(txtCode, "Code must not be blank");
                return false;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                App.Message.ShowValidationError(txtDescription, "Description must not be blank");
                return false;
            }


            var reader = new DeductionDataReader();

            var findItem = reader.GetItemWithCode(txtCode.Text.Trim());
            if (findItem != null && findItem.Id != ItemData.Id)
            {
                App.Message.ShowValidationError(txtCode, "Duplicate Deduction Code Already Exist!");
                return false;
            }


            return true;
        }

        public bool FileSave()
        {
            try
            {
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
                App.Message.ShowError(ex, this);
                return false;
            }
        }


    }
}
