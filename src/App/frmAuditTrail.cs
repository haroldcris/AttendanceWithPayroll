using DevComponents.DotNetBar;
using Dll;
using System;
using System.Windows.Forms;

namespace Winform
{
    public partial class frmAuditTrail : OfficeForm
    {
        public frmAuditTrail()
        {
            InitializeComponent();

            Shown += Form_Shown;
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Update();

            btnRefresh.RaiseClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            var items = ActionLog.GetAllLogs();

            //dataGridView1.DataSource = items;
            actionLogBindingSource.DataSource = items;
        }
    }
}
