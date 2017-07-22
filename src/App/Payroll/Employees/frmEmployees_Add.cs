using AiTech.Entities;
using System;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmEmployeesAdd : FormWithRecordInfo
    {
        public frmEmployeesAdd()
        {
            InitializeComponent();

            btnAddDeduction.Click += btnAddDeduction_Click;

        }

        private void btnAddDeduction_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var frm = new frmAddEmployeeDeduction();
            frm.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!DataIsValid()) return;
            
            DialogResult = DialogResult.OK;
        }

        private bool DataIsValid()
        {
            return true;
        }

        private void ShowData()
        {
            //if (MyContact.Id !=0) txtId.Text = MyContact.Id.ToString("0000");

            //ShowFileInfo (MyContact);
        }

    }
}
