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

namespace Winform
{
    public abstract partial class MDIClientFormWithCRUDButtons <T, TCol>: MDIClientForm
        where T: Entity
        where TCol : EntityCollection<T>, new()
    {
        protected TCol ItemDataCollection = new TCol();

        public MDIClientFormWithCRUDButtons()
        {
            InitializeComponent();

            InitializeButtonEventHandler();

            //InitializeGrid();
            
        }


        protected void InitializeButtonEventHandler()
        {
            this.Shown += (s, e) => { RefreshData(); };

            btnRefresh.Click += (s, e) => { RefreshData(); };
            btnEdit.Click += (s, e) => { EditData(); };
            btnAdd.Click += (s, e) => { NewData(); };
            btnDelete.Click += (s, e) => { DeleteData(); };
            SGrid.RowDoubleClick += (s, e) => { EditData(); };
        }



        protected virtual void InitializeGrid()
        {
            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;
                grid.CreateRecordInfoColumns();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


        protected virtual void LoadItems()
        {
            Show_Data();
        }


        protected void RefreshData()
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

        protected void Show_Data()
        {
            var grid = SGrid.PrimaryGrid;
            grid.Rows.Clear();

            var counter = 0;
            foreach (var item in ItemDataCollection.Items)
            {
                if (item.RowStatus == RecordStatus.DeletedRecord) continue;
                counter++;

                var row = grid.CreateNewRow (item);

                Show_DataOnRow(row, item);
            }
        }


        protected virtual void Show_DataOnRow(GridRow row, T item)
        {
            //row.Cells["Code"].Value = item.Code;
            //row.Cells["Description"].Value = item.Description;

            //row.Cells["Mandatory"].Value = item.Mandatory;
            //row.Cells["Priority"].Value = item.Priority;
            //row.Cells["Active"].Value = item.Active;

            //if (item.Active)
            //    row.CellStyles.Default = null;
            //else
            //    row.CellStyles.Default = new CellVisualStyle() { Background = new Background(System.Drawing.Color.LightGray) };

            GridHelper.ShowRecordInfo(row, item);
        }

        protected abstract T OnItemCreated();
        protected abstract T OnItemUpdated();
        protected abstract string GetItemDeleteMessage();

        protected virtual void NewData()
        {
            try
            {
                
                var newItem = OnItemCreated();

                if (newItem == null) return;

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


        protected T GetCurrentItemOnGrid()
        {
            var grid = SGrid.PrimaryGrid;
            if (grid.ActiveRow == null) return null;
            return (T)grid.ActiveRow.Tag;
        }

        private void EditData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //var grid = SGrid.PrimaryGrid;
                //if (grid.ActiveRow == null) return;
                //var itemToEdit = (T)grid.ActiveRow.Tag;

                //var frm = new frmDeduction_Add(this);
                //frm.ItemData = itemToEdit;

                //if (frm.ShowDialog(this) != DialogResult.OK) return;
                //frm.Dispose();

                var itemToEdit = OnItemUpdated();
                if (itemToEdit == null) return;

                if (itemToEdit.Id != 0) itemToEdit.RowStatus = RecordStatus.ModifiedRecord;
                DirtyStatus.SetDirty();
                ((GridRow)SGrid.PrimaryGrid.ActiveRow).RowDirty = true;

                Show_DataOnRow((GridRow)SGrid.PrimaryGrid.ActiveRow, itemToEdit);

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

            var item = (T)grid.ActiveRow.Tag;

            var ret = My.Message.AskToDelete(GetItemDeleteMessage());

            if (ret != eTaskDialogResult.Yes) return;

            ItemDataCollection.Remove(item);

            grid.ActiveRow.IsDeleted = true;
            grid.PurgeDeletedRows();

            DirtyStatus.SetDirty();
        }


        //internal virtual bool ContainsData(string code, string rowId)
        //{
        //    var foundItem = ItemDataCollection.Items.FirstOrDefault(x => x.Code == code &&
        //                                                                     x.RowId != rowId);
        //    if (foundItem == null) return false;
        //    return true;
        //}


    }
}
