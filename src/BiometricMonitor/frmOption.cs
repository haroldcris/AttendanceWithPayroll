using DevComponents.DotNetBar;
using System;
using System.Windows.Forms;

namespace Winform
{
    public partial class frmOption : OfficeForm
    {

        public int OptionSelected { get; set; }

        public frmOption()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OptionSelected = 1;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            OptionSelected = 2;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
