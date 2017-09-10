using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AiTech.LiteOrm;
using DevComponents.DotNetBar.SuperGrid;
using Dll.Payroll;

namespace Winform.Payroll
{
    public partial class frmGenerated_Open : FormWithHeader
    {
        private PayrollPeriodCollection ItemDataCollection;

        public frmGenerated_Open()
        {
            InitializeComponent();


            InitializeGrid();

            LoadItems();


            Shown += (s, e) => Show_Data(ItemDataCollection.Items);
        }

        public PayrollPeriod ItemData { get; private set; }


        private void InitializeGrid()
        {
            var grid = SGrid.PrimaryGrid;

            grid.ExpandButtonType = ExpandButtonType.Triangle;

            grid.GroupByRow.Visible = false;
            grid.GroupByRow.GroupBoxLayout = GroupBoxLayout.Hierarchical;

            grid.SelectionGranularity = SelectionGranularity.Row;

            grid.AllowEdit = false;
            grid.ShowRowDirtyMarker = true;

            grid.InitialActiveRow = RelativeRow.None;

            grid.ShowRowGridIndex = true;
            grid.GridPanel.RowHeaderIndexOffset = 1;

            grid.Columns.Clear();
            grid.Rows.Clear();


            SGrid.ColumnGrouped += Grid_ColumnGrouped;

            SGrid.DoubleClick += btnOk_Click;


            grid.CreateColumn("PayrollPeriod", "Period", 130);
            grid.CreateColumn("Title", "Title", 200);

            var col = grid.CreateColumn("SortOrder", "SortOrder", 80);
            col.Visible = false;


            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["SortOrder"]);

            grid.InsertGroup(col, 0);
        }

        private void Grid_ColumnGrouped(object sender, GridColumnGroupedEventArgs e)
        {
            string caption;

            switch (e.GridGroup.Text)
            {
                case "0":
                    caption = "This Month";
                    break;
                case "1":
                    caption = "This Year";
                    break;
                default:
                    caption = "Year " + e.GridGroup.Text;
                    break;
            }

            e.GridGroup.Text = caption;
        }


        private void LoadItems()
        {
            ItemDataCollection = new PayrollPeriodCollection();
            ItemDataCollection.LoadAllItems();
        }

        private void Show_Data(IEnumerable<PayrollPeriod> items)
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

        private void Show_DataOnRow(GridRow row, PayrollPeriod period)
        {
            row["PayrollPeriod"].Value = period.DateCovered.ToString("dd MMM yyyy");
            row["Title"].Value = period.Remarks;


            row["SortOrder"].Value = period.DateCovered.Year;


            if (period.DateCovered.Year.Equals(DateTime.Today.Year) &&
                period.DateCovered.Month.Equals(DateTime.Today.Month))
                row["SortOrder"].Value = 0;
            else if (period.DateCovered.Year == DateTime.Today.Year)
                row["SortOrder"].Value = 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var item = (PayrollPeriod) SGrid?.ActiveRow?.Tag;


            if (item == null) return;

            ItemData = item;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}