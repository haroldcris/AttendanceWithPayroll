using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AiTech.Biometric;
using DevComponents.DotNetBar;
using System.IO.Ports;
using Dll.SMS;

namespace BiometricMonitor
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        private Device MyDevice;

        private SerialPort Port = null;
        private SmsSender MySms = new SmsSender();

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
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnConnect.Text == "Connect")
                {
                    if (string.IsNullOrEmpty(txtIp.Text))
                    {
                        ToastNotification.Show(this, "Invalid IP Address", 1000, eToastPosition.TopCenter);
                        txtIp.Focus();
                        return;
                    }

                    txtStatus.Text = "Connecting to Device " + txtIp.Text + "\n";

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


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                btnConnect.Enabled = true;
            }
        }



        private void MyDevice_Disconnected(object sender, EventArgs e)
        {
            txtStatus.AppendText("Disconnected From Device\n");
            btnConnect.Text = "Connect";
        }

        private void MyDevice_Connected(object sender, EventArgs e)
        {

            Invoke((MethodInvoker)delegate
            {
                btnConnect.Text = "Disconnect";
                txtStatus.AppendText("Connected To Device\n");


                
                //txtStatus.AppendText("Date" + MyDevice.Settings.GetCurrentTime().ToString());
            });

        }

        private void MyDevice_TransactionEvent(object sender, TransactionEventArgs e)
        {
            txtStatus.AppendText (String.Format("-> Device {0} : {1} - {2} :state {3} -> {4}\n",
                                        MyDevice.IpAddress,
                                        e.UserData.BiometricId,
                                        e.TransactionDate.ToString(),
                                        e.State,
                                        e.UserData.Name));


            txtStatus.AppendText("Writing To dabase...");

            var item = new Transaction()
            {
                IPAddress = MyDevice.IpAddress,
                BiometricId = e.UserData.BiometricId,
                EntryType = "Device",
                InOut = e.State == 0 ? "In" : "Out",
                Station = MyDevice.IpAddress,
                TimeLog = e.TransactionDate
            };


            SaveChanges(item);
            txtStatus.AppendText("Done.\n");

            if(Port == null)
            {
                txtStatus.AppendText("NO Connected GSM Modem !!!\n");
                return;
            }

            txtStatus.AppendText("Sending SMS...\n");
            System.Threading.Thread.Sleep(1000);
            SendSMS(item);

        }




        private void SaveChanges(Transaction item)
        {
            var writer = new TransactionDataWriter(item);
            writer.SaveChanges();
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
                btnSMSConnect.Text = " Disconnect ";

            }
            else
            {
                DisconnectToGSM();
                btnSMSConnect.Text = " Connect ";

                Port = null;
            }

        }


        private void SendSMS(Transaction transaction)
        {
            try
            {
                
                Cursor.Current = Cursors.WaitCursor;

                var cellNum = TransactionDataReader.GetCellnumOfBiometricId(transaction.BiometricId);
                    cellNum = cellNum.Replace(" ", "").Replace("-", "");

                var message = "%date%\n\n";
                message += "Good day! This confirms your biometric entry on the above mentioned time.\n";
                message += "This is a system generated message. Do not reply";

                message = message.Replace("%date%", transaction.TimeLog.ToString("dd MMM yyyy, hh:mm:ss tt"));

                if (MySms.SendSms(Port, cellNum, message))
                    txtStatus.AppendText ("Message has sent successfully\n");
                else
                    txtStatus.AppendText("Failed to send message");

                //ToastNotification.DefaultToastGlowColor = eToastGlowColor.Green;
                //ToastNotification.ToastBackColor = Color.Green;
                //ToastNotification.Show(this, result, eToastPosition.MiddleCenter);
                //Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                txtStatus.AppendText(ex.Message + "\n");
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

        private void btnConnect_Click_1(object sender, EventArgs e)
        {

        }
    }
}
