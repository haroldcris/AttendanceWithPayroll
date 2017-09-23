using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmOfferedCourse_Add : Office2007Form, ISave
    {
        public DirtyFormHandler DirtyStatus { get; private set; }

        public OfferedCourse ItemData { get; set; }

        public frmOfferedCourse_Add()
        {
            InitializeComponent();

            DirtyStatus = new DirtyFormHandler(this);

            this.ConvertEnterToTab();
            this.AskToSaveOnDirtyClosing();


            cboYear.Items.Clear();
            cboYear.Items.Add("1st Year");
            cboYear.Items.Add("2nd Year");
            cboYear.Items.Add("3rd Year");
            cboYear.Items.Add("4th Year");
            cboYear.Items.Add("5th Year");

        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadCourseItems();
        }


        private void LoadCourseItems()
        {
            Cursor.Current = Cursors.WaitCursor;

            var courseItems = new CourseCollection();
            courseItems.LoadAllItemsFromDb();

            cboCourse.Items.Clear();
            foreach (var item in courseItems.Items)
            {
                cboCourse.Items.Add(item);
            }
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
            if (cboCourse.SelectedIndex == -1)
            {
                MessageDialog.ShowValidationError(cboCourse, "Select Course", errorProvider1, highlighterError);
                return false;
            }


            if (cboYear.SelectedIndex == -1)
            {
                MessageDialog.ShowValidationError(cboYear, "Select Year", errorProvider1, highlighterError);
                return false;
            }


            var hasExisting = (new OfferedCourseDataReader()).HasExistingItem(ItemData.BatchId,
                                                                                ((Course)cboCourse.SelectedItem).Id,
                                                                                cboYear.SelectedIndex + 1,
                                                                                ItemData.Id);

            if (hasExisting)
            {
                MessageDialog.ShowValidationError(cboCourse, "Similar Record Already Exist!");
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

                var course = (Course)cboCourse.SelectedItem;

                //Transfer Data To Class (UDT)
                ItemData.CourseId = course.Id;
                ItemData.YearLevel = cboYear.SelectedIndex + 1;

                ItemData.CourseClass = course;

                if (ItemData.Id != 0) ItemData.RowStatus = AiTech.LiteOrm.RecordStatus.ModifiedRecord;

                var writer = new OfferedCourseDataWriter(App.CurrentUser.User.Username, ItemData);
                writer.SaveChanges();

                DialogResult = DialogResult.OK;

                DirtyStatus.Clear();
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