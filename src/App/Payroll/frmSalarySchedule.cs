using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Payroll;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmSalarySchedule : MdiClientFormWithCrudButtons<SalarySchedule, SalaryScheduleCollection>
    {
        public frmSalarySchedule()
        {
            InitializeComponent();

            InitializeGrid();

            Header = " PAYROLL SALARY SCHEDULE";
            HeaderColor = System.Drawing.Color.LightSeaGreen;
        }

        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var dataWriter = new SalaryScheduleDataWriter(App.CurrentUser.User.Username, ItemDataCollection);
                dataWriter.SaveChanges();

                Show_Data();
            });
        }


        protected override void InitializeGrid()
        {
            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;
            var col = new GridColumn();

            grid.GroupByRow.Visible = false;

            col = grid.CreateColumn("Effectivity", "Effectivity", 180, Alignment.MiddleLeft);
            col.GroupBoxEffects = GroupBoxEffects.None;

            col = grid.CreateColumn("Remarks", "Remarks", 200, Alignment.MiddleLeft);

            grid.CreateRecordInfoColumns();

            grid.SetSort(SGrid.PrimaryGrid.Columns["Effectivity"], SortDirection.Descending);
        }


        protected override void LoadItems()
        {
            ItemDataCollection.LoadItemsFromDb();
        }


        protected override void Show_DataOnRow(GridRow row, SalarySchedule item)
        {
            row.Cells["Effectivity"].Value = item.Effectivity.ToString("dd MMMM yyyy");
            row.Cells["Remarks"].Value = item.Remarks;

            row.ShowRecordInfo(item);
        }



        protected override SalarySchedule OnItemCreated()
        {
            Cursor.Current = Cursors.WaitCursor;

            var newItem = new SalarySchedule();

            var frm = new frmSalarySchedule_Add(this);
            frm.ItemData = newItem;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();
            return newItem;
        }


        protected override SalarySchedule OnItemUpdated()
        {
            Cursor.Current = Cursors.WaitCursor;

            var itemToEdit = GetCurrentItemOnGrid();

            var frm = new frmSalarySchedule_Add(this);
            frm.ItemData = itemToEdit;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();

            return itemToEdit;
        }

        protected override string GetItemDeleteMessage()
        {
            var item = GetCurrentItemOnGrid();
            if (item == null) return "";

            return $"{item.Effectivity}";
        }


        internal bool ContainsData(DateTime effectivity, string rowId)
        {
            var foundItem = ItemDataCollection.Items.FirstOrDefault(x => x.Effectivity == effectivity &&
                                                                             x.RowId != rowId);
            if (foundItem == null) return false;
            return true;
        }



    }
}
