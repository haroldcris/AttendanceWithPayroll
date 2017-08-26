using AiTech.LiteOrm;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Contacts;
using Library.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            HeaderColor = System.Drawing.Color.DarkOrange;

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
            SGrid.RowDoubleClick += (s, e) => { btnEdit.RaiseClick(); };


            var grid = SGrid.PrimaryGrid;


            grid.CreateColumn("Id", "Id", 60, Alignment.MiddleCenter);

            grid.CreateColumn("Lastname", "Lastname", 120);
            grid.CreateColumn("Firstname", "Firstname", 150);
            grid.CreateColumn("Middlename", "Middlename", 85);
            grid.CreateColumn("NameExtension", "Ext");

            grid.CreateColumn("Gender", "Gender");

            grid.CreateColumn("Birthdate", "Birthdate", 80, Alignment.MiddleCenter);

            grid.CreateColumn("BirthTown", "Town", 120);
            grid.CreateColumn("BirthProvince", "Province", 85);
            grid.CreateColumn("BirthCountry", "Country", 85);
            grid.CreateColumn("CameraCounter", "Image File", 85);

            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

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

            row.Cells["Birthdate"].Value = currentItem.BirthDate.ToString("dd-MMM-yyyy");

            row.Cells["BirthCountry"].Value = currentItem.BirthCountry;
            row.Cells["BirthProvince"].Value = currentItem.BirthProvince;
            row.Cells["BirthTown"].Value = currentItem.BirthTown;

            //row.Cells["CameraCounter"].Value = currentItem.CameraCounter;

            var img = InputControls.GetImage(currentItem.CameraCounter);

            if (img != null)
            {
                imageList1.Images.Add(currentItem.CameraCounter,
                    InputControls.GetImage(currentItem.CameraCounter)
                    //System.Drawing.Image.FromFile(@"d:\my pictures\8.jpg")
                    );

                //row.Cells["Image"].Value = currentItem.CameraCounter;
                row.Cells["CameraCounter"].CellStyles.Default.Image = imageList1.Images[currentItem.CameraCounter];
                row.Cells["CameraCounter"].CellStyles.Default.ImageAlignment = Alignment.MiddleCenter;
            }


            Debug.WriteLine(imageList1.Images.Count);


            row.ShowRecordInfo(currentItem);

            row.RowHeight = row.GetMaximumRowHeight();
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


            SaveDataOf(newItem);

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


            SaveDataOf(selectedItem);

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

                    SaveDataOf(deletedItem);

                    ItemDataCollection.Remove((Person)currentItem);
                }
                catch (Exception ex)
                {
                    App.Message.ShowError(ex, this);
                }
            };
        }


        private void SaveDataOf(Person item)
        {
            try
            {
                var dataWriter = new PersonDataWriter(App.CurrentUser.User.Username, item);
                dataWriter.SaveChanges();
            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
            }
        }

    }
}
