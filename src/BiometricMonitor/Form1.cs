using AiTech.Tools.Winform;
using Biometric;
using DevComponents.DotNetBar;
using Dll.Biometric;
using Dll.Employee;
using Dll.SMS;
using System;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiometricMonitor
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        private Device MyDevice;

        private SerialPort Port = null;
        private SmsSender MySms = new SmsSender();

        private string _redirectedSmsNumber = "";

        public Form1()
        {
            InitializeComponent();

            #region Display all available COM Ports
            string[] ports = SerialPort.GetPortNames();

            // Add all port names to the combo box:
            foreach (string port in ports)
            {
                cboPort.Items.Add(port);
            }
            #endregion

            MySms = new SmsSender();


            var isRedirect = false;
            isRedirect = Dll.Settings.Get("RedirectSMS", "0") == "1" ? true : false;

            if (isRedirect)
            {
                _redirectedSmsNumber = Dll.Settings.Get("RedirectSmsNumber", "");
            }
        }



        private async void btnConnect_Click(object sender, EventArgs e)
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

                    txtStatus.Text = @"Connecting to Device " + txtIp.Text + @"\n";

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
            txtStatus.AppendText("Disconnected From Device\n");
            btnConnect.Text = @"Connect";
        }

        private void MyDevice_Connected(object sender, EventArgs e)
        {

            Invoke((MethodInvoker)delegate
            {
                btnConnect.Text = @"Disconnect";
                txtStatus.AppendText(@"Connected To Device\n");
                //txtStatus.AppendText("Date" + MyDevice.Settings.GetCurrentTime().ToString());

                txtStatus.AppendText(Environment.NewLine + MyDevice.GetPlatform());
                txtStatus.AppendText(Environment.NewLine + MyDevice.GetSerialNumber());
            });

        }

        private void MyDevice_TransactionEvent(object sender, TransactionEventArgs e)
        {
            txtStatus.AppendText(string.Format("-> Device {0} : {1} - {2} :state {3} -> {4}\n",
                                        MyDevice.IpAddress,
                                        e.UserData.BiometricId,
                                        e.TransactionDate.ToString(),
                                        e.State,
                                        e.UserData.Name));


            txtStatus.AppendText("Writing To dabase...");

            //var item = new Transaction()
            //{
            //    IPAddress = MyDevice.IpAddress,
            //    BiometricId = e.UserData.BiometricId,
            //    EntryType = "Device",
            //    InOut = e.State == 0 ? "In" : "Out",
            //    Station = MyDevice.IpAddress,
            //    TimeLog = e.TransactionDate
            //};


            var item = new BiometricTransaction
            {
                BiometricId = e.UserData.BiometricId,
                TimeLog = e.TransactionDate,
                Station = MyDevice.IpAddress,
                IpAddress = MyDevice.IpAddress,
                InOut = e.State == 0 ? "In" : "Out",
                SmsDate = new DateTime(1920, 1, 1)
            };

            SaveChanges(item);

            txtStatus.AppendText("Done.\n");

            if (Port == null)
            {
                txtStatus.AppendText("NO Connected GSM Modem !!!\n");
                return;
            }


            txtStatus.AppendText("Sending SMS...\n");
            //System.Threading.Thread.Sleep(500);

            if (SendSMS(item))
            {
                item.StartTrackingChanges();
                var sendDate = DateTime.Now;
                item.SmsDate = DateTime.Now;

                SaveChanges(item);
            }

        }


        private void SaveChanges(BiometricTransaction item)
        {

            try
            {
                var reader = new EmployeeDataReader();
                var emp = reader.GetBasicProfileOf(10);


                var writer = new BiometricTransactionDataWriter("Device", item);
                writer.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }

        }




        private void btnSMSConnect_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (string.IsNullOrEmpty(cboPort.Text))
            {
                ToastNotification.Show(cboPort, "Select Port First");
                return;
            }

            if (Port == null)
            {
                ConnectToGSM();
                btnSMSConnect.Text = @" Disconnect ";

            }
            else
            {
                DisconnectToGSM();
                btnSMSConnect.Text = @" Connect ";

                Port = null;
            }

        }


        private bool SendSMS(BiometricTransaction transaction)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;


                var reader = new BiometricUserDataReader();

                var data = reader.GetBasicInfoForSmsOf(transaction.BiometricId);


                data.PhoneNumber = data.PhoneNumber.Replace(" ", "").Replace("-", "");
                //var cellNum = reader.GetPhoneNumberOf(transaction.BiometricId);
                //cellNum = cellNum.Replace(" ", "").Replace("-", "");

                var message = "%date%\n\n";
                message += "Name: %name%\n";
                message += "Biometric Id: %biometricid%\n";

                //message += "Good day! This confirms your biometric entry on the above mentioned time.\n";
                message += "This is a system generated message. Do not reply";


                message = message.Replace("%date%", transaction.TimeLog.ToString("dd MMM yyyy, hh:mm:ss tt"));
                message = message.Replace("%name%", data.PersonClass.Name.Fullname);



                var cellNum = data.PhoneNumber;
                if (_redirectedSmsNumber.Length > 2)
                {
                    cellNum = _redirectedSmsNumber;
                }

                txtStatus.AppendText(@"Sending SMS...to: " + cellNum);


                if (!MySms.SendSms(Port, cellNum, message))
                {
                    txtStatus.AppendText("Failed to send message");

                    // MySms.SendSms(Port, cellNum, "Good day!This confirms your biometric entry on the above mentioned time.\n");
                    return true;
                }

                // MySms.SendSms(Port, cellNum, "Good day!This confirms your biometric entry on the above mentioned time.\n");
                //Console.WriteLine(result);
                txtStatus.AppendText("Message has sent successfully\n");
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                txtStatus.AppendText(ex.Message + "\n");
                return false;
            }
        }

        private void ConnectToGSM()
        {
            try
            {
                Port = MySms.OpenPort(cboPort.Text);

                txtStatus.AppendText("Connected to GSM Modem\n");
                //lblStatus.Text = "Ready";
                //lblConnected.Text = "Connected";

                //status.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisconnectToGSM()
        {
            try
            {

                if (Port == null) return;

                if (Port.IsOpen)
                    MySms.ClosePort(Port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            var message = "%date%\n\n";
            message += "Name: %name%";
            message += "Biometric Id: %biometricid%\n";

            message += "This is a system generated message. Do not reply";


            message = message.Replace("%date%", DateTime.Now.ToString("dd MMM yyyy, hh:mm:ss tt"));
            message = message.Replace("%name%", "Fullname here");

            MySms.SendSms(this.Port, "09277746758", message);
        }
    }
}
