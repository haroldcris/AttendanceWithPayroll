using AiTech.LiteOrm.Database;
using System;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;

namespace Winform
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

            styleManager1.ManagerStyle = eStyle.Metro;
            styleManager1.MetroColorParameters= MetroColorGeneratorParameters.Default;

            MainRibbonControl.MdiSystemItemVisible = false;
            MainRibbonControl.FadeEffect = true;

            lblServer.Text = @"Connected to: " + Connection.MyDbCredential.DatabasePath();
            lblVersion.Text = @"Version : " + App.CurrentVersion();

            mdiTab.Tabs.Clear();


            #region Event handler

            btnContacts.Click += (s, e) => OpenForm(new Contacts.frmContacts(), "Contacts Management");

            btnBatch.Click += (s, ev) => OpenForm(new frmBatch(), "Batch Management");
            btnCourse.Click += (s, ev) => OpenForm(new frmCourse(), "Course Management");


            btnPayMasterList.Click += (s, ev) => OpenForm(new Payroll.frmMasterFile(), "Payroll Master List");
            btnPayPositions.Click += (s, ev) => OpenForm(new Payroll.frmPosition(), "Payroll Positions");
            btnPayDeductions.Click += (s, ev) => OpenForm(new Payroll.frmDeduction(), "Payroll Deductions");
            //btnPayTax.Click += (s, ev) => OpenForm(new Payroll.frmTaxTable(), "Payroll Tax Table");


            btnPaySalarySchedule.Click += (s, ev) => OpenForm(new Payroll.frmSalarySchedule(), "Payroll Salary Schedule");


            btnSms.Click += (s, e) =>
            {
                var f = new SMS.frmSMS();
                f.ShowDialog();
            };

            #endregion
        }

        private void cmdSave_Executed(object sender, EventArgs e)
        {
            var active = ActiveMdiChild;
            if (active is ISave)
            {
                ((ISave)active).FileSave();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            AppButton.Visible = false;

            btnProfile.Text = string.Format("Welcome {0} [{1}]", App.CurrentUser.User.Username.ToUpper(), "--");


            //if (App.CurrentUser.SecurityLevel.ToLower() == "admin") {
            //    ribbonTabHomeAdmin.Select();
            //    ribbonTabHomeAdmin.Visible = true;
            //}

            App.MdiMainForm = this;

        }


        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
                cmdSave.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #region Common Scripts

        internal void OpenForm(IMDIForm form, string title)
        {
            Cursor.Current = Cursors.WaitCursor;


            var formTitle = " " + title + " ";

            if (MdiChildren.Count() != 0)
            {
                if (FindWindow(formTitle))
                {
                    ((Form)form).Dispose();
                    return;
                }
            }

            var frm = (Form)form;
            frm.MdiParent = this;
            ((MdiClientForm)frm).Title = formTitle;
            frm.Tag = formTitle;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

            Cursor.Current = Cursors.Default;
        }

        private bool FindWindow(string tag)
        {
            //Find if window is already open
            var foundWindow = MdiChildren.FirstOrDefault(o => o.Tag != null && o.Tag.ToString() == tag);
            if (foundWindow != null)
            {
                foundWindow.Focus();
                return true;
            }
            return false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            foreach (var frm in this.MdiChildren)
            {
                frm.Close();
            }

            if (!MdiChildren.Any())
                Application.Restart();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.TaskManagerClosing) return;

            if (!MdiChildren.Any()) return;

            foreach (var frm in MdiChildren)
            {
                ActivateMdiChild(frm);
                frm.Close();

                if (!frm.IsDisposed)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        #endregion


        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                item.Close();
            }
        }

    }
}
