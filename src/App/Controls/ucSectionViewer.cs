using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System.Drawing;
using System.Windows.Forms;

namespace Winform.Controls
{
    public partial class ucSectionViewer : UserControl
    {
        private ElementStyle SubItemStyle;

        /// <summary>
        /// The Node where the new items will be added
        /// </summary>
        private Node YearLevelNode;

        /// <summary>
        /// Set Variable to True if in Cell Editing
        /// </summary>
        private bool InEditMode;


        public event CellEditEventHandler AfterCellEdit;

        public Dll.SchoolYear.OfferedCourse OfferedCourseItem { get; set; }

        public bool IsDirty { get; set; }

        public ucSectionViewer()
        {
            InitializeComponent();

            TreeView.Nodes.Clear();
            TreeView.ExpandButtonType = eExpandButtonType.Triangle;
            TreeView.ExpandButtonSize = new Size(16, 16);

            TreeView.NodeSpacing = 10;


            // TreeView.KeyPress += TreeView_KeyPress;
            // TreeView.CellEditEnding += TreeView_CellEditEnding;

            SubItemStyle = new ElementStyle { TextColor = Color.Gray /*Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic) */};
        }


        public void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (OfferedCourseItem == null) throw new System.Exception("OfferedCourse Item NOT Set");

            OfferedCourseItem?.Sections.LoadItemsFromDb();

            TreeView.BeginUpdate();
            TreeView.Nodes.Clear();
            TreeView.View = eView.Tile;

            //Create Root            
            var course = OfferedCourseItem.CourseClass;
            var rootNode = new Node { Text = string.Format("{0} - {1}", course.CourseCode.ToUpper(), course.Description), Expanded = true };

            //Create Year Level Node
            //YearLevelNode = TreeView.FindNodeByName(OfferedCourseItem.YearLevelInWords);

            var yearNodeText = "";
            switch (OfferedCourseItem.YearLevel)
            {
                case 1: yearNodeText = "1st Year"; break;
                case 2: yearNodeText = "2nd Year"; break;
                case 3: yearNodeText = "3rd Year"; break;
                case 4: yearNodeText = "4th Year"; break;
                case 5: yearNodeText = "5th Year"; break;
                default: yearNodeText = ""; break;
            }

            YearLevelNode = new Node(yearNodeText);
            YearLevelNode.Name = yearNodeText;

            YearLevelNode.Expanded = true;

            rootNode.Nodes.Add(YearLevelNode);
            TreeView.Nodes.Add(rootNode);


            foreach (var sectionItem in OfferedCourseItem.Sections.Items)
            {
                YearLevelNode.Nodes.Add(CreateNode(sectionItem));
            }

            TreeView.EndUpdate();

        }

        private void TreeView_CellEditEnding(object sender, CellEditEventArgs e)
        {
            var itemEvent = AfterCellEdit;
            var section = (Dll.SchoolYear.Section)e.Cell.Tag;

            if (e.IsUserCanceled)
            {
                if (InEditMode)
                {
                    if (itemEvent != null) itemEvent.Invoke(sender, e);
                    return;
                }

                OfferedCourseItem.Sections.Remove(section);
                TreeView.SelectedNode.Remove();

                if (itemEvent != null) itemEvent.Invoke(sender, e);
                return;
            }


            ////var foundItem = OfferedCourseItem.Sections.Items.FirstOrDefault(o => o.SectionName == e.NewText);
            //var foundItem = ItemDictionary.FirstOrDefault(o => o.Value.SectionName == e.NewText &&
            //                                              o.Value.Token != section.Token &&
            //                                              o.Value.RecordStatus != RecordStatus.DeletedRecord).Value;

            //if (foundItem != null)
            //{
            //    ToastNotification.Show(this, "Similar Section Name Already Exists!", eToastPosition.TopCenter);
            //    e.Cancel = true;
            //    if (itemEvent != null) itemEvent.Invoke(sender, e);
            //    return;
            //}


            section.SectionName = e.NewText;
            IsDirty = true;
            if (itemEvent != null) itemEvent.Invoke(sender, e);
        }



        private void TreeView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                TreeView.SelectedNode.RaiseClick();
            }
        }



        //public Section SelectedSection
        //{
        //    get
        //    {
        //        if (TreeView.SelectedNode == null) return null;
        //        return (Section)TreeView.SelectedNode?.Tag;
        //    }
        //}



        private Node CreateNode(Dll.SchoolYear.Section item)
        {
            var newNode = new Node { Text = item.SectionName, Image = Properties.Resources.Conference_Call_30 };

            newNode.Cells.Add(new Cell { Text = "Created by:" + item.CreatedBy, StyleNormal = SubItemStyle });
            newNode.Cells.Add(new Cell { Text = item.Created.ToString("dd-MMM-yyyy  hh:mm tt"), StyleNormal = SubItemStyle });

            newNode.Name = item.RowId;
            newNode.Tag = item;
            newNode.CellLayout = eCellLayout.Vertical;
            return newNode;
        }

        public void AddSection()
        {
            var item = new Section();
            item.SectionName = "New Section " + TreeView.Nodes.Count + 1;

            OfferedCourseItem.Sections.Add(item);

            var writer = new SectionDataWriter(App.CurrentUser.User.Username, item);
            writer.SaveChanges();

            var newNode = CreateNode(item);
            YearLevelNode.Nodes.Add(newNode);
            TreeView.SelectNode(newNode, eTreeAction.Mouse);
            InEditMode = false;
            newNode.BeginEdit();
        }

        public void EditSection()
        {
            //if (this.SelectedSection == null)
            //{
            //    ToastNotification.Show(this, "Select an item to edit", eToastPosition.TopCenter);
            //    return;
            //}

            //InEditMode = true;
            //TreeView.SelectedNode.BeginEdit();
        }

        public void RemoveSelectedNode()
        {
            //if (this.SelectedSection == null)
            //{
            //    ToastNotification.Show(this, "Select an item to edit", eToastPosition.TopCenter);
            //    return;
            //}

            //OfferedCourseItem.Sections.Remove(this.SelectedSection);

            //IsDirty = true;
            //TreeView.SelectedNode.Remove();
        }
    }
}
