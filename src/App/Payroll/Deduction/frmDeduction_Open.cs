using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AiTech.LiteOrm.Database.Search;
using AiTech.Tools.Winform;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Dll.Payroll;

namespace Winform.Payroll
{
    public partial class frmDeduction_Open : Office2007Form
    {
        public frmDeduction_Open()
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

        public Deduction ItemData { get; private set; }

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

            var x = FlexGrid[FlexGrid.Row, "code"];
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

            if (string.IsNullOrEmpty(txtIdNum.Text))
            {
                MessageDialog.Show("Invalid Deduction Code", "You have entered an Invalid Code");
                txtIdNum.SelectAll();
                return;
            }
            ;


            var deduction = new DeductionDataReader().GetItem(txtIdNum.Text);

            if (deduction == null)
            {
                MessageDialog.Show("Invalid Deduction Code", "You have entered an Invalid Code");
                txtIdNum.SelectAll();
                return;
            }

            ItemData = deduction;

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
            try
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


                var reader = new DeductionDataReader();
                var items = reader.SearchItem(txtSearch.Text, searchStyle);

                var deductions = items as IList<Deduction> ?? items.ToList();

                if (!deductions.Any())
                {
                    MessageDialog.ShowValidationError(txtSearch, "No items match your search");
                    return;
                }


                FlexGrid.Rows.Count = deductions.Count() + 1;
                var row = 0;
                foreach (var item in deductions.OrderBy(_ => _.Description))
                {
                    row++;
                    FlexGrid[row, "code"] = item.Code;
                    FlexGrid[row, "description"] = item.Description;
                    FlexGrid.Select(1, 0);
                }
                FlexGrid.Focus();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }
    }
}