﻿using AiTech.LiteOrm;
using DevComponents.DotNetBar.SuperGrid;
using Dll.Payroll;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmPosition : MdiClientGridForm
    {
        internal PositionCollection ItemDataCollection = new PositionCollection();
        public frmPosition()
        {
            InitializeComponent();

            Header = " PAYROLL POSITIONS ";
            HeaderColor = System.Drawing.Color.RoyalBlue;

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

            grid.GroupByRow.Visible = false;

            grid.CreateColumn("Code", "Code", 120);
            grid.CreateColumn("Description", "Description", 200);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Lastname"]);

        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Position)item;

            row.Cells["Code"].Value = currentItem.Code;
            row.Cells["Description"].Value = currentItem.Description;

            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Position();

            using (var frm = new frmPosition_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            ItemDataCollection.Add(newItem);
            return newItem;
        }



        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Position)item;

            using (var frm = new frmPosition_Add())
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

            message = ((Position)item).Description;

            afterConfirm = (currentItem) =>
            {
                try
                {
                    var deletedItem = (Position)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to the Database
                    var dataWriter = new PositionDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((Position)currentItem);
                }
                catch (Exception ex)
                {
                    App.Message.ShowError(ex, this);
                }
            };
        }

    }
}