using AiTech.Tools.Winform;
using Dll.Contacts;
using Dll.Employee;
using Library.Tools;
using System;
using System.Windows.Forms;
using Winform.Contacts;

namespace Winform.Employee
{
    public partial class frmEmployee_Add : FormWithRecordInfo, ISave
    {
        public DirtyFormHandler DirtyStatus { get; }

        public Dll.Employee.Employee ItemData;

        private Person _tempPerson;

        public frmEmployee_Add()
        {
            InitializeComponent();
            //this.ConvertEnterToTab();

            this.AskToSaveOnDirtyClosing();
            DirtyStatus = new DirtyFormHandler(this);

            lblName.Text = "";

            Load += (s, e) => ShowData();

        }

        private void ShowData()
        {
            ShowPersonInfo(ItemData.PersonClass);

            //= ItemData.Id;
            _tempPerson = ItemData.PersonClass;
            txtEmpNum.Text = ItemData.EmpNum.ToString();
            cboCivilStatus.Text = ItemData.CivilStatus;
            txtHeight.Value = (double)ItemData.Height;
            txtWeight.Value = (double)ItemData.Weight;


            ShowFileInfo(ItemData);

            DirtyStatus.Clear();
        }


        public bool FileSave()
        {
            if (!DataIsValid()) return false;


            var empnum = Convert.ToInt32(txtEmpNum.Text.Replace("-", ""));

            ItemData.PersonId = _tempPerson.Id;
            ItemData.PersonClass = _tempPerson;
            ItemData.EmpNum = empnum;
            ItemData.CivilStatus = cboCivilStatus.Text;
            ItemData.Height = (decimal)txtHeight.Value;
            ItemData.Weight = (decimal)txtWeight.Value;


            var writer = new EmployeeDataWriter(App.CurrentUser.User.Username, ItemData);
            writer.SaveChanges();

            DirtyStatus.Clear();

            return true;
        }

        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtEmpNum.Text.Trim()))
            {
                MessageDialog.ShowValidationError(txtEmpNum, "Employee Number must NOT be blank");
                return false;
            }


            if (Int32.Parse(txtEmpNum.Text) <= 0)
            {
                MessageDialog.ShowValidationError(txtEmpNum, "Invalid Employee Number");
                return false;
            }



            if (string.IsNullOrEmpty(txtCitizenship.Text.Trim()))
            {
                MessageDialog.ShowValidationError(txtCitizenship, "Citizenship Data is Required");
                return false;
            }

            if (txtHeight.Value <= 0)
            {
                MessageDialog.ShowValidationError(txtHeight, "Invalid Height Data");
                return false;
            }

            if (txtWeight.Value <= 0)
            {
                MessageDialog.ShowValidationError(txtWeight, "Invalid Weight Data");
                return false;
            }



            return true;

        }


        private bool ExistingPersonId(int personId)
        {
            var reader = new EmployeeDataReader();
            return reader.HasExistingPersonId(personId);
        }


        private void btnContactsSelect_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (var frm = new frmContacts_Open())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;

                _tempPerson = frm.ItemData;
            }

            if (ExistingPersonId(_tempPerson.Id))
            {
                MessageDialog.Show(this, "Existing Record", "An existing Employee Record associated with this contact already exists!");
                return;
            }

            ShowPersonInfo(_tempPerson);
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

            template = template.Replace("%gender%", person.Gender == GenderType.Male ? "Male" : "Female");


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

        private void btnContactsNew_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _tempPerson = new Person();
            using (var frm = new frmContacts_Add())
            {
                frm.ItemData = _tempPerson;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return;
            }

            ShowPersonInfo(_tempPerson);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!FileSave()) return;

            DialogResult = DialogResult.OK;
        }
    }
}
