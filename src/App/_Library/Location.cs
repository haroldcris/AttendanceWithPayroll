using Dll.Location;
using System.Collections.Generic;
using System.Windows.Forms;


public static partial class App
{
    internal class Location
    {
        public static void LoadProvinces(ComboBox cb)
        {
            var reader = new ProvinceDataReader();
            var items = reader.GetProvinces();
            if (items == null) return;

            LoadToCombo<Province>(cb, items);
        }

        public static void LoadTowns(ComboBox cb, int id)
        {
            var reader = new TownDataReader();
            var items = reader.GetTownsWithProvinceId(id);
            if (items == null) return;

            LoadToCombo(cb, items);
        }

        public static void LoadTowns(ComboBox cb, string province)
        {
            var reader = new TownDataReader();
            var items = reader.GetTownsOfProvince(province);
            if (items == null) return;

            LoadToCombo(cb, items);
        }

        public static void LoadBarangays(ComboBox cb, string province, string town)
        {
            var reader = new BarangayDataReader();
            var items = reader.GetBarangaysOf(province, town);
            if (items == null) return;

            LoadToCombo(cb, items);
        }


        private static void LoadToCombo<T>(ComboBox cb, IEnumerable<T> items)
        {
            cb.Items.Clear();
            foreach (var item in items)
            {
                cb.Items.Add(item);
            }
        }
    }
}
