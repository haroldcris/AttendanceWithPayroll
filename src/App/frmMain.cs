using AiTech.LiteOrm.Database;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
using Dll.Contacts;
using Dll.Employee;
using Dll.Payroll;
using Idms;
using Library.Tools;
using System;
using System.Linq;
using System.Windows.Forms;
using Winform.Accounts;
using Winform.Biometric;
using Winform.Contacts;
using Winform.Employee;



namespace Winform
{
    public partial class frmMain : Office2007RibbonForm
    {
        private bool _buttonPress;

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


            btnBatch.Click += (s, ev) => OpenForm(new frmBatch(), "Batch Management");
            btnCourse.Click += (s, ev) => OpenForm(new frmCourse(), "Course Management");


            btnPayMasterList.Click += (s, ev) => OpenForm(new Payroll.frmMasterFile(), "Payroll Master List");
            btnPayPositions.Click += (s, ev) => OpenForm(new Payroll.frmPosition(), "Payroll Positions");
            btnPayDeductions.Click += (s, ev) => OpenForm(new Payroll.frmDeduction(), "Payroll Deductions");
            //btnPayTax.Click += (s, ev) => OpenForm(new Payroll.frmTaxTable(), "Payroll Tax Table");


            btnPaySalarySchedule.Click += (s, ev) => OpenForm(new Payroll.frmSalarySchedule(), "Payroll Salary Schedule");


            btnSms.Click += (s, e) =>
            {
                using (var f = new SMS.frmSMS())
                {
                    f.ShowDialog();
                }
            };


            //Accounts
            btnUserAccounts.Click += BtnUserAccounts_Click;

            btnChangePassword.Click += (s, e) =>
            {
                if (!InputControls.UserCanAccess(this, "ChangePassword")) return;

                using (var f = new frmChangePassword())
                {
                    f.ShowDialog();
                }
            };


            #endregion

            btnContextMdiTabs.PopupOpen += (s, e) => CreateContextTabMenu();



            // SETTINGS TAB
            ItemPanelSecurity.Visible = App.CurrentUser.User.RoleClass.Can("SysAdmin");


            // Handle User ROLE
            var canViewPayroll = App.CurrentUser.User.RoleClass.Can("ViewPayrollMenu");

            RibbonPayroll.Enabled = canViewPayroll;
            RibbonPayroll.Visible = canViewPayroll;



            // Handle Contacts
            var canViewContacts = App.CurrentUser.User.RoleClass.Can("ViewContactsMenu");

            RibbonContacts.Visible = canViewContacts;
            btnContacts.Enabled = canViewContacts;

            var canAddContacts = App.CurrentUser.User.RoleClass.Can("AddContacts");
            btnCreateContacts.Enabled = canAddContacts;


            // Handle Employee
            var canViewEmployee = App.CurrentUser.User.RoleClass.Can("ViewEmployee");
            RibbonEmployee.Visible = canViewEmployee;
            btnEmployee.Enabled = canViewEmployee;


        }

        private void BtnUserAccounts_Click(object sender, EventArgs e)
        {
            if (!InputControls.UserCanAccess(this, "SysAdmin")) return;

            OpenForm(new frmAccounts(), "User Account Management");

        }

        private void cmdSave_Executed(object sender, EventArgs e)
        {
            try
            {
                var active = ActiveMdiChild;
                if (active is ISave)
                {
                    ((ISave)active).FileSave();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
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
            try
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
                frm.WindowState = FormWindowState.Maximized;
                frm.Update();


                App.LogAction("Main", "Opened " + title);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
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
            try
            {
                var frm = this.ActiveMdiChild;
                frm.MdiParent = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }




        private void btnContactsCreate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var newItem = new Person();

                using (var frm = new frmContacts_Add())
                {
                    frm.ItemData = newItem;
                    frm.Owner = this;

                    if (frm.ShowDialog() != DialogResult.OK) return;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void btnContactsOpen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }




        private void btnAuditTrail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (var f = new frmAuditTrail())
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageDialog.ShowError(ex, this);
            }
        }



        private void btnGenerated_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            var period = new PayrollPeriod();
            using (var f = new Payroll.frmGenerated_Open())
            {
                f.ShowDialog();
                period = f.ItemData;
            }


            if (period == null) return;

            var frm = new Payroll.frmPayroll
            {
                ItemData = period,
                Header = $" PAYROLL - {period.DateCovered:MMMM dd, yyyy} [{period.Remarks}]"
            };

            OpenForm(frm, "Payroll " + period.DateCovered.ToString("dd MMM yyyy"));
        }

        private void btnRolePrivileges_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (!InputControls.UserCanAccess(this, "SysAdmin")) return;


                using (var frm = new Accounts.frmRolePrivileges())
                {
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            OpenForm(new frmContacts(), "Contacts Management");
        }

        private void btnBiometricUser_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!InputControls.UserCanAccess(this, "ViewBiometricUser")) return;

            OpenForm(new frmBiometricUser(), "Biometric User Management");

        }




        #region Employee Module
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (var frm = new frmEmployee_Add())
                {
                    frm.ItemData = new Dll.Employee.Employee();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }

        }

        private void btnOpenEmployee_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var empId = 0;
                using (var frm = new frmEmployee_Open())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    empId = frm.EmployeeId;
                }


                var employee = (new EmployeeDataReader()).GetItemOf(empId);



                using (var frm = new frmEmployee_Add())
                {
                    frm.ItemData = employee;
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenForm(new frmEmployee(), "Employees");
        }


        #endregion

        private void lblVersion_DoubleClick(object sender, EventArgs e)
        {
            if (_buttonPress)
            {
                _buttonPress = false;
                MessageBoxEx.Show(this, InputControls.RenderDisplay(), "Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            _buttonPress = e.Control && e.Alt && e.Shift;
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            _buttonPress = false;
        }
    }
}
