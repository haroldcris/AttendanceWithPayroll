using DevComponents.DotNetBar;

namespace Winform.Employee
{
    public partial class frmEmployee_Add : FormWithRecordInfo
    {
        public frmEmployee_Add()
        {
            InitializeComponent();
            //this.ConvertEnterToTab();
        }

        private void btnAddContact_Click(object sender, System.EventArgs e)
        {
            var item = new ListBoxItem();
            item.Image = imageList1.Images["phone"];
            item.Text = txtContact.Text;
            lstContacts.Items.Add(item);

            txtContact.Text = "";
        }
    }
}
