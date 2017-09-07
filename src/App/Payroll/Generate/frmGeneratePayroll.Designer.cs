namespace Winform.Payroll
{
    partial class frmGeneratePayroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneratePayroll));
            this.txtRemarks = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPeriod = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.pbStatus = new DevComponents.DotNetBar.ProgressBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderCaption
            // 
            // 
            // 
            // 
            this.HeaderCaption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HeaderCaption.Size = new System.Drawing.Size(297, 47);
            this.HeaderCaption.Text = "<div><h3><font color=\'blue\'><b>GENERATE PAYROLL</b></font></h3>\r\n</div><div>\r\nAll" +
    "ows you to create new Payroll Summary\r\n</div>";
            // 
            // HeaderPicture
            // 
            this.HeaderPicture.Image = global::Winform.Properties.Resources.Planner_40px;
            // 
            // txtRemarks
            // 
            this.txtRemarks.AutoSelectAll = true;
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemarks.Border.Class = "TextBoxBorder";
            this.txtRemarks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemarks.DisabledBackColor = System.Drawing.Color.White;
            this.txtRemarks.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(163, 107);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PreventEnterBeep = true;
            this.txtRemarks.Size = new System.Drawing.Size(210, 22);
            this.txtRemarks.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(160, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Payroll Title:";
            // 
            // dtPeriod
            // 
            this.dtPeriod.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtPeriod.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtPeriod.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtPeriod.ButtonDropDown.Visible = true;
            this.dtPeriod.CustomFormat = "MMM - dd - yyyy";
            this.dtPeriod.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPeriod.ForeColor = System.Drawing.Color.Blue;
            this.dtPeriod.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtPeriod.IsPopupCalendarOpen = false;
            this.dtPeriod.Location = new System.Drawing.Point(17, 107);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtPeriod.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtPeriod.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtPeriod.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtPeriod.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtPeriod.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtPeriod.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtPeriod.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtPeriod.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtPeriod.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtPeriod.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtPeriod.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtPeriod.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtPeriod.MonthCalendar.TodayButtonVisible = true;
            this.dtPeriod.Name = "dtPeriod";
            this.dtPeriod.Size = new System.Drawing.Size(139, 22);
            this.dtPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtPeriod.TabIndex = 3;
            this.dtPeriod.Value = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(14, 91);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Payroll Period";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(286, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowSubItems = false;
            this.btnCancel.Size = new System.Drawing.Size(87, 34);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.AutoSize = true;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(193, 146);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(87, 38);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "Generate";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.pbStatus});
            this.bar1.Location = new System.Drawing.Point(0, 193);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(385, 26);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 25;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // pbStatus
            // 
            // 
            // 
            // 
            this.pbStatus.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pbStatus.CanCustomize = false;
            this.pbStatus.ChunkGradientAngle = 0F;
            this.pbStatus.ColorTable = DevComponents.DotNetBar.eProgressBarItemColor.Paused;
            this.pbStatus.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.RecentlyUsed = false;
            this.pbStatus.Stretch = true;
            this.pbStatus.Text = "ssdfsdf";
            this.pbStatus.TextVisible = true;
            this.pbStatus.Value = 50;
            this.pbStatus.Visible = false;
            // 
            // frmGeneratePayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 219);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtPeriod);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGeneratePayroll";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Payroll";
            this.Controls.SetChildIndex(this.dtPeriod, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRemarks, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtPeriod;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRemarks;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ProgressBarItem pbStatus;
    }
}