using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.Drawing;
using Dll.SchoolYear;

namespace Winform
{
    public partial class frmCourse : MDIClientForm
    {
        CourseCollection CourseItems = new CourseCollection();

        public frmCourse()
        {
            InitializeComponent();
            Title = "Course Management";
            HeaderColor = Color.Maroon;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            flexGrid.ShowCursor = true;
            LoadItems();
        }

        private void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            CourseItems.LoadItemsFromDb();
            FlexGridHelper.DisplayItemsToGrid(flexGrid, CourseItems.Items, DisplayItemOnCurrentRowExt);
        }
        
        private void DisplayItemOnCurrentRowExt()
        {
            var grid = flexGrid;
            var row = flexGrid.Row;
            var item = grid.GetUserData(row, 0) as Course;

            flexGrid[row, flexGrid.Cols["coursecode"].Index] = item.CourseCode;
            flexGrid[row, flexGrid.Cols["description"].Index] = item.Description;
        }

       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Course();
            var frm = new frmCourse_Add(this);
                frm.CurrentCourse = newItem;

            var result = frm.ShowDialog();
                frm.Dispose();

            if (result == DialogResult.OK)
            {
                CourseItems.Add(newItem);
                DirtyStatus.SetDirty();

                FlexGridHelper.DoGridInsert(flexGrid, newItem, DisplayItemOnCurrentRowExt);
            }
        }
      
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var itemToEdit = (Course)flexGrid.GetUserData(flexGrid.Row, 0);
            if (itemToEdit == null) return;

            var frm = new frmCourse_Add(this);
                frm.CurrentCourse = itemToEdit;
            var result = frm.ShowDialog();
                frm.Dispose();

            if (result == DialogResult.OK)
            {
                DirtyStatus.SetDirty();
                FlexGridHelper.DisplayItemOnCurrentRow(flexGrid, DisplayItemOnCurrentRowExt);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh(() =>
            {
                LoadItems();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = (Course)flexGrid.GetUserData(flexGrid.Row, 0);

            if (item == null) return;

            var result = My.Message.AskToDelete();

            if (result == eTaskDialogResult.Yes)
            {
                CourseItems.Remove(item);
                DirtyStatus.SetDirty();
                flexGrid.RemoveItem(flexGrid.Row);
            }
        }


        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var dataWriter = new CourseDataWriter(My.App.CurrentUser.User.Username, CourseItems);
                var result = dataWriter.SaveChanges();

                if (!result) throw new Exception("No Record has been saved");
                FlexGridHelper.UpdateCreatedAndModifiedDate(flexGrid);
            });
        }

        private void flexGrid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.RaiseClick(eEventSource.Code);
        }

        internal bool ContainsData(Course item)
        {
            var foundItem= CourseItems.Items.FirstOrDefault(_ => _.CourseCode == item.CourseCode &&
                                                                           _.RowId != item.RowId);

            if (foundItem == null) return false;
            if (foundItem.Id == item.Id && foundItem.Id != 0) return false;

            return true;
        }

    }
}