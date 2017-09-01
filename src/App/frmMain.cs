using AiTech.LiteOrm.Database;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
using Dll.Contacts;
using Idms;
using System;
using System.Linq;
using System.Windows.Forms;
using Winform.Accounts;
using Winform.Contacts;
using Winform.Employee;

namespace Winform
{
    public partial class frmMain : Office2007RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

            styleManager1.ManagerStyle = eStyle.Metro;
            styleManager1.MetroColorParameters = MetroColorGeneratorParameters.Default;

            MainRibbonControl.MdiSystemItemVisible = false;
            MainRibbonControl.FadeEffect = true;


            Text = @"Megabyte College Information System";
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


            btnEmployee.Click += (s, e) => OpenForm(new frmEmployee(), "Employees");

            btnSms.Click += (s, e) =>
            {
                using (var f = new SMS.frmSMS())
                {
                    f.ShowDialog();
                }
            };


            //Accounts
            btnUserAccounts.Click += (s, e) => OpenForm(new frmAccounts(), "User Account Management");

            btnChangePassword.Click += (s, e) =>
            {
                using (var f = new frmChangePassword())
                {
                    f.ShowDialog();
                }
            };


            #endregion

            btnContextMdiTabs.PopupOpen += (s, e) => CreateContextTabMenu();

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

            btnProfile.Text = string.Format("Welcome {0} [{1}]", App.CurrentUser.User.Username.ToUpper()
                                                               , App.CurrentUser.User.RoleClass.RoleName);

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

        internal void OpenForm(IMdiForm form, string title)
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

            frm.WindowState = FormWindowState.Minimized;
            frm.Show();
            frm.Update();
            frm.WindowState = FormWindowState.Maximized;



            App.LogAction("", "Opened " + title);
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


        private void CreateContextTabMenu()
        {
            btnContextMdiTabs.SubItems.Clear();

            if (!MdiChildren.Any())
            {
                return;
            }

            foreach (var child in MdiChildren)
            {
                var buttonItem = new ButtonItem("btn" + child.Name, child.Text)
                {
                    Tag = child,
                };

                buttonItem.Click += (s, e) =>
                {
                    var frm = ((Form)((ButtonItem)s).Tag);
                    frm?.Activate();
                };

                btnContextMdiTabs.SubItems.Add(buttonItem);
            }

            var btnCloseAll = new ButtonItem()
            {
                Text = @"Close All Tabs",
                BeginGroup = true
            };

            btnCloseAll.Click += (s, e) =>
            {
                foreach (var w in MdiChildren) w.Close();
            };


            btnContextMdiTabs.SubItems.Add(btnCloseAll);
            btnContextMdiTabs.Refresh();

            btnContextMdiTabs.ShowSubItems = true;
            btnContextMdiTabs.RecalcSize();
        }

        private void mdiTab_DoubleClick(object sender, EventArgs e)
        {
            var frm = this.ActiveMdiChild;
            frm.MdiParent = null;
        }




        private void btnContactsCreate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var newItem = new Person();

            using (var frm = new frmContacts_Add())
            {
                frm.ItemData = newItem;
                frm.Owner = this;

                if (frm.ShowDialog() != DialogResult.OK) return;
            }
        }

        private void btnContactsOpen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Find Employee Id
            var item = new Person();
            using (var frm = new frmContacts_Open())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;
                item = frm.ItemData;
            }


            using (var frm = new frmContacts_Add())
            {
                frm.ItemData = item;
                frm.ShowDialog();
            }
            //
        }
    }
}
