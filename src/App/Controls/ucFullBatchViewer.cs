using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Winform.Controls;

namespace SmartApp.UC
{
    public partial class ucFullBatchViewer : ucBatchViewer
    {
        public event EventHandler<TreeNodeMouseEventArgs> NodeClick;
        public event EventHandler<OfferedCourse> OfferedCourseSelected;

        public ucFullBatchViewer()
        {
            InitializeComponent();

            TreeView.NodeClick += TreeView_NodeClick;
        }


        protected virtual void OnNodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            EventHandler<TreeNodeMouseEventArgs> handler = NodeClick;
            handler?.Invoke(sender, e);
        }

        private void TreeView_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            OnNodeClick(sender, e);

            var node = TreeView.SelectedNode;

            if (node == null) return;

            var batch = this.SelectedBatchItem;

            if (batch != null)
            {
                LoadOfferedCourses(batch);
            }
            else
            {
                //Load Sections 
                Debug.WriteLine("SElected Offered COurses");

                var item = (OfferedCourse)node.Tag;
                if (item == null) return;

                //var nodeSelectorHandler = OfferedCourseSelected;
                OfferedCourseSelected?.Invoke(this, item);
            }
        }

        public override void LoadItems()
        {
            base.LoadItems();

            if (TreeView.Nodes.Count == 0) return;

            TreeView.CollapseAll();
            TreeView.Nodes[0].ExpandAll();
        }

        protected void LoadOfferedCourses(Batch batch)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (batch == null) return;

            batch.OfferedCourses.LoadItems();

            TreeView.BeginUpdate();

            //TreeView.Nodes.Clear();
            //if (!UseSmallIcons) TreeView.View = eView.Tile;
            //Create Root
            //var rootNode = new Node { Name = "Root", Text = string.Format("{0} - {1}", batch.BatchName, batch.Semester), Expanded = true };

            TreeView.SelectedNode.Nodes?.Clear();

            foreach (var item in batch.OfferedCourses.Items)
            {
                CreateNode(item, TreeView.SelectedNode);
            }

            TreeView.EndUpdate();

        }


        private void CreateNode(OfferedCourse item, Node rootNode)
        {
            //var rootNode = TreeView.FindNodeByName("Root");

            var nodeCourse = rootNode.Nodes.Find(item.CourseClass.CourseCode, true)?.FirstOrDefault();

            if (nodeCourse == null)
            {
                nodeCourse = new Node(string.Format("{0}  [{1}]", item.CourseClass.Description, item.CourseClass.CourseCode));
                //nodeCourse.Image = Properties.Resources.Briefcase_30;
                nodeCourse.Name = item.CourseClass.CourseCode;

                //if (UseSmallIcons)
                //    nodeCourse.Image = Properties.Resources.Briefcase_16;

                nodeCourse.Expanded = true;
                rootNode.Nodes.Add(nodeCourse);
            }



            var node = new Node { Text = "Year " + item.YearLevel };
            node.Name = item.Id.ToString();
            node.Tag = item;

            UpdateNode(node);

            nodeCourse.Nodes.Add(node);
        }



        public void UpdateNode(Node node)
        {
            var item = (OfferedCourse)node?.Tag;

            if (item == null) throw new Exception("Node is Null");

            node.Text = "Year " + item.YearLevel;

            var subStyle = new ElementStyle { TextColor = Color.Gray /*Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic) */};

            //if (!UseSmallIcons)
            //{
            //    //node.Image = Properties.Resources.Courses_30;
            //    node.Cells.Add(new Cell { Text = "Created by:" + item.CreatedBy, StyleNormal = subStyle });
            //    node.Cells.Add(new Cell { Text = item.Created.ToShortTimeString(), StyleNormal = subStyle });
            //}
            //else
            //{
            //    //node.Image = Properties.Resources.Courses_16;
            //}

            node.Tag = item;
            node.CellLayout = eCellLayout.Vertical;
        }


        public OfferedCourse SelectedOfferedCourse
        {
            get
            {
                if (TreeView.SelectedNode == null) return null;
                if (TreeView.SelectedNode.Tag == null) return null;


                Debug.WriteLine(TreeView.SelectedNode.Tag.GetType().ToString().ToLower());

                if (TreeView.SelectedNode.Tag.GetType().ToString().ToLower().Equals("smartdata.offeredcourse"))
                    return (OfferedCourse)TreeView.SelectedNode.Tag;

                return null;
            }
        }



        protected override void TreeView_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            //base.TreeView_AfterNodeSelect(sender, e);
            if (e.Node.Level <= 2)
            {
                Debug.WriteLine("Batch Node is selected");

                var item = (Batch)e.Node?.Tag;
                OnItemSelected(item);
            }

        }



    }
}
