using DevComponents.DotNetBar;
using System;
using System.Windows.Forms;

namespace Winform.SchoolYear.Section
{
    public partial class frmSectionSelector : Office2007Form
    {

        public Dll.SchoolYear.Section ItemData { get; private set; }

        public frmSectionSelector()
        {
            InitializeComponent();
        }

        private void frmSectionSelector_Load(object sender, EventArgs e)
        {
            BatchViewer.LoadItems();

            BatchViewer.NodeClick += BatchViewer_NodeClick;
            BatchViewer.OfferedCourseSelected += UcFullBatchViewer1_OfferedCourseSelected;

            SectionViewer.ItemSelected += SectionViewer_ItemSelected;

            btnOk.Enabled = false;
        }

        private void SectionViewer_ItemSelected(object sender, Dll.SchoolYear.Section e)
        {
            btnOk.Enabled = e != null;

            ItemData = e;

        }

        private void BatchViewer_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            //throw new NotImplementedException();
            SectionViewer.Clear();
        }

        private void UcFullBatchViewer1_OfferedCourseSelected(object sender, Dll.SchoolYear.OfferedCourse e)
        {
            //throw new NotImplementedException();
            SectionViewer.LoadItems(e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (ItemData != null)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
