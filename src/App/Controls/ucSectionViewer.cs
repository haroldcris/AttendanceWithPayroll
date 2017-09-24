using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System;
using System.Drawing;
using System.Linq;
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

        public event EventHandler<Section> ItemSelected;
        public event EventHandler<Section> AfterItemEdit;

        private OfferedCourse OfferedCourseItem;

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

            TreeView.AfterNodeSelect += TreeView_AfterNodeSelect;
            TreeView.AfterCellEdit += TreeView_AfterCellEdit;

            SubItemStyle = new ElementStyle { TextColor = Color.Gray /*Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic) */};
        }

        private void TreeView_AfterCellEdit(object sender, CellEditEventArgs e)
        {
            if (e.IsUserCanceled) return;

            var item = (Section)e.Cell.Tag;


            if (string.IsNullOrWhiteSpace(e.NewText))
            {
                e.Cancel = true;
                return;
            }

            // Check for Duplicate Record
            var findItem = this.OfferedCourseItem.Sections.Items.Where(_ => _.SectionName == e.NewText && _.RowId != item.RowId);

            if (findItem.Any())
            {
                e.Cancel = true;
                FireEvent(AfterItemEdit, null);
                return;
            }



            item.SectionName = e.NewText;

            FireEvent(AfterItemEdit, item);

        }

        public void LoadItems(OfferedCourse item)
        {
            OfferedCourseItem = item;
            OfferedCourseItem.Sections.LoadItemsFromDb();

            ShowItems();
        }


        public bool SaveChanges(string username)
        {
            var writer = new SectionDataWriter(username, OfferedCourseItem.Sections);
            var result = writer.SaveChanges();

            UpdateFileInfo();

            return result;
        }


        private void TreeView_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            var item = (Section)e.Node?.Tag;
            if (item == null) return;

            FireEvent(ItemSelected, item);

        }


        public void RefreshData()
        {
            YearLevelNode.Nodes.Clear();

            foreach (var sectionItem in OfferedCourseItem.Sections.Items)
            {
                YearLevelNode.Nodes.Add(CreateNode(sectionItem));
            }
        }


        public void ShowItems()
        {
            if (OfferedCourseItem == null) throw new System.Exception("Offered Course Item NOT Set");

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

            RefreshData();

            TreeView.EndUpdate();

        }


        private void TreeView_CellEditEnding(object sender, CellEditEventArgs e)
        {
            //var itemEvent = AfterCellEdit;
            //var section = (Section)e.Cell.Tag;

            //if (e.IsUserCanceled)
            //{
            //    if (InEditMode)
            //    {
            //        if (itemEvent != null) itemEvent.Invoke(sender, e);
            //        return;
            //    }

            //    OfferedCourseItem.Sections.Remove(section);
            //    TreeView.SelectedNode.Remove();

            //    if (itemEvent != null) itemEvent.Invoke(sender, e);
            //    return;
            //}


            //////var foundItem = OfferedCourseItem.Sections.Items.FirstOrDefault(o => o.SectionName == e.NewText);
            ////var foundItem = ItemDictionary.FirstOrDefault(o => o.Value.SectionName == e.NewText &&
            ////                                              o.Value.Token != section.Token &&
            ////                                              o.Value.RecordStatus != RecordStatus.DeletedRecord).Value;

            ////if (foundItem != null)
            ////{
            ////    ToastNotification.Show(this, "Similar Section Name Already Exists!", eToastPosition.TopCenter);
            ////    e.Cancel = true;
            ////    if (itemEvent != null) itemEvent.Invoke(sender, e);
            ////    return;
            ////}


            //section.SectionName = e.NewText;
            //IsDirty = true;
            //if (itemEvent != null) itemEvent.Invoke(sender, e);
        }



        private void TreeView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    TreeView.SelectedNode.RaiseClick();
            //}
        }



        //public Section SelectedSection
        //{
        //    get
        //    {
        //        if (TreeView.SelectedNode == null) return null;
        //        return (Section)TreeView.SelectedNode?.Tag;
        //    }
        //}



        private Node CreateNode(Section item)
        {
            var newNode = new Node { Text = item.SectionName, Image = Properties.Resources.Classroom_24px };

            newNode.Cells.Add(new Cell { Name = "Created", Text = "Created by:" + item.CreatedBy, StyleNormal = SubItemStyle });
            newNode.Cells.Add(new Cell { Name = "Modified", Text = item.Created.ToString("dd-MMM-yyyy  hh:mm tt"), StyleNormal = SubItemStyle });

            newNode.Name = item.RowId;
            newNode.Tag = item;
            newNode.CellLayout = eCellLayout.Vertical;
            return newNode;
        }


        public void Clear()
        {
            TreeView.Nodes.Clear();
        }


        public Section CreateNewItem(bool editItemAfterCreate = false)
        {
            if (YearLevelNode == null) throw new Exception("No Selected Year Level");

            var item = new Section();
            item.OfferedCourseId = OfferedCourseItem.Id;
            item.SectionName = OfferedCourseItem.Sections.GetNewSectionName();

            var node = CreateNode(item);

            TreeView.SelectNode(node, eTreeAction.Mouse);

            YearLevelNode.Nodes.Add(node);

            if (editItemAfterCreate)
                node.BeginEdit();

            return item;
        }


        //public void UpdateSection(Section item)
        //{

        //}

        public void RemoveSelectedItem()
        {
            var item = (Section)TreeView.SelectedNode?.Tag;

            if (item == null) return;

            item.RowStatus = AiTech.LiteOrm.RecordStatus.DeletedRecord;

            IsDirty = true;
            TreeView.SelectedNode.Remove();

        }


        public void EditSelectedItem()
        {
            var item = (Section)TreeView.SelectedNode?.Tag;

            if (item == null) return;

            IsDirty = true;
            TreeView.SelectedNode.BeginEdit();
        }


        public void UpdateFileInfo()
        {
            foreach (Node node in YearLevelNode.Nodes)
            {
                var item = (Section)node?.Tag;

                if (item == null) continue;

                node.Cells["Created"].Text = "Created by:" + item.CreatedBy;
                node.Cells["Modified"].Text = item.Created.ToString("dd-MMM-yyyy  hh:mm tt");
            }
        }


        protected virtual void FireEvent(EventHandler<Section> eventHandler, Section args)
        {
            eventHandler?.Invoke(this, args);
        }


    }
}
