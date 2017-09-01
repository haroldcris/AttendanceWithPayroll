using AForge.Video;
using AForge.Video.DirectShow;
using AiTech.Tools.Winform;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Devices
{
    public partial class frmCaptureDevice : DevComponents.DotNetBar.Metro.MetroForm
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;


        private bool CaptureDevicePreviewIsReady = false;

        public FileInfo File { get; set; }

        public frmCaptureDevice()
        {
            InitializeComponent();

            circularProgress1.IsRunning = true;

            //Initialize Cropping
            //picImage.MouseDown += ImageOnMouseDown;
            //picImage.MouseMove += ImageOnMouseMove;
            //picImage.MouseUp += ImageOnMouseUp;
            //picImage.Paint += ImageOnPaint;
        }

        // Main form is loaded
        private void MainForm_Load(object sender, EventArgs e)
        {
            //
        }

        // Closing the main form
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        // Enable/disable connection related controls
        private void EnableConnectionControls(bool enable)
        {
            devicesCombo.Enabled = enable;
            videoResolutionsCombo.Enabled = enable;
            snapshotResolutionsCombo.Enabled = enable;
            connectButton.Enabled = enable;
            disconnectButton.Enabled = !enable;

            triggerButton.Enabled = (!enable) && (snapshotCapabilities.Length != 0);


        }

        // New video device is selected
        private void devicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                EnumeratedSupportedFrameSizes(videoDevice);
            }
        }

        // Collect supported video and snapshot sizes
        private void EnumeratedSupportedFrameSizes(VideoCaptureDevice videoDevice)
        {
            this.Cursor = Cursors.WaitCursor;

            videoResolutionsCombo.Items.Clear();
            snapshotResolutionsCombo.Items.Clear();

            try
            {
                videoCapabilities = videoDevice.VideoCapabilities;
                snapshotCapabilities = videoDevice.SnapshotCapabilities;

                foreach (VideoCapabilities capabilty in videoCapabilities)
                {
                    videoResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                foreach (VideoCapabilities capabilty in snapshotCapabilities)
                {
                    snapshotResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                if (videoCapabilities.Length == 0)
                {
                    videoResolutionsCombo.Items.Add("Not supported");
                }
                if (snapshotCapabilities.Length == 0)
                {
                    snapshotResolutionsCombo.Items.Add("Not supported");
                }

                videoResolutionsCombo.SelectedIndex = 0;
                snapshotResolutionsCombo.SelectedIndex = 0;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // On "Connect" button clicked
        private void connectButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (videoDevice != null)
            {
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.VideoResolution = videoCapabilities[videoResolutionsCombo.SelectedIndex];
                }

                if ((snapshotCapabilities != null) && (snapshotCapabilities.Length != 0))
                {
                    videoDevice.ProvideSnapshots = true;
                    videoDevice.SnapshotResolution = snapshotCapabilities[snapshotResolutionsCombo.SelectedIndex];
                    videoDevice.SnapshotFrame += new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }

                EnableConnectionControls(false);

                videoSourcePlayer.VideoSource = videoDevice;
                videoSourcePlayer.Start();

                videoSourcePlayer.NewFrame += VideoSourcePlayer_NewFrame;

            }
        }


        private void VideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            //throw new NotImplementedException();
            if (!CaptureDevicePreviewIsReady) CaptureDevicePreviewIsReady = true;

        }


        // On "Disconnect" button clicked
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        // Disconnect from video device
        private void Disconnect()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;

                if (videoDevice.ProvideSnapshots)
                {
                    videoDevice.SnapshotFrame -= new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }

                EnableConnectionControls(true);
            }
        }

        // Simulate snapshot trigger
        private void triggerButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if ((videoDevice != null) && (videoDevice.ProvideSnapshots))
            {
                videoDevice.SimulateTrigger();
                return;
            }
            else
            {
                MessageDialog.ShowValidationError(triggerButton, "Device Capture NOT Ready!");
                return;
            }

            //if (!CaptureDevicePreviewIsReady)
            //{
            //    MessageDialog.ShowValidationError(triggerButton, "Device Preview NOT Ready!");
            //    return;
            //}

        }

        // New snapshot frame is available
        private void videoDevice_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //Console.WriteLine(eventArgs.Frame.Size);

            ShowSnapshot((Bitmap)eventArgs.Frame.Clone());
        }

        private void ShowSnapshot(Bitmap snapshot)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Bitmap>(ShowSnapshot), snapshot);
            }
            else
            {

                picImage.Image = snapshot;
                tabControl1.SelectedTab = tabItem2;

                tabItem1.Visible = false;
                tabItem2.Visible = true;
            }
        }



        private void MainForm_Shown(object sender, EventArgs e)
        {
            // enumerate video devices
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count != 0)
            {
                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    devicesCombo.Items.Add(device.Name);
                }
            }
            else
            {
                devicesCombo.Items.Add("No DirectShow devices found");
            }

            devicesCombo.SelectedIndex = 0;

            EnableConnectionControls(true);

            PanelLoading.Visible = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            picImage.Image = null;
            tabControl1.SelectedTab = tabItem1;
            tabItem1.Visible = true;
            tabItem2.Visible = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ImageFormat format = ImageFormat.Jpeg;

            try
            {
                lock (this)
                {
                    Bitmap image = (Bitmap)picImage.Image;


                    var targetFolder = Path.Combine(Path.GetTempPath(), "amwp");

                    var file = DateTime.Now.ToString("yymmddhhmmss");
                    var filename = file + ".jpg";

                    Directory.CreateDirectory(targetFolder);

                    // 1708181311.jpg
                    Console.WriteLine("Saving Image...");
                    image.Save(Path.Combine(targetFolder, filename), format);

                    this.File = new FileInfo(Path.Combine(targetFolder, filename));

                    DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed saving the snapshot.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private bool UploadImage(string fullFilename)
        //{
        //    var username = AiTech.Database.Connection.MyDbCredential.Username;
        //    var password = AiTech.Database.Connection.MyDbCredential.Password;

        //    var credential = new NetworkCredential() { UserName = username, Password = password };


        //    var ftp = new AiTech.Tools.FtpClass(AiTech.Database.Connection.MyDbCredential.ServerName, credential);

        //    return ftp.UploadFile(fullFilename, "/idms/pictures/");

        //}



        #region Cropping Image


        private bool _selecting;
        private Rectangle _selection;

        private void ImageOnMouseDown(object sender, MouseEventArgs e)
        {
            // Starting point of the selection:
            if (e.Button == MouseButtons.Left)
            {
                _selecting = true;
                _selection = new Rectangle(new Point(e.X, e.Y), new Size());
            }
        }

        private void ImageOnMouseMove(object sender, MouseEventArgs e)
        {
            // Update the actual size of the selection:
            if (_selecting)
            {
                _selection.Width = e.X - _selection.X;
                _selection.Height = e.Y - _selection.Y;

                // Redraw the picturebox:
                picImage.Refresh();
            }
        }

        private void ImageOnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                _selecting &&
                _selection.Size != new Size())
            {
                // Create cropped image:
                Image img = picImage.Image.Crop(_selection);


                // Fit image to the picturebox:
                picImage.Image = img.Fit2PictureBox(picImage);

                _selecting = false;
            }
            else
                _selecting = false;
        }

        private void ImageOnPaint(object sender, PaintEventArgs e)
        {
            if (_selecting)
            {
                // Draw a rectangle displaying the current selection
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, _selection);
            }
        }


        #endregion

    }
}
