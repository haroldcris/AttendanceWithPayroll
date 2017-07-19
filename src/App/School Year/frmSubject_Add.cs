using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SmartData;
using DevComponents.AdvTree;

namespace SmartApp
{
    public partial class frmSubject_Add : DevComponents.DotNetBar.OfficeForm
    {
        public new frmSubject ParentForm { get; set; }

        public Subject SubjectItem{ get; set; }

        public frmSubject_Add(frmSubject parent)
        {
            InitializeComponent();
            ParentForm = parent;
            SubjectItem = null;

            highlighter1.SetHighlightOnFocus(txtSubjectCode, true);
            highlighter1.SetHighlightOnFocus(txtDescription, true);
        }

        private void form_Load(object sender, EventArgs e)
        {
            if (SubjectItem == null) return;

            txtSubjectCode.Text = SubjectItem.SubjectCode;
            txtDescription.Text = SubjectItem.Description;
        }

        private void frmBatch_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Enter) || (e.KeyChar == (int)Keys.Return))
            {
                this.SelectNextControl(this.ActiveControl, true, false, true, true);
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidInputs()) return;

            Cursor.Current = Cursors.WaitCursor;

            if (SubjectItem == null)
                SubjectItem = new Subject();

            if (ParentForm.ContainsData(new Subject()
            {
                Id = SubjectItem.Id,
                SubjectCode = txtSubjectCode.Text,
                Description = txtDescription.Text 
            }))
            { 
                App.Message.ShowValidationError(txtDescription, "Duplicate Record!", errorProvider1, highlighterError);
                return;
            }

            SubjectItem.SubjectCode = txtSubjectCode.Text;
            SubjectItem.Description = txtDescription.Text;

            DialogResult = DialogResult.OK;
        }

     
        private bool ValidInputs()
        {
            App.ClearErrorDisplay(txtSubjectCode, errorProvider1, highlighterError);
            if (txtSubjectCode.TextLength == 0)
            {
                App.Message.ShowValidationError(txtSubjectCode, "Enter Subject Code", errorProvider1, highlighterError);
                return false;
            }

            App.ClearErrorDisplay(txtDescription, errorProvider1, highlighterError);
            if (txtDescription.TextLength == 0)
            {
                App.Message.ShowValidationError(txtDescription, "Enter Subject Description", errorProvider1, highlighterError);
                return false;
            }

            return true;
        }

     
    }
}