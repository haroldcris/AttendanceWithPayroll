using System.Windows.Forms;
using System.Linq;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Threading.Tasks;
using AiTech.Entities;
using Dll.Payroll;

namespace Winform.Payroll
{
    public partial class frmPosition : MDIClientFormWithCRUDButtons<Position, PositionCollection>
    {
        public frmPosition()
        {
            InitializeComponent();

            InitializeGrid();

            this.Header = " PAYROLL POSITION MANAGEMENT";
            this.HeaderColor = System.Drawing.Color.RoyalBlue;
        }
        
        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var dataWriter = new PositionDataWriter(My.App.CurrentUser.User.Username, ItemDataCollection);
                dataWriter.SaveChanges();

                Show_Data();
            });
        }

        protected override void LoadItems()
        {
            ItemDataCollection.LoadItemsFromDb();
        }

        protected override void InitializeGrid()
        {
            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;

            grid.GroupByRow.Visible = false;

            grid.CreateColumn("Code", "Code", 120, Alignment.MiddleLeft);
            grid.CreateColumn("Description", "Description", 200, Alignment.MiddleLeft);

            grid.CreateRecordInfoColumns();

            grid.SetSort(SGrid.PrimaryGrid.Columns["Code"]);
        }

       
        protected override void Show_DataOnRow(GridRow row, Position item)
        {
            row.Cells["Code"].Value = item.Code;
            row.Cells["Description"].Value = item.Description;

            GridHelper.ShowRecordInfo(row, item);
        }

        protected override Position OnItemCreated()
        {
            Cursor.Current = Cursors.WaitCursor;

            var newItem = new Position();
            var frm = new frmPosition_Add(this);
            frm.ItemData = newItem;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();

            return newItem;
        }

        protected override Position OnItemUpdated()
        {
            Cursor.Current = Cursors.WaitCursor;

            var grid = SGrid.PrimaryGrid;
            if (grid.ActiveRow == null) return null;
            var itemToEdit = (Position)grid.ActiveRow.Tag;

            var frm = new frmPosition_Add(this);
            frm.ItemData = itemToEdit;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();

            return itemToEdit;
        }


        protected override string GetItemDeleteMessage()
        {
            var selectedItem = GetCurrentItemOnGrid();
            if (selectedItem == null) return "";
            return $"{selectedItem.Code} - {selectedItem.Description}";
        }

       
        internal bool ContainsData(string code, string rowId)
        {
            var foundItem = ItemDataCollection.Items.FirstOrDefault(x => x.Code == code &&
                                                                             x.RowId != rowId);
            if (foundItem == null) return false;
            return true;
        }
    }
}
