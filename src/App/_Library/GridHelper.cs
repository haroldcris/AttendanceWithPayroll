using AiTech.LiteOrm;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

internal static partial class GridHelper
{

    public static void CreateRecordInfoColumns(this GridPanel control)
    {
        control.CreateColumn("CreatedBy", "Created By", 90, Alignment.MiddleLeft);
        control.CreateColumn("Created", "Created", 130, Alignment.MiddleLeft);
        control.CreateColumn("ModifiedBy", "Modified By", 90, Alignment.MiddleLeft);
        control.CreateColumn("Modified", "Modified", 130, Alignment.MiddleLeft);
    }


    public static void ShowRecordInfo(GridRow row, Entity item)
    {

        row.Cells["Created"].Value = item.Created.Year <= 1920 ? "---" : item.Created.ToString("dd-MMM-yyyy hh:mm:ss tt");
        row.Cells["CreatedBy"].Value = item.Created.Year <= 1920 ? "---" : item.CreatedBy;

        row.Cells["Modified"].Value = item.Modified.Year <= 1920 ? "---" : item.Modified.ToString("dd-MMM-yyyy hh:mm:ss tt"); ;
        row.Cells["ModifiedBy"].Value = item.Modified.Year <= 1920 ? "---" : item.ModifiedBy;


        var font = row.SuperGrid.Font; ;

        row.Cells["Created"].CellStyles.Default.Font = new System.Drawing.Font(font.FontFamily, 7);
        row.Cells["CreatedBy"].CellStyles.Default.Font = new System.Drawing.Font(font.FontFamily, 7);
    }


    public static GridRow CreateNewRow(this GridPanel control)
    {
        var row = new GridRow();

        for (var i = 0; i < control.Columns.Count; i++)
            row.Cells.Add(new GridCell());

        control.Rows.Add(row);
        return row;
    }

    public static GridRow CreateNewRow(this GridPanel control, object tag)
    {
        var row = CreateNewRow(control);
        row.Tag = tag;
        return row;
    }

    public static GridColumn CreateColumn(this SuperGridControl control, string name, string text, int width = 50, Alignment alignment = Alignment.MiddleLeft)
    {
        var grid = control.PrimaryGrid;
        var col = new GridColumn(name);
        col.Width = width;
        col.HeaderText = text;
        col.CellStyles.Default.Alignment = alignment;
        grid.Columns.Add(col);
        return col;
    }

    public static GridColumn CreateColumn(this GridPanel control, string name, string text, int width = 50, Alignment alignment = Alignment.MiddleLeft)
    {
        var col = new GridColumn(name);
        col.Width = width;
        col.HeaderText = text;
        col.CellStyles.Default.Alignment = alignment;
        control.Columns.Add(col);
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
    }

}

