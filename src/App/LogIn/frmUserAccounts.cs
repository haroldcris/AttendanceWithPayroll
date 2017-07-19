using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using SmartData.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartApp
{
    public partial class frmUserAccounts : MDIClientForm
    {
        UserAccountCollection UserAccountItems;

        public frmUserAccounts()
        {
            InitializeComponent();

            Title = "User Accounts";
            HeaderColor = Color.CadetBlue;
            
            UserAccountItems = new UserAccountCollection();
        }
        
        private Node CreateNode(UserAccount item)
        {
            var newNode = new Node { Text = item.Username, Image = Properties.Resources.Gender_Neutral_User_30px };

            var subItemStyle = new ElementStyle { Font = new Font(Font.FontFamily, Font.Size, FontStyle.Italic) };

            if (item.AssociatedEmployee != null)
            {                
                var employee = item.AssociatedEmployee.Employee;

                if (employee != null)
                    newNode.Cells.Add(new Cell { Text = employee.Fullname(), StyleNormal = subItemStyle });

                newNode.Image = employee.Gender.StartsWith("F") ? Properties.Resources.Administrator_Female_30 : Properties.Resources.Administrator_Male_30;
            }

            newNode.Cells.Add(new Cell { Text = "Level:" + item.SecurityLevel, StyleNormal = subItemStyle });

            newNode.VerticalCellLayoutAlignment= eHorizontalAlign.Left;
            newNode.Name = item.Token;
            newNode.Tag = item;

            newNode.CellLayout = eCellLayout.Vertical;

            return newNode;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            ShowUserAccounts();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            TreeView.View = eView.Tile;
            TreeView.ExpandButtonType = eExpandButtonType.Triangle;

        }

        private void ShowUserAccounts()
        {
            Cursor.Current = Cursors.WaitCursor;
            TreeView.Nodes.Clear();

            if (!UserAccountItems.ReadFromCache)
            {
                System.Console.WriteLine("Reading from UserAccount Db");
                UserAccountItems.LoadItemsFromDb();
            }
            else
                System.Console.WriteLine("Reading from Cache");
                
                       
            foreach (var account in UserAccountItems.Items.OrderBy(_ => _.SecurityLevel)
                                                          .ThenBy(_ => _.Username))
            {
                var root = TreeView.Nodes.Find(account.SecurityLevel, false).FirstOrDefault();

                if(root == null)
                {
                    root = new Node{ Text = account.SecurityLevel, Name = account.SecurityLevel, Expanded = true };
                    TreeView.Nodes.Add(root);
                }

                root.Nodes.Add(CreateNode(account));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var user = new UserAccount();

            var frm = new frmUserAccounts_Add(this)
            {
                CurrentUserAccount = user
            };

            var result = frm.ShowDialog();
            if (result != DialogResult.OK) return;
           
            frm.Dispose();
            UserAccountItems.Add(user);
            ShowUserAccounts();
            DirtyStatus.SetDirty();     
        }

        public override bool FileSave()
        {
            try
            {
                var DataManager = new UserAccountManager(App.CurrentUser.Username);
                var dirtyItems = UserAccountItems.GetDirtyItems();
                DataManager.AttachRange(dirtyItems);
                DataManager.SaveChanges();

                ShowUserAccounts();
                DirtyStatus.Clear();
                return true;
            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
                return false;
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh(() =>
            {
                UserAccountItems.ReadFromCache = false;
                ShowUserAccounts();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = (UserAccount)TreeView.SelectedNode.Tag;

            if (item == null) return;

            var result = App.Message.AskToDelete();
            if (result == eTaskDialogResult.No) return;

            UserAccountItems.Remove(item);
            TreeView.SelectedNode.Parent.Nodes.Remove(TreeView.SelectedNode);
            

            DirtyStatus.SetDirty();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
          
            if (TreeView.SelectedNode == null) return;

            Cursor.Current = Cursors.WaitCursor;

            var item = (UserAccount)TreeView.SelectedNode.Tag;

            var frm = new frmUserAccounts_Add(this)
            {
                CurrentUserAccount = item
            };


            var result = frm.ShowDialog();
            if (result != DialogResult.OK) return;

            frm.Dispose();
            ShowUserAccounts();
            DirtyStatus.SetDirty();
        }

        private void TreeView_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            var item = (UserAccount)e.Node.Tag;
            if (item == null) return;
            btnEdit_Click(sender, EventArgs.Empty);
        }
    }
}
