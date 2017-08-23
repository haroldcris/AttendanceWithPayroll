using Library.Tools;

namespace Winform
{
    public partial class FormWithHeader : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormWithHeader()
        {
            InitializeComponent();
        }

        protected void ConvertEnterKeyToTab()
        {
            KeyPress += (s, e) => { InputControls.ConvertEnterToTab(this, e); };
        }
    }
}
