using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System;
using System.Windows.Forms;
using Winform.SchoolYear.Section;

namespace Winform.SchoolYear
{
    public partial class frmOfferedClass_Add : Office2007Form, ISave
    {

        public OfferedClass ItemData { get; set; }

        public DirtyFormHandler DirtyStatus { get; }

        public frmOfferedClass_Add()
        {
            InitializeComponent();

            DirtyStatus = new DirtyFormHandler(this);

            this.AskToSaveOnDirtyClosing();
            this.ConvertEnterToTab();

        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadSubjects();

            ShowData();
        }



        private void ShowData()
        {
            if (ItemData.Id == 0) return;

            cboSubject.Text = ItemData.SubjectClass.ToString();

            txtSection.Text = ItemData.SectionClass.SectionName;
            txtSection.Tag = ItemData.SectionClass;

            txtEmployee.Tag = ItemData.EmployeeClass;
            txtEmployee.Text = ItemData.EmployeeClass.PersonClass.Name.Fullname;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FileSave();
        }


        private bool DataIsValid()
        {
            if (string.IsNullOrWhiteSpace(cboSubject.Text))
            {
                MessageDialog.ShowValidationError(cboSubject, "Select a subject to continue");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSection.Text))
            {
                MessageDialog.ShowValidationError(txtSection, "Select Section");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmployee.Text))
            {
                MessageDialog.ShowValidationError(txtEmployee, "Select Instructor for this class");
                return false;
            }


            var subjectId = ((Subject)cboSubject.SelectedItem).Id;
            var sectionId = ((Dll.SchoolYear.Section)txtSection.Tag).Id;

            var existing = new OfferedClassDataReader().HasExisting(subjectId, sectionId, ItemData.Id);

            if (existing)
            {
                MessageDialog.ShowValidationError(cboSubject,"Similar Record Already Exist!");
                return false;
            }


            return true;

        }


        private void LoadSubjects()
        {
            var subjects = new SubjectCollection();

            subjects.LoadAllItemsFromDb();
            cboSubject.Items.Clear();

            foreach (var item in subjects.Items)
            {
                cboSubject.Items.Add(item);
            }
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            try
            {
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

        public bool FileSave()
        {
            try
            {
                if (!DataIsValid()) return false;

                var subject = (Subject)cboSubject.SelectedItem;
                var section = (Dll.SchoolYear.Section)txtSection.Tag;
                var employee = (Dll.Employee.Employee)txtEmployee.Tag;

                ItemData.SubjectId = subject.Id;
                ItemData.SubjectClass = subject;

                ItemData.SectionId = section.Id;
                ItemData.SectionClass = section;

                ItemData.EmployeeClass = employee;
                ItemData.TeacherId = employee.Id;



                ItemData.Mon = new DateTime();
                ItemData.Tue = new DateTime();
                ItemData.Wed = new DateTime();
                ItemData.Thu = new DateTime();
                ItemData.Fri = new DateTime();
                ItemData.Sat = new DateTime();



                if (ItemData.Id != 0) ItemData.RowStatus = AiTech.LiteOrm.RecordStatus.ModifiedRecord;


                var writer = new OfferedClassDataWriter(App.CurrentUser.User.Username, ItemData);
                writer.SaveChanges();

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

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new Employee.frmEmployee_Open())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;

                    var employeeItem = frm.ItemData;



                    txtEmployee.Text = employeeItem.PersonClass.Name.Fullname;
                    txtEmployee.Tag = employeeItem;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }

        }
    }
}
