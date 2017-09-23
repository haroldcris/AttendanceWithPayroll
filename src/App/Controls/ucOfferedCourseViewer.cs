using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Winform.Controls
{
    public partial class ucOfferedCourseViewer : UserControl
    {
        private Dictionary<string, bool> NodeDictionary;

        public IEnumerable<OfferedCourse> OfferedCourseItems { get; private set; }
        public bool UseSmallIcons { get; set; }

        public ucOfferedCourseViewer()
        {
            InitializeComponent();
            NodeDictionary = new Dictionary<string, bool>();


            TreeView.DragDropEnabled = false;
            TreeView.ExpandButtonType = eExpandButtonType.Triangle;
            TreeView.ExpandButtonSize = new Size(16, 16);

            TreeView.NodeSpacing = 10;
            TreeView.SelectionFocusAware = false;

            TreeView.KeyPress += TreeView_KeyPress;
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
        public bool IsActiveNodeSelectedBefore
        {
            get
            {
                if (TreeView.SelectedNode == null) return false;
                if (!NodeDictionary.ContainsKey(TreeView.SelectedNode.Name))
                {
                    return false;
                }
                return NodeDictionary[TreeView.SelectedNode.Name];
            }
            set
            {
                if (TreeView.SelectedNode == null) return;
                if (!NodeDictionary.ContainsKey(TreeView.SelectedNode.Name))
                {
                    NodeDictionary.Add(TreeView.SelectedNode.Name, value);
                }

                NodeDictionary[TreeView.SelectedNode.Name] = value;
            }
        }

        public OfferedCourse SelectedOfferedCourse
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
            var rootNode = new Node { Text = string.Format("{0} - {1}", batch.BatchName, batch.Semester), Expanded = true };

            TreeView.Nodes.Add(rootNode);
            var subStyle = new ElementStyle { TextColor = Color.Gray /*Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic) */};

            foreach (var item in batch.OfferedCourses.Items)
            {
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


                if (!UseSmallIcons)
                {
                    node.Image = Properties.Resources.Courses_30;
                    node.Cells.Add(new Cell { Text = "Created by:" + item.CreatedBy, StyleNormal = subStyle });
                    node.Cells.Add(new Cell { Text = item.Created.ToShortTimeString(), StyleNormal = subStyle });
                }
                else
                    node.Image = Properties.Resources.Courses_16;

                node.Tag = item;
                nodeCourse.Nodes.Add(node);
                node.CellLayout = eCellLayout.Vertical;
            }

            TreeView.EndUpdate();

        }


        //public void ClearTrackingChanges()
        //{
        //    NodeDictionary = new Dictionary<string, bool>();
        //}

        //public void ClearAll()
        //{
        //    NodeDictionary = new Dictionary<string, bool>();
        //    TreeView.Nodes.Clear();
        //    //course
        //}
    }
}
