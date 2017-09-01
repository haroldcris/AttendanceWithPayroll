using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Winform
{
    public partial class MdiClientForm : Office2007Form, ISave, IMdiForm //DevComponents.DotNetBar.OfficeForm, ISave, IMdiForm
    {
        string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                Text = value;
            }
        }

        public string Header
        {
            get
            {
                return lblHeader.Text;
            }
            set
            {
                lblHeader.Text = value;
            }
        }

        public Color HeaderColor
        {
            get
            {
                return PanelHead.BackColor;
            }
            set
            {
                PanelHead.BackColor = value;
            }
        }

        public Color HeaderTextColor
        {
            get
            {
                return lblHeader.ForeColor;
            }
            set
            {
                lblHeader.ForeColor = value;
            }
        }

        public DirtyFormHandler DirtyStatus { get; private set; }

        public virtual bool FileSave() { return false; }




        public MdiClientForm()
        {
            InitializeComponent();

            //StartPosition = FormStartPosition.CenterParent;
            DirtyStatus = new DirtyFormHandler(this);


            this.AskToSaveOnDirtyClosing();

            WindowState = FormWindowState.Maximized;

        }



        protected virtual void Form_Load(object sender, EventArgs e)
        {
            DirtyStatus = new DirtyFormHandler(this);
            DirtyStatus.DirtySet += (s, ex) => UpdateMainMdiForm();
            DirtyStatus.DirtyCleared += (s, ex) => UpdateMainMdiForm();
        }


        private void Form_Activated(object sender, EventArgs e)
        {
            UpdateMainMdiForm();

            Cursor = Cursors.Default;
        }

        private void UpdateMainMdiForm()
        {
            var mainMdiForm = (frmMain)MdiParent;

            if (mainMdiForm == null) return;

            var statusBar = mainMdiForm.StatusBar;

            if (DirtyStatus.IsDirty)
            {
                //Set Dirty
                statusBar.BackColor = Color.Red;
                mainMdiForm.lblStatus.Text = @"Pending changes detected. Save is required";
            }
            else
            {
                //Clear Error
                statusBar.BackColor = new Color();
                mainMdiForm.lblStatus.Text = @"Ready";
            }

            statusBar.Refresh();

            //Enable Save Buttons
            mainMdiForm.cmdSave.Enabled = DirtyStatus.IsDirty;
        }




        protected void DoRefresh(Action action)
        {
            if (DirtyStatus.IsDirty)
            {
                if (MessageDialog.AskToRefresh() == MessageDialogResult.No)
                    return;
            }

            action();

            DirtyStatus.Clear();
        }


        protected bool DoSave(Action action)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DirtyStatus.IsDirty) return true;
                action();
                DirtyStatus.Clear();
                return true;
            }
            catch (DuplicateNameException ex)
            {
                MessageDialog.Show("Duplicate Record Found!", "Can not save record with duplicate item.\n\n" + ex.GetBaseException().Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
                return false;
            }
        }
    }
}