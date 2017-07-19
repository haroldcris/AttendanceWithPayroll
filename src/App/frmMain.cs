using System;
using System.Linq;
using System.Net.Configuration;
using System.Windows.Forms;
using System.Diagnostics;
using AiTech.Database;

namespace Winform
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

            MainRibbonControl.MdiSystemItemVisible = false;
            MainRibbonControl.FadeEffect = true;

            lblServer.Text = @"Connected to: " + Connection.MyDbCredential.DatabasePath() ;
            lblVersion.Text = "Version : " + My.App.CurrentVersion();

            mdiTab.Tabs.Clear();
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

            
            btnProfile.Text = string.Format("Welcome {0} [{1}]", My.App.CurrentUser.User.Username.ToUpper(), "--");

            ribbonHomeUserTab.Visible = true;

            //if (App.CurrentUser.SecurityLevel.ToLower() == "admin") {
            //    ribbonTabHomeAdmin.Select();
            //    ribbonTabHomeAdmin.Visible = true;
            //}

            My.App.MainForm = this;

        }

     
        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Any())
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
            ((MDIClientForm)frm).Title = formTitle;
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
            Application.Restart();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.TaskManagerClosing) return;

            if (this.MdiChildren.Count() == 0) return;

            foreach (var frm in MdiChildren)
            {
                this.ActivateMdiChild(frm);
                frm.Close();

                if (!frm.IsDisposed)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        #endregion










        private void btnOpenClass_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;

            //var fOpen = new frmOpenClass();
            //var response  = fOpen.ShowDialog();
            //if (response != DialogResult.OK) return;

            //var selected = fOpen.SelectedHandledSubject;
            //fOpen.Dispose();

            //var section = selected.Section;
            //section.LoadStudentsOfSubject(selected.SubjectId);

            //var fClassRecord = new FrmClassRecord()
            //{
            //    CurrentSection = section
            //};
            //OpenForm(fClassRecord);


        }


        private void btnBatch_Click(object sender, EventArgs e)
        {
            OpenForm( new frmBatch(),"Batch Management");
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            OpenForm(new frmCourse(), "Course Management");
        }

        private void btnCourseOffered_Click(object sender, EventArgs e)
        {
            //OpenForm(new frmOfferedCourse());
        }

      
        private void btnSections_Click(object sender, EventArgs e)
        {
            //OpenForm(new frmSection());
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            //OpenForm(new frmSubject());
        }

        private void btnUserAccounts_Click(object sender, EventArgs e)
        {
            //OpenForm(new frmUserAccounts());

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //var frm = new frmChangePassword();
            //frm.ShowDialog();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            //var frm = new frmStudent();
            //OpenForm(frm);

        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var item in this.MdiChildren)
            {
                item.Close();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //var fSettings = new frmSettings();
            //fSettings.ShowDialog();
        }
    }
}
