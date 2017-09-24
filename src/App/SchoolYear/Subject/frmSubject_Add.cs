using AiTech.Tools.Winform;
using Dll.SchoolYear;
using System;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmSubject_Add : FormWithRecordInfo, ISave
    {

        public Subject ItemData { get; set; }

        public DirtyFormHandler DirtyStatus { get; private set; }


        public frmSubject_Add()
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

            txtSubjectCode.Text = ItemData.SubjectCode;
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
            if (txtSubjectCode.Text.Length == 0 || string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                MessageDialog.ShowValidationError(txtSubjectCode, "Subject Code is Required");
                return false;
            }


            if (txtDescription.Text.Length == 0 || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageDialog.ShowValidationError(txtDescription, "Subject Description is Required");
                return false;
            }


            var existing = (new SubjectDataReader()).HasExistingItem(txtSubjectCode.Text.Trim(), ItemData.Id);

            if (existing)
            {
                MessageDialog.ShowValidationError(txtSubjectCode, "Similar Item Already Exists!");
                return false;
            }

            return true;
        }



        public bool FileSave()
        {
            Cursor.Current = Cursors.WaitCursor;


            if (!DataIsValid()) return false;


            ItemData.SubjectCode = txtSubjectCode.Text;
            ItemData.Description = txtDescription.Text;


            if (ItemData.Id != 0) ItemData.RowStatus = AiTech.LiteOrm.RecordStatus.ModifiedRecord;


            var writer = new SubjectDataWriter(App.CurrentUser.User.Username, ItemData);
            writer.SaveChanges();


            DialogResult = DialogResult.OK;

            DirtyStatus.Clear();

            return true;

        }


    }
}