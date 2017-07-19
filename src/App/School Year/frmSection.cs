using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartData;

namespace SmartApp
{
    public partial class frmSection : MDIClientForm
    {
        public frmSection()
        {
            InitializeComponent();
            Title = "Section Management";
            HeaderColor = Color.Sienna;

            CourseOfferedViewer.UseSmallIcons = true;

            this.Load += Form_Load;

            BatchViewer.TreeView.NodeClick += BatchViewer_NodeClick;
            CourseOfferedViewer.TreeView.NodeClick += CourseOffered_NodeClick;
            
            SectionViewer.AfterCellEdit += SectionViewer_AfterCellEdit;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            BatchViewer.LoadBatchItems();

            CourseOfferedViewer.TreeView.Nodes.Clear();
            SectionViewer.TreeView.Nodes.Clear();            
        }


        private void SectionViewer_AfterCellEdit(object sender, DevComponents.AdvTree.CellEditEventArgs e)
        {
            if (SectionViewer.IsDirty)
                DirtyStatus.SetDirty();
        }

        private void CourseOffered_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            SectionViewer.TreeView.Nodes.Clear();

            var node = CourseOfferedViewer.TreeView.SelectedNode;
            var courseOffered = CourseOfferedViewer.SelectedOfferedCourse;

            if (courseOffered == null) return;

            SectionViewer.OfferedCourseItem = courseOffered;

            if(CourseOfferedViewer.IsActiveNodeSelectedBefore)
            {
                Console.WriteLine("From Cache");
                SectionViewer.LoadItems();
            }
            else
            {
                Console.WriteLine("From Database");
                SectionViewer.LoadItems(true);
                CourseOfferedViewer.IsActiveNodeSelectedBefore = true;
            }
        }

        private void BatchViewer_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            CourseOfferedViewer.TreeView.Nodes.Clear();
            SectionViewer.TreeView.Nodes.Clear();

            var node = BatchViewer.TreeView.SelectedNode;
            var batch = BatchViewer.SelectedBatch;

            if (batch == null) return;

            if (BatchViewer.IsActiveNodeSelectedBefore)
            {
                Console.WriteLine("Batch From Cache");
                CourseOfferedViewer.LoadItems(batch);
            }
            else
            {
                Console.WriteLine("Batch From Database");
                CourseOfferedViewer.LoadItems(batch, true);
                BatchViewer.IsActiveNodeSelectedBefore = true;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CourseOfferedViewer.SelectedOfferedCourse == null)
            {
                ToastNotification.Show(CourseOfferedViewer, "Select Year Level Item in order to Add", eToastPosition.TopCenter);
                return;
            }

            SectionViewer.OfferedCourseItem = CourseOfferedViewer.SelectedOfferedCourse;
            SectionViewer.IsDirty = false;
            SectionViewer.AddSection();
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SectionViewer.SelectedSection == null)
            {
                ToastNotification.Show(SectionViewer, "Select Section Item to Edit", eToastPosition.TopCenter);
                return;
            }

            SectionViewer.OfferedCourseItem = CourseOfferedViewer.SelectedOfferedCourse;
            SectionViewer.IsDirty = false;
            SectionViewer.EditSection();
            if (SectionViewer.IsDirty)
                DirtyStatus.SetDirty();

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SectionViewer.TreeView.SelectedNode.IsEditing) return;

            if (SectionViewer.SelectedSection == null)
            {
                ToastNotification.Show(SectionViewer, "Select Section Item to Delete", eToastPosition.TopCenter);
                return;
            }

            if (App.Message.AskToDelete() == eTaskDialogResult.No) return;

            SectionViewer.OfferedCourseItem = CourseOfferedViewer.SelectedOfferedCourse;
            SectionViewer.RemoveSelectedNode();
            DirtyStatus.SetDirty();
        }


        public override bool FileSave()
        {
            return DoSave(() =>
            {
                SectionManager DataManager = new SectionManager(App.CurrentUser.Username);

                var itemsToBeSaved = BatchViewer.BatchItems.Items.SelectMany(o => o.OfferedCourseItems.Items.SelectMany(s => s.Sections.GetDirtyItems()));

                DataManager.Sections.AttachRange(itemsToBeSaved);
                DataManager.SaveChanges();

                var sections = BatchViewer.BatchItems.Items.SelectMany(b => b.OfferedCourseItems.Items.Select(c => c.Sections));

                foreach (var item in sections)
                    item.CommitChanges();

                CourseOfferedViewer.ClearTrackingChanges();
                DirtyStatus.Clear();

                CourseOffered_NodeClick(null, null);
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh(() =>
            {
                SectionViewer.TreeView.Nodes.Clear();
                CourseOfferedViewer.ClearAll();
                BatchViewer.LoadBatchItems();
            });
        }

        private void BatchViewer_Load(object sender, EventArgs e)
        {

        }
        
    }
}
