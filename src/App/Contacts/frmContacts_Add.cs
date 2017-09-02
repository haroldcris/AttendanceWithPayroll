using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
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
    public partial class frmContacts_Add : FormWithRecordInfo, ISave
    {
        public Person ItemData { get; set; }

        public DirtyFormHandler DirtyStatus { get; }


        public frmContacts_Add()
        {
            InitializeComponent();

            #region Initialize DirtyHandler

            DirtyStatus = new DirtyFormHandler(this);

            this.AskToSaveOnDirtyClosing();
            this.ConvertEnterToTab();
            Load += (s, e) =>
            {
                ShowData();
                DirtyStatus.Clear();
            };

            #endregion


            InputControls.LoadToComboBox(cboCountry, InputControls.Address.GetCountryList().OrderBy(_ => _));
            cboCountry.SelectedIndexChanged += CboCountry_SelectedIndexChanged;

            InputControls.Address.LoadProvinceListTo(cboProvince);
            cboProvince.SelectedIndexChanged += cboProvince_SelectedIndexChanged;



            RecordInfoPanel.Groups[0].ItemAlignment = eItemAlignment.Far;

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

        public bool FileSave()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!DataIsValid()) return false;

                ItemData.Name.Lastname = txtLastname.Text.Trim();
                ItemData.Name.Firstname = txtFirstname.Text.Trim();
                ItemData.Name.Middlename = txtMiddlename.Text.Trim();
                ItemData.Name.MiddleInitial = txtMi.Text.Trim();
                ItemData.Name.NameExtension = cboNameExtension.Text;


                ItemData.Name.MaidenMiddlename = txtMaidenMiddlename.Enabled ? txtMaidenMiddlename.Text : "";

                ItemData.Gender = cboGender.Text.ToLower() == "male" ? GenderType.Male : GenderType.Female;
                ItemData.BirthDate = dtBirthdate.Value;

                ItemData.BirthProvince = cboProvince.Text;
                ItemData.BirthTown = cboTown.Text;
                ItemData.BirthCountry = cboCountry.Text;

                ItemData.CameraCounter = txtImageFile.Text;



                //Write Mobile Numbers;
                if (lstContacts.Items.Any())
                {
                    foreach (ListBoxItem listItem in lstContacts.Items)
                    {
                        var m = (MobileNumber)listItem.Tag;

                        if (!listItem.Visible)
                        {
                            m.RowStatus = RecordStatus.DeletedRecord;
                        }
                        else
                        {
                            if (m.Id == 0) ItemData.MobileNumbers.Add(m);
                        }
                    }



                }


                var dataWriter = new PersonDataWriter(App.CurrentUser.User.Username, ItemData);

                var ret = dataWriter.SaveChanges();


                for (var c = lstContacts.Items.Count - 1; c >= 0; c--)
                {
                    if (!((ListBoxItem)lstContacts.Items[c]).Visible)
                        lstContacts.Items.Remove(lstContacts.Items[c]);
                }


                App.LogAction("Contacts", "Updated Contacts");

                DialogResult = DialogResult.OK;
                DirtyStatus.Clear();
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
                return false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FileSave();
        }



        private bool DataIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                MessageDialog.ShowValidationError(txtLastname, "Lastname must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                MessageDialog.ShowValidationError(txtFirstname, "Firstname must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboGender.Text))
            {
                MessageDialog.ShowValidationError(cboGender, "Gender must NOT be blank.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(cboCountry.Text))
            {
                MessageDialog.ShowValidationError(cboCountry, "Country must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboProvince.Text))
            {
                MessageDialog.ShowValidationError(cboProvince, "Province must NOT be blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboTown.Text))
            {
                MessageDialog.ShowValidationError(cboTown, "Town must NOT be blank.");
                return false;
            }


            var reader = new PersonDataReader();
            var findItem = reader.GetItem(txtLastname.Text, txtFirstname.Text, txtMiddlename.Text);

            if (findItem != null && findItem.Id != ItemData.Id)
            {
                var response = MessageDialog.Ask("Create Duplicate Record?",
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

            txtMaidenMiddlename.Text = ItemData.Name.MaidenMiddlename;

            cboGender.Text = ItemData.Gender == GenderType.Male ? "Male" : "Female";
            dtBirthdate.Value = ItemData.BirthDate;

            cboCountry.Text = ItemData.BirthCountry;
            cboProvince.Text = ItemData.BirthProvince;
            cboTown.Text = ItemData.BirthTown;


            txtImageFile.Text = ItemData.CameraCounter;


            //Mobile Numbers
            ItemData.MobileNumbers.LoadItemsFromDb();
            Show_MobileNumbers();

            //Show Picture
            InputControls.LoadImage(picImage, ItemData.CameraCounter);

            ShowFileInfo(ItemData);
        }


        private void Show_MobileNumbers()
        {

            foreach (var m in ItemData.MobileNumbers.Items)
            {
                var listItem = new ListBoxItem
                {
                    Image = imageList1.Images["phone"],
                    Text = m.PhoneNumber,
                    Tag = m
                };

                lstContacts.Items.Add(listItem);
            }
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
            txtMaidenMiddlename.Enabled = enabled;
        }



        private async Task UploadAndDisplayImage(string fullFilename)
        {

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


            if (!uploadResult)
                MessageDialog.ShowValidationError(this, errorMessage);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddContacts_Click(object sender, EventArgs e)
        {
            if (txtContact.Text.Length != 11)
            {
                MessageDialog.ShowValidationError(txtContact, "Invalid Mobile Number");
                txtContact.Focus();
                txtContact.SelectAll();
                return;
            }


            var items = lstContacts.Items.Select(_ => ((ListBoxItem)_).Text);
            if (items.Contains(txtContact.Text))
            {
                MessageDialog.ShowValidationError(txtContact, "Mobile Already Exists");
                return;
            }


            var item = new MobileNumber
            {
                PhoneNumber = txtContact.Text,
                PersonId = ItemData.Id
            };


            var listItem = new ListBoxItem
            {
                Image = imageList1.Images["phone"],
                Text = item.PhoneNumber,
                Tag = item
            };


            lstContacts.Items.Add(listItem);
            //Do not add yet until save
            //ItemData.MobileNumbers.Add(item);

            txtContact.Text = "";
            txtContact.Focus();
        }



        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtContact.PerformButtonCustomClick();
            }
        }

        private void btnDeleteNumber_Click(object sender, EventArgs e)
        {
            var item = (ListBoxItem)lstContacts.SelectedItem;
            if (item == null) return;

            var mobile = (MobileNumber)item.Tag;

            if (mobile.Id == 0)
            {
                lstContacts.Items.Remove(item);
                return;
            }

            //item.RowStatus = RecordStatus.DeletedRecord;
            item.Visible = false;
            lstContacts.RefreshItems();

            DirtyStatus.SetDirty();
        }
    }
}
