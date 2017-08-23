using AiTech.LiteOrm;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class MdiClientGridForm : MdiClientForm
    {

        public MdiClientGridForm()
        {
            InitializeComponent();

            InitializeGrid();
        }


        protected virtual void InitializeGrid()
        {
            var grid = SGrid.PrimaryGrid;

            grid.Filter.Visible = true;
            grid.EnableFiltering = true;

            grid.EnableColumnFiltering = true;

            grid.FilterMatchType = FilterMatchType.RegularExpressions;


            SGrid.ColumnHeaderMouseUp += SGrid_ColumnHeaderMouseUp;
        }

        private void SGrid_ColumnHeaderMouseUp(object sender, GridColumnHeaderMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var p = this.PointToScreen(e.Location);
                mnuGridColumn.Popup(p);
            }
        }



        protected void CreateGridContextMenu()
        {
            var grid = SGrid.PrimaryGrid;


            //mnuGridColumn.SubItems.Clear();
            mnuGridColumn.ThemeAware = true;

            for (var c = 0; c < grid.Columns.Count; c++)
            {
                var col = grid.Columns[c];

                var btn = new ButtonItem
                {
                    Text = col.HeaderText,
                    AutoCheckOnClick = true,
                    AutoCollapseOnClick = false,
                    HotTrackingStyle = eHotTrackingStyle.Color,
                    Checked = col.Visible == true,
                    ThemeAware = true,
                    Enabled = c > 1,
                    Tag = col,
                };

                btn.Command = cmdContext;

                mnuGridColumn.SubItems.Add(btn);
            }

        }


        /// <summary>
        /// Load all the Item Collection. Common Code:
        /// 
        /// ItemDataCollection = new PersonCollection();
        /// ItemDataCollection.LoadItemsFromDb();
        /// </summary>
        protected virtual IEnumerable<Entity> LoadItems() { return null; }

        protected virtual void Show_Data(IEnumerable<Entity> items)
        {
            SGrid.PrimaryGrid.Rows.Clear();

            foreach (var item in items)
            {
                if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                var row = SGrid.PrimaryGrid.CreateNewRow();
                row.Tag = item;

                Show_DataOnRow(row, item);
            }
        }

        protected virtual void Show_DataOnRow(GridRow row, Entity item) { }

        protected virtual Entity OnAdd() { throw new NotImplementedException(); }

        protected virtual bool OnEdit(Entity item) { throw new NotImplementedException(); }

        protected virtual void OnDelete(Entity item, out string message, ref Action<Entity> AfterConfirm) { message = ""; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var newItem = OnAdd();

                if (newItem == null) return;


                if (SGrid.PrimaryGrid.IsGrouped)
                {
                    RefreshData();
                    return;
                }

                var row = SGrid.PrimaryGrid.CreateNewRow();
                row.Tag = newItem;

                Show_DataOnRow(row, newItem);

                SGrid.PrimaryGrid.ClearSelectedRows();
                row.SetActive();
                row.IsSelected = true;
                row.EnsureVisible();

            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SGrid.ActiveFilterPanel != null) return;

            Cursor.Current = Cursors.WaitCursor;

            var grid = SGrid.PrimaryGrid;

            var item = (Entity)grid.ActiveRow?.Tag;

            if (item == null) return;



            string deleteMessage;
            Action<Entity> action = (i) => { };

            OnDelete(item, out deleteMessage, ref action);

            var ret = App.Message.AskToDelete("<b>" + deleteMessage.ToUpper() + "</b>");

            if (ret != MessageDialogResult.Yes) return;

            action(item);

            grid.ActiveRow.IsDeleted = true;
            grid.PurgeDeletedRows();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var grid = SGrid.PrimaryGrid;
                if (grid.ActiveRow == null) return;

                var item = (Entity)grid.ActiveRow.Tag;

                if (item == null) return;
                if (!OnEdit(item)) return;


                if (SGrid.PrimaryGrid.IsGrouped)
                {
                    RefreshData();
                    return;
                }

                Show_DataOnRow((GridRow)grid.ActiveRow, item);

            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RefreshData();
        }

        protected void RefreshData()
        {
            DoRefresh(async () =>
            {
                progressBarX1.Visible = true;

                var grid = SGrid.PrimaryGrid;
                grid.Rows.Clear();

                var items = Enumerable.Empty<Entity>();
                await Task.Factory.StartNew(() =>
                {
                    items = LoadItems();
                });

                progressBarX1.Visible = false;
                Show_Data(items);
            });
        }

        private void cmdContext_Executed(object sender, EventArgs e)
        {
            var button = (ButtonItem)sender;
            var col = (GridColumn)button.Tag;

            col.Visible = button.Checked;
        }
    }
}
