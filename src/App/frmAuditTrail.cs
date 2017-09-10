using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Dll;

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
            Update();
            btnRefresh.RaiseClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            IEnumerable<ActionLog> items;

            items = App.CurrentUser.User.RoleClass.Can("SysAdmin")
                ? ActionLog.GetAllLogs()
                : ActionLog.GetAllLogs(App.CurrentUser.User.Username);


            //dataGridView1.DataSource = items;
            actionLogBindingSource.DataSource = items;
        }
    }
}