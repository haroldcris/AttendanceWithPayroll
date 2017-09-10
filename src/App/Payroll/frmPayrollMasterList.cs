using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Contacts;
using Dll.Employee;
using Dll.Payroll;
using Winform.Employee;

namespace Winform.Payroll
{
    public partial class frmMasterFile : MdiClientForm
    {
        internal PayrollEmployeeCollection ItemDataCollection = new PayrollEmployeeCollection();

        public frmMasterFile()
        {
            InitializeComponent();

            Header = " PAYROLL MASTERFILE ";
            HeaderColor = App.BarColor.PayrollMasterColor;

            InitializeGrid();

            RefreshData();
        }


        protected IEnumerable<PayrollEmployee> LoadItems()
        {
            ItemDataCollection.LoadAllItemsFromDb();
            return ItemDataCollection.Items;
        }


        protected void InitializeGrid()
        {
            SGrid.InitializeGrid();


            var grid = SGrid.PrimaryGrid;
            var col = new GridColumn();

            SGrid.RowDoubleClick += (s, e) => { btnPayViewProfile.RaiseClick(); };
            SGrid.ColumnHeaderMouseUp += SGrid_ColumnHeaderMouseUp;

            grid.GroupByRow.Visible = false;
            grid.Filter.Visible = true;
            grid.EnableFiltering = true;

            grid.EnableColumnFiltering = true;
            grid.FilterMatchType = FilterMatchType.RegularExpressions;


            grid.CheckBoxes = true;


            grid.CreateColumn("Empnum", "Employee No.", 100, Alignment.MiddleCenter);


            grid.CreateColumn("Name", "Name", 200);
            grid.CreateColumn("Gender", "Gender", 50, Alignment.MiddleCenter).Visible = false;

            grid.CreateColumn("Position", "Position", 90);

            grid.CreateColumn("Department", "Department", 90);

            grid.CreateColumn("TaxCode", "Tax Code", 80);

            grid.CreateColumn("SG", "SG", 40, Alignment.MiddleCenter);
            grid.CreateColumn("Step", "Step", 40, Alignment.MiddleCenter);

            col = grid.CreateColumn("Exemption", "Tax Exemption", 80, Alignment.MiddleRight);
            col.RenderType = typeof(GridDoubleInputEditControl);


            col = grid.CreateColumn("BasicSalary", "Salary", 80, Alignment.MiddleRight);
            col.RenderType = typeof(GridDoubleInputEditControl);


            col = grid.CreateColumn("Active", "Active", 40, Alignment.MiddleCenter);
            col.RenderType = typeof(GridCheckBoxXEditControl);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Name"]);
        }


        private void Show_Data(IEnumerable<PayrollEmployee> items)
        {
            SGrid.PrimaryGrid.Rows.Clear();

            foreach (var item in items)
            {
                if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                var row = SGrid.PrimaryGrid.CreateNewRow();
                row.Tag = item;

                Show_DataOnRow(row, item);
            }
        }


        protected void Show_DataOnRow(GridRow row, PayrollEmployee item)
        {
            var currentItem = item;

            row.Cells["Empnum"].Value = currentItem.EmployeeClass.EmpNum;
            row.Cells["Name"].Value = currentItem.EmployeeClass.PersonClass.Name.Fullname;

            row.Cells["Gender"].Value = currentItem.EmployeeClass.PersonClass.Gender == GenderType.Male
                ? "Male"
                : "Female";

            row.Cells["Position"].Value = currentItem.PositionClass.Description;
            row.Cells["SG"].Value = currentItem.SG;


            row.Cells["Step"].Value = currentItem.Step;

            row.Cells["Department"].Value = currentItem.Department;

            row.Cells["TaxCode"].Value = currentItem.TaxClass.ShortDesc;
            row.Cells["Exemption"].Value = currentItem.TaxClass.Exemption;


            row.Cells["BasicSalary"].Value = currentItem.BasicSalary;

            row.Cells["Active"].Value = currentItem.Active;

            row.CellStyles.Default = currentItem.Active
                ? null
                : new CellVisualStyle {Background = new Background(Color.LightGray)};

            row.ShowRecordInfo(currentItem);
        }


        protected void RefreshData()
        {
            DoRefresh(async () =>
            {
                //progressBarX1.Visible = true;

                var grid = SGrid.PrimaryGrid;
                grid.Rows.Clear();

                var items = Enumerable.Empty<PayrollEmployee>();
                await Task.Factory.StartNew(() => { items = LoadItems(); });

                //progressBarX1.Visible = false;
                Show_Data(items);
            });
        }


        protected PayrollEmployee OnAdd()
        {
            // Find Employee Id
            var employeeId = 0;

            using (var frm = new frmEmployee_Open())
            {
                if (frm.ShowDialog() != DialogResult.OK) return null;
                employeeId = frm.EmployeeId;
            }


            // Check for Duplicate
            var duplicate = new PayrollEmployeeDataReader().HasExistingId(employeeId);
            if (duplicate)
            {
                MessageDialog.Show("Duplicate Record", "An existing Record with same employee already exists");
                return null;
            }


            // Get Employee Profile
            var employee = new EmployeeDataReader().GetBasicProfileOf(employeeId);

            if (employee == null) throw new Exception("Record NOT found");


            // Create New Payroll Employee
            var newItem = new PayrollEmployee
            {
                EmployeeId = employee.Id,
                EmployeeClass = employee,
                Active = true
            };


            // Mandatory Deductions
            newItem.Deductions.AddMandatoryDeductions();
            DeductionGenerator.UpdateMandatoryDeductions(newItem);


            using (var frm = new frmPayrollEmployee_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }


            App.LogAction("Payroll", "Added Employee : " + newItem.EmployeeClass.EmpNum);

            return newItem;
        }


