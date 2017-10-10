using DevComponents.DotNetBar;
using Dll.SMS;
using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Winform.SMS;

namespace Winform
{
    public partial class frmSmsMonitor : OfficeForm
    {
        private SerialPort Port = null;
        private SmsSender MySms = new SmsSender();

        public frmSmsMonitor()
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


        //private bool SendSMS(BiometricTransaction transaction)
        //{
        //    try
        //    {

        //        Cursor.Current = Cursors.WaitCursor;


        //        var reader = new BiometricUserDataReader();

        //        var data = reader.GetBasicInfoForSmsOf(transaction.BiometricId);


        //        data.PhoneNumber = data.PhoneNumber.Replace(" ", "").Replace("-", "");
        //        //var cellNum = reader.GetPhoneNumberOf(transaction.BiometricId);
        //        //cellNum = cellNum.Replace(" ", "").Replace("-", "");

        //        var message = "%date%\n\n";
        //        message += "Name: %name%\n";
        //        message += "Biometric Id: %biometricid%\n";

        //        //message += "Good day! This confirms your biometric entry on the above mentioned time.\n";
        //        message += "This is a system generated message. Do not reply";


        //        message = message.Replace("%date%", transaction.TimeLog.ToString("dd MMM yyyy, hh:mm:ss tt"));
        //        message = message.Replace("%name%", data.PersonClass.Name.Fullname);



        //        var cellNum = data.PhoneNumber;
        //        //if (_redirectedSmsNumber.Length > 2)
        //        //{
        //        //    cellNum = _redirectedSmsNumber;
        //        //}

        //        txtStatus.AppendText(@"Sending SMS...to: " + cellNum);


        //        if (!MySms.SendSms(Port, cellNum, message))
        //        {
        //            txtStatus.AppendText("Failed to send message");

        //            // MySms.SendSms(Port, cellNum, "Good day!This confirms your biometric entry on the above mentioned time.\n");
        //            return true;
        //        }

        //        // MySms.SendSms(Port, cellNum, "Good day!This confirms your biometric entry on the above mentioned time.\n");
        //        //Console.WriteLine(result);
        //        txtStatus.AppendText("Message has sent successfully\n");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        txtStatus.AppendText(ex.Message + "\n");
        //        return false;
        //    }
        //}

        private bool SendSms(Sms item)
        {

            if (Port == null) return false;

            txtStatus.AppendText(@"Sending SMS...to: " + item.ContactNumber + "\n");


            var cellNum = item.ContactNumber;

            //var message = item.Message;

            var message = "%date%\n\n";
            message += "Name: [Your_Full_Name_Here]\n";
            message += "Biometric Id: %biometricid%\n";

            //message += "Good day! This confirms your biometric entry on the above mentioned time.\n";
            message += "This is a system generated message. Do not reply";

            var messages = Sms.Parser(message);

            var success = true;
            foreach (var msg in messages)
            {
                success = MySms.SendSms(Port, cellNum, msg) && success;
                System.Threading.Thread.Sleep(800);
            }

            return success;
        }


        private void ConnectToGSM()
        {
            try
            {
                Port = MySms.OpenPort(cboPort.Text);

                txtStatus.AppendText(CurrentTimeStamp() + "Connected to GSM Modem.\n\n");
                lblStatus.Text = @"Connected to GSM Modem";

                timer1_Tick(this, EventArgs.Empty);

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


                timer1.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CurrentTimeStamp()
        {
            return DateTime.Now.ToString("G") + "\t";
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            txtStatus.AppendText(CurrentTimeStamp() + "Fetching Pending SMS Messages...");

            var items = Sms.GetPendingItems().ToList();

            txtStatus.AppendText(" Done.");

            if (!items.Any())
            {
                txtStatus.AppendText(" No pending items. Checking after 5 seconds...\n");
                timer1.Start();
                return;
            }


            txtStatus.AppendText("\n" + CurrentTimeStamp() + $"\nFound {items.Count()} pending items to be sent\n\n");

            try
            {
                var counter = 1;
                foreach (var item in items)
                {

                    txtStatus.AppendText(CurrentTimeStamp() + $"Sending message[{counter}]...");


                    if (!SendSms(item))
                    {
                        txtStatus.AppendText("Failed to send message!!!\n");
                    }
                    else
                    {
                        txtStatus.AppendText("Message has sent successfully!\n");
                        txtStatus.AppendText($"Marking message[{counter}] as SENT...");
                        item.MarkAsSent();
                        txtStatus.AppendText("done.\n\n");
                    }

                    System.Threading.Thread.Sleep(400);
                    counter++;
                }


            }
            catch (Exception ex)
            {
                txtStatus.AppendText(CurrentTimeStamp() + "Error Occurred:  \n" + ex.Message);
            }

            timer1.Start();
        }
    }
}
