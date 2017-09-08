using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Biometric;
using Dll.Contacts;
using Dll.Employee;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.Biometric
{
    public partial class frmBiometricUser : MdiClientGridForm
    {
        internal BiometricUserCollection ItemDataCollection = new BiometricUserCollection();
        public frmBiometricUser()
        {
            InitializeComponent();


            Header = " BIOMETRIC USER ";
            HeaderColor = App.BarColor.BiometricUser;

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

            var col = grid.CreateColumn("BiometricId", "Biometric Id", 80, Alignment.MiddleCenter);

            grid.CreateColumn("Lastname", "Lastname", 90);
            grid.CreateColumn("Firstname", "Firstname", 100);
            grid.CreateColumn("Middlename", "Middlename", 80);
            grid.CreateColumn("NameExtension", "Ext", 40);

            grid.CreateColumn("Gender", "Gender");


            grid.CreateColumn("Category", "Category", 90);
            grid.CreateColumn("PhoneNumber", "Phone No.", 100);

            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Lastname"]);

        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (BiometricUser)item;

            row.Cells["BiometricId"].Value = currentItem.BiometricId;

            row.Cells["Lastname"].Value = currentItem.PersonClass.Name.Lastname;
            row.Cells["Firstname"].Value = currentItem.PersonClass.Name.Firstname;
            row.Cells["Middlename"].Value = currentItem.PersonClass.Name.Middlename;
            row.Cells["NameExtension"].Value = currentItem.PersonClass.Name.NameExtension;

            row.Cells["Gender"].Value = currentItem.PersonClass.Gender == GenderType.Male ? "Male" : "Female";

            row.Cells["Category"].Value = currentItem.Category;
            row.Cells["PhoneNumber"].Value = currentItem.PhoneNumber;

            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new BiometricUser();

            using (var frm = new frmBiometricUser_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            App.LogAction("Biometric", "Created Biometric Employee : " + newItem.BiometricId);

            ItemDataCollection.Add(newItem);
            return newItem;
        }



        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (BiometricUser)item;

            using (var frm = new frmBiometricUser_Add())
            {
                if (selectedItem.Id != 0) selectedItem.RowStatus = RecordStatus.ModifiedRecord;
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("Biometric", "Updated Biometric Employee : " + selectedItem.BiometricId);

            return true;
        }



        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((BiometricUser)item).PersonClass.Name.Fullname;

            afterConfirm = (currentItem) =>
            {
                try
                {
                    var deletedItem = (BiometricUser)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new BiometricUserDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((BiometricUser)currentItem);

                    App.LogAction("Biometric", "Deleted Biometric Employee : " + deletedItem.BiometricId);

                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }



    }
}
