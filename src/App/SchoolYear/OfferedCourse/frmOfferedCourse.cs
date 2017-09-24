using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Winform.Properties;

namespace Winform.SchoolYear
{
    public partial class frmOfferedCourse : MdiClientForm
    {
        private Batch SelectedBatch = null;

        public frmOfferedCourse()
        {
            InitializeComponent();

            Header = " OFFERED COURSES MANAGEMENT ";
            HeaderColor = App.BarColor.CourseColor;

            Load += (s, e) => { LoadData(); };


            BatchViewer.ItemSelected += BatchViewer_ItemSelected;

            tv.ExpandButtonType = eExpandButtonType.Triangle;
        }


        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

            tv.Nodes.Clear();

            BatchViewer.LoadItems();
        }


        private void BatchViewer_ItemSelected(object sender, Batch e)
        {
            Cursor.Current = Cursors.WaitCursor;

            tv.Nodes.Clear();

            SelectedBatch = e;
            if (SelectedBatch == null) return;

            SelectedBatch.OfferedCourses.LoadItems();

            if (!SelectedBatch.OfferedCourses.Items.Any()) return;

            Show_OfferedCourses(SelectedBatch);

        }





        private void Show_OfferedCourses(Batch batchItem)
        {
            Cursor.Current = Cursors.WaitCursor;

            tv.BeginUpdate();
            tv.Nodes.Clear();
            tv.View = eView.Tile;


            //Create Root Node
            var rootNode = new Node { Text = string.Format("{0} - {1}", batchItem.BatchName, batchItem.Semester), Expanded = true };
            tv.Nodes.Add(rootNode);


            var subStyle = new ElementStyle
            {
                TextColor = Color.Gray
                //Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic)
            };


            foreach (var offeredCourseItem in batchItem.OfferedCourses.Items)
            {
                var nodeCourse = tv.FindNodeByName(offeredCourseItem.CourseClass.CourseCode);

                if (nodeCourse == null)
                {
                    nodeCourse = new Node(string.Format("{0}  [{1}]", offeredCourseItem.CourseClass.Description, offeredCourseItem.CourseClass.CourseCode))
                    {
                        Name = offeredCourseItem.CourseClass.CourseCode,
                        Image = Resources.Briefcase_16
                    };

                    nodeCourse.Expanded = true;
                    rootNode.Nodes.Add(nodeCourse);
                }

                //node.Cells.Add(new DevComponents.AdvTree.Cell() {
                //Text = "Year "  + item.YearLevel.ToString(),
                //StyleNormal = subStyle });

                var node = new Node { Text = "Year " + offeredCourseItem.YearLevel, Image = Resources.Courses_16 };

                node.Cells.Add(new Cell { Text = "Created by:" + offeredCourseItem.CreatedBy, StyleNormal = subStyle });
                node.Cells.Add(new Cell { Text = offeredCourseItem.Created.ToString("dd-MMM-yyyy  hh:mm tt"), StyleNormal = subStyle });
                node.Name = offeredCourseItem.Id.ToString();
                node.Tag = offeredCourseItem;

                nodeCourse.Nodes.Add(node);
                node.CellLayout = eCellLayout.Vertical;
            }

            tv.EndUpdate();

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

            using (var frm = new frmOfferedCourse_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

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
                Show_OfferedCourses(SelectedBatch);

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
            try
            {
                var item = (OfferedCourse)tv.SelectedNode?.Tag;
                if (item == null)
                {
                    MessageDialog.ShowValidationError(BatchViewer, "Select Item First", null, null, 40, false);
                    return;
                }
                string deleteMessage;
                Action<OfferedCourse> action = i => { };

                OnDelete(item, out deleteMessage, ref action);

                var ret = MessageDialog.AskToDelete("<b>" + deleteMessage.ToUpper() + "</b>");

                if (ret != MessageDialogResult.Yes) return;

                action(item);

                tv.SelectedNode.Remove();
                App.LogAction("Offered Course", "Deleted Offered Course : " + item.CourseClass.CourseCode + " - " + item.YearLevel.ToString());

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }
    }
}
