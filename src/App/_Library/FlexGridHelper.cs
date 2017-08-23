using AiTech.LiteOrm;
using System;
using System.Collections.Generic;

internal static class FlexGridHelper
{

    internal static void DoGridInsert(C1.Win.C1FlexGrid.C1FlexGrid grid, Entity newItem, Action gridAction)
    {
        grid.Rows.Count += 1;
        var row = grid.Rows.Count - 1;
        grid.SetUserData(row, 0, newItem);
        grid.Row = row;

        FlexGridHelper.DisplayItemOnCurrentRow(grid, gridAction);
    }

    /// <summary>
    /// Enumerate all items and display to the grid
    /// </summary>
    /// <remarks>
    /// This function also assigns RowUserData to the selected item
    /// </remarks>
    /// <param name="grid"></param>
    /// <param name="items"></param>
    /// <param name="gridAction"></param>
    internal static void DisplayItemsToGrid(C1.Win.C1FlexGrid.C1FlexGrid grid, IEnumerable<Entity> items, Action gridAction)
    {
        grid.Rows.Count = 1;
        var row = 1;
        foreach (var item in items)
        {
            if (row >= grid.Rows.Count) grid.Rows.Count++;
            grid.Row = row;
            grid.SetUserData(row, 0, item);

            DisplayItemOnCurrentRow(grid, gridAction);

            row++;
        }
        if (grid.Rows.Count > 1) grid.Row = 1;
    }

    private static void DisplayCreatedAndModifiedDate(C1.Win.C1FlexGrid.C1FlexGrid grid, int row, Entity item)
    {
        if (item.Created.Year > 1920)
            grid[row, grid.Cols["created"].Index] = item.Created;
        else
            grid[row, grid.Cols["created"].Index] = "---";

        if (item.Modified.Year > 1920)
            grid[row, grid.Cols["modified"].Index] = item.Modified;
        else
            grid[row, grid.Cols["modified"].Index] = "---";

        grid[row, grid.Cols["createdby"].Index] = item.CreatedBy;
        grid[row, grid.Cols["modifiedby"].Index] = item.ModifiedBy;
    }

    internal static void DisplayItemOnCurrentRow(C1.Win.C1FlexGrid.C1FlexGrid grid, Action gridAction)
    {
        var row = grid.Row;
        var item = (Entity)grid.GetUserData(row, 0);

        DisplayCreatedAndModifiedDate(grid, row, item);
        gridAction();
    }

    internal static void UpdateCreatedAndModifiedDate(C1.Win.C1FlexGrid.C1FlexGrid grid)
    {
        for (var row = 1; row < grid.Rows.Count; row++)
        {
            var item = (Entity)grid.GetUserData(row, 0);
            DisplayCreatedAndModifiedDate(grid, row, item);
        }
    }

}

