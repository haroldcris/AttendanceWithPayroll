using System;
using System.Linq;
using System.Windows.Forms;
using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using Dll.Payroll;
using Library.Tools;

namespace Winform.Payroll
{
    public partial class frmPayrollEmployee_Add : FormWithRecordInfo, ISave
    {
        public PayrollEmployee ItemData;

        //private PayrollEmployeeDeductionCollection _tempPayEmpDeductions;
        public frmPayrollEmployee_Add()
        {
            InitializeComponent();

            this.AskToSaveOnDirtyClosing();

            DirtyStatus = new DirtyFormHandler(this);

            Load_Positions();
            Load_Tax();

            Load += (s, e) => ShowData();
        }

        public DirtyFormHandler DirtyStatus { get; }


        public bool FileSave()
        {
            if (!DataIsValid()) return false;


            //ItemData.EmployeeId = record.EmployeeId;
            ItemData.DateHired = dtDateHired.Value;
            ItemData.Department = cboDepartment.Text;


            ItemData.Tin = txtTin.Text;
            ItemData.PhilHealth = txtPhilHealth.Text;
            ItemData.PagIbig = txtPagIbig.Text;


            //Position
            var selectedPSG = (PositionSalaryGrade) cboPosition.SelectedItem;
            ItemData.SG = selectedPSG.SG;
            ItemData.PositionId = selectedPSG.PositionId;
            ItemData.PositionClass = selectedPSG.PositionClass;


            ItemData.Step = cboStep.SelectedIndex + 1;


            //Tax
            var selectedTax = (Tax) cboTax.SelectedItem;
            ItemData.TaxClass = selectedTax;
            ItemData.TaxId = selectedTax.Id;


            ItemData.Active = switchActive.Value;


            //Deductions
            //ItemData.Deductions;


            //UPdate BASIC SALARY
            ItemData.UpdateBasicSalary(DateTime.Now);


            var writer = new PayrollEmployeeDataWriter(App.CurrentUser.User.Username, ItemData);
            writer.SaveChanges();


            DirtyStatus.Clear();

            DialogResult = DialogResult.OK;
            return true;
        }


        private void Load_Tax()
        {
            var items = new TaxCollection();
            items.LoadItemsFromDb();

            InputControls.LoadToComboBox(cboTax, items.Items);
        }


        private void Load_Positions()
        {
            var items = new PositionSalaryGradeCollection();
            items.LoadLatestSchedule();

            InputControls.LoadToComboBox(cboPosition, items.Items);
        }


        private void cboPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPosition.SelectedIndex == -1) return;

            var item = (PositionSalaryGrade) cboPosition.SelectedItem;

