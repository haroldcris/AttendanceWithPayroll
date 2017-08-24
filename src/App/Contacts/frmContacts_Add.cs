using Dll.Contacts;
using Dll.Location;
using Library.Tools;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.Contacts
{
    public partial class frmContacts_Add : FormWithRecordInfo
    {
        public Person ItemData { get; set; }

        public frmContacts_Add()
        {
            InitializeComponent();

            Load += (s, e) => ShowData();

            InputControls.Address.LoadProvinceListTo(cboProvince);
            cboProvince.SelectedIndexChanged += cboProvince_SelectedIndexChanged;


            InputControls.LoadToComboBox(cboCountry, InputControls.GetCountryList().OrderBy(_ => _));
            cboCountry.SelectedIndexChanged += CboCountry_SelectedIndexChanged;
        }

        private void CboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCountry.SelectedIndex < 0) return;

            var comboStyle = cboCountry.Text.Equals("philippines", StringComparison.CurrentCultureIgnoreCase) ? ComboBoxStyle.DropDownList : ComboBoxStyle.DropDown;

            cboProvince.SelectedIndex = -1;
            cboProvince.DropDownStyle = comboStyle;

            cboTown.SelectedIndex = -1;
            cboTown.DropDownStyle = comboStyle;
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvince.SelectedIndex < 0) return;

            var id = ((Province)cboProvince.SelectedItem).Id;
            InputControls.Address.LoadTownListTo(cboTown, id);
        }


        #region Main Script

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataIsValid()) return;

                ItemData.Name.Lastname = txtLastname.Text.Trim();
                ItemData.Name.Firstname = txtFirstname.Text.Trim();
                ItemData.Name.Middlename = txtMiddlename.Text.Trim();
                ItemData.Name.MiddleInitial = txtMi.Text.Trim();
                ItemData.Name.NameExtension = cboNameExtension.Text;


                ItemData.Name.SpouseLastname = txtSpouseLastname.Enabled ? txtSpouseLastname.Text : "";

                ItemData.Gender = cboGender.Text.ToLower() == "male" ? GenderType.Male : GenderType.Female;
                ItemData.BirthDate = dtBirthdate.Value;

                ItemData.BirthProvince = cboProvince.Text;
                ItemData.BirthTown = cboTown.Text;
                ItemData.BirthCountry = cboCountry.Text;

                ItemData.CameraCounter = txtImageFile.Text;


                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                App.Message.ShowError(ex, this);
            }

        }



        private bool DataIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                App.Message.ShowValidationError(txtLastname, "Lastname must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                App.Message.ShowValidationError(txtFirstname, "Firstname must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboGender.Text))
            {
                App.Message.ShowValidationError(cboGender, "Gender must NOT be blank.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(cboCountry.Text))
            {
                App.Message.ShowValidationError(cboCountry, "Country must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboProvince.Text))
            {
                App.Message.ShowValidationError(cboProvince, "Province must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboTown.Text))
            {
                App.Message.ShowValidationError(cboTown, "Town must NOT be blank.");
                return false;
            }


            var reader = new PersonDataReader();
            var findItem = reader.GetItem(txtLastname.Text, txtFirstname.Text, txtMiddlename.Text);

            if (findItem != null && findItem.Id != ItemData.Id)
            {
                var response = App.Message.Ask("Create Duplicate Record?",
                                string.Format(@"System detected a similar contact with the following details:<br/><br/>
                                                Fullname : <b>{0}</b><br/>
                                                BirthDate: <b>{1}</b>", findItem.Name.Fullname, findItem.BirthDate.ToString("yyyy MMMM dd")));

                if (response == MessageDialogResult.No) return false;
            }

            return true;
        }

        private void ShowData()
        {
            if (ItemData.Id != 0) txtId.Text = ItemData.Id.ToString("0000");

            txtLastname.Text = ItemData.Name.Lastname;
            txtFirstname.Text = ItemData.Name.Firstname;
            txtMiddlename.Text = ItemData.Name.Middlename;
            txtMi.Text = ItemData.Name.MiddleInitial;
            cboNameExtension.Text = ItemData.Name.NameExtension;

            txtSpouseLastname.Text = ItemData.Name.SpouseLastname;

            cboGender.Text = ItemData.Gender == GenderType.Male ? "Male" : "Female";
            dtBirthdate.Value = ItemData.BirthDate;

            cboCountry.Text = ItemData.BirthCountry;
            cboProvince.Text = ItemData.BirthProvince;
            cboTown.Text = ItemData.BirthTown;


            txtImageFile.Text = ItemData.CameraCounter;

            InputControls.LoadImage(picImage, ItemData.CameraCounter);

            ShowFileInfo(ItemData);
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        #endregion

        private void txtMiddlename_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMiddlename.Text.Length == 0) return;
            txtMi.Text = txtMiddlename.Text.Substring(0, 1).ToUpper();
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            var enabled = cboGender.Text.ToLower() == "female";

            lblSpouse.Enabled = enabled;
            txtSpouseLastname.Enabled = enabled;
        }




        private async Task UploadAndDisplayImage(string fullFilename)
        {

            ImageProgressBar.Visible = true;

            string errorMessage = null;

            var uploadResult = await Task.Run(() =>
            {

                var username = AiTech.LiteOrm.Database.Connection.MyDbCredential.Username;
                var password = AiTech.LiteOrm.Database.Connection.MyDbCredential.Password;

                var credential = new NetworkCredential() { UserName = username, Password = password };


                var ftp = new AiTech.Tools.FtpClass(AiTech.LiteOrm.Database.Connection.MyDbCredential.ServerName,
                    credential);

                var result = ftp.UploadFile(fullFilename, "/amwp/pictures/");

                errorMessage = "";
                if (!result) errorMessage = ftp.LastError;

                return result;
            });


            ImageProgressBar.Visible = false;

            if (!uploadResult)
                App.Message.ShowValidationError(this, errorMessage);
            else
                InputControls.LoadImage(picImage, txtImageFile.Text);

        }


        private async void txtImageFile_ButtonCustomClick(object sender, EventArgs e)
        {
            FileInfo file;
            using (var frm = new Devices.frmCaptureDevice())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;

                file = frm.File;
            }

            txtImageFile.Text = Path.GetFileNameWithoutExtension(file.FullName);

            await UploadAndDisplayImage(file.FullName);
        }


        private async void txtImageFile_ButtonCustom2Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = @"Picture Files|*.jpg",
                Multiselect = false,
                CheckFileExists = true,
                Title = @"Select an image File"
            };

            if (openDialog.ShowDialog() != DialogResult.OK) return;

            var targetFolder = Path.Combine(Path.GetTempPath(), "amwp");
            var targetName = DateTime.Now.ToString("yymmddhhmmss");
            var targetFilename = Path.Combine(targetFolder, targetName + ".jpg");

            Directory.CreateDirectory(targetFolder);

            File.Copy(openDialog.FileName, targetFilename);

            txtImageFile.Text = targetName;
            await UploadAndDisplayImage(targetFilename);

            File.Delete(targetFilename);
        }
    }
}
