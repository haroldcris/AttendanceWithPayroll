using AiTech.LiteOrm.Database.Search;
using AiTech.Tools.Winform;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Dll.Biometric;
using Dll.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Winform.Biometric
{
    public partial class frmBiometric_Open : Office2007Form
    {

        public int BiometricId { get; private set; }


        public frmBiometric_Open()
        {
            InitializeComponent();

            InitializeGrid();


            KeyPreview = true;

            KeyDown += Form_KeyDown;

            cboSearchType.Items.Clear();
            cboSearchType.Items.Add("Contains");
            cboSearchType.Items.Add("Starts With");
            cboSearchType.Items.Add("Ends With");
            cboSearchType.SelectedIndex = 0;
        }



        private void InitializeGrid()
        {
            FlexGrid.Rows.Count = 1;
            FlexGrid.RowColChange += FlexGrid_RowColChange;
            FlexGrid.SelectionMode = SelectionModeEnum.Row;

            FlexGrid.AllowFiltering = false;
            FlexGrid.AutoSearch = AutoSearchEnum.FromTop;
            FlexGrid.KeyActionEnter = KeyActionEnum.None;
        }

        private void FlexGrid_RowColChange(object sender, EventArgs e)
        {
            if (FlexGrid.Row < 1) return;

            var x = FlexGrid[FlexGrid.Row, "biometricid"];
            if (x == null) return;
            txtIdNum.Text = x.ToString();
        }


        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
                txtSearch.Focus();


            if (e.KeyCode == Keys.Return)
            {
                if (ActiveControl.Name == txtSearch.Name)
                {
                    btnSearch.PerformClick();
                    return;
                }

                btnOk.PerformClick();
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var biometricId = 0;
            if (!int.TryParse(txtIdNum.Text.Replace("-", "").Replace(" ", ""), out biometricId))
            {
                MessageDialog.Show("Invalid Biometric Id", "You have entered an Invalid Id");
                txtIdNum.SelectAll();
                return;
            }
            ;

            var validBiometricId = (new BiometricUserDataReader()).HasExistingBiometricId(biometricId);

            if (!validBiometricId)
            {
                MessageDialog.Show("Invalid Biometric Number", "You have entered an Invalid Number");
                txtIdNum.SelectAll();
                return;
            }

            this.BiometricId = biometricId;

            DialogResult = DialogResult.OK;
        }


        private bool DataSearchIsValid()
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageDialog.ShowValidationError(txtSearch, "Enter item to search");

                return false;
            }


            if (cboSearchType.SelectedIndex == -1)
            {
                MessageDialog.ShowValidationError(cboSearchType, "Select Type of Search");

                return false;
            }


            return true;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            FlexGrid.Rows.Count = 1;

            if (!DataSearchIsValid()) return;

            var searchStyle = new SearchStyleEnum();
            switch (cboSearchType.Text)
            {
                case "Contains":
                    searchStyle = SearchStyleEnum.Contains;
                    break;
                case "Starts With":
                    searchStyle = SearchStyleEnum.StartsWith;
                    break;
                case "Ends With":
                    searchStyle = SearchStyleEnum.EndsWith;
                    break;
            }


            var reader = new BiometricUserDataReader();
            var items = reader.SearchItem(txtSearch.Text, searchStyle);

            var enumerable = items as IList<BiometricUser> ?? items.ToList();

            if (!enumerable.Any())
            {
                MessageDialog.ShowValidationError(txtSearch, "No items match your search");
                return;
            }


            FlexGrid.Rows.Count = enumerable.Count() + 1;
            var row = 0;
            foreach (var item in enumerable.OrderBy(_ => _.PersonClass.Name.Fullname))
            {
                row++;
                FlexGrid[row, "biometricid"] = item.BiometricId;
                FlexGrid[row, "name"] = item.PersonClass.Name.Fullname;
                FlexGrid[row, "gender"] = item.PersonClass.Gender == GenderType.Male ? "Male" : "Female";

                FlexGrid.Select(1, 0);
            }
            FlexGrid.Focus();
        }
    }
}