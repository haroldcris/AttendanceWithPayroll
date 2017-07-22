using AiTech.Entities;
using System;
using System.Windows.Forms;

namespace Winform.Contacts
{
    public partial class frmContacts_Add : FormWithRecordInfo
    {
        public Dll.Contacts.Person MyContact{ get; set; }

        public frmContacts_Add()
        {
            InitializeComponent();

            My.App.Location.LoadProvinces(cboProvince);
            cboProvince.SelectedIndexChanged += cboProvince_SelectedIndexChanged;
            cboTown.SelectedIndexChanged += cboTown_SelectedIndexChanged;
        }

        private void cboTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTown.SelectedIndex < 0) return;

            cboBarangay.Items.Clear();
            My.App.Location.LoadBarangays(cboBarangay, cboProvince.Text, cboTown.Text);
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvince.SelectedIndex < 0) return;

            cboBarangay.Items.Clear();

            var id = ((AiTech.Location.Province)cboProvince.SelectedItem).Id;

            My.App.Location.LoadTowns(cboTown, id);
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.HandleEnterKey(this, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!DataIsValid()) return;

            MyContact.Name.Lastname = txtLastname.Text.Trim();
            MyContact.Name.Firstname = txtFirstname.Text.Trim();
            MyContact.Name.Middlename = txtMiddlename.Text.Trim();
            MyContact.Name.MiddleInitial = txtMi.Text.Trim();
            MyContact.Name.NameExtension = cboNameExtension.Text;


            MyContact.Gender = cboGender.Text == "Male" ? Dll.Contacts.Enums.GenderType.Male : Dll.Contacts.Enums.GenderType.Female;
            MyContact.BirthDate = dtBirthdate.Value;

            MyContact.Address.Street = txtAddress.Text.Trim();
            MyContact.Address.Barangay = cboBarangay.Text;
            MyContact.Address.Town = cboTown.Text;
            MyContact.Address.Province = cboProvince.Text;

            DialogResult = DialogResult.OK;
        }

        private void Form_Load(object sender, EventArgs e)
        {
           ShowData();
        }

        private bool DataIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                My.Message.ShowValidationError(txtLastname, "Lastname must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                My.Message.ShowValidationError(txtFirstname, "Firstname must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboGender.Text))
            {
                My.Message.ShowValidationError(cboGender, "Gender must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboProvince.Text))
            {
                My.Message.ShowValidationError(cboProvince, "Province must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboTown.Text))
            {
                My.Message.ShowValidationError(cboTown, "Town must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboBarangay.Text))
            {
                My.Message.ShowValidationError(cboBarangay, "Barangay must NOT be blank.");
                return false;
            }


            return true;
        }

        private void ShowData()
        {
            if (MyContact.Id !=0) txtId.Text = MyContact.Id.ToString("0000");

            txtLastname.Text = MyContact.Name.Lastname;
            txtFirstname.Text = MyContact.Name.Firstname;
            txtMiddlename.Text = MyContact.Name.Middlename;
            txtMi.Text = MyContact.Name.MiddleInitial;
            cboNameExtension.Text = MyContact.Name.NameExtension;

            cboGender.Text = MyContact.Gender == Dll.Contacts.Enums.GenderType.Male ? "Male" : "Female";
            dtBirthdate.Value = MyContact.BirthDate;

            txtAddress.Text = MyContact.Address.Street;
            cboBarangay.Text = MyContact.Address.Barangay;
            cboTown.Text = MyContact.Address.Town;
            cboProvince.Text = MyContact.Address.Province;

            ShowFileInfo (MyContact);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtMiddlename_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMiddlename.Text.Length == 0) return;
            txtMi.Text = txtMiddlename.Text.Substring(0, 1).ToUpper();
        }
    }
}
