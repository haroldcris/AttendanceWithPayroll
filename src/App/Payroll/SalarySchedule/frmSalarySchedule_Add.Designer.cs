namespace Winform.Payroll
{
    partial class frmSalarySchedule_Add
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.SGGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell9 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridRow3 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.PositionGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridRow4 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridRow5 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell5 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell6 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridRow6 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell7 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell8 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.dtEffectivityDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEffectivityDate)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderCaption
            // 
            // 
            // 
            // 
            this.HeaderCaption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HeaderCaption.Location = new System.Drawing.Point(76, 5);
            this.HeaderCaption.Size = new System.Drawing.Size(437, 54);
            this.HeaderCaption.Text = "<div><h3><font color=\'blue\'>PAYROLL SALARY SCHEDULE INFO</font></h3>\r\n</div><div>" +
    "\r\nAllows you to add and update salary schedule from the database\r\n</div>";
            // 
            // HeaderPicture
            // 
            this.HeaderPicture.Image = global::Winform.Properties.Resources.Community_Grants_40px;
            this.HeaderPicture.Location = new System.Drawing.Point(10, 3);
            this.HeaderPicture.Size = new System.Drawing.Size(59, 48);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Effectivity:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Winform.Properties.Resources.Cancel_24px;
            this.btnCancel.Location = new System.Drawing.Point(613, 675);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowSubItems = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 39);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = global::Winform.Properties.Resources.Ok_24px;
            this.btnOk.Location = new System.Drawing.Point(524, 675);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(83, 39);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Save";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BackColor = System.Drawing.Color.White;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(10, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(692, 532);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            this.tabControl1.TabIndex = 4;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            this.tabControl1.ThemeAware = true;
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.SGGrid);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tabControlPanel1.Size = new System.Drawing.Size(692, 504);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // SGGrid
            // 
            this.SGGrid.BackColor = System.Drawing.Color.White;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SGGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background1;
            this.SGGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SGGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.SGGrid.ForeColor = System.Drawing.Color.Black;
            this.SGGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.SGGrid.Location = new System.Drawing.Point(10, 10);
            this.SGGrid.Name = "SGGrid";
            // 
            // 
            // 
            this.SGGrid.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.SGGrid.PrimaryGrid.MultiSelect = false;
            this.SGGrid.PrimaryGrid.Rows.Add(this.gridRow1);
            this.SGGrid.PrimaryGrid.Rows.Add(this.gridRow2);
            this.SGGrid.PrimaryGrid.Rows.Add(this.gridRow3);
            this.SGGrid.PrimaryGrid.UseAlternateRowStyle = true;
            this.SGGrid.Size = new System.Drawing.Size(672, 484);
            this.SGGrid.TabIndex = 2;
            this.SGGrid.Text = "superGridControl1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridRow1
            // 
            this.gridRow1.Cells.Add(this.gridCell9);
            // 
            // gridCell9
            // 
            this.gridCell9.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.gridCell9.Value = "12000";
            // 
            // gridRow2
            // 
            this.gridRow2.Cells.Add(this.gridCell1);
            this.gridRow2.Cells.Add(this.gridCell2);
            // 
            // gridRow3
            // 
            this.gridRow3.Cells.Add(this.gridCell3);
            this.gridRow3.Cells.Add(this.gridCell4);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Salary Grade";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.PositionGrid);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tabControlPanel2.Size = new System.Drawing.Size(692, 504);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // PositionGrid
            // 
            this.PositionGrid.BackColor = System.Drawing.Color.White;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PositionGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            this.PositionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.PositionGrid.ForeColor = System.Drawing.Color.Black;
            this.PositionGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.PositionGrid.Location = new System.Drawing.Point(10, 10);
            this.PositionGrid.Name = "PositionGrid";
            // 
            // 
            // 
            this.PositionGrid.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.PositionGrid.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.PositionGrid.PrimaryGrid.MultiSelect = false;
            this.PositionGrid.PrimaryGrid.Rows.Add(this.gridRow4);
            this.PositionGrid.PrimaryGrid.Rows.Add(this.gridRow5);
            this.PositionGrid.PrimaryGrid.Rows.Add(this.gridRow6);
            this.PositionGrid.Size = new System.Drawing.Size(672, 484);
            this.PositionGrid.TabIndex = 0;
            this.PositionGrid.Text = "superGridControl1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Name = "gridColumn1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Name = "gridColumn2";
            // 
            // gridRow5
            // 
            this.gridRow5.Cells.Add(this.gridCell5);
            this.gridRow5.Cells.Add(this.gridCell6);
            // 
            // gridRow6
            // 
            this.gridRow6.Cells.Add(this.gridCell7);
            this.gridRow6.Cells.Add(this.gridCell8);
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Position Salary Grade";
            // 
            // dtEffectivityDate
            // 
            this.dtEffectivityDate.AutoAdvance = true;
            this.dtEffectivityDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtEffectivityDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtEffectivityDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEffectivityDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtEffectivityDate.ButtonDropDown.Visible = true;
            this.dtEffectivityDate.CustomFormat = "MMM - dd - yyyy";
            this.dtEffectivityDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEffectivityDate.ForeColor = System.Drawing.Color.Black;
            this.dtEffectivityDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtEffectivityDate.IsPopupCalendarOpen = false;
            this.dtEffectivityDate.Location = new System.Drawing.Point(15, 91);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtEffectivityDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEffectivityDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtEffectivityDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtEffectivityDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtEffectivityDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEffectivityDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtEffectivityDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtEffectivityDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtEffectivityDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtEffectivityDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEffectivityDate.MonthCalendar.DisplayMonth = new System.DateTime(2017, 7, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtEffectivityDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtEffectivityDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEffectivityDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtEffectivityDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEffectivityDate.MonthCalendar.TodayButtonVisible = true;
            this.dtEffectivityDate.Name = "dtEffectivityDate";
            this.dtEffectivityDate.Size = new System.Drawing.Size(138, 22);
            this.dtEffectivityDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtEffectivityDate.TabIndex = 1;
            this.dtEffectivityDate.Value = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(156, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemarks.Border.Class = "TextBoxBorder";
            this.txtRemarks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemarks.DisabledBackColor = System.Drawing.Color.White;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(159, 91);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PreventEnterBeep = true;
            this.txtRemarks.Size = new System.Drawing.Size(534, 22);
            this.txtRemarks.TabIndex = 3;
            // 
            // frmSalarySchedule_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 735);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtEffectivityDate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalarySchedule_Add";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Payroll Salary Schedule Info";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.dtEffectivityDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtRemarks, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtEffectivityDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl SGGrid;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEffectivityDate;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow1;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow2;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell1;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell2;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow3;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell3;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell4;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl PositionGrid;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow4;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow5;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell5;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell6;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow6;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell7;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell8;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRemarks;
        private System.Windows.Forms.Label label1;
    }
}