        protected bool OnEdit(PayrollEmployee item)
        {
            var selectedItem = item;

            using (var frm = new frmPayrollEmployee_Add())
            {
                if (selectedItem.Id != 0) selectedItem.RowStatus = RecordStatus.ModifiedRecord;
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("Payroll", "Updated Employee : " + selectedItem.EmployeeClass.EmpNum);

            return true;
        }


        protected void OnDelete(PayrollEmployee item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = item.EmployeeClass.PersonClass.Name.Fullname;

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (PayrollEmployee) currentItem;

                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new PayrollEmployeeDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();

                    ItemDataCollection.Remove((PayrollEmployee) currentItem);

                    App.LogAction("Payroll", "Deleted Employee : " + deletedItem.EmployeeClass.EmpNum);
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }


        private void SGrid_ColumnHeaderMouseUp(object sender, GridColumnHeaderMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var p = PointToScreen(e.Location);

                mnuGridColumn.PopupMenu(p);
            }
        }


        protected void CreateGridContextMenu()
        {
            var grid = SGrid.PrimaryGrid;


            //mnuGridColumn.SubItems.Clear();
            mnuGridColumn.ThemeAware = true;

            for (var c = 0; c < grid.Columns.Count; c++)
            {
                var col = grid.Columns[c];

                var btn = new ButtonItem
                {
                    Text = col.HeaderText,
                    AutoCheckOnClick = true,
                    AutoCollapseOnClick = false,
                    HotTrackingStyle = eHotTrackingStyle.Color,
                    Checked = col.Visible,
                    ThemeAware = true,
                    Enabled = c > 1,
                    Tag = col
                };

                btn.Command = cmdContext;

                mnuGridColumn.SubItems.Add(btn);
            }
        }


        private void cmdContext_Executed(object sender, EventArgs e)
        {
            var button = (ButtonItem) sender;
            var col = (GridColumn) button.Tag;

            col.Visible = button.Checked;
        }

        private void btnPayViewProfile_Click(object sender, EventArgs e)
        {
            //using (var frm = new frmPayrollEmployee_Add())
            //{
            //    if (frm.ShowDialog() != DialogResult.OK) return;
            //}
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                var newItem = OnAdd();

                if (newItem == null) return;

                ItemDataCollection.Add(newItem);

                if (SGrid.PrimaryGrid.IsGrouped)
                {
                    RefreshData();
                    return;
                }

                var row = SGrid.PrimaryGrid.CreateNewRow();
                row.Tag = newItem;

                Show_DataOnRow(row, newItem);

                SGrid.PrimaryGrid.ClearSelectedRows();
                row.SetActive();
                row.IsSelected = true;
                row.EnsureVisible();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SGrid.ActiveFilterPanel != null) return;

            Cursor.Current = Cursors.WaitCursor;

            var grid = SGrid.PrimaryGrid;
            var item = (PayrollEmployee) grid.ActiveRow?.Tag;
            if (item == null) return;


            string deleteMessage;
            Action<Entity> action = i => { };

            OnDelete(item, out deleteMessage, ref action);

            var ret = MessageDialog.AskToDelete("<b>" + deleteMessage.ToUpper() + "</b>");

            if (ret != MessageDialogResult.Yes) return;

            var strType = item.GetType().ToString().Split('.');

            App.LogAction(strType[strType.Length - 1], "Deleted " + deleteMessage);

            action(item);

            grid.ActiveRow.IsDeleted = true;
            grid.PurgeDeletedRows();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var grid = SGrid.PrimaryGrid;

                var item = (PayrollEmployee) grid.ActiveRow?.Tag;

                if (item == null) return;
                if (!OnEdit(item)) return;


                if (SGrid.PrimaryGrid.IsGrouped)
                {
                    RefreshData();
                    return;
                }

                Show_DataOnRow((GridRow) grid.ActiveRow, item);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RefreshData();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            var grid = SGrid.PrimaryGrid;

            foreach (var gridElement in grid.Rows)
            {
                var row = (GridRow) gridElement;

                row.Checked = true;
            }

            grid.SelectAll();
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            var grid = SGrid.PrimaryGrid;

            foreach (var gridElement in grid.Rows)
            {
                var row = (GridRow) gridElement;

                row.Checked = false;
            }

            grid.ClearSelectedRows();
        }

        private void btnToggleCheck_Click(object sender, EventArgs e)
        {
            var grid = SGrid.PrimaryGrid;

            foreach (var gridElement in grid.GetSelectedRows())
            {
                var row = (GridRow) gridElement;

                row.Checked = !row.Checked;
            }
        }

        private void btnPayGenerate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var list = new List<PayrollEmployee>();

            var grid = SGrid.PrimaryGrid;
            foreach (var gridElement in grid.Rows)
            {
                var row = (GridRow) gridElement;
                if (row.Checked)
                    list.Add((PayrollEmployee) row.Tag);
            }

            if (!list.Any())
            {
                MessageDialog.Show(this, "No Selected Item", "Check items that you wish to generate.");
                return;
            }


            var payPeriod = new PayrollPeriod();

            using (var frmGenerate = new frmGeneratePayroll())
            {
                frmGenerate.ItemData = payPeriod;
                frmGenerate.ListOfEmployees = list;
                frmGenerate.ShowDialog();
            }


            var frm = new frmPayroll
            {
                ItemData = payPeriod,
                Header = $" PAYROLL - {payPeriod.DateCovered:MMMM dd, yyyy} [{payPeriod.Remarks}]"
            };

            App.MdiMainForm.OpenForm(frm, "Payroll " + payPeriod.DateCovered.ToString("dd MMM yyyy"));
        }
    }
}