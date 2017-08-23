using Dll.Payroll;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmDeduction_Add : FormWithHeader
    {
        public Deduction ItemData { get; set; }

        public frmDeduction_Add()
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

            swMandatory.Value = ItemData.Mandatory;
            swPriority.Value = ItemData.Priority > 0 ? true : false;
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

        private void Save()
        {
            if (!DataIsValid()) return;

            ItemData.Code = txtCode.Text.Trim();
            ItemData.Description = txtDescription.Text.Trim();

            ItemData.Mandatory = swMandatory.Value;
            ItemData.Priority = swPriority.Value ? 1 : 0;
            ItemData.Active = swActive.Value;

            //Save to Database
            var dataWriter = new DeductionDataWriter(App.CurrentUser.User.Username, ItemData);
            dataWriter.SaveChanges();


            DialogResult = DialogResult.OK;
        }


    }
}
