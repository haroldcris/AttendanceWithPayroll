using Dll.Payroll;
using System.Windows.Forms;
using AiTech.Tools.Winform;

namespace Winform.Payroll
{
    public partial class frmTaxTable_Add : FormWithHeader
    {
        public Tax ItemData { get; set; }

        public frmTaxTable_Add()
        {
            InitializeComponent();

            Load += (s, e) => { ShowData(); };

            CancelButton = btnCancel;
            btnCancel.Click += (s, e) => { Close(); };
            btnOk.Click += (s, e) => { Save(); };


            for (var c = 0; c <= 4; c++)
                cboDependent.Items.Add(c);

        }

        private void ShowData()
        {
            if (ItemData == null) return;

            txtTaxId.Text = ItemData.Id.ToString();
            txtShort.Text = ItemData.ShortDesc;

            txtDescription.Text = ItemData.Description;

            cboDependent.Text = ItemData.Dependent.ToString();
            txtExemption.Value = ItemData.Exemption;
        }


        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtTaxId.Text))
            {
                MessageDialog.ShowValidationError(txtTaxId, "Code must not be blank");
                return false;
            }

            if (string.IsNullOrEmpty(txtShort.Text))
            {
                MessageDialog.ShowValidationError(txtShort, "Short Description must not be blank");
                return false;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageDialog.ShowValidationError(txtDescription, "Description must not be blank");
                return false;
            }

            //var reader = new TaxDataReader();
            //var item = reader.GetItemWithId()
            //if (CallerForm.ContainsData(txtTaxId.Text, ItemData.RowId))
            //{
            //    MessageDialog.ShowValidationError(txtTaxId, "Duplicate Record!");
            //    return false;
            //}


            return true;
        }

        private void Save()
        {
            if (!DataIsValid()) return;

            //ItemData.Id = int.Parse(txtTaxId.Text.Trim());
            ItemData.ShortDesc = txtShort.Text.Trim();
            ItemData.Description = txtDescription.Text.Trim();

            ItemData.Dependent = int.Parse(cboDependent.Text.Trim());
            ItemData.Exemption = txtExemption.Value;


            var dataWriter = new TaxDataWriter(App.CurrentUser.User.Username, ItemData);
            dataWriter.SaveChanges();


            DialogResult = DialogResult.OK;
        }


    }
}
