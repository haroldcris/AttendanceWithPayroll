using Biometric;
using DevComponents.DotNetBar;
using Dll.Biometric;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class frmOutputWindow : Office2007Form
    {
        private Device MyDevice;

        public frmOutputWindow()
        {
            InitializeComponent();

            lblTime.Text = "";
            lblName.Text = "";
        }

        private async void btnConnect_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (btnConnect.Text == @"Connect")
                {
                    if (string.IsNullOrEmpty(txtIp.Text))
                    {
                        ToastNotification.Show(this, "Invalid IP Address", 1000, eToastPosition.TopCenter);
                        txtIp.Focus();
                        return;
                    }


                    lblStatus.Text = @"Connecting to Device " + txtIp.Text + @"\n";

                    btnConnect.Enabled = false;

                    MyDevice = new Device(txtIp.Text);
                    MyDevice.Connected += MyDevice_Connected;
                    MyDevice.Disconnected += MyDevice_Disconnected;
                    MyDevice.TransactionEvent += MyDevice_TransactionEvent;

                    await Task.Run(() =>
                    {
                        MyDevice.Connect();
                    });


                }
                else
                {
                    //Disconnect
                    MyDevice.Disconnect();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnConnect.Enabled = true;
            }
        }


        private void MyDevice_Disconnected(object sender, EventArgs e)
        {
            lblStatus.Text = "Disconnected From Device";
            btnConnect.Text = @"Connect";
        }

        private void MyDevice_Connected(object sender, EventArgs e)
        {

            Invoke((MethodInvoker)delegate
            {
                btnConnect.Text = @"Disconnect";
                lblStatus.Text = @"Connected To Device";
                //txtStatus.AppendText("Date" + MyDevice.Settings.GetCurrentTime().ToString());
            });

        }

        private void MyDevice_TransactionEvent(object sender, TransactionEventArgs e)
        {

            timer1.Enabled = false;

            var item = new BiometricUser();

            var reader = new BiometricUserDataReader();
            item = reader.GetBasicInfoForSmsOf(e.UserData.BiometricId);

            LoadImage((item.PersonClass.CameraCounter));



            lblTime.BackColor = e.State == 0 ? Color.SpringGreen : Color.Red;

            if (e.State == 0)
                lblTime.Text = string.Format(" LOG IN : \n{0}", e.TransactionDate.ToString("dddd dd MMM yyyy\n hh:mm:ss tt"));
            else
                lblTime.Text = string.Format(" LOG OUT: \n{0}", e.TransactionDate.ToString("dddd dd MMM yyyy\n hh:mm:ss tt"));



            lblName.Text = " Name:\n<h1>%name%</h1>".Replace("%name%", item.PersonClass.Name.Fullname);

            timer1.Enabled = true;
        }


        private void LoadImage(string filenameFromServer)
        {
            if (string.IsNullOrEmpty(filenameFromServer)) return;

            var path = string.Format("http://{0}/amwp/pictures/{1}.jpg", AiTech.LiteOrm.Database.Connection.MyDbCredential.ServerName, filenameFromServer);
            picImage.LoadAsync(path);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            picImage.Image = null;

            lblTime.BackColor = new Color();
            lblTime.Text = "";
            lblName.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var user = new DeviceUser()
            {
                BiometricId = 1042,
                Name = "name"
            };

            var args = new TransactionEventArgs()
            {
                UserData = user,
                State = 0,
                TransactionDate = DateTime.Now
            };


            MyDevice_TransactionEvent(this, args);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var user = new DeviceUser()
            {
                BiometricId = 1042,
                Name = "name"
            };

            var args = new TransactionEventArgs()
            {
                UserData = user,
                State = 1,
                TransactionDate = DateTime.Now
            };


            MyDevice_TransactionEvent(this, args);
        }


    }
}
