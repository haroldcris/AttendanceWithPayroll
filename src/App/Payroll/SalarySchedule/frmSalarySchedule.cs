using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using Dll.Payroll;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmSalarySchedule : MdiClientGridForm
    {
        internal SalaryScheduleCollection ItemDataCollection = new SalaryScheduleCollection();
        public frmSalarySchedule()
        {
            InitializeComponent();

            Header = " PAYROLL SALARY SCHEDULE";
            HeaderColor = App.BarColor.PayrollSalaryScheduleColor;

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

            grid.CreateColumn("Effectivity", "Effectivity", 180);

            grid.CreateColumn("Remarks", "Remarks", 200);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Effectivity"], SortDirection.Descending);

        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (SalarySchedule)item;

            row.Cells["Effectivity"].Value = currentItem.Effectivity.ToString("dd MMMM yyyy");
            row.Cells["Remarks"].Value = currentItem.Remarks;

            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new SalarySchedule();

            using (var frm = new frmSalarySchedule_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            ItemDataCollection.Add(newItem);
            return newItem;
        }



        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (SalarySchedule)item;

            using (var frm = new frmSalarySchedule_Add())
            {
                if (selectedItem.Id != 0) selectedItem.RowStatus = RecordStatus.ModifiedRecord;
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            return true;
        }



        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((SalarySchedule)item).Effectivity.ToString("yyyy MMMM dd");

            afterConfirm = (currentItem) =>
            {
                try
                {
                    var deletedItem = (SalarySchedule)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to the Database
                    var dataWriter = new SalaryScheduleDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((SalarySchedule)currentItem);
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }

    }
}
