using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Payroll;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmTaxTable : MdiClientFormWithCrudButtons<Tax, TaxCollection>
    {
        public frmTaxTable()
        {
            InitializeComponent();

            InitializeGrid();

            Header = " TAX TABLE MANAGEMENT";
            HeaderColor = System.Drawing.Color.Gold;
            HeaderTextColor = System.Drawing.Color.Black;
        }


        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var dataWriter = new TaxDataWriter(App.CurrentUser.User.Username, ItemDataCollection);
                dataWriter.SaveChanges();

                Show_Data();
            });
        }


        protected override void InitializeGrid()
        {
            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;
            var col = new GridColumn();

            col = grid.CreateColumn("TaxId", "Tax Id", 80, Alignment.MiddleCenter);
            col.DataType = typeof(Int32);

            col.GroupBoxEffects = GroupBoxEffects.None;

            col = grid.CreateColumn("Description", "Description", 200, Alignment.MiddleLeft);
            col = grid.CreateColumn("Short", "Short Description", 100, Alignment.MiddleLeft);


            col = grid.CreateColumn("Dependent", "Dependent", 80, Alignment.MiddleCenter);

            col = grid.CreateColumn("Exemption", "Exemption", 80, Alignment.MiddleRight);

            grid.CreateRecordInfoColumns();

            grid.SetSort(SGrid.PrimaryGrid.Columns["TaxId"]);
        }


        protected override void LoadItems()
        {
            ItemDataCollection.LoadItemsFromDb();
        }

        protected override void Show_DataOnRow(GridRow row, Tax item)
        {
            row.Cells["TaxId"].Value = item.TaxID;
            row.Cells["Description"].Value = item.Description;
            row.Cells["Short"].Value = item.ShortDesc;
            row.Cells["Dependent"].Value = item.Dependent;
            row.Cells["Exemption"].Value = item.Exemption.ToString("#,#0.00");

            row.ShowRecordInfo(item);
        }

        protected override Tax OnItemCreated()
        {
            Cursor.Current = Cursors.WaitCursor;
            var newItem = new Tax();

            var frm = new frmTaxTable_Add(this);
            frm.ItemData = newItem;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();

            return newItem;
        }

        protected override Tax OnItemUpdated()
        {
            Cursor.Current = Cursors.WaitCursor;

            var itemToEdit = GetCurrentItemOnGrid();

            var frm = new frmTaxTable_Add(this);
            frm.ItemData = itemToEdit;

            if (frm.ShowDialog(this) != DialogResult.OK) return null;
            frm.Dispose();

            return itemToEdit;
        }

        protected override string GetItemDeleteMessage()
        {
            var item = GetCurrentItemOnGrid();
            if (item == null) return "";

            return $"{item.TaxID} -  {item.Description}";
        }


        internal bool ContainsData(string taxId, string rowId)
        {
            var id = int.Parse(taxId);

            var foundItem = ItemDataCollection.Items.FirstOrDefault(x => x.TaxID == id &&
                                                                             x.RowId != rowId);
            if (foundItem == null) return false;
            return true;
        }


    }
}
