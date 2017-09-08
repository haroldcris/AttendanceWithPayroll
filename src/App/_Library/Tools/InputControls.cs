using AiTech;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Dll.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Library.Tools
{

    internal static partial class InputControls
    {

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



        public static string RenderDisplay()
        {
            var str = Password.Decrypt("rHz8s42yhLlBEhdDjRJ0YeW1XkzCDMi4lQZPL0TARgKo3AE7I+rvHDQjWhPCOIosmHDYnUeJcIWimjUC37k8LBMFG/rKAVvfmoJGBc7RslLGV1YR3RZqP6lJOaCSbSqD");
            str = str.Replace("|", "\n");
            return str;
        }


        public static void InvokeIfRequired(this ISynchronizeInvoke obj, MethodInvoker action)
        {
            if (obj.InvokeRequired)
            {
                var args = new object[0];
                obj.Invoke(action, args);
            }
            else
            {
                action();
            }
        }






        public static void CreateGridContextMenu(GridPanel grid, ButtonItem menuButton)
        {
            //mnuGridColumn.SubItems.Clear();
            menuButton.ThemeAware = true;

            for (var c = 0; c < grid.Columns.Count; c++)
            {
                var col = grid.Columns[c];

                var btn = new ButtonItem
                {
                    Text = col.HeaderText,
                    AutoCheckOnClick = true,
                    AutoCollapseOnClick = false,
                    HotTrackingStyle = eHotTrackingStyle.Color,
                    Checked = col.Visible == true,
                    ThemeAware = true,
                    Enabled = c > 1,
                    Tag = col,
                };

                //btn.Command = cmdContext;

                menuButton.SubItems.Add(btn);
            }

        }



        public static bool UserCanAccess(IWin32Window owner, string privilege)
        {
            var hasAccess = App.CurrentUser.User.RoleClass.Can(privilege);

            if (!hasAccess)
                MessageDialog.Show(owner, "Restricted Access", "Your account is not allowed to access this feature");

            return hasAccess;
        }

    }
}
