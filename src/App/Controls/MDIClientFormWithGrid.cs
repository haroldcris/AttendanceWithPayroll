using System.Windows.Forms;
using System.Linq;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Threading.Tasks;
using AiTech.Entities;
using Dll.Payroll;

namespace Winform
{
    public abstract partial class MDIClientFormWithGrid <T, TCol> : MDIClientForm 
        where T: Entity
        where TCol:EntityCollection<T>, new()
    {
        TCol ItemDataCollection = new TCol();

        public MDIClientFormWithGrid()
        {
            InitializeComponent();

            InitializeGrid();

            this.Shown += (s, e) => { RefreshData(); };

            btnRefresh.Click += (s,e) => { RefreshData(); };
            btnEdit.Click += (s, e) => { EditData(); };
            btnAdd.Click += (s, e) => { NewData(); };
            btnDelete.Click += (s, e) => { DeleteData(); };
            SGrid.RowDoubleClick += (s, e) => { EditData(); };
        }

       
        public override bool FileSave()
        {
            return DoSave(() =>
            {
                //var dataWriter = new PositionDataWriter(My.App.CurrentUser.User.Username, ItemDataCollection);
                //dataWriter.SaveChanges();

                Show_Data();
            });
        }


        protected virtual void InitializeGrid()
        {
            SGrid.InitializeGrid();
            //SGrid.PrimaryGrid.GroupByRow.Visible = false;

            //SGrid.CreateColumn("Code", "Code", 120, Alignment.MiddleLeft);
            //SGrid.CreateColumn("Description", "Description", 200, Alignment.MiddleLeft);

            //SGrid.CreateColumn("CreatedBy", "Created By", 90, Alignment.MiddleLeft);
            //SGrid.CreateColumn("Created", "Created", 130, Alignment.MiddleLeft);
            //SGrid.CreateColumn("ModifiedBy", "Modified By", 90, Alignment.MiddleLeft);
            //SGrid.CreateColumn("Modified", "Modified", 130, Alignment.MiddleLeft);

            //SGrid.PrimaryGrid.SetSort(SGrid.PrimaryGrid.Columns["Code"]);
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

                var row = CreateNewRow(item);

                Show_DataOnRow(row, item);
            }
        }

        private GridRow CreateNewRow(T item)
        {
            var row = SGrid.PrimaryGrid.CreateNewRow();
            row.Tag = item;
            return row;
        }

        protected void Show_DataOnRow(GridRow row, T item)
        {
            //row.Cells["Code"].Value = item.Code;
            //row.Cells["Description"].Value = item.Description;

            GridHelper.ShowRecordInfo(row, item);
        }


        private void NewData()
        {
            try
            {
                var newItem = new Position();
                var frm = new frmPosition_Add(this);
                frm.ItemData = newItem;

                if (frm.ShowDialog(this) != DialogResult.OK) return;
                frm.Dispose();

                ItemDataCollection.Add(newItem);
                DirtyStatus.SetDirty();

                var row = CreateNewRow(newItem);
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
                var itemToEdit = (Position)grid.ActiveRow.Tag;

                var frm = new frmPosition_Add(this);
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

            var item = (T)grid.ActiveRow.Tag;

            var ret = My.Message.AskToDelete(item.Code);

            if (ret != eTaskDialogResult.Yes) return;

            ItemDataCollection.Remove(item);

            grid.ActiveRow.IsDeleted = true;
            grid.PurgeDeletedRows();

            DirtyStatus.SetDirty();
        }

        

        internal bool ContainsData(string code, string rowId)
        {
            var foundItem = ItemDataCollection.Items.FirstOrDefault(x => x.Code == code &&
                                                                             x.RowId != rowId);
            if (foundItem == null) return false;
            return true;
        }
    }
}
