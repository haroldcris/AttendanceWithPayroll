using AiTech.Security;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Library.Tools;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Winform.Accounts
{
    public partial class frmRolePrivileges : OfficeForm
    {
        private RoleCollection ItemDataCollection;

        public frmRolePrivileges()
        {
            InitializeComponent();

            InitializeGrid();


            Shown += (s, e) =>
            {
                LoadItems();
                SGrid.PrimaryGrid.ExpandAll(3);

                SGrid.Refresh();
            };
        }


        private void LoadItems()
        {
            ItemDataCollection = new RoleCollection();
            ItemDataCollection.LoadAllItems();

            InputControls.LoadToComboBox(cboRole, ItemDataCollection.Items);
        }

        private void InitializeGrid()
        {
            // SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;


            grid.GroupByRow.Visible = false;

            grid.Columns.Clear();


            var col = grid.CreateColumn("Description", "Description", 200);
            col.ColumnSortMode = ColumnSortMode.None;

            col = grid.CreateColumn("Allow", "Allow", 80, Alignment.MiddleCenter);
            col.EditorType = typeof(GridCheckBoxXEditControl);
            col.ColumnSortMode = ColumnSortMode.None;

            col = grid.CreateColumn("Category", "Category", 100);
            col.ColumnSortMode = ColumnSortMode.None;
            col.Visible = false;

            grid.GroupColumns.Add(col);
            grid.Rows.Clear();


            SGrid.PrimaryGrid.AutoExpandSetGroup = true;
            SGrid.CellValueChanged += SGrid_CellValueChanged;
        }

        private void SGrid_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            GridRow row = e.GridCell.GridRow;
            if (row?.Tag == null) return;

            var item = (IRolePrivilege)row.Tag;

            item.Enable = (bool)e.GridCell.Value;


            var writer = new RoleDataWriter(App.CurrentUser.User.Username, (Role)cboRole.SelectedItem);
            writer.SaveChanges();
        }

        private void frmRolePrivileges_Load(object sender, EventArgs e)
        {


        }


        private void Show_RolePrivileges(Role selectedRole)
        {


            var grid = SGrid.PrimaryGrid;

            grid.Rows.Clear();
            grid.ClearAll();

            var list = selectedRole.RolePrivileges.Items.OrderBy(_ => _.PrivilegeClass.Category)
                                                        .ThenBy(_ => _.PrivilegeClass.DisplayOrder).ToList();

            foreach (var item in list)
            {
                var row = grid.CreateNewRow();

                row["Category"].Value = item.PrivilegeClass.Category.ToUpper();
                row["Description"].Value = "    " + item.PrivilegeClass.DisplayName;
                row["Description"].AllowEdit = false;

                row["Allow"].Value = item.Enable;

                row.Tag = item;

                //Debug.WriteLine(item.PrivilegeClass.DisplayName);
            }
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex < 0) return;

            var selectedRole = (Role)cboRole.SelectedItem;

            selectedRole.RolePrivileges.LoadItemsFromDb();

            Show_RolePrivileges(selectedRole);

        }
    }
}
