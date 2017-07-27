using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Linq;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Threading.Tasks;
using Dll.Payroll;
using AiTech.Entities;

namespace Winform.Payroll
{
    public partial class frmTaxTable : MDIClientForm
    {
        private TaxCollection ItemDataCollection = new TaxCollection();

        public frmTaxTable()
        {
            InitializeComponent();

            InitializeEventHandler();

            InitializeGrid();
        }


        private void InitializeEventHandler()
        {
            this.Shown += (s, e) => { RefreshData(); };

            btnRefresh.Click += (s, e) => { RefreshData(); };
            btnEdit.Click += (s, e) => { EditData(); };
            btnAdd.Click += (s, e) => { NewData(); };
            btnDelete.Click += (s, e) => { DeleteData(); };
            SGrid.RowDoubleClick += (s, e) => { EditData(); };
        }

        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var dataWriter = new TaxDataWriter (My.App.CurrentUser.User.Username, ItemDataCollection);
                dataWriter.SaveChanges();

                Show_Data();
            });
        }


        private void InitializeGrid()
        {
            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;
            var col = new GridColumn();

            col = grid.CreateColumn("TaxId", "Tax Id", 80, Alignment.MiddleCenter);
            col.DataType = typeof(Int32);

            col.GroupBoxEffects = GroupBoxEffects.None;

            col = grid.CreateColumn("Description", "Description", 200, Alignment.MiddleLeft);
            col = grid.CreateColumn("Short", "Short Description", 100, Alignment.MiddleLeft);
            

            col = grid.CreateColumn("Dependent", "Dependent", 80, Alignment.MiddleCenter);

            col = grid.CreateColumn("Exemption", "Exemption", 80, Alignment.MiddleRight);

            grid.CreateRecordInfoColumns();

            grid.SetSort(SGrid.PrimaryGrid.Columns["TaxId"]);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loading");
            RefreshData();
            Console.WriteLine("Exit RefreshData");
        }

        private void LoadItems()
        {
            ItemDataCollection.LoadItemsFromDb();
        }

        private void RefreshData()
        {
            DoRefresh(async () =>
            {
                progressBarX1.Visible = true;

                var grid = SGrid.PrimaryGrid;
                grid.Rows.Clear();

                await Task.Factory.StartNew(() =>
                {
                    LoadItems();
                });

                progressBarX1.Visible = false;
                Show_Data();
            });
        }

        private void Show_Data()
        {
            var grid = SGrid.PrimaryGrid;
            grid.Rows.Clear();

            var counter = 0;
            foreach (var item in ItemDataCollection.Items)
            {
                if (item.RowStatus == RecordStatus.DeletedRecord) continue;
                counter++;

                var row = grid.CreateNewRow(item);

                Show_DataOnRow(row, item);
            }
        }



        protected void Show_DataOnRow(GridRow row, Tax item)
        {
            row.Cells["TaxId"].Value = item.TaxID;
            row.Cells["Description"].Value = item.Description;
            row.Cells["Short"].Value = item.ShortDesc;
            row.Cells["Dependent"].Value = item.Dependent;
            row.Cells["Exemption"].Value = item.Exemption.ToString("#,#0.00");

            GridHelper.ShowRecordInfo(row, item);
        }


        private void NewData()
        {
            try
            {
                var newItem = new Tax();

                var frm = new frmTaxTable_Add(this);
                frm.ItemData = newItem;

                if (frm.ShowDialog(this) != DialogResult.OK) return;
                frm.Dispose();

                ItemDataCollection.Add(newItem);
                DirtyStatus.SetDirty();

                var row = SGrid.PrimaryGrid.CreateNewRow(newItem);
                Show_DataOnRow(row, newItem);
                row.SetActive(true);
                row.EnsureVisible();

            }
            catch (Exception ex)
            {
                My.Message.ShowError(ex, this);
            }
        }

        private void EditData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var grid = SGrid.PrimaryGrid;
                if (grid.ActiveRow == null) return;
                var itemToEdit = (Tax)grid.ActiveRow.Tag;

                var frm = new frmTaxTable_Add(this);
                frm.ItemData = itemToEdit;

                if (frm.ShowDialog(this) != DialogResult.OK) return;
                frm.Dispose();

                if (itemToEdit.Id != 0) itemToEdit.RowStatus = RecordStatus.ModifiedRecord;
                DirtyStatus.SetDirty();
                ((GridRow)grid.ActiveRow).RowDirty = true;
                Show_DataOnRow((GridRow)grid.ActiveRow, itemToEdit);

            }
            catch (Exception ex)
            {
                My.Message.ShowError(ex, this);
            }
        }

        private void DeleteData()
        {
            var grid = SGrid.PrimaryGrid;

            if (grid.ActiveRow == null) return;

            var item = (Tax)grid.ActiveRow.Tag;

            var ret = My.Message.AskToDelete(item.Description);

            if (ret != eTaskDialogResult.Yes) return;

            ItemDataCollection.Remove(item);

            grid.ActiveRow.IsDeleted = true;
            grid.PurgeDeletedRows();

            DirtyStatus.SetDirty();
        }


        internal bool ContainsData(string taxId, string rowId)
        {
            var id = int.Parse(taxId);

            var foundItem = ItemDataCollection.Items.FirstOrDefault(x => x.TaxID == id &&
                                                                             x.RowId != rowId);
            if (foundItem == null) return false;
            return true;
        }


    }
}
