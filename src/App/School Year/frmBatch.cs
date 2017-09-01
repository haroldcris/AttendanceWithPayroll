using DevComponents.DotNetBar;
using Dll.SchoolYear;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AiTech.Tools.Winform;

namespace Winform
{
    public partial class frmBatch : MdiClientForm
    {
        BatchCollection BatchItems = new BatchCollection();

        public frmBatch()
        {
            InitializeComponent();
            Title = "Batch Management";
            HeaderColor = Color.Indigo;
        }

        private void frmBatch_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            BatchItems.LoadItemsFromDb();
            FlexGridHelper.DisplayItemsToGrid(flexGrid, BatchItems.Items, DisplayItemOnCurrentRowExt);
        }

        private void DisplayItemOnCurrentRowExt()
        {
            var grid = flexGrid;
            var row = flexGrid.Row;
            var item = grid.GetUserData(row, 0) as Batch;

            grid[row, grid.Cols["batch"].Index] = item.BatchName;
            grid[row, grid.Cols["semester"].Index] = item.Semester;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Batch();
            var frm = new frmBatch_Add(this);
            frm.Batch = newItem;

            var result = frm.ShowDialog();
            frm.Dispose();

            if (result == DialogResult.OK)
            {
                BatchItems.Add(newItem);
                DirtyStatus.SetDirty();
                FlexGridHelper.DoGridInsert(flexGrid, newItem, DisplayItemOnCurrentRowExt);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (flexGrid.Rows.Count < 2) return;

            var itemToEdit = (Batch)flexGrid.GetUserData(flexGrid.Row, 0);
            if (itemToEdit == null) return;

            var frm = new frmBatch_Add(this);
            frm.Batch = itemToEdit;

            var result = frm.ShowDialog();
            frm.Dispose();

            if (result == DialogResult.OK)
            {
                DirtyStatus.SetDirty();
                FlexGridHelper.DisplayItemOnCurrentRow(flexGrid, DisplayItemOnCurrentRowExt);
            }
        }

        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var dataWriter = new BatchDataWriter(App.CurrentUser.User.Username, BatchItems);

                var result = dataWriter.SaveChanges();

                if (!result) throw new Exception("No Record has been saved");

                FlexGridHelper.UpdateCreatedAndModifiedDate(flexGrid);
            });
        }


        private void flexGrid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.RaiseClick(eEventSource.Code);
        }

        internal bool ContainsData(Batch item)
        {

            var foundItem = BatchItems.Items.FirstOrDefault(x => x.BatchName == item.BatchName &&
                                                                             x.Semester == item.Semester &&
                                                                             x.RowId != item.RowId);
            if (foundItem == null) return false;
            //if (foundItem.Id == item.Id && foundItem.Id != 0) return false;

            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh(LoadItems);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (flexGrid.Rows.Count == 1) return;

            var item = (Batch)flexGrid.GetUserData(flexGrid.Row, 0);

            if (item == null) return;

            var result = MessageDialog.AskToDelete();
            if (result == MessageDialogResult.Yes)
            {
                BatchItems.Remove(item);
                DirtyStatus.SetDirty();

                flexGrid.RemoveItem(flexGrid.Row);
            }
        }

    }
}