using AiTech.LiteOrm;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

internal static class SuperGridHelper
{
    public static void CreateRecordInfoColumns(this GridPanel control)
    {
        GridColumn col;
        col = control.CreateColumn("CreatedBy", "Created By", 80);
        col.Visible = false;

        col = control.CreateColumn("ModifiedBy", "Modified By", 80);
        col.Visible = false;




        col = control.CreateColumn("Created", "Created", 130);
        col.Visible = false;
        col.DataType = typeof(DateTime);
        col.FilterEditType = FilterEditType.DateTime;

        col = control.CreateColumn("Modified", "Modified", 130);
        col.Visible = false;
        col.DataType = typeof(DateTime);
        col.FilterEditType = FilterEditType.DateTime;
    }


    public static void ShowRecordInfo(this GridRow row, Entity item)
    {
        row.Cells["Created"].Value = item.Created.Year <= 1920 ? (object)"---" : item.Created;//.ToString("dd-MMM-yyyy hh:mm:ss tt");
        row.Cells["CreatedBy"].Value = item.Created.Year <= 1920 ? "---" : item.CreatedBy;

        row.Cells["Modified"].Value = item.Modified.Year <= 1920 ? (object)"---" : item.Modified;//.ToString("dd-MMM-yyyy hh:mm:ss tt"); ;
        row.Cells["ModifiedBy"].Value = item.Modified.Year <= 1920 ? "---" : item.ModifiedBy;
    }


    public static GridRow CreateNewRow(this GridPanel control)
    {
        var row = new GridRow();

        for (var i = 0; i < control.Columns.Count; i++)
            row.Cells.Add(new GridCell());

        control.Rows.Add(row);
        return row;
    }


    public static GridColumn CreateColumn(this GridPanel control, string name, string text, int width = 50, Alignment alignment = Alignment.MiddleLeft)
    {
        var col = new GridColumn(name)
        {
            Width = width,
            HeaderText = text
        };
        col.CellStyles.Default.Alignment = alignment;
        control.Columns.Add(col);
        return col;
    }


    public static GridColumn CreateColumn(this SuperGridControl control, string name, string text, int width = 50, Alignment alignment = Alignment.MiddleLeft)
    {
        var grid = control.PrimaryGrid;
        var col = new GridColumn(name)
        {
            Width = width,
            HeaderText = text
        };

        col.CellStyles.Default.Alignment = alignment;
        grid.Columns.Add(col);
        return col;
    }

    public static void InitializeGrid(this SuperGridControl control)
    {
        var grid = control.PrimaryGrid;
        grid.ExpandButtonType = ExpandButtonType.Triangle;

        grid.GroupByRow.Visible = true;
        grid.GroupByRow.GroupBoxLayout = GroupBoxLayout.Hierarchical;

        grid.SelectionGranularity = SelectionGranularity.Row;

        grid.AllowEdit = false;
        grid.ShowRowDirtyMarker = true;

        grid.InitialActiveRow = RelativeRow.None;

        grid.ShowRowGridIndex = true;
        grid.GridPanel.RowHeaderIndexOffset = 1;

        grid.Columns.Clear();
        grid.Rows.Clear();


        control.ColumnGrouped += Control_ColumnGrouped;


        control.EnableClipboardCopy();


        control.KeyDown += (s, e) =>
        {
            //Select All
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                ((SuperGridControl)s).PrimaryGrid.SelectAll();
            }
        };
    }

    private static void Control_ColumnGrouped(object sender, GridColumnGroupedEventArgs e)
    {
        var total = e.GridGroup.Rows.Count;

        e.GridGroup.Text = e.GridGroup.Text.ToUpper() + "  - " + total + (total < 2 ? " item" : " items");
    }


    public static void EnableClipboardCopy(this SuperGridControl control)
    {
        control.KeyDown += (s, e) =>
        {
            //Copy
            if (!e.Control || e.KeyCode != Keys.C) return;

            e.SuppressKeyPress = true;
            var panel = ((SuperGridControl)s).PrimaryGrid;

            var groupBy = panel.GetSelectedCells().GroupBy(_ => ((GridCell)_).RowIndex);

            var selectedText = string.Join("\n",
                groupBy.Select(groupCell => string.Join("\t",
                    groupCell.Select(v => ((GridCell)v).Value.ToString()).ToArray())).ToArray());

            if (!string.IsNullOrEmpty(selectedText))
                Clipboard.SetText(selectedText);

            Debug.WriteLine(panel.SelectedCellCount);
        };
    }

    public static void EnableClipboardPasteNumbers(this GridPanel panel)
    {
        panel.SuperGrid.KeyDown += (s, e) =>
        {
            //Paste
            if (!e.Control || e.KeyCode != Keys.V) return;

            e.SuppressKeyPress = true;

            var clipBoard = System.Windows.Forms.Clipboard.GetText();

            var lines = clipBoard.Split('\n');

            var currentRow = panel.ActiveCell.RowIndex;
            var currentCol = panel.ActiveCell.ColumnIndex;


            for (var row = 0; row < lines.Length - 1; row++)
            {

                var cells = lines[row].Split('\t');

                for (var col = 0; col < cells.Length; col++)
                {
                    var activeCell = panel.GetCell(currentRow + row, currentCol + col);

                    if (activeCell == null) continue;


                    if (!activeCell.GridPanel.AllowEdit) continue;
                    if (!activeCell.GridColumn.AllowEdit) continue;
                    if (!activeCell.AllowEdit) continue;

                    decimal result;
                    activeCell.Value = decimal.TryParse(cells[col], out result) ? result : 0;

                    activeCell.EditorDirty = true;
                    activeCell.IsSelected = true;
                }

            }
        };
    }

}

