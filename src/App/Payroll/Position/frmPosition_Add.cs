using AiTech.Tools.Winform;
using Dll.Payroll;
using System;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmPosition_Add : FormWithHeader, ISave
    {
        public DirtyFormHandler DirtyStatus { get; }

        public Position ItemData { get; set; }

        public frmPosition_Add()
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


            var reader = new PositionDataReader();
            var item = reader.GetItemWithCode(txtCode.Text.Trim());

            if (item != null && item.Id != ItemData.Id)
            {
                MessageDialog.ShowValidationError(txtCode, "Duplicate Position Code Exist!");
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

                var dataWriter = new PositionDataWriter(App.CurrentUser.User.Username, ItemData);
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


    }
}