            txtSG.Text = item.SG.ToString();
        }

        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTax.SelectedIndex == -1) return;

            var item = (Tax) cboTax.SelectedItem;

            txtExemption.Text = item.Exemption.ToString("0,000.00");
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            FileSave();
        }

        private bool DataIsValid()
        {
            if (dtDateHired.Value.Date.Year < 1950)
            {
                MessageDialog.ShowValidationError(dtDateHired, "Date Hired is Invalid");
                return false;
            }


            if (string.IsNullOrWhiteSpace(cboDepartment.Text))
            {
                MessageDialog.ShowValidationError(cboDepartment, "Department Data is Required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboPosition.Text))
            {
                MessageDialog.ShowValidationError(cboPosition, "Position is Required");
                return false;
            }

            if (cboStep.SelectedIndex == -1)
            {
                MessageDialog.ShowValidationError(cboStep, "Step Data is Required");
                return false;
            }


            if (cboTax.SelectedIndex == -1)
            {
                MessageDialog.ShowValidationError(cboTax, "Tax Exemption Data is Required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTin.Text))
            {
                MessageDialog.ShowValidationError(txtTin, "TIN data is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhilHealth.Text))
            {
                MessageDialog.ShowValidationError(txtPhilHealth, "PhilHealth Number is Required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPagIbig.Text))
            {
                MessageDialog.ShowValidationError(txtPagIbig, "PAG-IBIG Number is Required");
                return false;
            }


            return true;
        }

        private void ShowData()
        {
            Show_NameProfile();

            InputControls.LoadImage(picImage, ItemData.EmployeeClass.PersonClass.CameraCounter);

            switchActive.Value = ItemData.Active;


            txtTin.Text = ItemData.Tin;
            txtPhilHealth.Text = ItemData.PhilHealth;
            txtPagIbig.Text = ItemData.PagIbig;


            dtDateHired.Value = ItemData.DateHired;
            cboDepartment.Text = ItemData.Department;

            // Match Position 
            foreach (var p in cboPosition.Items)
            {
                if (((PositionSalaryGrade) p).PositionId != ItemData.PositionId) continue;
                cboPosition.SelectedItem = p;
                break;
            }

            cboStep.Text = ItemData.Step.ToString();

            // Match Tax Code
            foreach (var t in cboTax.Items)
            {
                if (((Tax) t).Id != ItemData.TaxId) continue;
                cboTax.SelectedItem = t;
                break;
            }


            // Deductions
            if (ItemData.Id != 0)
                Load_Deductions();

            Show_Deductions();


            expandableSplitter1.Expanded = ItemData.Id != 0;

            ShowFileInfo(ItemData);

            DirtyStatus.Clear();
        }


        private void Show_NameProfile()
        {
            var template = @"Name:<br/>
<font color='blue'><b>%name%</b></font><br/><br/>
Employee No.:<br/>
<font color='blue'><b>%empnum%</b></font>
";

            template = template.Replace("%name%", ItemData.EmployeeClass.PersonClass.Name.Fullname.ToUpper());
            template = template.Replace("%empnum%", ItemData.EmployeeClass.EmpNum.ToString());

            lblNameProfile.Text = template;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Show_Deductions()
        {
            FlexGridDeductions.Rows.Count = 1;

            if (!ItemData.Deductions.Items.Any()) return;

            FlexGridDeductions.Rows.Count = ItemData.Deductions.Items.Count();


            FlexGridDeductions.Rows.Count = ItemData.Deductions.Items.Count() + 1;

            var row = 0;
            foreach (var item in ItemData.Deductions.Items)
            {
                row++;
                FlexGridDeductions[row, "code"] = item.DeductionClass.Code;
                FlexGridDeductions[row, "description"] = item.DeductionClass.Description;
                FlexGridDeductions[row, "amount"] = item.Amount;


                FlexGridDeductions[row, "startdate"] = item.DeductionClass.Mandatory ? (object) "---" : item.DateFrom;
                FlexGridDeductions[row, "enddate"] = item.DeductionClass.Mandatory ? (object) "---" : item.DateTo;

                FlexGridDeductions.Rows[row].UserData = item;
            }
        }

        private void Load_Deductions()
        {
            ItemData.Deductions.LoadAllItemsWithDeduction();
        }


        private void btnAddDeduction_Click(object sender, EventArgs e)
        {
            var newItem = new PayrollEmployeeDeduction();

            using (var frm = new frmEmployeeDeduction_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return;

                //newItem = frm.ItemData;
            }

            ItemData.Deductions.Add(newItem);
            Show_Deductions();
        }

        private void btnDeleteDeduction_Click(object sender, EventArgs e)
        {
            if (FlexGridDeductions.Row < 1) return;

            var item = (PayrollEmployeeDeduction) FlexGridDeductions.Rows[FlexGridDeductions.Row].UserData;


            if (item.DeductionClass.Mandatory)
            {
                MessageDialog.ShowValidationError(FlexGridDeductions, "You Can NOT delete Mandatory Deduction");
                return;
            }


            item.RowStatus = RecordStatus.DeletedRecord;

            FlexGridDeductions.RemoveItem(FlexGridDeductions.Row);
        }
    }
}