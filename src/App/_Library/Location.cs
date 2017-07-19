using AiTech.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static partial class App
{
    internal class Location
    {
        public static IEnumerable<Province> GetProvinces()
        {
            var reader = new AiTech.Location.LocationDataReader();
            return reader.GetProvinces();
        }

        public static IEnumerable<Town> GetTowns(int provinceId)
        {
            var reader = new AiTech.Location.LocationDataReader();
            return reader.GetTowns(provinceId);
        }

        public static IEnumerable<Town> GetTowns(string province)
        {
            var reader = new AiTech.Location.LocationDataReader();
            return reader.GetTowns(province);
        }

        public static IEnumerable<Barangay> GetBarangay(string province, string town)
        {
            var reader = new AiTech.Location.LocationDataReader();
            return reader.GetBarangays(province, town);
        }



        public static void LoadProvinces(ComboBox cb)
        {
            var items = GetProvinces();
            if (items == null) return;

            LoadToCombo<Province>(cb, items);
        }

        public static void LoadTowns(ComboBox cb, int id)
        {
            var items = GetTowns(id);
            if (items == null) return;

            LoadToCombo<Town>(cb, items);
        }

        public static void LoadTowns(ComboBox cb, string province)
        {
            var items = GetTowns(province);
            if (items == null) return;

            LoadToCombo<Town>(cb, items);
        }

        public static void LoadBarangays(ComboBox cb, string province, string town)
        {
            var items = GetBarangay(province, town);
            if (items == null) return;

            LoadToCombo<Barangay>(cb, items);
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
