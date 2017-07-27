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
    public partial class frmTaxTable_Add : FormWithHeader
    {
        public Tax ItemData { get; set; }
        
        private frmTaxTable CallerForm;
             
        public frmTaxTable_Add(frmTaxTable caller)
        {
            InitializeComponent();
            CallerForm = caller;

            this.Load += (s, e) => { ShowData(); };

            this.CancelButton = btnCancel;
            btnCancel.Click += (s, e) => { Dispose(); };
            btnOk.Click += (s, e) => { Save(); };


            for (var c = 0; c <= 4; c++)
                cboDependent.Items.Add (c);

        }

        private void ShowData()
        {
            if (ItemData == null) return;

            txtTaxId.Text = ItemData.TaxID.ToString();
            txtShort.Text = ItemData.ShortDesc;

            txtDescription.Text = ItemData.Description;

            cboDependent.Text = ItemData.Dependent.ToString() ;
            txtExemption.Value = ItemData.Exemption;
        }


        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtTaxId.Text))
            {
                My.Message.ShowValidationError(txtTaxId, "Code must not be blank");
                return false; 
            }

            if (string.IsNullOrEmpty(txtShort.Text))
            {
                My.Message.ShowValidationError(txtShort, "Short Description must not be blank");
                return false;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                My.Message.ShowValidationError(txtDescription, "Description must not be blank");
                return false;
            }

            if (CallerForm.ContainsData( txtTaxId.Text , ItemData.RowId))
            {
                My.Message.ShowValidationError(txtTaxId, "Duplicate Record!");
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (!DataIsValid()) return;

            ItemData.TaxID = int.Parse (txtTaxId.Text.Trim());
            ItemData.ShortDesc = txtShort.Text.Trim();
            ItemData.Description = txtDescription.Text.Trim();

            ItemData.Dependent = int.Parse (cboDependent.Text.Trim());
            ItemData.Exemption = txtExemption.Value;

            DialogResult = DialogResult.OK;
        }

       
    }
}
