using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using Dll.SchoolYear;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmSubject : MdiClientGridForm
    {
        internal SubjectCollection ItemDataCollection = new SubjectCollection();

        public frmSubject()
        {
            InitializeComponent();

            Header = " SUBJECT MANAGEMENT ";
            HeaderColor = App.BarColor.SubjectColor;

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


            grid.CreateColumn("Code", "Code", 90);
            grid.CreateColumn("Description", "Description", 250);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Code"]);
        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Subject)item;

            row.Cells["Code"].Value = currentItem.SubjectCode;
            row.Cells["Description"].Value = currentItem.Description;


            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Subject();

            using (var frm = new frmSubject_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            App.LogAction("Subject", "Created Subject : " + newItem.SubjectCode);


            ItemDataCollection.Add(newItem);

            return newItem;
        }


        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Subject)item;

            using (var frm = new frmSubject_Add())
            {
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("Subject", "Updated Subject : " + selectedItem.SubjectCode);

            return true;
        }


        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Subject)item).SubjectCode + " - " + ((Subject)item).Description;

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (Subject)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new SubjectDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((Subject)currentItem);

                    App.LogAction("Subject", "Deleted Subject : " + deletedItem.SubjectCode);

                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }
    }
}