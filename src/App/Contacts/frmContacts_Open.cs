using AiTech.LiteOrm.Database.Search;
using AiTech.Tools.Winform;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Dll.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Winform.Contacts
{
    public partial class frmContacts_Open : Office2007Form
    {
        public frmContacts_Open()
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

        public Person ItemData { get; set; }

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

            var x = FlexGrid[FlexGrid.Row, "contactid"];
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


        private void btnOk_Click(object sender, EventArgs e)
        {
            var id = 0;
            if (!int.TryParse(txtIdNum.Text, out id))
            {
                MessageDialog.ShowValidationError(txtIdNum, "You have entered an Invalid Id");
                return;
            }


            var reader = new PersonDataReader();
            var item = reader.GetItem(id);

            if (item == null)
            {
                MessageDialog.ShowValidationError(txtIdNum, "You have entered an Invalid Id");
                return;
            }

            ItemData = item;

            DialogResult = DialogResult.OK;
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

            var reader = new PersonDataReader();
            var items = reader.SearchItem(txtSearch.Text, searchStyle);

            var enumerable = items as IList<Person> ?? items.ToList();

            if (!enumerable.Any())
            {
                MessageDialog.ShowValidationError(txtSearch, "No items match your search");
                return;
            }


            FlexGrid.Rows.Count = enumerable.Count() + 1;
            var row = 0;
            foreach (var item in enumerable.OrderBy(_ => _.Name.Fullname))
            {
                row++;
                FlexGrid[row, "contactid"] = item.Id;
                FlexGrid[row, "name"] = item.Name.Fullname;
                FlexGrid[row, "gender"] = item.Gender == GenderType.Male ? "Male" : "Female";

                FlexGrid[row, "birthdate"] = item.BirthDate.ToString("yyyy MMM dd");

                FlexGrid.Select(1, 0);
            }
            FlexGrid.Focus();
        }
    }
}