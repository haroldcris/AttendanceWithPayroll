using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Dll.SMS;

namespace Winform.SMS
{
    public partial class frmSMS : FormWithHeader
    {
        private readonly SmsSender MySms = new SmsSender();
        private SerialPort Port;

        public frmSMS()
        {
            InitializeComponent();

            //this.Load += (s, e) => { ShowData(); };
            //this.ConvertEnterKeyToTab();

            #region Display all available COM Ports

            var ports = SerialPort.GetPortNames();

            // Add all port names to the combo box:
            foreach (var port in ports)
                cboPort.Items.Add(port);

            #endregion

            FormClosed += (s, e) => { Disconnect(); };

            btnConnect.Click += (s, e) => { OnButtonConnectionClick(); };

            tabInbox.Click += (s, e) => { CheckInbox(); };


            InboxGrid.InitializeGrid();
            var grid = InboxGrid.PrimaryGrid;
            var col = new GridColumn();

            col = grid.CreateColumn("Time", "Time", 80);
            col = grid.CreateColumn("Sender", "Sender", 80);
            col = grid.CreateColumn("Message", "Message", 200);
        }

        private void OnButtonConnectionClick()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (string.IsNullOrEmpty(cboPort.Text))
            {
                MessageDialog.ShowValidationError(cboPort, "Select Port First");
                return;
            }

            if (Port == null)
            {
                Connect();
                btnConnect.Text = @" Disconnect ";
            }
            else
            {
                Disconnect();
                btnConnect.Text = @" Connect ";

                Port = null;
            }

            tabControl1.Visible = Port != null;
        }

        private void CheckInbox()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var items = MySms.ReadSMS(Port);

                var grid = InboxGrid.PrimaryGrid;

                grid.Rows.Clear();
                foreach (var item in items)
                {
                    var row = grid.CreateNewRow();

                    row["Time"].Value = item.Sent;
                    row["Sender"].Value = item.Sender;
                    row["Message"].Value = item.Message;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void SendSMS()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var result = "";

                var num = txtCellnum.Text.Replace(" ", "").Replace("-", "");
                if (MySms.SendSms(Port, num, txtMessage.Text))
                    result = "Message has sent successfully";
                else
                    result = "Failed to send message";


                //ToastNotification.DefaultToastGlowColor = eToastGlowColor.Green;
                ToastNotification.ToastBackColor = Color.Green;

                ToastNotification.Show(this, result, eToastPosition.MiddleCenter);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void Connect()
        {
            try
            {
                Port = MySms.OpenPort(cboPort.Text);

                lblStatus.Text = "Ready";
                lblConnected.Text = "Connected";

                Status.Refresh();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void Disconnect()
        {
            try
            {
                if (Port == null) return;

                if (Port.IsOpen)
                    MySms.ClosePort(Port);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendSMS();
        }
    }
}