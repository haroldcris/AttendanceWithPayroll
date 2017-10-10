using AiTech.LiteOrm.Database.Search;
using AiTech.Tools.Winform;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Dll.Contacts;
using Dll.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Winform.Employee
{
    public partial class frmEmployee_Open : Office2007Form
    {
        public frmEmployee_Open()
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

        public int EmployeeId { get; private set; }

        public Dll.Employee.Employee ItemData { get; private set; }

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

            var x = FlexGrid[FlexGrid.Row, "empnum"];
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

            try
            {
                var empnum = 0;
                if (!int.TryParse(txtIdNum.Text, out empnum))
                {
                    MessageDialog.Show("Invalid Employee Number", "You have entered an Invalid Number");
                    txtIdNum.SelectAll();
                    return;
                }
                ;

                var empId = new EmployeeDataReader().GetIdOf(empnum);

                if (empId == 0)
                {
                    MessageDialog.Show("Invalid Employee Number", "You have entered an Invalid Number");
                    txtIdNum.SelectAll();
                    return;
                }

                EmployeeId = empId;


                ItemData = (new EmployeeDataReader()).GetItemOf(empId);


                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
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


            var reader = new EmployeeDataReader();
            var items = reader.SearchItem(txtSearch.Text, searchStyle);

            var enumerable = items as IList<Dll.Employee.Employee> ?? items.ToList();

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
                FlexGrid[row, "empnum"] = item.EmpNum;
                FlexGrid[row, "name"] = item.PersonClass.Name.Fullname;
                FlexGrid[row, "gender"] = item.PersonClass.Gender == GenderType.Male ? "Male" : "Female";

                FlexGrid.Select(1, 0);
            }
            FlexGrid.Focus();
        }
    }
}