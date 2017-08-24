using DevComponents.DotNetBar;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Winform
{
    public partial class MdiClientForm : Form, ISave, IMDIForm //DevComponents.DotNetBar.OfficeForm, ISave, IMDIForm
    {
        string _title;
        public string Title { get { return _title; } set { _title = value; Text = value; } }

        public string Header { get { return lblHeader.Text; } set { lblHeader.Text = value; } }

        public Color HeaderColor { get { return PanelHead.BackColor; } set { PanelHead.BackColor = value; } }

        public Color HeaderTextColor { get { return lblHeader.ForeColor; } set { lblHeader.ForeColor = value; } }

        public DirtyChecker DirtyStatus { get; private set; }
        public MdiClientForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public virtual bool FileSave() { return false; }

        private void Form_Load(object sender, EventArgs e)
        {
            DirtyStatus = new DirtyChecker(this);
            WindowState = FormWindowState.Maximized;
        }
        private void Form_Activated(object sender, EventArgs e)
        {
            DirtyStatus.UpdateMDIForm();
            Cursor = Cursors.Default;
        }

        private void Form_Leave(object sender, EventArgs e)
        {
            DirtyStatus.UpdateMDIForm(true);
        }


        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:


                //case CloseReason.MdiFormClosing:
                case CloseReason.UserClosing:

                    if (!DirtyStatus.IsDirty) return;
                    var result = App.Message.AskToSave();

                    if (result == MessageDialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (result == MessageDialogResult.Yes)
                        if (!FileSave()) e.Cancel = true;
                    break;
            }
        }


        protected void DoRefresh(Action action)
        {
            if (DirtyStatus.IsDirty)
            {
                if (App.Message.AskToRefresh() == MessageDialogResult.No)
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
                App.Message.Show("Duplicate Record Found!", "Can not save record with duplicate item.\n\n" + ex.GetBaseException().Message, eTaskDialogIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
                return false;
            }
        }
    }
}