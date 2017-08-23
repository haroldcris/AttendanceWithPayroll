using System;
using System.Windows.Forms;

namespace Winform.Contacts
{

    public partial class frmContacts_Open : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Dll.Contacts.Person MyContact { get; set; }

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

        private void InitializeGrid()
        {
            FlexGrid.Rows.Count = 1;
            FlexGrid.RowColChange += FlexGrid_RowColChange;
            FlexGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;

            FlexGrid.AllowFiltering = false;
            FlexGrid.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop;
            FlexGrid.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;

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


        private void btnOk_Click(object sender, EventArgs e)
        {
            //var reader = new Dll.Contacts.ContactManager("");

            //var id = 0;
            //int.TryParse(txtIdNum.Text, out id);

            //var item = reader.GetItem(id);

            //if (item == null)
            //{
            //    My.Message.Show("Invalid Contact Id", "You have entered an Invalid Id");
            //    return;
            //}

            //ItemData = item;

            //DialogResult = DialogResult.OK;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FlexGrid.Rows.Count = 1;

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                App.Message.ShowValidationError(txtSearch, "Enter item to search");
                return;
            }


            if (cboSearchType.SelectedIndex == -1)
            {
                App.Message.ShowValidationError(cboSearchType, "Select Type of Search");
                return;
            }


            //var reader = new Dll.Contacts.ContactManager(App.CurrentUser.User.Username);

            //var searchStyle = new SearchStyleEnum();
            //switch(cboSearchType.Text)
            //{
            //    case "Contains": searchStyle = SearchStyleEnum.Contains; break;
            //    case "Starts With": searchStyle = SearchStyleEnum.StartsWith;  break;
            //    case "Ends With": searchStyle = SearchStyleEnum.EndsWith;  break;
            //}

            //var items = reader.SearchItem(txtSearch.Text, searchStyle);

            //if (items.Count() == 0)
            //{
            //    My.Message.ShowValidationError(txtSearch, "No items match your search");
            //    return;
            //}

            //FlexGrid.Rows.Count = items.Count() + 1;
            //var row = 0;
            //foreach(var item in items)
            //{
            //    row++;
            //    FlexGrid [row, "contactid"] = item.Id;
            //    FlexGrid [row, "name"] = item.Fullname();
            //    FlexGrid [row, "gender"] = item.Gender;

            //    FlexGrid.Select(1, 0);
            //}
            //FlexGrid.Focus();

        }


    }
}
