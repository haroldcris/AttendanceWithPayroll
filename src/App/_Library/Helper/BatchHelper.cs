using System.Linq;
using System.Windows.Forms;

public static class Helper
{
    public static class BatchHelper
    {
        internal static AutoCompleteStringCollection GetBatchList()
        {
            var col = new AutoCompleteStringCollection();
            foreach (var i in Enumerable.Range(1950, 2020))
                col.Add($"{i}-{i + 1}");
            return col;
        }
    }
}