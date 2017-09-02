using Dll.Payroll;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmAddEmployeeDeduction : Form
    {
        public frmAddEmployeeDeduction()
        {
            InitializeComponent();
        }

        private void btnSelectDeduction_Click(object sender, System.EventArgs e)
        {
            var item = new Deduction();
            using (var frm = new frmDeduction_Open())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;

                item = frm.ItemData;
            }


            Show_Deduction(item);
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




    }
}
