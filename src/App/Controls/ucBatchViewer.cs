using DevComponents.AdvTree;
using Dll.SchoolYear;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Winform.Controls
{
    public partial class ucBatchViewer : UserControl
    {
        private Dictionary<string, bool> NodeDictionary;

        public string Encoder { get; set; }

        public BatchCollection BatchItems { get; private set; }
        public ucBatchViewer()
        {
            InitializeComponent();

            Encoder = "UserControl";
            NodeDictionary = new Dictionary<string, bool>();

            TreeView.DragDropEnabled = false;
            TreeView.ExpandButtonType = eExpandButtonType.Triangle;
            TreeView.ExpandButtonSize = new Size(16, 16);

            TreeView.NodeSpacing = 5;
            TreeView.SelectionFocusAware = false;

            TreeView.KeyPress += TreeView_KeyPress;

            TreeView.Nodes.Clear();

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
                if (!NodeDictionary.ContainsKey(TreeView.SelectedNode.Name)) return false;
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

        private void DisplayBatchItems(IEnumerable<Batch> items)
        {
            TreeView.BeginUpdate();
            TreeView.Nodes.Clear();
            TreeView.ClearAndDisposeAllNodes();

            var root = new Node();
            root.Text = "Batch";
            TreeView.Nodes.Add(root);
            root.ExpandAll();

            foreach (var item in items)
            {
                var batchNode = TreeView.FindNodeByName(item.BatchName);

                if (batchNode == null)
                {
                    batchNode = new Node
                    {
                        Text = item.BatchName,
                        Expanded = true,
                        Name = item.BatchName

                    };

                    root.Nodes.Add(batchNode);
                }

                var semNode = TreeView.FindNodeByName(item.BatchName + item.Semester);
                if (semNode == null)
                {
                    semNode = new Node
                    {
                        Name = item.BatchName + item.Semester, //Name must Match the BatchDictionary
                        Text = item.Semester,
                        Image = Properties.Resources.Address_Book_16,
                        Tag = item,
                        ExpandVisibility = eNodeExpandVisibility.Visible
                    };

                    batchNode.Nodes.Add(semNode);
                }
            }
            TreeView.EndUpdate();
        }



        public virtual void LoadBatchItems()
        {
            Cursor.Current = Cursors.WaitCursor;

            BatchItems = new BatchCollection();
            BatchItems.LoadAllItemsFromDb();

            NodeDictionary = new Dictionary<string, bool>();

            DisplayBatchItems(BatchItems.Items);
        }




        public void LoadBatchItem(int batchId)
        {
            Cursor.Current = Cursors.WaitCursor;

            BatchItems.LoadItem(batchId);

            NodeDictionary = new Dictionary<string, bool>();

            DisplayBatchItems(BatchItems.Items);

        }


        //public Batch SelectedBatch
        //{
        //    get
        //    {
        //        if (TreeView.SelectedNode == null) return null;
        //        if (TreeView.SelectedNode.Tag == null) return null;

        //        if (TreeView.SelectedNode.Tag.GetType().ToString().ToLower().Equals("smartdata.batch"))
        //            return (Batch)TreeView.SelectedNode.Tag;

        //        return null;
        //    }
        //}


    }
}
