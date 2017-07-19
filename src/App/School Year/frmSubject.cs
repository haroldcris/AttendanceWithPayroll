using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using SmartData;
using DevComponents.DotNetBar;

namespace SmartApp
{
    public partial class frmSubject : MDIClientForm
    {
        SubjectCollection SubjectItems = new SubjectCollection();

        public frmSubject()
        {
            InitializeComponent();
            Title = "Subject Management";
            HeaderColor = Color.DarkGoldenrod;
        }
        private void frmSubject_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            SubjectItems.LoadItemsFromDb();
            //DisplayItems();
            GridHelper.DisplayItemsToGrid(flexGrid, SubjectItems.Items, DisplayItemOnCurrentRowExt);
        }

        private void DisplayItemOnCurrentRowExt()
        {
            var grid = flexGrid;
            var row = flexGrid.Row;
            var item = grid.GetUserData(row, 0) as Subject;

            flexGrid[row, flexGrid.Cols["subjectcode"].Index] = item.SubjectCode;
            flexGrid[row, flexGrid.Cols["description"].Index] = item.Description;
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Subject();
            var frm = new frmSubject_Add(this) { SubjectItem = newItem };

            var result = frm.ShowDialog();
                frm.Dispose();

            if (result == DialogResult.OK)
            {
                SubjectItems.Add(newItem);
                DirtyStatus.SetDirty();

                GridHelper.DoGridInsert(flexGrid, newItem, DisplayItemOnCurrentRowExt);
            }
        }
        

        public override bool FileSave()
        {
            return DoSave(() =>
            {
                var writer = new SubjectManager(App.CurrentUser.Username);
                writer.SetItems(SubjectItems);
                writer.SaveChanges();

                GridHelper.UpdateCreatedAndModifiedDate(flexGrid);
            });
        }

        internal bool ContainsData(Subject item)
        {
            var foundItem = SubjectItems.Items.FirstOrDefault(x => x.SubjectCode == item.SubjectCode);

            if (foundItem == null) return false;
            if (foundItem.Id == item.Id && foundItem.Id != 0) return false;

            return true;
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
            var item = (Subject)flexGrid.GetUserData(flexGrid.Row, 0);

            if (item == null) return;

            var result = App.Message.AskToDelete();

            if (result == eTaskDialogResult.Yes)
            {
                SubjectItems.Remove(item);
                DirtyStatus.SetDirty();
                flexGrid.RemoveItem(flexGrid.Row);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var subject = (Subject)flexGrid.GetUserData(flexGrid.Row, 0);
            if (subject == null) return;

            var frm = new frmSubject_Add(this);
                frm.SubjectItem = subject;

            var result = frm.ShowDialog();
                frm.Dispose();

            if (result == DialogResult.OK)
            {
                DirtyStatus.SetDirty();
                GridHelper.DisplayItemOnCurrentRow(flexGrid, DisplayItemOnCurrentRowExt);
            }
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.RaiseClick(eEventSource.Code);
        }
    }
}
