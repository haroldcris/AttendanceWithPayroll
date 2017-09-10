namespace Winform
{
    partial class frmOutputWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.Controls.ClockStyleData clockStyleData1 = new DevComponents.DotNetBar.Controls.ClockStyleData();
            DevComponents.DotNetBar.Controls.ColorData colorData1 = new DevComponents.DotNetBar.Controls.ColorData();
            DevComponents.DotNetBar.Controls.ColorData colorData2 = new DevComponents.DotNetBar.Controls.ColorData();
            DevComponents.DotNetBar.Controls.ColorData colorData3 = new DevComponents.DotNetBar.Controls.ColorData();
            DevComponents.DotNetBar.Controls.ClockHandStyleData clockHandStyleData1 = new DevComponents.DotNetBar.Controls.ClockHandStyleData();
            DevComponents.DotNetBar.Controls.ColorData colorData4 = new DevComponents.DotNetBar.Controls.ColorData();
            DevComponents.DotNetBar.Controls.ColorData colorData5 = new DevComponents.DotNetBar.Controls.ColorData();
            DevComponents.DotNetBar.Controls.ClockHandStyleData clockHandStyleData2 = new DevComponents.DotNetBar.Controls.ClockHandStyleData();
            DevComponents.DotNetBar.Controls.ColorData colorData6 = new DevComponents.DotNetBar.Controls.ColorData();
            DevComponents.DotNetBar.Controls.ClockHandStyleData clockHandStyleData3 = new DevComponents.DotNetBar.Controls.ClockHandStyleData();
            DevComponents.DotNetBar.Controls.ColorData colorData7 = new DevComponents.DotNetBar.Controls.ColorData();
            DevComponents.DotNetBar.Controls.ColorData colorData8 = new DevComponents.DotNetBar.Controls.ColorData();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.PanelHead = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.analogClockControl1 = new DevComponents.DotNetBar.Controls.AnalogClockControl();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.button1 = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtIp = new DevComponents.Editors.IpAddressInput();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.lblStatus = new DevComponents.DotNetBar.LabelItem();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.PanelHead.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(5, 127);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(282, 261);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // PanelHead
            // 
            this.PanelHead.BackColor = System.Drawing.Color.RoyalBlue;
            this.PanelHead.Controls.Add(this.lblHeader);
            this.PanelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelHead.Location = new System.Drawing.Point(0, 0);
            this.PanelHead.Name = "PanelHead";
            this.PanelHead.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.PanelHead.Size = new System.Drawing.Size(1004, 30);
            this.PanelHead.TabIndex = 20;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(443, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = " ATTENDANCE MONITORING SYSTEM";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // analogClockControl1
            // 
            this.analogClockControl1.AutomaticMode = true;
            this.analogClockControl1.ClockStyle = DevComponents.DotNetBar.Controls.eClockStyles.Custom;
            colorData1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData1.BrushAngle = 90F;
            colorData1.BrushSBSScale = 1F;
            colorData1.BrushType = DevComponents.DotNetBar.Controls.eBrushTypes.Linear;
            colorData1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            colorData1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            clockStyleData1.BezelColor = colorData1;
            colorData2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData2.BorderWidth = 0.01F;
            colorData2.BrushSBSScale = 1F;
            colorData2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            colorData2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            clockStyleData1.CapColor = colorData2;
            clockStyleData1.CapSize = 0.1F;
            colorData3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData3.BrushAngle = 90F;
            colorData3.BrushSBSScale = 1F;
            colorData3.BrushType = DevComponents.DotNetBar.Controls.eBrushTypes.Linear;
            colorData3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            colorData3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            clockStyleData1.FaceColor = colorData3;
            clockStyleData1.GlassAngle = 0;
            colorData4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData4.BorderWidth = 0.01F;
            colorData4.BrushAngle = 90F;
            colorData4.BrushSBSScale = 1F;
            colorData4.BrushType = DevComponents.DotNetBar.Controls.eBrushTypes.Linear;
            colorData4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData4.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            clockHandStyleData1.HandColor = colorData4;
            clockHandStyleData1.HandStyle = DevComponents.DotNetBar.Controls.eHandStyles.Style3;
            clockHandStyleData1.Length = 0.45F;
            clockHandStyleData1.Width = 0.175F;
            clockStyleData1.HourHandStyle = clockHandStyleData1;
            colorData5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData5.BorderWidth = 0.01F;
            colorData5.BrushSBSScale = 1F;
            colorData5.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData5.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            clockStyleData1.LargeTickColor = colorData5;
            clockStyleData1.LargeTickWidth = 0.01F;
            colorData6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData6.BorderWidth = 0.01F;
            colorData6.BrushAngle = 90F;
            colorData6.BrushSBSScale = 1F;
            colorData6.BrushType = DevComponents.DotNetBar.Controls.eBrushTypes.Linear;
            colorData6.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData6.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            clockHandStyleData2.HandColor = colorData6;
            clockHandStyleData2.HandStyle = DevComponents.DotNetBar.Controls.eHandStyles.Style3;
            clockHandStyleData2.Length = 0.75F;
            clockHandStyleData2.Width = 0.175F;
            clockStyleData1.MinuteHandStyle = clockHandStyleData2;
            clockStyleData1.NumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            clockStyleData1.NumberFont = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            clockHandStyleData3.DrawOverCap = true;
            colorData7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData7.BorderWidth = 0.01F;
            colorData7.BrushSBSScale = 1F;
            colorData7.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData7.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            clockHandStyleData3.HandColor = colorData7;
            clockHandStyleData3.HandStyle = DevComponents.DotNetBar.Controls.eHandStyles.Style4;
            clockHandStyleData3.Length = 0.9F;
            clockHandStyleData3.Width = 0.01F;
            clockStyleData1.SecondHandStyle = clockHandStyleData3;
            colorData8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData8.BorderWidth = 0.01F;
            colorData8.BrushSBSScale = 1F;
            colorData8.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            colorData8.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            clockStyleData1.SmallTickColor = colorData8;
            clockStyleData1.SmallTickLength = 0.01F;
            clockStyleData1.SmallTickWidth = 0.01F;
            clockStyleData1.Style = DevComponents.DotNetBar.Controls.eClockStyles.Custom;
            this.analogClockControl1.ClockStyleData = clockStyleData1;
            this.analogClockControl1.IndicatorStyle = DevComponents.DotNetBar.Controls.eClockIndicatorStyles.Numbers;
            this.analogClockControl1.Location = new System.Drawing.Point(309, 46);
            this.analogClockControl1.Name = "analogClockControl1";
            this.analogClockControl1.Size = new System.Drawing.Size(159, 159);
            this.analogClockControl1.TabIndex = 21;
            this.analogClockControl1.Text = "analogClockControl1";
            this.analogClockControl1.Value = new System.DateTime(2017, 9, 9, 14, 38, 31, 63);
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(309, 211);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(695, 177);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "<b>LASTNAME , FIRSTNAME MIDDLENAME</b>";
            this.lblName.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.FontBold = true;
            this.lblTime.Location = new System.Drawing.Point(474, 46);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(530, 155);
            this.lblTime.TabIndex = 22;
            this.lblTime.Text = "MON 01 - JAN - 2017   11:59 AM";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 49);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtIp);
            this.groupPanel1.Controls.Add(this.btnConnect);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(5, 36);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(282, 76);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 24;
            this.groupPanel1.Text = "Biometric";
            // 
            // txtIp
            // 
            this.txtIp.AutoOverwrite = true;
            // 
            // 
            // 
            this.txtIp.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtIp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIp.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtIp.ButtonFreeText.Visible = true;
            this.txtIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Location = new System.Drawing.Point(12, 25);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(158, 24);
            this.txtIp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtIp.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.Location = new System.Drawing.Point(176, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 27);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP Address:";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblStatus});
            this.bar1.Location = new System.Drawing.Point(0, 567);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1004, 20);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 25;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Ready";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(97, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 49);
            this.button2.TabIndex = 26;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmOutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 587);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.analogClockControl1);
            this.Controls.Add(this.PanelHead);
            this.Controls.Add(this.picImage);
            this.DoubleBuffered = true;
            this.Name = "frmOutputWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Monitoring";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.PanelHead.ResumeLayout(false);
            this.PanelHead.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Panel PanelHead;
        private System.Windows.Forms.Label lblHeader;
        private DevComponents.DotNetBar.Controls.AnalogClockControl analogClockControl1;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.LabelX lblTime;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.Editors.IpAddressInput txtIp;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelItem lblStatus;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
    }
}