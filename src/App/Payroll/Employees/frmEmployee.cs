﻿using AiTech.LiteOrm;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Contacts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmContacts : MdiClientForm
    {
        internal PersonCollection MyList = new PersonCollection();
        public frmContacts()
        {
            InitializeComponent();


            InitializeGrid();
        }


        public override bool FileSave()
        {
            return DoSave(() =>
            {

                var dataWriter = new PersonDataWriter(App.CurrentUser.User.Username, MyList);
                dataWriter.SaveChanges();

                Show_Data();
            });
        }


        private void LoadItems()
        {
            MyList.LoadItemsFromDb();
        }

        private void InitializeGrid()
        {
            SGrid.InitializeGrid();

            SGrid.CreateColumn("Id", "Id", 75, Alignment.MiddleCenter);

            SGrid.CreateColumn("Lastname", "Lastname", 140, Alignment.MiddleLeft);
            SGrid.CreateColumn("Firstname", "Firstname", 160, Alignment.MiddleLeft);
            SGrid.CreateColumn("Middlename", "Middlename", 100, Alignment.MiddleLeft);
            SGrid.CreateColumn("Gender", "Gender", 60, Alignment.MiddleLeft);

            SGrid.CreateColumn("Birthdate", "Birthdate", 75, Alignment.MiddleCenter);

            SGrid.CreateColumn("Street", "Address", 250, Alignment.MiddleLeft);
            SGrid.CreateColumn("Barangay", "Barangay", 120, Alignment.MiddleLeft);
            SGrid.CreateColumn("Town", "Town", 120, Alignment.MiddleLeft);
            SGrid.CreateColumn("Province", "Province", 120, Alignment.MiddleLeft);

            SGrid.CreateColumn("CreatedBy", "Created By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Created", "Created", 130, Alignment.MiddleLeft);
            SGrid.CreateColumn("ModifiedBy", "Modified By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Modified", "Modified", 130, Alignment.MiddleLeft);

            SGrid.RowDoubleClick += btnEdit_Click;

            SGrid.ColumnGrouped += (s, e) =>
            {
                var total = e.GridGroup.Rows.Count();

                e.GridGroup.Text = e.GridGroup.Text.ToUpper() + "  - " + total + (total < 2 ? " item" : " items");
            };
        }


        private void Update_Data()
        {
            foreach (var r in SGrid.PrimaryGrid.Rows)
            {
                Show_DataOnRow((GridRow)r, (Dll.Contacts.Person)r.Tag);
                ((GridRow)r).RowDirty = false;
            }
        }

        private void Show_Data()
        {
            SGrid.PrimaryGrid.Rows.Clear();

            var counter = 0;
            foreach (var item in MyList.Items)
            {
                if (item.RowStatus == RecordStatus.DeletedRecord) continue;
                counter++;

                var row = SGrid.PrimaryGrid.CreateNewRow();
                row.Tag = item;

                Show_DataOnRow(row, item);
            }
        }

        private void Show_DataOnRow(GridRow row, Dll.Contacts.Person item)
        {
            row.Cells["Id"].Value = item.Id.ToString("0000");

            row.Cells["Lastname"].Value = item.Name.Lastname;
            row.Cells["Firstname"].Value = item.Name.Firstname;
            row.Cells["Middlename"].Value = item.Name.Middlename;
            row.Cells["Gender"].Value = item.Gender;

            row.Cells["Birthdate"].Value = item.BirthDate.ToString("d-MMM-yyyy");

            //row.Cells["Street"].Value = item.Address.Street;
            //row.Cells["Barangay"].Value = item.Address.Barangay;
            //row.Cells["Town"].Value = item.Address.Town;
            //row.Cells["Province"].Value = item.Address.Province;

            row.ShowRecordInfo(item);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Contacts.frmContacts_Add();
                var newItem = new Dll.Contacts.Person();

                frm.ItemData = newItem;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return;
                frm.Dispose();

                MyList.Add(newItem);

                DirtyStatus.SetDirty();
                var row = SGrid.PrimaryGrid.CreateNewRow();
                row.Tag = newItem;

                Show_DataOnRow(row, newItem);

                SGrid.PrimaryGrid.ClearSelectedRows();
                row.SetActive();
                row.IsSelected = true;
                row.RowDirty = true;

            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var grid = SGrid.PrimaryGrid;

            if (grid.ActiveRow == null) return;

            var item = (Dll.Contacts.Person)grid.ActiveRow.Tag;

            var ret = App.Message.AskToDelete(item.Name.FullnameWithFirstnameFirst);

            if (ret != MessageDialogResult.Yes) return;

            MyList.Remove(item);

            grid.ActiveRow.IsDeleted = true;
            grid.PurgeDeletedRows();
            DirtyStatus.SetDirty();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();

            Console.WriteLine(@"Down Refresh");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var grid = SGrid.PrimaryGrid;
                if (grid.ActiveRow == null) return;

                var item = (Dll.Contacts.Person)grid.ActiveRow.Tag;

                var frm = new Contacts.frmContacts_Add
                {
                    ItemData = item,
                    Owner = this
                };

                if (frm.ShowDialog() != DialogResult.OK) return;
                frm.Dispose();

                if (item.Id != 0) item.RowStatus = RecordStatus.ModifiedRecord;
                DirtyStatus.SetDirty();
                ((GridRow)grid.ActiveRow).RowDirty = true;
                Show_DataOnRow((GridRow)grid.ActiveRow, item);

            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
            }
        }

        private void RefreshData()
        {
            DoRefresh(async () =>
            {
                progressBarX1.Visible = true;

                var grid = SGrid.PrimaryGrid;
                grid.Rows.Clear();

                await Task.Factory.StartNew(LoadItems);

                progressBarX1.Visible = false;
                Show_Data();
            });
        }

        private void Form_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


    }
}
