namespace Winform.Payroll
{
    partial class frmEmployeeDeduction_Add
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtDateReceived = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label5 = new System.Windows.Forms.Label();
            this.dtEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblDeduction = new DevComponents.DotNetBar.LabelX();
            this.btnSelectDeduction = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAmount = new DevComponents.Editors.DoubleInput();
            this.txtRemarks = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnOk = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateReceived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtDateReceived);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.dtEnd);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtStart);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 135);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Date Range";
            // 
            // dtDateReceived
            // 
            this.dtDateReceived.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtDateReceived.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtDateReceived.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateReceived.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtDateReceived.ButtonDropDown.Visible = true;
            this.dtDateReceived.CustomFormat = "MMM - dd - yyyy";
            this.dtDateReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateReceived.ForeColor = System.Drawing.Color.Blue;
            this.dtDateReceived.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtDateReceived.IsPopupCalendarOpen = false;
            this.dtDateReceived.Location = new System.Drawing.Point(12, 40);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtDateReceived.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateReceived.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtDateReceived.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtDateReceived.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtDateReceived.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDateReceived.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtDateReceived.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtDateReceived.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtDateReceived.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtDateReceived.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateReceived.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtDateReceived.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtDateReceived.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDateReceived.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtDateReceived.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateReceived.MonthCalendar.TodayButtonVisible = true;
            this.dtDateReceived.Name = "dtDateReceived";
            this.dtDateReceived.Size = new System.Drawing.Size(132, 22);
            this.dtDateReceived.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtDateReceived.TabIndex = 1;
            this.dtDateReceived.Value = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date Received:";
            // 
            // dtEnd
            // 
            this.dtEnd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtEnd.ButtonDropDown.Visible = true;
            this.dtEnd.CustomFormat = "MMM - dd - yyyy";
            this.dtEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.ForeColor = System.Drawing.Color.Blue;
            this.dtEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtEnd.IsPopupCalendarOpen = false;
            this.dtEnd.Location = new System.Drawing.Point(150, 95);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEnd.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEnd.MonthCalendar.TodayButtonVisible = true;
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(132, 22);
            this.dtEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtEnd.TabIndex = 5;
            this.dtEnd.Value = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(147, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Termination Date:";
            // 
            // dtStart
            // 
            this.dtStart.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtStart.ButtonDropDown.Visible = true;
            this.dtStart.CustomFormat = "MMM - dd - yyyy";
            this.dtStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.ForeColor = System.Drawing.Color.Blue;
            this.dtStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtStart.IsPopupCalendarOpen = false;
            this.dtStart.Location = new System.Drawing.Point(12, 95);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.MonthCalendar.TodayButtonVisible = true;
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(132, 22);
            this.dtStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStart.TabIndex = 3;
            this.dtStart.Value = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Effectivity Date:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblDeduction);
            this.groupBox3.Controls.Add(this.btnSelectDeduction);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(11, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 90);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deduction Info";
            // 
            // lblDeduction
            // 
            this.lblDeduction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblDeduction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDeduction.Location = new System.Drawing.Point(102, 16);
            this.lblDeduction.Name = "lblDeduction";
            this.lblDeduction.Size = new System.Drawing.Size(373, 67);
            this.lblDeduction.TabIndex = 1;
            this.lblDeduction.Text = "Deduction Code:<br/>\r\n<font color=\'blue\' size=\'+2\'>\r\n  <b>%code%</b><br/></font>\r" +
    "\nDescription: <br/>\r\n<font color=\'blue\' size=\'+3\'>\r\n  <b>%description%</b>\r\n</fo" +
    "nt>";
            this.lblDeduction.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnSelectDeduction
            // 
            this.btnSelectDeduction.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectDeduction.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSelectDeduction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectDeduction.Image = global::Winform.Properties.Resources.Open_16px;
            this.btnSelectDeduction.Location = new System.Drawing.Point(13, 24);
            this.btnSelectDeduction.Name = "btnSelectDeduction";
            this.btnSelectDeduction.ShowSubItems = false;
            this.btnSelectDeduction.Size = new System.Drawing.Size(70, 22);
            this.btnSelectDeduction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectDeduction.TabIndex = 0;
            this.btnSelectDeduction.Text = "Select...";
            this.btnSelectDeduction.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnSelectDeduction.Click += new System.EventHandler(this.btnSelectDeduction_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(320, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account:";
            // 
            // txtAmount
            // 
            // 
            // 
            // 
            this.txtAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmount.ButtonFreeText.Checked = true;
            this.txtAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Blue;
            this.txtAmount.FreeTextEntryMode = true;
            this.txtAmount.Increment = 1D;
            this.txtAmount.Location = new System.Drawing.Point(15, 40);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShowUpDown = true;
            this.txtAmount.Size = new System.Drawing.Size(148, 22);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.Value = 123456D;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemarks.Border.Class = "TextBoxBorder";
            this.txtRemarks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemarks.DisabledBackColor = System.Drawing.Color.White;
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(15, 96);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PreventEnterBeep = true;
            this.txtRemarks.Size = new System.Drawing.Size(148, 21);
            this.txtRemarks.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Remarks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount:";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOk,
            this.btnCancel});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(510, 39);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 112;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnOk
            // 
            this.btnOk.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = global::Winform.Properties.Resources.Ok_30;
            this.btnOk.Name = "btnOk";
            this.btnOk.Text = "Save Record";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = global::Winform.Properties.Resources.Cancel_24px;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Text = "Cancel Changes";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmEmployeeDeduction_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 296);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployeeDeduction_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deduction Info";
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateReceived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.LabelX lblDeduction;
        private DevComponents.DotNetBar.ButtonX btnSelectDeduction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEnd;
        private System.Windows.Forms.Label label2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStart;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtDateReceived;
        private System.Windows.Forms.Label label5;
        private DevComponents.Editors.DoubleInput txtAmount;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRemarks;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnOk;
        private DevComponents.DotNetBar.ButtonItem btnCancel;
    }
}