using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using SmartData;
using DevComponents.AdvTree;
using SmartApp.Properties;
using System.Drawing;
using System.Collections.Generic;
using Aitech.Crud;

namespace SmartApp
{
    public partial class frmOfferedCourse : MDIClientForm
    {
        OfferedCourseCollection OfferedCourseItems = new OfferedCourseCollection();
        Dictionary<string, Batch> BatchDictionary = new Dictionary<string, Batch>();

        public frmOfferedCourse()
        {
            InitializeComponent();
            Title = "Offered Courses Management";
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadBatchItems();

            tv.ExpandButtonType = eExpandButtonType.Triangle;
            tvBatch.ExpandButtonType = eExpandButtonType.Triangle;
        }

      
        private void DisplayBatchItems(IEnumerable<Batch> items)
        {
            tvBatch.Nodes.Clear();

            tvBatch.BeginUpdate();
            tv.Nodes.Clear();
            foreach (var item in items)
            {
                var batchNode = tvBatch.FindNodeByName(item.BatchName);

                if (batchNode == null)
                {
                    batchNode = new Node
                    {
                        //Name = item.BatchName,
                        Text = item.BatchName,
                        Expanded = true,
                        Name = item.BatchName
                    };

                    tvBatch.Nodes.Add(batchNode);
                }

                var semNode = tvBatch.FindNodeByName(item.BatchName + item.Semester);
                if (semNode == null)
                {
                    semNode = new Node
                    {
                        Name = item.BatchName + item.Semester, //Name must Match the BatchDictionary
                        Text = item.Semester,
                        Image = Resources.Address_Book_16
                    };

                    batchNode.Nodes.Add(semNode);
                }
            }
            tvBatch.EndUpdate();
        }

        private void LoadBatchItems()
        {
            Cursor.Current = Cursors.WaitCursor;

            var batchItems = new BatchCollection();
                batchItems.LoadItemsFromDb();

            BatchDictionary = new Dictionary<string, Batch>();

            foreach (var item in batchItems.Items)
                BatchDictionary.Add(item.BatchName + item.Semester, item);

            DisplayBatchItems(batchItems.Items);
        }

        private void DisplayItems(IEnumerable<OfferedCourse> items)
        {
            Cursor.Current = Cursors.WaitCursor;

            tv.BeginUpdate();
            tv.Nodes.Clear();
            tv.View = eView.Tile;
            //tv.View = eView.Tree;

            //Create Root Node
            var selectedNode = tvBatch.SelectedNode;
            if (selectedNode == null) return;

            var b = BatchDictionary[selectedNode.Name];
            var rootNode = new Node { Text = string.Format("{0} - {1}", b.BatchName, b.Semester), Expanded = true };

            tv.Nodes.Add(rootNode);

            var subStyle = new ElementStyle
            {
                TextColor = Color.Gray
                //Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic)
            };

            foreach (var item in items)
            {
                var nodeCourse = tv.FindNodeByName(item.CourseCode);

                if (nodeCourse == null)
                {
                    nodeCourse = new Node(string.Format("{0}  [{1}]", item.Course.Description, item.CourseCode)) {
                        Name = item.CourseCode,
                        Image = Resources.Briefcase_16};

                    nodeCourse.Expanded = true;
                    rootNode.Nodes.Add(nodeCourse);
                }

                //node.Cells.Add(new DevComponents.AdvTree.Cell() {
                //Text = "Year "  + item.YearLevel.ToString(),
                //StyleNormal = subStyle });

                var node = new Node { Text = "Year " + item.YearLevel, Image = Resources.Courses_16 };
                node.Cells.Add(new Cell { Text = "Created by:" + item.CreatedBy, StyleNormal = subStyle });
                node.Cells.Add(new Cell { Text = item.Created.ToString("dd-MMM-yyyy  hh:mm tt"), StyleNormal = subStyle });
                node.Name = item.Id.ToString();
                node.Tag = item;

                nodeCourse.Nodes.Add(node);
                node.CellLayout = eCellLayout.Vertical;
            }

            tv.EndUpdate();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedBatchNode = tvBatch.SelectedNode;
            if (selectedBatchNode == null)
            {
                ToastNotification.Show(this, "Select Semester First",  eToastPosition.TopCenter);
                return;
            }

            if (!BatchDictionary.ContainsKey(tvBatch.SelectedNode.Name))
            {
                ToastNotification.Show(this, "No Selected Semester Error", eToastPosition.TopCenter);
                return;
            }

            var frm = new frmOfferedCourse_Add(this);
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var item = frm.OfferedCourseItem;
                var batch = (Batch)BatchDictionary[tvBatch.SelectedNode.Name];
                item.Batch = batch;
                item.BatchId = batch.Id;

                batch.OfferedCourseItems.Add(item);
                DirtyStatus.SetDirty();
                tvBatch_NodeClick(tvBatch.SelectedNode, null);
            }

            frm.Dispose();

        }

        
        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var allBatch = BatchDictionary.Values;
                var items = allBatch.SelectMany(p => p.OfferedCourseItems.GetDirtyItems());

                var dataWriter = new OfferedCourseManager(App.CurrentUser.Username);
                    dataWriter.AttachRange(items);
                    dataWriter.SaveChanges();

                var selectedNode = tvBatch.SelectedNode.Name;

                DisplayBatchItems(BatchDictionary.Values);

                var node = tvBatch.FindNodeByName(selectedNode);
                tvBatch.SelectedNode = node;
                tvBatch_NodeClick(null, null);
            });            
        }

            
        internal bool ContainsData(OfferedCourse item)
        {
            var b = (Batch)BatchDictionary[tvBatch.SelectedNode.Name];

            var foundItem = b.OfferedCourseItems.Items.FirstOrDefault(x => x.CourseCode == item.CourseCode &&
                                                    x.YearLevel == item.YearLevel);

            if (foundItem == null) return false;
            if (foundItem.Id == item.Id && foundItem.Id != 0) return false;

            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh(() =>
            {
                OfferedCourseItems = new OfferedCourseCollection();
                LoadBatchItems();
            });
            
            DirtyStatus.Clear();
        }

      
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(tv.SelectedNode == null)
            {
                ToastNotification.Show(this, "Select item to be deleted", eToastPosition.TopCenter);
                return;
            }

            var item = (OfferedCourse)tv.SelectedNode.Tag;
            if (item == null) return;

            var result = App.Message.AskToDelete();
            if (result == eTaskDialogResult.No) return;

            var selectedBatch = BatchDictionary[tvBatch.SelectedNode.Name];            
            selectedBatch.OfferedCourseItems.Remove(item);

            var parentNode = tv.SelectedNode.Parent;
            if (parentNode != null) 
                parentNode.Nodes.Remove(tv.SelectedNode);

            if (!parentNode.HasChildNodes)
                parentNode.Remove();

            DirtyStatus.SetDirty();
        }

       
        private void tvBatch_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tv.Nodes.Clear();
            var node = tvBatch.SelectedNode;

            if (!BatchDictionary.ContainsKey(node.Name)) return;

            IEnumerable<OfferedCourse> items = new List<OfferedCourse>();
            var selectedBatch = BatchDictionary[node.Name];

            if (node.TagString == "done")
                //Filter Locally
                items = selectedBatch.OfferedCourseItems.Items;
            else
            {
                //Get From Db
                selectedBatch.LoadCoursesOffered();
                items = selectedBatch.OfferedCourseItems.Items;
                node.TagString = "done";
            }

            DisplayItems(items);
        }
    }
}