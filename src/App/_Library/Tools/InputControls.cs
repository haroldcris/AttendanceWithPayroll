using AiTech.LiteOrm;
using DevComponents.DotNetBar;
using Dll.Location;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Library.Tools
{
    internal static partial class InputControls
    {

        public static void ConvertEnterToTab(System.Windows.Forms.Form form, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Enter) || (e.KeyChar == (int)Keys.Return))
            {
                //Console.WriteLine("Next Control " + form.ActiveControl.Name); ;
                form.SelectNextControl(form.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }





        public static void HandleComboBoxAutoComplete(ComboBox control, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                //let it go if it's a control char such as escape, tab, backspace, enter...
                return;
            }

            //must get the selected portion only. Otherwise, we append the e.KeyChar to the AutoSuggested value (i.e. we'd never get anywhere)
            string nonSelected = control.Text.Substring(0, control.Text.Length - control.SelectionLength);

            string text = nonSelected + e.KeyChar;
            //if(box.Items.ToString().StartsWith(text)

            bool matched = false;
            for (int i = 0; i < control.Items.Count; i++)
            {
                if (control.Items[i].ToString().ToLowerInvariant().StartsWith(text, StringComparison.CurrentCultureIgnoreCase))
                {
                    matched = true;
                    break;
                }
            }

            //toggle the matched bool because if we set handled to true, it precent's input, and we don't want to prevent
            //input if it's matched.
            e.Handled = !matched;
        }

        public static void LoadToComboBox<T>(ComboBox cb, IEnumerable<T> items)
        {
            cb.Items.Clear();
            if (items == null) return;

            foreach (var item in items)
            {
                cb.Items.Add(item);
            }
        }


        public static void LoadImage(PictureBox control, string filenameFromServer)
        {
            if (string.IsNullOrEmpty(filenameFromServer)) return;

            var path = string.Format("http://{0}/amwp/pictures/{1}.jpg", AiTech.LiteOrm.Database.Connection.MyDbCredential.ServerName, filenameFromServer);
            control.LoadAsync(path);

        }


        public static Image GetImage(string filenameFromServer)
        {
            if (string.IsNullOrEmpty(filenameFromServer)) return null;

            var path = string.Format("http://{0}/amwp/pictures/{1}.jpg", AiTech.LiteOrm.Database.Connection.MyDbCredential.ServerName, filenameFromServer);

            Debug.WriteLine(path);
            var pb = new PictureBox();
            pb.Load(path);

            return pb.Image;
        }




        public static class Address
        {
            public static void LoadProvinceListTo(ComboBox cb)
            {
                var reader = new ProvinceDataReader();
                var items = reader.GetProvinces();

                LoadToComboBox(cb, items);
            }

            public static void LoadTownListTo(ComboBox cb, int provinceId)
            {
                var reader = new TownDataReader();
                var items = reader.GetTownsWithProvinceId(provinceId);

                LoadToComboBox(cb, items);
            }

            public static void LoadTownListTo(ComboBox cb, string province)
            {
                var reader = new TownDataReader();
                var items = reader.GetTownsOfProvince(province);

                LoadToComboBox(cb, items);
            }

            public static void LoadBarangayListTo(ComboBox cb, string town, string province)
            {
                var reader = new BarangayDataReader();
                var items = reader.GetBarangaysOf(town, province);

                InputControls.LoadToComboBox<Barangay>(cb, items);

                cb.DropDownStyle = cb.Items.Count == 0 ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList;

            }

            public static List<string> GetCountryList()
            {
                List<string> cultureList = new List<string>();

                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

                foreach (CultureInfo culture in cultures)
                {
                    RegionInfo region = new RegionInfo(culture.LCID);

                    if (!(cultureList.Contains(region.EnglishName)))
                    {
                        cultureList.Add(region.EnglishName);
                    }
                }
                return cultureList;
            }
        }


        public static void ShowFileInfo(IRecordInfo info, LabelItem lblCreated, LabelItem lblModified)
        {
            const string template = @"<b>{By}</b><br/>
                                      {Date}<br/>{Time}";

            var str = "";

            if (info.Created.Year <= 1920) return;

            str = template.Replace("{By}", info.CreatedBy);
            str = str.Replace("{Date}", info.Created.ToString("dd-MMM-yyyy"));
            str = str.Replace("{Time}", info.Created.ToString("hh:mm:ss tt"));

            lblCreated.Text = str;

            str = template.Replace("{By}", info.ModifiedBy);
            str = str.Replace("{Date}", info.Modified.ToString("dd-MMM-yyyy"));
            str = str.Replace("{Time}", info.Modified.ToString("hh:mm:ss tt"));

            lblModified.Text = str;

        }



    }
}
