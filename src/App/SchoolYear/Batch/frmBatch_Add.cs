using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using Dll.SchoolYear;
using System;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmBatch_Add : FormWithRecordInfo, ISave
    {

        public Batch ItemData { get; set; }

        public DirtyFormHandler DirtyStatus { get; private set; }



        public frmBatch_Add()
        {
            InitializeComponent();

            DirtyStatus = new DirtyFormHandler(this);

            this.AskToSaveOnDirtyClosing();
            this.ConvertEnterToTab();

            LoadBatch();

            this.Load += (s, e) => ShowData();
        }



        private void ShowData()
        {
            if (ItemData == null) return;
            if (ItemData.Id == 0) return;

            txtBatchName.Text = ItemData.BatchName;
            cboSemester.Text = ItemData.Semester;

            ShowFileInfo(ItemData);

            DirtyStatus.Clear();
        }


        private void LoadBatch()
        {
            txtBatchName.AutoCompleteCustomSource = Helper.BatchHelper.GetBatchList();
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
            if (txtBatchName.Text.Length == 0)
            {
                MessageDialog.ShowValidationError(txtBatchName, "Enter Batch");
                return false;
            }


            if (!txtBatchName.Text.Contains("-"))
            {
                MessageDialog.ShowValidationError(txtBatchName, "Invalid Batch Format");
                return false;
            }


            var b = txtBatchName.Text.Split('-');
            var start = 0;
            var finish = 0;

            if (!int.TryParse(b.GetValue(0).ToString(), out start))
            {
                MessageDialog.ShowValidationError(txtBatchName, "Invalid Batch Format");
                return false;
            }

            if (!int.TryParse(b.GetValue(1).ToString(), out finish))
            {
                MessageDialog.ShowValidationError(txtBatchName, "Invalid Batch Format");
                return false;
            }


            if (start < 1920)
            {
                MessageDialog.ShowValidationError(txtBatchName, "Invalid Batch Format. Batch starts at 1950");
                return false;
            }
            if (start + 1 != finish)
            {
                MessageDialog.ShowValidationError(txtBatchName, "Invalid Batch Format");
                return false;
            }


            if (cboSemester.Text.Length == 0)
            {
                MessageDialog.ShowValidationError(cboSemester, "Select Semester");
                return false;
            }


            var existing = (new BatchDataReader()).HasExistingItem(txtBatchName.Text.Trim(), cboSemester.Text, ItemData.Id);

            if (existing)
            {
                MessageDialog.ShowValidationError(txtBatchName, "Similar Record has already exists");
                return false;
            }


            return true;
        }



        public bool FileSave()
        {
            Cursor.Current = Cursors.WaitCursor;


            if (!DataIsValid()) return false;

            ItemData.BatchName = txtBatchName.Text;
            ItemData.Semester = cboSemester.Text;

            if (ItemData.Id != 0) ItemData.RowStatus = RecordStatus.ModifiedRecord;

            var writer = new BatchDataWriter(App.CurrentUser.User.Username, ItemData);

            if (!writer.SaveChanges())
            {
                MessageDialog.Show(this, "No Changes Detected", "No changes to be saved.");
                return false;
            }

            DialogResult = DialogResult.OK;

            DirtyStatus.Clear();

            return true;
        }
    }
}