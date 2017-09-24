using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Winform.Controls
{
    public partial class ucOfferedCourseViewer : UserControl
    {
        public event EventHandler<OfferedCourse> ItemSelected;

        public IEnumerable<OfferedCourse> OfferedCourseItems { get; private set; }

        public bool UseSmallIcons { get; set; }

        public ucOfferedCourseViewer()
        {
            InitializeComponent();

            TreeView.DragDropEnabled = false;
            TreeView.ExpandButtonType = eExpandButtonType.Triangle;
            TreeView.ExpandButtonSize = new Size(16, 16);

            TreeView.NodeSpacing = 10;
            TreeView.SelectionFocusAware = false;

            TreeView.KeyPress += TreeView_KeyPress;
            TreeView.AfterNodeSelect += TreeView_AfterNodeSelect;
        }

        private void TreeView_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            var item = (OfferedCourse)e.Node?.Tag;
            OnItemSelected(item);
        }


        private void TreeView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                System.Console.WriteLine("CLick");
                TreeView.SelectedNode.RaiseClick();
            }
        }


        /// <summary>
        /// Check if this item is already click before
        /// </summary>
        //public bool IsActiveNodeSelectedBefore
        //{
        //    get
        //    {
        //        if (TreeView.SelectedNode == null) return false;
        //        if (!NodeDictionary.ContainsKey(TreeView.SelectedNode.Name))
        //        {
        //            return false;
        //        }
        //        return NodeDictionary[TreeView.SelectedNode.Name];
        //    }
        //    set
        //    {
        //        if (TreeView.SelectedNode == null) return;
        //        if (!NodeDictionary.ContainsKey(TreeView.SelectedNode.Name))
        //        {
        //            NodeDictionary.Add(TreeView.SelectedNode.Name, value);
        //        }

        //        NodeDictionary[TreeView.SelectedNode.Name] = value;
        //    }
        //}


        public OfferedCourse SelectedItem
        {
            get
            {
                if (TreeView.SelectedNode == null) return null;
                if (TreeView.SelectedNode.Tag == null) return null;

                return (OfferedCourse)TreeView.SelectedNode.Tag;
            }
        }



        public void LoadItems(Batch batch)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (batch == null) return;

            batch.OfferedCourses.LoadItems();

            TreeView.BeginUpdate();
            TreeView.Nodes.Clear();

            if (!UseSmallIcons) TreeView.View = eView.Tile;

            //Create Root
            var rootNode = new Node { Name = "Root", Text = string.Format("{0} - {1}", batch.BatchName, batch.Semester), Expanded = true };

            TreeView.Nodes.Add(rootNode);


            foreach (var item in batch.OfferedCourses.Items)
            {
                CreateNode(item);
            }

            TreeView.EndUpdate();

        }


        public void UpdateNode()
        {
            UpdateNode(TreeView.SelectedNode);
        }


        public void UpdateNode(Node node)
        {
            var item = (OfferedCourse)node?.Tag;

            if (item == null) throw new Exception("Node is Null");

            node.Text = "Year " + item.YearLevel;

            var subStyle = new ElementStyle { TextColor = Color.Gray /*Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic) */};

            if (!UseSmallIcons)
            {
                node.Image = Properties.Resources.Courses_30;
                node.Cells.Add(new Cell { Text = "Created by:" + item.CreatedBy, StyleNormal = subStyle });
                node.Cells.Add(new Cell { Text = item.Created.ToShortTimeString(), StyleNormal = subStyle });
            }
            else
            {
                node.Image = Properties.Resources.Courses_16;
            }

            node.Tag = item;
            node.CellLayout = eCellLayout.Vertical;
        }




        public void CreateNode(OfferedCourse item)
        {
            var rootNode = TreeView.FindNodeByName("Root");

            var nodeCourse = TreeView.FindNodeByName(item.CourseClass.CourseCode);

            if (nodeCourse == null)
            {
                nodeCourse = new Node(string.Format("{0}  [{1}]", item.CourseClass.Description, item.CourseClass.CourseCode));
                nodeCourse.Image = Properties.Resources.Briefcase_30;
                nodeCourse.Name = item.CourseClass.CourseCode;

                if (UseSmallIcons)
                    nodeCourse.Image = Properties.Resources.Briefcase_16;

                nodeCourse.Expanded = true;
                rootNode.Nodes.Add(nodeCourse);
            }



            var node = new Node { Text = "Year " + item.YearLevel };
            node.Name = item.Id.ToString();
            node.Tag = item;

            UpdateNode(node);

            nodeCourse.Nodes.Add(node);
        }


        //public void ClearTrackingChanges()
        //{
        //    NodeDictionary = new Dictionary<string, bool>();
        //}

        public void Clear()
        {
            TreeView.Nodes.Clear();
        }


        protected virtual void OnItemSelected(OfferedCourse item)
        {
            ItemSelected?.Invoke(this, item);
        }
    }
}
