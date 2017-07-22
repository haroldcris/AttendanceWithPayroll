using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Winform
{
    public partial class MDIClientForm : Form, ISave, IMDIForm //DevComponents.DotNetBar.OfficeForm, ISave, IMDIForm
    {
        string _title;
        public string Title { get { return _title; } set { _title = value; this.Text = value; } }

        public string Header { get { return lblHeader.Text; } set { lblHeader.Text = value; } }

        Color _headerColor;
        public Color HeaderColor { get { return _headerColor; } set { PanelHead.BackColor = value; _headerColor = value; } }

        public DirtyChecker DirtyStatus { get; private set; }
        public MDIClientForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public virtual bool FileSave() { return false; }

        private void Form_Load(object sender, EventArgs e)
        {
            DirtyStatus = new DirtyChecker(this);
            this.WindowState = FormWindowState.Maximized;
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


        private  void Form_Closing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                //case CloseReason.MdiFormClosing:
                case CloseReason.UserClosing:

                    if (!DirtyStatus.IsDirty) return;
                    var result = My.Message.AskToSave();

                    if (result == eTaskDialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (result == eTaskDialogResult.Yes)
                        if (!FileSave()) e.Cancel = true;
                    break;
            }
        }


        protected void DoRefresh(Action action)
        {
            if (DirtyStatus.IsDirty)
            {
                if (My.Message.AskToRefresh() == eTaskDialogResult.No)
                    return;
            }

            action();

            DirtyStatus.Clear();
        }


        protected bool DoSave(Action action)
        {
            try
            {
                if (!DirtyStatus.IsDirty) return true;
                action();
                DirtyStatus.Clear();
                return true;
            }
            catch (DuplicateNameException ex)
            {
                My.Message.Show("Duplicate Record Found!", "Can not save record with duplicate item.\n\n" + ex.GetBaseException().Message, eTaskDialogIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                My.Message.ShowError(ex, this);
                return false;
            }
        }
    }
}