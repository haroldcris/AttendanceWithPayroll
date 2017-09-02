using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Payroll;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmTaxTable : MdiClientGridForm
    {
        internal TaxCollection ItemDataCollection = new TaxCollection();
        public frmTaxTable()
        {
            InitializeComponent();

            Header = " TAX TABLE ";
            HeaderColor = App.BarColor.PayrollTaxColor;
            HeaderTextColor = System.Drawing.Color.Black;

            Load += (s, e) => { RefreshData(); };
        }




        protected override IEnumerable<Entity> LoadItems()
        {
            ItemDataCollection.LoadItemsFromDb();
            return ItemDataCollection.Items;
        }


        protected override void InitializeGrid()
        {
            base.InitializeGrid();

            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;

            grid.GroupByRow.Visible = false;


            var col = new GridColumn();

            col = grid.CreateColumn("TaxId", "Tax Id", 80);
            col.DataType = typeof(Int32);

            grid.CreateColumn("Description", "Description", 200);
            grid.CreateColumn("Short", "Short Description", 100);


            grid.CreateColumn("Dependent", "Dependent", 80, Alignment.MiddleCenter);

            grid.CreateColumn("Exemption", "Exemption", 80, Alignment.MiddleRight);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["TaxId"]);

        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Tax)item;

            row.Cells["TaxId"].Value = currentItem.Id;
            row.Cells["Description"].Value = currentItem.Description;
            row.Cells["Short"].Value = currentItem.ShortDesc;
            row.Cells["Dependent"].Value = currentItem.Dependent;
            row.Cells["Exemption"].Value = currentItem.Exemption.ToString("#,#0.00");

            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Tax();

            using (var frm = new frmTaxTable_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            ItemDataCollection.Add(newItem);

            App.LogAction("Tax Table", "Created Tax Code : " + newItem.ShortDesc);

            return newItem;
        }



        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Tax)item;

            using (var frm = new frmTaxTable_Add())
            {
                if (selectedItem.Id != 0) selectedItem.RowStatus = RecordStatus.ModifiedRecord;
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("Tax Table", "Updated Tax Code : " + selectedItem.ShortDesc);

            return true;
        }



        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Tax)item).Description;

            afterConfirm = (currentItem) =>
            {
                try
                {
                    var deletedItem = (Tax)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to the Database
                    var dataWriter = new TaxDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((Tax)currentItem);

                    App.LogAction("Tax Table", "Deleted Tax Code : " + deletedItem.ShortDesc);

                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }

    }
}
