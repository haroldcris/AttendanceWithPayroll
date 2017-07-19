using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static partial class Helper
{
    public static partial class BatchHelper
    {

        internal static AutoCompleteStringCollection GetBatchList()
        {
            var col = new AutoCompleteStringCollection();
            foreach (var i in Enumerable.Range(1950, 2020))
            {
                col.Add(string.Format("{0}-{1}", i, i + 1));
            }
            return col;
        }
    }
}
