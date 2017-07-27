using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll.Payroll;

namespace Winform.Payroll
{
    public partial class frmPosition_Add : FormWithHeader
    {
        public Position ItemData { get; set; }
        
        private frmPosition CallerForm;
             
        public frmPosition_Add(frmPosition caller)
        {
            InitializeComponent();
            CallerForm = caller;

            this.Load += (s, e) => { ShowData(); };
            this.ConvertEnterKeyToTab();

            this.CancelButton = btnCancel;
            btnCancel.Click += (s, e) => { Dispose(); };
            btnOk.Click += (s, e) => { Save(); };
        }

        private void ShowData()
        {
            if (ItemData == null) return;
            txtCode.Text = ItemData.Code;
            txtDescription.Text = ItemData.Description;
        }


        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                My.Message.ShowValidationError(txtCode, "Code must not be blank");
                return false; 
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                My.Message.ShowValidationError(txtDescription, "Description must not be blank");
                return false;
            }

            if (CallerForm.ContainsData(txtCode.Text , ItemData.RowId))
            {
                My.Message.ShowValidationError(txtCode, "Duplicate Record!");
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (!DataIsValid()) return;

            ItemData.Code = txtCode.Text.Trim();
            ItemData.Description = txtDescription.Text.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
