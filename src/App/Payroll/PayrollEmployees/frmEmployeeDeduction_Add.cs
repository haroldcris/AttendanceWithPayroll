using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using Dll.Payroll;
using System;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmEmployeeDeduction_Add : Office2007Form
    {

        public PayrollEmployeeDeduction ItemData { get; set; }

        private Deduction _tempDeduction;



        public frmEmployeeDeduction_Add()
        {
            InitializeComponent();


            lblDeduction.Text = "";
            dtDateReceived.Value = DateTime.Today;
            dtStart.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today;

            txtAmount.Value = 0;
        }


        private void btnSelectDeduction_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (var frm = new frmDeduction_Open())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;

                    _tempDeduction = frm.ItemData;
                }


                Show_Deduction(_tempDeduction);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void Show_Deduction(Deduction item)
        {
            //throw new System.NotImplementedException();
            var template = @"Deduction Code:<br/>
<font color='blue' size='+2'>
  <b>%code%</b><br/></font>
Description: <br/>
<font color='blue' size='+3'>
  <b>%description%</b>
</font>";

            template = template.Replace("%code%", item.Code);
            template = template.Replace("%description%", item.Description);


            lblDeduction.Text = template;

        }


        public void ShowData()
        {
            //
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {

            try
            {
                //ItemData.EmpId = ;
                ItemData.DeductionId = _tempDeduction.Id;
                ItemData.DeductionClass = _tempDeduction;

                ItemData.Amount = (decimal)txtAmount.Value;

                ItemData.DateFrom = dtStart.Value;
                ItemData.DateTo = dtEnd.Value;

                ItemData.Remarks = txtRemarks.Text;

                //var writer = new PayrollEmployeeD

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }



        }
    }
}
