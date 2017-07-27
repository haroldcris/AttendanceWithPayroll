using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.Drawing;
using Dll.SchoolYear;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.DotNetBar.SuperGrid;

namespace Winform.Payroll
{    
    public partial class frmMasterFile : MDIClientForm
    {        
        BatchCollection BatchItems = new BatchCollection();

        public frmMasterFile()
        {
            InitializeComponent();

            InitializeGrid();
            LoadItems();
        }

        private void InitializeGrid()
        {
            SGrid.InitializeGrid();

            SGrid.CreateColumn("Empnum", "Employee No.", 100, Alignment.MiddleCenter);

            
            SGrid.CreateColumn("Name", "Name", 300, Alignment.MiddleLeft);
            SGrid.CreateColumn("Gender", "Gender", 80, Alignment.MiddleCenter);

            SGrid.CreateColumn("Position", "Position", 120, Alignment.MiddleLeft);
            SGrid.CreateColumn("Department", "Department", 100, Alignment.MiddleLeft);
            
            SGrid.CreateColumn("Exemption", "Tax Exemption", 120, Alignment.MiddleLeft);

            SGrid.CreateColumn("CreatedBy", "Created By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Created", "Created", 130, Alignment.MiddleLeft);
            SGrid.CreateColumn("ModifiedBy", "Modified By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Modified", "Modified", 130, Alignment.MiddleLeft);

            SGrid.PrimaryGrid.CheckBoxes = true;
            SGrid.PrimaryGrid.Rows.Add(new GridRow("test"));
            SGrid.PrimaryGrid.Rows.Add(new GridRow("test"));
            SGrid.PrimaryGrid.Rows.Add(new GridRow("test"));


            SGrid.ColumnGrouped += (s, e) =>
            {
                var total = e.GridGroup.Rows.Count();
                e.GridGroup.Text = e.GridGroup.Text.ToUpper() + "  - " + total + (total < 2 ? " item" : " items");
            };


        }

        private void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            //BatchItems.LoadItemsFromDb();
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

        private void btnPayAdd_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;


            //var newItem = new Batch();
            var frm = new frmEmployeesAdd();

            var result = frm.ShowDialog();
            frm.Dispose();

            if (result == DialogResult.OK)
            {
            //    BatchItems.Add(newItem);
             //   DirtyStatus.SetDirty();
             //   FlexGridHelper.DoGridInsert(flexGrid, newItem, DisplayItemOnCurrentRowExt);
            }
        }
    }
}