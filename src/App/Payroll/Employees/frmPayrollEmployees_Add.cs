using AiTech.Tools.Winform;
using Dll.Contacts;
using Dll.Payroll;
using Library.Tools;
using System;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmPayrollEmployee_Add : FormWithRecordInfo, ISave
    {

        public DirtyFormHandler DirtyStatus { get; }


        public PayrollEmployee ItemData;


        public frmPayrollEmployee_Add()
        {
            InitializeComponent();

            this.AskToSaveOnDirtyClosing();

            DirtyStatus = new DirtyFormHandler(this);

            btnAddDeduction.Click += btnAddDeduction_Click;

            Load_Positions();
            Load_Tax();

            Load += (s, e) => ShowData();
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

            var item = (PositionSalaryGrade)cboPosition.SelectedItem;

            txtSG.Text = item.SG.ToString();
        }

        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTax.SelectedIndex == -1) return;

            var item = (Tax)cboTax.SelectedItem;

            txtExemption.Text = item.Exemption.ToString("0,000.00");

        }



        private void btnAddDeduction_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var frm = new frmAddEmployeeDeduction();
            frm.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FileSave();
        }

        private bool DataIsValid()
        {
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

            //cboPosition
            foreach (var p in cboPosition.Items)
            {
                if (((PositionSalaryGrade)p).PositionId != ItemData.PositionId) continue;
                cboPosition.SelectedItem = p;
                break;
            }

            cboStep.Text = ItemData.Step.ToString();


            foreach (var t in cboTax.Items)
            {
                if (((Tax)t).Id != ItemData.TaxId) continue;
                cboTax.SelectedItem = t;
                break;
            }


            expandableSplitter1.Expanded = ItemData.Id != 0;

            ShowFileInfo(ItemData);

            DirtyStatus.Clear();
        }


        private void Show_NameProfile()
        {
            var template = @"<font color='blue'><b>%name%</b> <br/>
                                        %gender% <br/>
                                        </font>";

            template = template.Replace("%name%", ItemData.EmployeeClass.PersonClass.Name.Fullname.ToUpper());
            template = template.Replace("%gender%", ItemData.EmployeeClass.PersonClass.Gender == GenderType.Male ? "Male" : "Female");

            lblNameProfile.Text = template;
        }




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
            var selectedPSG = ((PositionSalaryGrade)cboPosition.SelectedItem);
            ItemData.SG = selectedPSG.SG;
            ItemData.PositionId = selectedPSG.PositionId;
            ItemData.PositionClass = selectedPSG.PositionClass;


            ItemData.Step = cboStep.SelectedIndex + 1;


            //Tax
            var selectedTax = (Tax)cboTax.SelectedItem;
            ItemData.TaxClass = selectedTax;
            ItemData.TaxId = selectedTax.Id;


            ItemData.Active = switchActive.Value;


            //UPdate BASIC SALARY
            var reader = new SalaryScheduleDataReader();
            ItemData.BasicSalary = reader.GetSalaryOfPositionId(ItemData.PositionId, ItemData.Step, DateTime.Now);

            var writer = new PayrollEmployeeDataWriter(App.CurrentUser.User.Username, ItemData);
            writer.SaveChanges();

            DirtyStatus.Clear();

            DialogResult = DialogResult.OK;
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
