using System.Windows.Forms;
using System.Linq;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Threading.Tasks;
using AiTech.Entities;
using Dll.Payroll;

namespace Winform.Payroll
{
    public partial class frmPosition : MDIClientForm
    {
        PositionCollection ItemDataCollection = new PositionCollection();

        public frmPosition()
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
                var dataWriter = new PositionDataWriter(My.App.CurrentUser.User.Username, ItemDataCollection);
                dataWriter.SaveChanges();

                Show_Data();
            });
        }


        private void InitializeGrid()
        {
            SGrid.InitializeGrid();

            var grid = SGrid.PrimaryGrid;

            grid.GroupByRow.Visible = false;

            grid.CreateColumn("Code", "Code", 120, Alignment.MiddleLeft);
            grid.CreateColumn("Description", "Description", 200, Alignment.MiddleLeft);

            grid.CreateRecordInfoColumns();

            grid.SetSort(SGrid.PrimaryGrid.Columns["Code"]);
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



        protected void Show_DataOnRow(GridRow row, Position item)
        {
            row.Cells["Code"].Value = item.Code;
            row.Cells["Description"].Value = item.Description;

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

            var item = (Position)grid.ActiveRow.Tag;

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
