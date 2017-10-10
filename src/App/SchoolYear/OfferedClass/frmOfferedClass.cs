using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using Dll.SchoolYear;
using System;
using System.Collections.Generic;

namespace Winform.SchoolYear
{
    public partial class frmOfferedClass : MdiClientGridForm
    {
        internal OfferedClassCollection ItemDataCollection = new OfferedClassCollection();

        public frmOfferedClass()
        {
            InitializeComponent();

            Header = " CLASS ASSIGNMENT MANAGEMENT ";
            HeaderColor = App.BarColor.OfferedClassColor;
            HeaderTextColor = System.Drawing.Color.Black;

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

            // grid.CreateColumn("CameraCounter", "Image File", 85);

            grid.CreateColumn("Id", "Id");

            grid.CreateColumn("SubjectCode", "Subject Code", 100);
            grid.CreateColumn("Subject", "Subject", 150);

            grid.CreateColumn("SectionId", "Section Id");
            grid.CreateColumn("Section", "Section", 80);


            grid.CreateColumn("Teacher", "Teacher", 180);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Lastname"]);
        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (OfferedClass)item;

            row.Cells["Id"].Value = currentItem.Id;

            row.Cells["SubjectCode"].Value = currentItem.SubjectClass.SubjectCode;
            row.Cells["Subject"].Value = currentItem.SubjectClass.Description.ToUpper();

            row.Cells["SectionId"].Value = currentItem.SectionId;
            row.Cells["Section"].Value = currentItem.SectionClass.SectionName;

            row.Cells["Teacher"].Value = currentItem.EmployeeClass.PersonClass.Name.Fullname.ToUpper();

            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new OfferedClass();

            using (var frm = new frmOfferedClass_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return null;
            }

            App.LogAction("OfferedClass", "Created OfferedClass : " + newItem.Id.ToString());

            ItemDataCollection.Add(newItem);
            return newItem;
        }


        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (OfferedClass)item;

            using (var frm = new frmOfferedClass_Add())
            {
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return false;
            }

            App.LogAction("OfferedClass", "Updated Offered Class : " + selectedItem.SectionClass.SectionName + " - " + selectedItem.SubjectClass.Description);

            return true;
        }


        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((OfferedClass)item).Id.ToString();

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (OfferedClass)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new OfferedClassDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((OfferedClass)currentItem);

                    App.LogAction("OfferedClass", "Deleted OfferedClass : " + deletedItem.Id.ToString());


                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }
    }
}
