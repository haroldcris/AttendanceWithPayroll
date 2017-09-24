using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using Dll.SchoolYear;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmBatch : MdiClientGridForm
    {
        internal BatchCollection ItemDataCollection = new BatchCollection();

        public frmBatch()
        {
            InitializeComponent();

            Header = " BATCH MANAGEMENT ";
            HeaderColor = App.BarColor.BatchColor;

            Load += (s, e) => { RefreshData(); };
        }


        protected override IEnumerable<Entity> LoadItems()
        {
            ItemDataCollection.LoadAllItemsFromDb();
            return ItemDataCollection.Items;
        }


        protected override void InitializeGrid()
        {
            base.InitializeGrid();

            SGrid.InitializeGrid();


            var grid = SGrid.PrimaryGrid;

            grid.GroupByRow.Visible = false;


            grid.CreateColumn("Batch", "Batch", 90);
            grid.CreateColumn("Semester", "Semester", 100);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Batch"]);
        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Batch)item;

            row.Cells["Batch"].Value = currentItem.BatchName;
            row.Cells["Semester"].Value = currentItem.Semester;


            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Dll.SchoolYear.Batch();

            using (var frm = new frmBatch_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return null;
            }

            App.LogAction("School Year.Batch", "Created Batch : " + newItem.BatchName);


            ItemDataCollection.Add(newItem);

            return newItem;
        }


        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Batch)item;

            using (var frm = new frmBatch_Add())
            {
                frm.ItemData = selectedItem;

                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("School Year.Batch", "Updated Batch : " + selectedItem.BatchName);

            return true;
        }


        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Batch)item).BatchName;

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (Batch)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new BatchDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((Dll.SchoolYear.Batch)currentItem);

                    App.LogAction("School Year.Batch", "Deleted Batch : " + deletedItem.BatchName);

                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }
    }
}