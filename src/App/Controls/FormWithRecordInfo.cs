using AiTech.Entities;
using System.Windows.Forms;

namespace Winform
{
    public partial class FormWithRecordInfo : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormWithRecordInfo()
        {
            InitializeComponent();

            this.KeyPress += (s, e) => { Helper.HandleEnterKey(this, e); };
        }

        protected void ShowFileInfo(IRecordInfo info)
        {
            var template = @"<b>{By}</b><br/>
                            {Date}<br/>{Time}";

            var str = "";

            if (info.Created.Year <= 1920) return;

            str = template.Replace("{By}", info.CreatedBy);
            str = str.Replace("{Date}", info.Created.ToString("dd-MMM-yyyy"));
            str = str.Replace("{Time}", info.Created.ToString("hh:mm:ss tt"));

            lblCreated.Text = str;

            str = template.Replace("{By}", info.ModifiedBy);
            str = str.Replace("{Date}", info.Modified.ToString("dd-MMM-yyyy"));
            str = str.Replace("{Time}", info.Modified.ToString("hh:mm:ss tt"));

            lblModified.Text = str;

        }

    }
}
