using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AiTech.LiteOrm;
using AiTech.Security;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace Winform.Accounts
{
    public partial class frmAccounts : MdiClientGridForm
    {
        internal UserAccountCollection ItemDataCollection = new UserAccountCollection();

        public frmAccounts()
        {
            InitializeComponent();

            Header = " USER ACCOUNTS MANAGEMENT ";
            HeaderColor = App.BarColor.AccountsColor;

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


            grid.CreateColumn("Id", "Id", 60, Alignment.MiddleCenter);

            grid.CreateColumn("Username", "Username", 80);
            grid.CreateColumn("Role", "Role", 80);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Username"]);
        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (UserAccount) item;

            row.Cells["Id"].Value = currentItem.Id.ToString("0000");

            row.Cells["Username"].Value = currentItem.Username;
            row.Cells["Role"].Value = currentItem.RoleClass.RoleName;

            //row.Cells["CameraCounter"].Value = currentItem.CameraCounter;

            //var img = InputControls.GetImage(currentItem.CameraCounter);

            //if (img != null)
            //{
            //    imageList1.Images.Add(currentItem.CameraCounter, InputControls.GetImage(currentItem.CameraCounter));

            //    row.Cells["CameraCounter"].CellStyles.Default.Image = imageList1.Images[currentItem.CameraCounter];
            //    row.Cells["CameraCounter"].CellStyles.Default.ImageAlignment = Alignment.MiddleCenter;
            //}

            row.RowHeight = row.GetMaximumRowHeight();

            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new UserAccount();

            using (var frm = new frmAccount_Add())
            {
                frm.ItemData = newItem;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            ItemDataCollection.Add(newItem);
            return newItem;
        }


        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (UserAccount) item;

            using (var frm = new frmAccount_Add())
            {
                frm.ItemData = selectedItem;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            return true;
        }


        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((UserAccount) item).Username;

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (UserAccount) currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    var dataWriter = new UserAccountDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();

                    ItemDataCollection.Remove((UserAccount) currentItem);
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }

        #region MyGridImageEditControl

        /// <summary>
        ///     GridImageEditControl with the ability
        ///     to pass in a default ImageList and ImageBoxSizeMode
        /// </summary>
        private class MyGridImageEditControl : GridImageEditControl
        {
            public MyGridImageEditControl(
                ImageList imageList, ImageSizeMode sizeMode)
            {
                ImageList = imageList;
                ImageSizeMode = sizeMode;
                ImageSizeMode = sizeMode;
            }
        }

        #endregion
    }
}