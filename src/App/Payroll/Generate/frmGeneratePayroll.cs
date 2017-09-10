using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AiTech.Tools.Winform;
using Dll.Payroll;

namespace Winform.Payroll
{
    public partial class frmGeneratePayroll : FormWithHeader
    {
        public frmGeneratePayroll()
        {
            InitializeComponent();

            dtPeriod.Value = DateTime.Today;
        }

        public IEnumerable<PayrollEmployee> ListOfEmployees { get; set; }

        public PayrollPeriod ItemData { get; set; }


        private bool FileSave()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (!DataIsValid()) return false;


                // Update MANDATORY COMPUTATIONS
                foreach (var emp in ListOfEmployees)
                {
                    emp.Deductions.LoadAllItemsWithDeduction();
                    DeductionGenerator.UpdateMandatoryDeductions(emp);
                    var mandatoryWriter = new PayrollEmployeeDataWriter(App.CurrentUser.User.Username, emp);
                    mandatoryWriter.SaveChanges();
                }


                //ItemData.Id =  ;
                ItemData.PayrollType = "Regular";
                ItemData.DateCovered = dtPeriod.Value;
                ItemData.Remarks = txtRemarks.Text;


                var generator = new PayrollGenerator();

                pbStatus.Maximum = ListOfEmployees.Count();
                pbStatus.Text = "";
                pbStatus.Visible = true;

                pbStatus.Refresh();

                generator.Generate(ItemData, ListOfEmployees, OnProgress);


                var writer = new PayrollPeriodDataWriter(App.CurrentUser.User.Username, ItemData);
                writer.SaveChanges();

                App.LogAction("Payroll", "Generated New Payroll :" + dtPeriod.Value.ToString("yyyy MMMM dd"));
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
                return false;
            }
        }


        private void OnProgress(int completed, string statusText)
        {
            pbStatus.Text = statusText;
            pbStatus.Value = completed;
            bar1.Refresh();

            //pbStatus.InvokeIfRequired(() =>
            //{
            //    lblStatus.Text = statusText;
            //    lblStatus.Refresh();
            //});


            //progressBar1.InvokeIfRequired(() =>
            //{
            //    progressBar1.Value = completed;
            //});
        }


        private bool DataIsValid()
        {
            if (!txtRemarks.Text.Any())
            {
                MessageDialog.ShowValidationError(txtRemarks, "Payroll Title is Required");
                return false;
            }


            var reader = new PayrollPeriodDataReader();

            if (reader.HasExistingPeriod(dtPeriod.Value))
            {
                MessageDialog.ShowValidationError(dtPeriod, "Similar Payroll Period Date alreay Exists!");
                return false;
            }


            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (FileSave())
                DialogResult = DialogResult.OK;
        }
    }
}