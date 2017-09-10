using System;
using System.Windows.Forms;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using Dll.SchoolYear;

namespace Winform
{
    public partial class frmCourse_Add : OfficeForm
    {
        public frmCourse_Add(frmCourse parent)
        {
            InitializeComponent();

            ParentForm = parent;
            CurrentCourse = null;

            highlighter1.SetHighlightOnFocus(txtCourseCode, true);
            highlighter1.SetHighlightOnFocus(txtDescription, true);
        }

        public new frmCourse ParentForm { get; set; }

        public Course CurrentCourse { get; set; }

        private void form_Load(object sender, EventArgs e)
        {
            if (CurrentCourse == null) return;

            txtCourseCode.Text = CurrentCourse.CourseCode;
            txtDescription.Text = CurrentCourse.Description;
        }

        private void frmBatch_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Enter || e.KeyChar == (int) Keys.Return)
            {
                SelectNextControl(ActiveControl, true, false, true, true);
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

            if (ParentForm.ContainsData(CurrentCourse))
            {
                MessageDialog.ShowValidationError(txtCourseCode, "Duplicate Record!", errorProvider1, highlighterError);
                return;
            }

            CurrentCourse.CourseCode = txtCourseCode.Text;
            CurrentCourse.Description = txtDescription.Text;

            DialogResult = DialogResult.OK;
        }


        private bool ValidInputs()
        {
            //My.App.ClearErrorDisplay(txtCourseCode, errorProvider1, highlighterError);
            if (txtCourseCode.Text.Length == 0 || string.IsNullOrEmpty(txtCourseCode.Text))
            {
                MessageDialog.ShowValidationError(txtCourseCode, "Course Code is Required");
                return false;
            }


            //My.App.ClearErrorDisplay(txtDescription, errorProvider1, highlighterError);
            if (txtDescription.Text.Length == 0 || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageDialog.ShowValidationError(txtDescription, "Course Description is Required");
                return false;
            }

            return true;
        }
    }
}