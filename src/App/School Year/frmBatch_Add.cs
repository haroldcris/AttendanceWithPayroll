using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using Dll.SchoolYear;
using Library.Tools;

namespace Winform
{
    public partial class frmBatch_Add : OfficeForm
    {
        public new frmBatch ParentForm { get; set; }

        public Batch Batch { get; set; }

        public frmBatch_Add(frmBatch parent)
        {
            InitializeComponent();

            ParentForm = parent;
            Batch = null;

            highlighter1.SetHighlightOnFocus(txtBatchName, true);
            highlighter1.SetHighlightOnFocus(cboSemester, true);

            KeyPreview = true;
            KeyPress += (s,e) => InputControls.ConvertEnterToTab(this, e);

            LoadBatch();
        }

        private void form_Load(object sender, EventArgs e)
        {
            if (Batch == null) return;
            txtBatchName.Text = Batch.BatchName;
            cboSemester.Text = Batch.Semester;
        }

        private void LoadBatch()
        {
            txtBatchName.AutoCompleteCustomSource = Helper.BatchHelper.GetBatchList();
        }

        private void frmBatch_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
           //
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidInputs()) return;

            Cursor.Current = Cursors.WaitCursor;
            
            Batch.BatchName = txtBatchName.Text;
            Batch.Semester = cboSemester.Text;
            
            
            if (ParentForm.ContainsData(Batch))
            {
                App.Message.ShowValidationError(txtBatchName, "Duplicate Record!", errorProvider1, highlighterError);
                return;
            }
            

            DialogResult = DialogResult.OK;
        }

   

        private bool ValidInputs()
        {
            
            //My.App.ClearErrorDisplay(txtBatchName, errorProvider1, highlighterError);
            if (txtBatchName.Text.Length == 0)
            {
                App.Message.ShowValidationError(txtBatchName, "Enter Batch");
                return false;
            }

            if (!txtBatchName.Text.Contains("-"))
            {
                App.Message.ShowValidationError(txtBatchName, "Invalid Batch Format");
                return false;
            }

            var b = txtBatchName.Text.Split('-');
            var start = 0;
            var finish = 0;

            if(!Int32.TryParse(b.GetValue(0).ToString(), out start))
            {
                App.Message.ShowValidationError(txtBatchName, "Invalid Batch Format");
                return false;
            }

            if (!Int32.TryParse(b.GetValue(1).ToString(), out finish))
            {
                App.Message.ShowValidationError(txtBatchName, "Invalid Batch Format");
                return false;
            }

            if (start < 1920) { App.Message.ShowValidationError(txtBatchName, "Invalid Batch Format. Batch starts at 1950"); return false; }
            if (start + 1 != finish) { App.Message.ShowValidationError(txtBatchName, "Invalid Batch Format"); return false; }


            //My.App.ClearErrorDisplay(cboSemester, errorProvider1, highlighterError);
            if (cboSemester.Text.Length == 0)
            {
                App.Message.ShowValidationError(cboSemester, "Select Semester");
                return false;
            }

            return true;
        }
    }
}