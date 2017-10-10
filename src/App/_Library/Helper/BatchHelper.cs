using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;
using Dll.SchoolYear;
using System;
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


        public static void LoadBatchListOnCombo(ComboTree cb, Action onChangedAction, int batchId = 0)
        {
            var loader = new BatchCollection();

            if (batchId != 0)
                loader.LoadItem(batchId);
            else
                loader.LoadAllItemsFromDb();

            cb.Nodes.Clear();

            foreach (var item in loader.Items)
            {
                var node = new Node()
                {
                    Name = item.Id.ToString(),
                    Text = $@"{item.BatchName} - {item.Semester}",
                    Tag = item,
                    //Image = Properties.Resources.Address_Book_16
                };
                cb.Nodes.Add(node);
            }

            if (cb.Nodes.Count != 0) cb.SelectedNode = cb.Nodes[cb.Nodes.Count - 1];
            if (onChangedAction != null)
                cb.TextChanged += (s, e) => { onChangedAction(); };
        }
    }
}