using AiTech.Tools.Winform;
using Dll.SchoolYear;
using System;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmCourse_Add : FormWithRecordInfo, ISave
    {

        public Course ItemData { get; set; }

        public DirtyFormHandler DirtyStatus { get; private set; }


        public frmCourse_Add()
        {
            InitializeComponent();

            DirtyStatus = new DirtyFormHandler(this);

            this.ConvertEnterToTab();
            this.AskToSaveOnDirtyClosing();


            Load += (s, e) => { ShowData(); };
        }



        private void ShowData()
        {
            if (ItemData.Id == 0) return;

            txtCourseCode.Text = ItemData.CourseCode;
            txtDescription.Text = ItemData.Description;


            ShowFileInfo(ItemData);
            DirtyStatus.Clear();
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
            if (txtCourseCode.Text.Length == 0 || string.IsNullOrEmpty(txtCourseCode.Text))
            {
                MessageDialog.ShowValidationError(txtCourseCode, "Course Code is Required");
                return false;
            }


            if (txtDescription.Text.Length == 0 || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageDialog.ShowValidationError(txtDescription, "Course Description is Required");
                return false;
            }


            var existing = (new CourseDataReader()).HasExistingItem(txtCourseCode.Text.Trim(), ItemData.Id);

            if (existing)
            {
                MessageDialog.ShowValidationError(txtCourseCode, "Similar Item Already Exists!");
                return false;
            }

            return true;
        }



        public bool FileSave()
        {
            Cursor.Current = Cursors.WaitCursor;


            if (!DataIsValid()) return false;


            ItemData.CourseCode = txtCourseCode.Text;
            ItemData.Description = txtDescription.Text;


            if (ItemData.Id != 0) ItemData.RowStatus = AiTech.LiteOrm.RecordStatus.ModifiedRecord;

            var writer = new CourseDataWriter(App.CurrentUser.User.Username, ItemData);
            writer.SaveChanges();


            DialogResult = DialogResult.OK;

            DirtyStatus.Clear();

            return true;

        }


    }
}