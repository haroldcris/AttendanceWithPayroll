using DevComponents.DotNetBar;

namespace Winform.Employee
{
    public partial class frmEmployee_AssignSubject : Office2007Form
    {
        public frmEmployee_AssignSubject()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, System.EventArgs e)
        {


            Helper.BatchHelper.LoadBatchListOnCombo(cboBatch, ShowSubjectsHandled);
        }


        private void ShowSubjectsHandled()
        {

        }
    }
}
