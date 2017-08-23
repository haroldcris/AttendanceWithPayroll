using Dll.Payroll;
using System;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmPosition_Add : FormWithHeader
    {
        public Position ItemData { get; set; }

        public frmPosition_Add()
        {
            InitializeComponent();

            Load += (s, e) => { ShowData(); };
            ConvertEnterKeyToTab();

            CancelButton = btnCancel;
            btnCancel.Click += (s, e) => { Close(); };
            btnOk.Click += (s, e) => { Save(); };
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
                App.Message.ShowValidationError(txtCode, "Code must not be blank");
                return false;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                App.Message.ShowValidationError(txtDescription, "Description must not be blank");
                return false;
            }


            var reader = new PositionDataReader();
            var item = reader.GetItemWithCode(txtCode.Text.Trim());

            if (item != null && item.Id != ItemData.Id)
            {
                App.Message.ShowValidationError(txtCode, "Duplicate Position Code Exist!");
                return false;
            }

            return true;
        }

        private void Save()
        {
            try
            {
                if (!DataIsValid()) return;

                ItemData.Code = txtCode.Text.Trim();
                ItemData.Description = txtDescription.Text.Trim();

                var dataWriter = new PositionDataWriter(App.CurrentUser.User.Username, ItemData);
                dataWriter.SaveChanges();


                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
            }
        }
    }
}
