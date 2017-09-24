using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using Dll.SchoolYear;
using System;
using System.Windows.Forms;

namespace Winform.SchoolYear
{
    public partial class frmSection : MdiClientForm
    {
        public frmSection()
        {
            InitializeComponent();


            Header = " SECTION MANAGEMENT ";
            HeaderColor = App.BarColor.SectionColor;

            Load += (s, e) => { LoadData(); };


            BatchViewer.ItemSelected += BatchViewer_ItemSelected;
            OfferedCourseViewer.ItemSelected += OfferedCourseViewer_ItemSelected;

            SectionViewer.AfterItemEdit += SectionViewer_AfterItemEdit;
        }

        private void SectionViewer_AfterItemEdit(object sender, Section e)
        {
            try
            {

                if (e == null)
                {
                    MessageDialog.ShowValidationError(this, "Similar Record Already Exists!", null,null, 40);
                    return;
                }


                e.RowStatus = RecordStatus.ModifiedRecord;
                SectionViewer.SaveChanges(App.CurrentUser.User.Username);
                App.LogAction("Section", "Updated Section : " + e.SectionName);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowValidationError(this, ex.Message);
            }
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

            OfferedCourseViewer.Clear();
            SectionViewer.Clear();

            BatchViewer.LoadItems();
        }


        private void OfferedCourseViewer_ItemSelected(object sender, OfferedCourse e)
        {
            Cursor.Current = Cursors.WaitCursor;

            SectionViewer.Clear();

            if (e == null) return;

            SectionViewer.LoadItems(e);
        }


        private void BatchViewer_ItemSelected(object sender, Batch e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                OfferedCourseViewer.Clear();
                SectionViewer.Clear();

                if (e == null) return;

                OfferedCourseViewer.LoadItems(e);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }




        private Section GetSelectedItem()
        {
            var item = (Section)SectionViewer.TreeView.SelectedNode?.Tag;

            if (item == null)
            {
                MessageDialog.ShowValidationError(BatchViewer, "Select Item First", null, null, 40, false);
                return null;
            }

            return item;
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (BatchViewer.SelectedItem == null)
                {
                    MessageDialog.ShowValidationError(BatchViewer, "Select Batch First", null, null, 40, false);
                    return;
                }

                if (OfferedCourseViewer.SelectedItem == null)
                {
                    MessageDialog.ShowValidationError(BatchViewer, "Select Year Level First", null, null, 40, false);
                    return;
                }


                SectionViewer.Focus();
                var item = SectionViewer.CreateNewItem(true);

                OfferedCourseViewer.SelectedItem.Sections.Add(item);

                SectionViewer.SaveChanges(App.CurrentUser.User.Username);

                App.LogAction("Section", "Added Section " + item.SectionName);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }


        private void OnDelete(Section item, out string deleteMessage, ref Action<Section> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            deleteMessage = item.SectionName;

            afterConfirm = currentItem =>
            {
                try
                {
                    currentItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new SectionDataWriter(App.CurrentUser.User.Username, currentItem);
                    dataWriter.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var item = GetSelectedItem();
                if (item == null) return;


                string deleteMessage;
                Action<Section> action = i => { };

                OnDelete(item, out deleteMessage, ref action);

                var ret = MessageDialog.AskToDelete("<b>" + deleteMessage.ToUpper() + "</b>");

                if (ret != MessageDialogResult.Yes) return;

                action(item);

                SectionViewer.TreeView.SelectedNode.Remove();

                App.LogAction("Section", "Deleted Section : " + item.SectionName);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var item = GetSelectedItem();
                if (item == null) return;

                SectionViewer.EditSelectedItem();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }
    }
}
