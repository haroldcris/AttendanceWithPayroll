namespace Winform
{
    partial class frmSmsMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmsMonitor));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSMSConnect = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.txtStatus = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.lblStatus = new DevComponents.DotNetBar.LabelItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel2.CanvasColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnSMSConnect);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.cboPort);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(12, 12);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(211, 84);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 16;
            this.groupPanel2.Text = "GSM Sender";
            // 
            // btnSMSConnect
            // 
            this.btnSMSConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSMSConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSMSConnect.Location = new System.Drawing.Point(121, 27);
            this.btnSMSConnect.Name = "btnSMSConnect";
            this.btnSMSConnect.Size = new System.Drawing.Size(66, 25);
            this.btnSMSConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSMSConnect.TabIndex = 13;
            this.btnSMSConnect.Text = "Connect";
            this.btnSMSConnect.Click += new System.EventHandler(this.btnSMSConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Port:";
            // 
            // cboPort
            // 
            this.cboPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.ForeColor = System.Drawing.Color.Black;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(9, 27);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(106, 21);
            this.cboPort.TabIndex = 12;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtStatus.Border.Class = "TextBoxBorder";
            this.txtStatus.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStatus.DisabledBackColor = System.Drawing.Color.White;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.Black;
            this.txtStatus.Location = new System.Drawing.Point(13, 109);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.PreventEnterBeep = true;
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(785, 246);
            this.txtStatus.TabIndex = 17;
            this.txtStatus.WordWrap = false;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.White;
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(116)))), ((int)(((byte)(71))))));
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(229, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(410, 69);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "When Connected, this App will check the database every <b>5 seconds</b> for pendi" +
    "ng SMS that needs to be sent";
            this.labelX1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelX1.WordWrap = true;
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
            this.bar1.Location = new System.Drawing.Point(0, 376);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(810, 20);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 19;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Ready";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSmsMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 396);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.groupPanel2);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSmsMonitor";
            this.Text = "SMS Monitor";
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSMSConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPort;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStatus;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelItem lblStatus;
        private System.Windows.Forms.Timer timer1;
    }
}