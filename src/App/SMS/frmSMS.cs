using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll.Payroll;
using System.IO.Ports;
using Dll.SMS;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace Winform.SMS
{
    public partial class frmSMS : FormWithHeader
    {
        private SerialPort Port;
        private SmsSender MySms = new SmsSender();

        public frmSMS()
        {
            InitializeComponent();


            //this.Load += (s, e) => { ShowData(); };
            //this.ConvertEnterKeyToTab();

            #region Display all available COM Ports
            string[] ports = SerialPort.GetPortNames();

            // Add all port names to the combo box:
            foreach (string port in ports)
            {
                this.cboPort.Items.Add(port);
            }
            #endregion

            btnConnect.Click += (s, e) => { Connect(); };
            btnSend.Click += (s, e) => { SendSMS(); };

            tabInbox.Click += (s, e) => { CheckInbox(); };


            InboxGrid.InitializeGrid();
            var grid = InboxGrid.PrimaryGrid;
            var col = new GridColumn();

            col = grid.CreateColumn("Time", "Time", 80);
            col = grid.CreateColumn("Sender", "Sender", 80);
            col = grid.CreateColumn("Message", "Message", 200);
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

            } catch (Exception ex)
            {
                My.Message.ShowError(ex, this);
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

                ToastNotification.Show(this, result , eToastPosition.MiddleCenter);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                My.Message.ShowError(ex, this);
            }
        }

        private void Connect()
        {
            Port = MySms.OpenPort(cboPort.Text);

            lblStatus.Text = "Ready";
            lblConnected.Text = "Connected";

            status.Refresh();
        }
    }
}
