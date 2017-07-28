using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Linq;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Threading.Tasks;

using Dll.Payroll;
using AiTech.Entities;

namespace Winform.Payroll
{
    public partial class frmDeduction : MDIClientFormWithCRUDButtons<Deduction, DeductionCollection>
    {
        public frmDeduction()
        {
            InitializeComponent();

            InitializeGrid();

            this.Header = " PAYROLL DEDUCTIONS MANAGEMENT";
            this.HeaderColor = System.Drawing.Color.Crimson;
        }

        protected override void LoadItems()
        {
            ItemDataCollection.LoadItemsFromDb();
        }


        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var dataWriter = new DeductionDataWriter(My.App.CurrentUser.User.Username, ItemDataCollection);
                dataWriter.SaveChanges();

                Show_Data();
            });
        }

        protected override void InitializeGrid()
        {
            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;

            var col = new GridColumn();

            col = grid.CreateColumn("Code", "Code", 80, Alignment.MiddleCenter);
            col.GroupBoxEffects = GroupBoxEffects.None;

            col = grid.CreateColumn("Description", "Description", 200, Alignment.MiddleLeft);

            col = grid.CreateColumn("Mandatory", "Mandatory", 80, Alignment.MiddleCenter);
            col.EditorType = typeof(GridCheckBoxXEditControl);

            col = grid.CreateColumn("Priority", "Priority", 80, Alignment.MiddleCenter);
            col.EditorType = typeof(GridCheckBoxXEditControl);

            col = grid.CreateColumn("Active", "Active", 80, Alignment.MiddleCenter);
            col.EditorType = typeof(GridCheckBoxXEditControl);


            grid.CreateRecordInfoColumns();

            grid.SetSort(SGrid.PrimaryGrid.Columns["Code"]);
        }


        protected override void Show_DataOnRow(GridRow row, Deduction item)
        {
            row.Cells["Code"].Value = item.Code;
            row.Cells["Description"].Value = item.Description;

            row.Cells["Mandatory"].Value = item.Mandatory;
            row.Cells["Priority"].Value = item.Priority;
            row.Cells["Active"].Value = item.Active;

            if (item.Active)
                row.CellStyles.Default = null;
            else
                row.CellStyles.Default = new CellVisualStyle() { Background = new Background(System.Drawing.Color.LightGray) };

            base.Show_DataOnRow(row, item);
        }
       


        internal bool ContainsData(string code, string rowId)
        {
            var foundItem = ItemDataCollection.Items.FirstOrDefault(x => x.Code == code &&
                                                                             x.RowId != rowId);
            if (foundItem == null) return false;
            return true;
        }


        protected override Deduction OnItemCreated()
        {
            Cursor.Current = Cursors.WaitCursor;

            var newItem = new Deduction();
            newItem.Active = true;

            var frm = new frmDeduction_Add(this);
            frm.ItemData = newItem;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();
            return newItem;
        }

        protected override Deduction OnItemUpdated()
        {
            Cursor.Current = Cursors.WaitCursor;

            var itemToEdit = this.GetCurrentItemOnGrid();

            if (itemToEdit == null) return null;

            var frm = new frmDeduction_Add(this);
            frm.ItemData = itemToEdit;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();

            return itemToEdit;

        }

        protected override string GetItemDeleteMessage()
        {
            var selectedItem = GetCurrentItemOnGrid();
            if (selectedItem == null) return "";
            return selectedItem.Code + " - " + selectedItem.Description;
        }
    }
}
