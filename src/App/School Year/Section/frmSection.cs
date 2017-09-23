using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using Dll.SchoolYear;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmSection : MdiClientForm
    {
        private Batch SelectedBatch = null;

        public frmSection()
        {
            InitializeComponent();


            Header = " COURSES OFFERED MANAGEMENT ";
            HeaderColor = App.BarColor.CourseColor;

            Load += (s, e) => { LoadData(); };


            BatchViewer.TreeView.NodeClick += Batch_NodeClick;
            OfferedCourseViewer.TreeView.NodeClick += OfferedCourse_NodeClick;

        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

            BatchViewer.LoadBatchItems();
        }



        private void OfferedCourse_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            var item = (OfferedCourse)e.Node?.Tag;

            if (item == null) return;

            SectionViewer.OfferedCourseItem = item;
            SectionViewer.LoadItems();
        }




        private void Batch_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            SelectedBatch = (Batch)e.Node.Tag;
            if (SelectedBatch == null) return;

            SelectedBatch.OfferedCourses.LoadItems();

            if (!SelectedBatch.OfferedCourses.Items.Any()) return;

            OfferedCourseViewer.LoadItems(SelectedBatch);
        }



        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadData();
        }


        private OfferedCourse OnAdd()
        {
            var newItem = new OfferedCourse();


            newItem.BatchId = SelectedBatch.Id;
            newItem.BatchClass = SelectedBatch;

            //using (var frm = new frmSection_Add())
            //{
            //    frm.ItemData = newItem;
            //    if (frm.ShowDialog() != DialogResult.OK) return null;
            //}

            return newItem;
        }


        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (SelectedBatch == null)
            {
                MessageDialog.ShowValidationError(BatchViewer, "Select Batch First", null, null, 40, false);

                return;
            }

            try
            {
                var item = OnAdd();
                if (item == null) return;

                SelectedBatch.OfferedCourses.Attach(item);

                App.LogAction("Offered Course", "Added Offered Course " + item.CourseClass.Description);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }



        private void OnDelete(OfferedCourse item, out string deleteMessage, ref Action<OfferedCourse> afterConfirm)
        {
            deleteMessage = item.CourseClass.CourseCode + " - " + item.YearLevel.ToString();

            afterConfirm = currentItem =>
            {
                try
                {
                    currentItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new OfferedCourseDataWriter(App.CurrentUser.User.Username, currentItem);
                    dataWriter.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }


        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    var item = (OfferedCourse)tv.SelectedNode?.Tag;
            //    if (item == null)
            //    {
            //        MessageDialog.ShowValidationError(BatchViewer, "Select Item First", null, null, 40, false);
            //        return;
            //    }
            //    string deleteMessage;
            //    Action<OfferedCourse> action = i => { };

            //    OnDelete(item, out deleteMessage, ref action);

            //    var ret = MessageDialog.AskToDelete("<b>" + deleteMessage.ToUpper() + "</b>");

            //    if (ret != MessageDialogResult.Yes) return;

            //    action(item);

            //    tv.SelectedNode.Remove();
            //    App.LogAction("Offered Course", "Deleted Offered Course : " + item.CourseClass.CourseCode + " - " + item.YearLevel.ToString());

            //}
            //catch (Exception ex)
            //{
            //    MessageDialog.ShowError(ex, this);
            //}
        }
    }
}
