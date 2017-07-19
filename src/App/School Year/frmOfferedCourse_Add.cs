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
    public partial class frmOfferedCourse_Add : DevComponents.DotNetBar.OfficeForm
    {
        public new frmOfferedCourse ParentForm { get; set; }

        public OfferedCourse OfferedCourseItem{ get; set; }

        private Dictionary<string, Course> CourseItems;
        public frmOfferedCourse_Add(frmOfferedCourse parent)
        {
            InitializeComponent();
            ParentForm = parent;
            OfferedCourseItem = null;

            highlighter1.SetHighlightOnFocus(cboCourse, true);
            highlighter1.SetHighlightOnFocus(cboYear, true);

            cboYear.Items.Clear();
            cboYear.Items.Add("1st Year");
            cboYear.Items.Add("2nd Year");
            cboYear.Items.Add("3rd Year");
            cboYear.Items.Add("4th Year");
            cboYear.Items.Add("5th Year");
        }

        private void form_Load(object sender, EventArgs e)
        {
            LoadCourseItems();

            if (OfferedCourseItem == null) return;

            
            cboCourse.Text = formatCourse(OfferedCourseItem.CourseCode, OfferedCourseItem.Course.Description);
            cboYear.SelectedIndex = OfferedCourseItem.YearLevel - 1;
        }

        private string formatCourse(string code, string description)
        {
            return string.Format("{0} [{1}]", description, code);
        }
        private void LoadCourseItems()
        {
            Cursor.Current = Cursors.WaitCursor;

            var courseManager = new CourseManager("");
            courseManager.Courses.LoadItemsFromDb();

            cboCourse.Items.Clear();
            CourseItems = new Dictionary<string, Course>();
            foreach (var item in courseManager.Courses.Items)
            {
                cboCourse.Items.Add( formatCourse(item.CourseCode ,item.Description));
                CourseItems.Add(item.CourseCode, item);
            }
        }

        private void frmBatch_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Enter) || (e.KeyChar == (int)Keys.Return))
            {
                this.SelectNextControl(this.ActiveControl, true, false, true, true);
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

            if (OfferedCourseItem == null)
                OfferedCourseItem = new OfferedCourse();

            var course = CourseItems.ElementAt(cboCourse.SelectedIndex).Value ;

            if (ParentForm.ContainsData(new OfferedCourse()
            {
                Id = OfferedCourseItem.Id,
                CourseCode = course.CourseCode,
                Course = course,
                YearLevel = cboYear.SelectedIndex+1
            }))
            {
                App.Message.ShowValidationError(cboCourse, "Duplicate Record!", errorProvider1, highlighterError);
                return;
            }

            //Transfer Data To Class (UDT)
            OfferedCourseItem.CourseCode = course.CourseCode;
            OfferedCourseItem.Course = course;
            OfferedCourseItem.YearLevel = cboYear.SelectedIndex + 1;

            DialogResult = DialogResult.OK;
        }

     
        private bool ValidInputs()
        {
            App.ClearErrorDisplay(cboCourse, errorProvider1, highlighterError);
            if (cboCourse.SelectedIndex == -1)
            {
                App.Message.ShowValidationError(cboCourse, "Select Course", errorProvider1, highlighterError);
                return false;
            }


            App.ClearErrorDisplay(cboYear, errorProvider1, highlighterError);
            if (cboYear.SelectedIndex == -1)
            {
                App.Message.ShowValidationError(cboYear, "Select Year", errorProvider1, highlighterError);
                return false;
            }

            return true;
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}