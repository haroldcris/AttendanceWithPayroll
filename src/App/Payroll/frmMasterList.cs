using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.Drawing;
using Dll.SchoolYear;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.DotNetBar.SuperGrid;

namespace Winform
{    
    public partial class frmMasterFile : MDIClientForm
    {        
        BatchCollection BatchItems = new BatchCollection();

        public frmMasterFile()
        {
            InitializeComponent();
            Title = "PAYROLL MASTER LIST";

            LoadItems();
        }


        private void InitializeGrid()
        {
            SGrid.ColumnGrouped += Grid_ColumnGrouped;

            SGrid.InitializeGrid();

            SGrid.CreateColumn("Code", "Code", 100, Alignment.MiddleCenter);
            SGrid.CreateColumn("Description", "Description", 150, Alignment.MiddleLeft);
            SGrid.CreateColumn("Barangay", "Barangay", 100, Alignment.MiddleLeft);
            SGrid.CreateColumn("Route", "Route", 450, Alignment.MiddleLeft);

            SGrid.CreateColumn("CreatedBy", "Created By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Created", "Created", 130, Alignment.MiddleLeft);
            SGrid.CreateColumn("ModifiedBy", "Modified By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Modified", "Modified", 130, Alignment.MiddleLeft);

        }
        private void Grid_ColumnGrouped(object sender, GridColumnGroupedEventArgs e)
        {
            //throw new NotImplementedException();
            var total = e.GridGroup.Rows.Count();

            e.GridGroup.Text = e.GridGroup.Text.ToUpper() + "  - " + total + (total < 2 ? " item" : " items");
        }


        private void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            //BatchItems.LoadItemsFromDb();
        }
              
        
       

        private void btnAdd_Click (object sender, EventArgs e)
        {
            //var newItem = new Batch();
            //var frm = new frmBatch_Add(this);
            //frm.Batch = newItem;

            //var result = frm.ShowDialog();
            //frm.Dispose();

            //if (result == DialogResult.OK)
            //{
            //    BatchItems.Add(newItem);
            //    DirtyStatus.SetDirty();
            //    FlexGridHelper.DoGridInsert(flexGrid, newItem, DisplayItemOnCurrentRowExt);
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (flexGrid.Rows.Count < 2) return;

            //var itemToEdit = (Batch)flexGrid.GetUserData(flexGrid.Row, 0);
            //if (itemToEdit == null) return;

            //var frm = new frmBatch_Add(this);
            //frm.Batch = itemToEdit;

            //var result = frm.ShowDialog();
            //frm.Dispose();

            //if (result == DialogResult.OK)
            //{
            //    DirtyStatus.SetDirty();
            //    FlexGridHelper.DisplayItemOnCurrentRow(flexGrid, DisplayItemOnCurrentRowExt);
            //}
        }

        public override bool FileSave()
        {
            return DoSave(() => 
            {
                //var dataWriter = new BatchDataWriter(My.App.CurrentUser.User.Username, BatchItems);

                //var result = dataWriter.SaveChanges();

                //if (!result) throw new Exception("No Record has been saved");

                //FlexGridHelper.UpdateCreatedAndModifiedDate(flexGrid);
            });
        }


        private void flexGrid_DoubleClick(object sender, EventArgs e)
        {
            //btnEdit.RaiseClick(eEventSource.Code);
        }

        internal bool ContainsData(Batch item)
        {

            //var foundItem = BatchItems.Items.FirstOrDefault(x => x.BatchName == item.BatchName && 
            //                                                                 x.Semester == item.Semester  &&
            //                                                                 x.RowId != item.RowId);
            //if (foundItem == null) return false;
            ////if (foundItem.Id == item.Id && foundItem.Id != 0) return false;

            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh(LoadItems);            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (flexGrid.Rows.Count == 1) return;

            //var item = (Batch) flexGrid.GetUserData(flexGrid.Row, 0);

            //if (item == null) return;

            //var result = My.Message.AskToDelete();
            //if (result == eTaskDialogResult.Yes)
            //{
            //    BatchItems.Remove(item);
            //    DirtyStatus.SetDirty();

            //    flexGrid.RemoveItem(flexGrid.Row);
            //}
        }
       
    }
}