using AiTech.Tools.Winform;
using Dll.Contacts;
using Dll.SchoolYear;
using Dll.Student;
using Library.Tools;
using System;
using System.Linq;
using System.Windows.Forms;
using Winform.Contacts;
using Winform.SchoolYear.Section;

namespace Winform.Student
{
    public partial class frmStudent_Add : FormWithRecordInfo, ISave
    {
        //private Person _tempPerson;

        public Dll.Student.Student ItemData;
        public DirtyFormHandler DirtyStatus { get; }

        public frmStudent_Add()
        {
            InitializeComponent();


            DirtyStatus = new DirtyFormHandler(this);

            this.ConvertEnterToTab();
            this.AskToSaveOnDirtyClosing();

            lblName.Text = "";
            Load += (s, e) => ShowData();
        }




        public bool FileSave()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!DataIsValid()) return false;

            var section = (Section)txtSection.Tag;
            var person = (Person)lblName.Tag;


            var empnum = Convert.ToInt32(txtStudNum.Text.Replace("-", ""));

            ItemData.PersonId = person.Id;
            ItemData.PersonClass = person;
            ItemData.StudentNumber = empnum;


            ItemData.SectionId = section.Id;
            ItemData.SectionClass = section;


            if (ItemData.Id != 0) ItemData.RowStatus = AiTech.LiteOrm.RecordStatus.ModifiedRecord;

            var writer = new StudentDataWriter(App.CurrentUser.User.Username, ItemData);
            var result = writer.SaveChanges();

            if (!result)
            {
                MessageDialog.ShowValidationError(this, "No detected changes to be saved");
                return false;
            }

            DirtyStatus.Clear();

            DialogResult = DialogResult.OK;
            return true;
        }

        private void ShowData()
        {
            if (ItemData.Id == 0) return;

            InputControls.LoadImage(picImage, ItemData.PersonClass.CameraCounter);

            ShowPersonInfo(ItemData.PersonClass);

            txtStudNum.Text = ItemData.StudentNumber.ToString();


            txtSection.Tag = ItemData.SectionClass;
            txtSection.Text = ItemData.SectionClass.SectionName;


            ShowFileInfo(ItemData);

            DirtyStatus.Clear();
        }

        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtStudNum.Text.Trim()))
            {
                MessageDialog.ShowValidationError(txtStudNum, "Student Number must NOT be blank");
                return false;
            }


            int studnum;
            if (!int.TryParse(txtStudNum.Text, out studnum))
            {
                txtStudNum.Focus();

                MessageDialog.ShowValidationError(txtStudNum, "Invalid Student Number");
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtSection.Text))
            {
                MessageDialog.ShowValidationError(txtSection, "Section is Required. Specify Section");
                return false;
            }


            var reader = new StudentDataReader();
            if (reader.HasExistingStudentNumber(Convert.ToInt32(txtStudNum.Text), ItemData.Id))
            {
                MessageDialog.ShowValidationError(txtStudNum, "Student Number already exists!");
                return false;
            }


            return true;
        }


        private bool ExistingPersonId(int personId)
        {
            var reader = new StudentDataReader();
            return reader.HasExistingPersonId(personId);
        }


        private void btnContactsSelect_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Person personItem;

            using (var frm = new frmContacts_Open())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;

                personItem = frm.ItemData;
            }

            if (ExistingPersonId(personItem.Id))
            {
                MessageDialog.Show(this, "Existing Record",
                    "An existing Student Record associated with this contact already exists!");

                lblName.Tag = null;
                return;
            }

            ShowPersonInfo(personItem);
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

            lblName.Tag = person;

        }

        private void btnContactsNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var personItem = new Person();
            using (var frm = new frmContacts_Add())
            {
                frm.ItemData = personItem;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return;
            }

            ShowPersonInfo(personItem);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FileSave();
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (var frm = new frmSectionSelector())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;

                    var item = frm.ItemData;

                    txtSection.Text = item.SectionName;
                    txtSection.Tag = item;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }
    }
}