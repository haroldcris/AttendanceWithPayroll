using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using Dll.SchoolYear;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmCourse : MdiClientGridForm
    {
        internal CourseCollection ItemDataCollection = new CourseCollection();

        public frmCourse()
        {
            InitializeComponent();

            Header = " COURSE MANAGEMENT ";
            HeaderColor = App.BarColor.CourseColor;

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
            var currentItem = (Course)item;

            row.Cells["Code"].Value = currentItem.CourseCode;
            row.Cells["Description"].Value = currentItem.Description;


            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Course();

            using (var frm = new frmCourse_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            App.LogAction("School Year.Course", "Created Course : " + newItem.CourseCode);


            ItemDataCollection.Add(newItem);

            return newItem;
        }


        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Course)item;

            using (var frm = new frmCourse_Add())
            {
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("School Year.Course", "Updated Course : " + selectedItem.CourseCode);

            return true;
        }


        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Course)item).CourseCode + " - " + ((Course)item).Description;

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (Course)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new CourseDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((Dll.SchoolYear.Course)currentItem);

                    App.LogAction("School Year.Course", "Deleted Course : " + deletedItem.CourseCode);

                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }
    }
}