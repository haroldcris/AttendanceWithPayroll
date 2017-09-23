using AiTech.Tools.Winform;
using Dll.Biometric;
using Dll.Contacts;
using Library.Tools;
using System;
using System.Linq;
using System.Windows.Forms;
using Winform.Contacts;

namespace Winform.Biometric
{
    public partial class frmBiometricUser_Add : FormWithRecordInfo, ISave
    {
        private Person _tempPerson;

        public BiometricUser ItemData;

        public frmBiometricUser_Add()
        {
            InitializeComponent();
            //this.ConvertEnterToTab();

            this.AskToSaveOnDirtyClosing();
            DirtyStatus = new DirtyFormHandler(this);

            lblName.Text = "";

            Load += (s, e) => ShowData();
        }

        public DirtyFormHandler DirtyStatus { get; }


        public bool FileSave()
        {
            if (!DataIsValid()) return false;


            var biometricId = Convert.ToInt32(txtBiometricId.Text.Replace("-", ""));

            ItemData.BiometricId = biometricId;

            ItemData.PersonId = _tempPerson.Id;
            ItemData.PersonClass = _tempPerson;

            ItemData.Category = cboCategory.Text;
            ItemData.PhoneNumber = cboPhoneNumber.Text;



            ItemData.MonIn = dtMonIn.Value;
            ItemData.MonOut = dtMonOut.Value;

            ItemData.TueIn = dtTueIn.Value;
            ItemData.TueOut = dtTueOut.Value;

            ItemData.WedIn = dtWedIn.Value;
            ItemData.WedOut = dtWedOut.Value;

            ItemData.ThuIn = dtThuIn.Value;
            ItemData.ThuOut = dtThuOut.Value;

            ItemData.FriIn = dtFriIn.Value;
            ItemData.FriOut = dtFriOut.Value;

            ItemData.SatIn = dtSatIn.Value;
            ItemData.SatOut = dtSatOut.Value;



            var writer = new BiometricUserDataWriter(App.CurrentUser.User.Username, ItemData);
            writer.SaveChanges();

            DirtyStatus.Clear();

            return true;
        }

        private void ShowData()
        {
            ShowPersonInfo(ItemData.PersonClass);

            //= ItemData.Id;
            _tempPerson = ItemData.PersonClass;
            txtBiometricId.Text = ItemData.BiometricId.ToString();


            if (ItemData.PersonClass.Id != 0)
            {
                ItemData.PersonClass.MobileNumbers.LoadItemsFromDb();
                InputControls.LoadToComboBox(cboPhoneNumber, ItemData.PersonClass.MobileNumbers.Items);
            }

            cboCategory.Text = ItemData.Category;
            cboPhoneNumber.Text = ItemData.PhoneNumber;


            dtMonIn.Value = ItemData.MonIn;
            dtMonOut.Value = ItemData.MonOut;

            dtTueIn.Value = ItemData.TueIn;
            dtTueOut.Value = ItemData.TueOut;

            dtWedIn.Value = ItemData.WedIn;
            dtWedOut.Value = ItemData.WedOut;

            dtThuIn.Value = ItemData.ThuIn;
            dtThuOut.Value = ItemData.ThuOut;

            dtFriIn.Value = ItemData.FriIn;
            dtFriOut.Value = ItemData.FriOut;

            dtSatIn.Value = ItemData.SatIn;
            dtSatOut.Value = ItemData.SatOut;


            ShowFileInfo(ItemData);
            DirtyStatus.Clear();
        }

        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtBiometricId.Text.Trim()))
            {
                MessageDialog.ShowValidationError(txtBiometricId, "Biometric Id must NOT be blank");
                return false;
            }


            if (int.Parse(txtBiometricId.Text) <= 0)
            {
                txtBiometricId.Focus();

                MessageDialog.ShowValidationError(txtBiometricId, "Invalid Biometric Id");
                return false;
            }


            if (_tempPerson == null)
            {
                MessageDialog.ShowValidationError(btnContactsSelect, "No associated Contact Info");
                return false;
            }


            var reader = new BiometricUserDataReader();
            if (reader.HasExistingBiometricId(Convert.ToInt32(txtBiometricId.Text)) &&
                Convert.ToInt32(txtBiometricId.Text) != ItemData.BiometricId)
            {
                MessageDialog.ShowValidationError(txtBiometricId, "Biometric Id already exists!");
                return false;
            }

            return true;
        }


        private bool ExistingPersonId(int personId)
        {
            var reader = new BiometricUserDataReader();
            return reader.HasExistingPersonId(personId);
        }


        private void ShowPersonInfo(Person personInfo)
        {
            Show_NameProfile(personInfo);
            InputControls.LoadImage(picImage, personInfo.CameraCounter);
        }

        private void Show_NameProfile(Person person)
        {
            var template = @"Lastname:
<font color='blue'><h5>  %lastname%</h5></font>
Firstname:
<font color='blue'><h5>  %firstname%</h5></font>
Middlename:  %maiden%
<font color='blue'><h5>  %middlename%</h5></font>
Name Extension:
<font color='blue'><h5>  %extension%</h5></font>
Gender:
<font color='blue'><h5>  %gender%</h5></font>";

            template = template.Replace("%lastname%", person.Name.Lastname.ToUpper());
            template = template.Replace("%firstname%", person.Name.Firstname.ToUpper());

            template = template.Replace("%extension%", person.Name.NameExtension.ToUpper());

            template = !person.Name.Lastname.Any()
                ? template.Replace("%gender%", "")
                : template.Replace("%gender%", person.Gender == GenderType.Male ? "Male" : "Female");

            if (person.Name.MaidenMiddlename.Length == 0)
            {
                template = template.Replace("%maiden%", "");
                template = template.Replace("%middlename%", person.Name.Middlename.ToUpper());
            }
            else
            {
                template = template.Replace("%maiden%", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Maiden Middlename");
                template = template.Replace("%middlename%", person.Name.Middlename.ToUpper() +
                                                            "&nbsp;&nbsp;&nbsp;" +
                                                            person.Name.MaidenMiddlename.ToUpper());
            }

            lblName.Text = template;
        }

        private void btnContactsNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _tempPerson = new Person();
            using (var frm = new frmContacts_Add())
            {
                frm.ItemData = _tempPerson;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return;
            }

            LoadPhoneNumbers(_tempPerson);

            ShowPersonInfo(_tempPerson);
        }


        private void btnContactsSelect_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (var frm = new frmContacts_Open())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;

                _tempPerson = frm.ItemData;
            }

            if (ExistingPersonId(_tempPerson.Id))
            {
                _tempPerson = null;
                MessageDialog.Show(this, "Existing Record",
                    "An existing Record associated with this contact already exists!");
                return;
            }


            LoadPhoneNumbers(_tempPerson);
            ShowPersonInfo(_tempPerson);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!FileSave()) return;

            DialogResult = DialogResult.OK;
        }


        private void LoadPhoneNumbers(Person person)
        {
            person.MobileNumbers.LoadItemsFromDb();

            InputControls.LoadToComboBox(cboPhoneNumber, person.MobileNumbers.Items);
        }
    }
}