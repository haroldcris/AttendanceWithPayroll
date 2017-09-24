using DevComponents.AdvTree;
using Dll.SchoolYear;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Winform.Controls
{
    public partial class ucBatchViewer : UserControl
    {

        public event EventHandler<Batch> ItemSelected;

        private BatchCollection ItemDataCollection;

        private Node _batchNode;

        public IEnumerable<Batch> Items;

        public ucBatchViewer()
        {
            InitializeComponent();

            TreeView.DragDropEnabled = false;
            TreeView.ExpandButtonType = eExpandButtonType.Triangle;
            TreeView.ExpandButtonSize = new Size(16, 16);

            TreeView.NodeSpacing = 5;
            TreeView.SelectionFocusAware = false;

            TreeView.Nodes.Clear();

            TreeView.KeyPress += TreeView_KeyPress;
            TreeView.AfterNodeSelect += TreeView_AfterNodeSelect; ;

            ItemDataCollection = new BatchCollection();

            Items = ItemDataCollection.Items;
        }



        public void LoadItems()
        {
            ItemDataCollection.LoadAllItemsFromDb();
            ShowItems();
        }


        public bool SaveChanges(string username)
        {
            var writer = new BatchDataWriter(username, ItemDataCollection);
            return writer.SaveChanges();
        }


        private void TreeView_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            var item = (Batch)e.Node?.Tag;

            OnItemSelected(item);
        }

        private void TreeView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Debug.WriteLine("CLick");
                TreeView.SelectedNode.RaiseClick();
            }
        }


        private void ShowItems()
        {
            if (ItemDataCollection == null) throw new Exception("Item Data Collection is NOT set");

            TreeView.BeginUpdate();
            TreeView.Nodes.Clear();
            TreeView.ClearAndDisposeAllNodes();

            var root = new Node();
            root.Name = "root";
            root.Text = "Batch";
            TreeView.Nodes.Add(root);
            root.ExpandAll();


            foreach (var item in ItemDataCollection.Items)
            {
                CreateNode(item);
            }


            TreeView.EndUpdate();
        }



        private void CreateNode(Batch item)
        {

            var root = TreeView.FindNodeByName("root");

            _batchNode = TreeView.FindNodeByName(item.BatchName);

            if (_batchNode == null)
            {
                _batchNode = new Node
                {
                    Text = item.BatchName,
                    Expanded = true,
                    Name = item.BatchName

                };

                root.Nodes.Add(_batchNode);
            }

            var semNode = TreeView.FindNodeByName(item.BatchName + item.Semester);
            if (semNode == null)
            {
                semNode = new Node
                {
                    Name = item.BatchName + item.Semester,
                    Text = item.Semester,
                    Image = Properties.Resources.Address_Book_16,
                    Tag = item,
                    ExpandVisibility = eNodeExpandVisibility.Visible
                };

                _batchNode.Nodes.Add(semNode);
            }
        }


        public void AddItem(Batch item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));


            ItemDataCollection.Add(item);

            CreateNode(item);
        }


        public Batch SelectedItem
        {
            get
            {
                var item = (Batch)TreeView.SelectedNode?.Tag;

                if (item == null) return null;

                return item;
            }
        }


        protected virtual void OnItemSelected(Batch item)
        {
            ItemSelected?.Invoke(this, item);
        }

    }
}
