using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Contacts;
using Library.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Winform.Contacts
{
    public partial class frmContacts : MdiClientGridForm
    {
        internal PersonCollection ItemDataCollection = new PersonCollection();
        public frmContacts()
        {
            InitializeComponent();

            Header = " CONTACTS MANAGEMENT ";
            HeaderColor = App.BarColor.ContactColor;

            Load += (s, e) => { RefreshData(); };

            //Image Size
            imageList1.ImageSize = new Size(30, 30);
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


            grid.CreateColumn("Id", "Id", 50, Alignment.MiddleCenter);

            grid.CreateColumn("Lastname", "Lastname", 90);
            grid.CreateColumn("Firstname", "Firstname", 100);
            grid.CreateColumn("Middlename", "Middlename", 80);
            grid.CreateColumn("NameExtension", "Ext", 40);

            grid.CreateColumn("Gender", "Gender");

            grid.CreateColumn("Birthdate", "Birthdate", 80, Alignment.MiddleCenter);

            grid.CreateColumn("BirthTown", "Town", 120);
            grid.CreateColumn("BirthProvince", "Province", 85);
            grid.CreateColumn("BirthCountry", "Country", 70);

            grid.CreateColumn("CameraCounter", "Image File", 85);

            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            this.CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Lastname"]);



        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Person)item;

            row.Cells["Id"].Value = currentItem.Id.ToString("0000");

            row.Cells["Lastname"].Value = currentItem.Name.Lastname;
            row.Cells["Firstname"].Value = currentItem.Name.Firstname;
            row.Cells["Middlename"].Value = currentItem.Name.Middlename;
            row.Cells["NameExtension"].Value = currentItem.Name.NameExtension;

            row.Cells["Gender"].Value = currentItem.Gender;

            row.Cells["Birthdate"].Value = currentItem.BirthDate.ToString("dd - MMM - yyyy");

            row.Cells["BirthCountry"].Value = currentItem.BirthCountry;
            row.Cells["BirthProvince"].Value = currentItem.BirthProvince;
            row.Cells["BirthTown"].Value = currentItem.BirthTown;

            //row.Cells["CameraCounter"].Value = currentItem.CameraCounter;


            var img = InputControls.GetImage(currentItem.CameraCounter);

            if (img != null)
            {
                imageList1.Images.Add(currentItem.CameraCounter, img);

                row.Cells["CameraCounter"].CellStyles.Default.Image = imageList1.Images[currentItem.CameraCounter];
                row.Cells["CameraCounter"].CellStyles.Default.ImageAlignment = Alignment.MiddleCenter;
            }

            row.RowHeight = row.GetMaximumRowHeight();


            row.ShowRecordInfo(currentItem);

        }

        #region MyGridImageEditControl

        /// <summary>
        /// GridImageEditControl with the ability
        /// to pass in a default ImageList and ImageBoxSizeMode
        /// </summary>
        private class MyGridImageEditControl : GridImageEditControl
        {
            public MyGridImageEditControl(
                ImageList imageList, ImageSizeMode sizeMode)
            {
                ImageList = imageList;
                ImageSizeMode = sizeMode;
                ((GridImageEditControl)this).ImageSizeMode = sizeMode;
            }
        }

        #endregion



        protected override Entity OnAdd()
        {
            var newItem = new Person();

            using (var frm = new frmContacts_Add())
            {
                frm.ItemData = newItem;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            App.LogAction("Contacts", "Created " + newItem.Name.Fullname);

            ItemDataCollection.Add(newItem);
            return newItem;
        }



        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Person)item;

            using (var frm = new frmContacts_Add())
            {
                frm.ItemData = selectedItem;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("Contacts", "Updated " + selectedItem.Name.Fullname);

            return true;
        }



        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Person)item).Name.Fullname;

            afterConfirm = (currentItem) =>
            {
                try
                {
                    var deletedItem = (Person)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    var dataWriter = new PersonDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();

                    App.LogAction("Contacts", "Deleted " + ((Person)currentItem).Name.Fullname);

                    ItemDataCollection.Remove((Person)currentItem);
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }



    }
}
