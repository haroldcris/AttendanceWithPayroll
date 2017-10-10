namespace Winform.Payroll
{
    partial class frmPayrollEmployee_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayrollEmployee_Add));
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboBarangay = new System.Windows.Forms.ComboBox();
            this.cboTown = new System.Windows.Forms.ComboBox();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.cboTax = new System.Windows.Forms.ComboBox();
            this.dtDateHired = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cboStep = new System.Windows.Forms.ComboBox();
            this.switchActive = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.txtPagIbig = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPhilHealth = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTin = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSSS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblNameProfile = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtExemption = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSG = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FlexGridDeductions = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.btnAddDeduction = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditDeduction = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeleteDeduction = new DevComponents.DotNetBar.ButtonItem();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnOk = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.explorerBarGroupItem1 = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.lblSalary = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateHired)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexGridDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecordInfoPanel
            // 
            // 
            // 
            // 
            this.RecordInfoPanel.BackStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground2;
            this.RecordInfoPanel.BackStyle.BackColorGradientAngle = 90;
            this.RecordInfoPanel.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground;
            this.RecordInfoPanel.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RecordInfoPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.RecordInfoPanel.Groups.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.explorerBarGroupItem1});
            this.RecordInfoPanel.Location = new System.Drawing.Point(0, 39);
            this.RecordInfoPanel.Size = new System.Drawing.Size(109, 497);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.Location = new System.Drawing.Point(109, 39);
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 497);
            // 
            // BarImage
            // 
            // 
            // 
            // 
            this.BarImage.BackStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.BarImage.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.BarImage.BackStyle.BorderBottomWidth = 1;
            this.BarImage.BackStyle.BorderColor = System.Drawing.Color.White;
            this.BarImage.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.BarImage.BackStyle.BorderLeftWidth = 1;
            this.BarImage.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.BarImage.BackStyle.BorderRightWidth = 1;
            this.BarImage.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.BarImage.TitleHotStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(181)))));
            this.BarImage.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(93)))), ((int)(((byte)(206)))));
            this.BarImage.TitleHotStyle.CornerDiameter = 3;
            this.BarImage.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BarImage.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarImage.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarImage.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.BarImage.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(181)))));
            this.BarImage.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(93)))), ((int)(((byte)(206)))));
            this.BarImage.TitleStyle.CornerDiameter = 3;
            this.BarImage.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BarImage.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarImage.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarImage.TitleStyle.TextColor = System.Drawing.Color.White;
            // 
            // highlighter1
            // 
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSelectAll = true;
            this.txtAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.DisabledBackColor = System.Drawing.Color.White;
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.txtAddress, true);
            this.txtAddress.Location = new System.Drawing.Point(14, 37);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PreventEnterBeep = true;
            this.txtAddress.Size = new System.Drawing.Size(405, 20);
            this.txtAddress.TabIndex = 16;
            // 
            // cboBarangay
            // 
            this.cboBarangay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBarangay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBarangay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboBarangay.ForeColor = System.Drawing.Color.Black;
            this.cboBarangay.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboBarangay, true);
            this.cboBarangay.Location = new System.Drawing.Point(282, 82);
            this.cboBarangay.Name = "cboBarangay";
            this.cboBarangay.Size = new System.Drawing.Size(137, 21);
            this.cboBarangay.TabIndex = 22;
            // 
            // cboTown
            // 
            this.cboTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboTown.ForeColor = System.Drawing.Color.Black;
            this.cboTown.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboTown, true);
            this.cboTown.Location = new System.Drawing.Point(138, 82);
            this.cboTown.Name = "cboTown";
            this.cboTown.Size = new System.Drawing.Size(138, 21);
            this.cboTown.TabIndex = 20;
            // 
            // cboProvince
            // 
            this.cboProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProvince.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboProvince.ForeColor = System.Drawing.Color.Black;
            this.cboProvince.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboProvince, true);
            this.cboProvince.Items.AddRange(new object[] {
            "Pampanga",
            "Bulacan",
            "Nueva Ecija",
            "Manila",
            "Makati"});
            this.cboProvince.Location = new System.Drawing.Point(14, 82);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(118, 21);
            this.cboProvince.TabIndex = 18;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highlighter1.SetHighlightOnFocus(this.buttonX1, true);
            this.buttonX1.Image = global::Winform.Properties.Resources.Open_16px;
            this.buttonX1.Location = new System.Drawing.Point(7, 21);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.ShowSubItems = false;
            this.buttonX1.Size = new System.Drawing.Size(73, 21);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 104;
            this.buttonX1.Text = "Select ...";
            this.buttonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highlighter1.SetHighlightOnFocus(this.buttonX2, true);
            this.buttonX2.Image = global::Winform.Properties.Resources.Add_List_16;
            this.buttonX2.Location = new System.Drawing.Point(88, 21);
            this.buttonX2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.ShowSubItems = false;
            this.buttonX2.Size = new System.Drawing.Size(73, 21);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 105;
            this.buttonX2.Text = "Create...";
            this.buttonX2.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // cboDepartment
            // 
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDepartment.ForeColor = System.Drawing.Color.Blue;
            this.cboDepartment.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboDepartment, true);
            this.cboDepartment.Items.AddRange(new object[] {
            "High School",
            "College"});
            this.cboDepartment.Location = new System.Drawing.Point(152, 35);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(138, 23);
            this.cboDepartment.TabIndex = 3;
            // 
            // cboPosition
            // 
            this.cboPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboPosition.ForeColor = System.Drawing.Color.Blue;
            this.cboPosition.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboPosition, true);
            this.cboPosition.Items.AddRange(new object[] {
            "Pampanga",
            "Bulacan",
            "Nueva Ecija",
            "Manila",
            "Makati"});
            this.cboPosition.Location = new System.Drawing.Point(10, 87);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(184, 23);
            this.cboPosition.TabIndex = 5;
            this.cboPosition.SelectedIndexChanged += new System.EventHandler(this.cboPosition_SelectedIndexChanged);
            // 
            // cboTax
            // 
            this.cboTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTax.ForeColor = System.Drawing.Color.Blue;
            this.cboTax.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboTax, true);
            this.cboTax.Items.AddRange(new object[] {
            "Pampanga",
            "Bulacan",
            "Nueva Ecija",
            "Manila",
            "Makati"});
            this.cboTax.Location = new System.Drawing.Point(10, 143);
            this.cboTax.Name = "cboTax";
            this.cboTax.Size = new System.Drawing.Size(203, 23);
            this.cboTax.TabIndex = 11;
            this.cboTax.SelectedIndexChanged += new System.EventHandler(this.cboTax_SelectedIndexChanged);
            // 
            // dtDateHired
            // 
            this.dtDateHired.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtDateHired.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtDateHired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateHired.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtDateHired.ButtonDropDown.Visible = true;
            this.dtDateHired.CustomFormat = "MMM - dd - yyyy";
            this.dtDateHired.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateHired.ForeColor = System.Drawing.Color.Blue;
            this.dtDateHired.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.highlighter1.SetHighlightOnFocus(this.dtDateHired, true);
            this.dtDateHired.IsPopupCalendarOpen = false;
            this.dtDateHired.Location = new System.Drawing.Point(10, 35);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtDateHired.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateHired.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtDateHired.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtDateHired.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtDateHired.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDateHired.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtDateHired.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtDateHired.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtDateHired.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtDateHired.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateHired.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtDateHired.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtDateHired.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDateHired.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtDateHired.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDateHired.MonthCalendar.TodayButtonVisible = true;
            this.dtDateHired.Name = "dtDateHired";
            this.dtDateHired.Size = new System.Drawing.Size(132, 22);
            this.dtDateHired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtDateHired.TabIndex = 1;
            this.dtDateHired.Value = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // cboStep
            // 
            this.cboStep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboStep.ForeColor = System.Drawing.Color.Black;
            this.cboStep.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboStep, true);
            this.cboStep.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cboStep.Location = new System.Drawing.Point(237, 87);
            this.cboStep.Name = "cboStep";
            this.cboStep.Size = new System.Drawing.Size(53, 23);
            this.cboStep.TabIndex = 9;
            this.cboStep.SelectedIndexChanged += new System.EventHandler(this.cboStep_SelectedIndexChanged);
            // 
            // switchActive
            // 
            this.switchActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.switchActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.switchActive, true);
            this.switchActive.Location = new System.Drawing.Point(219, 137);
            this.switchActive.Name = "switchActive";
            this.switchActive.OffText = "INACTIVE";
            this.switchActive.OnBackColor = System.Drawing.Color.Green;
            this.switchActive.OnText = "Active";
            this.switchActive.Size = new System.Drawing.Size(98, 25);
            this.switchActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchActive.SwitchBackColor = System.Drawing.Color.MidnightBlue;
            this.switchActive.SwitchWidth = 25;
            this.switchActive.TabIndex = 2;
            this.switchActive.Value = true;
            this.switchActive.ValueObject = "Y";
            // 
            // txtPagIbig
            // 
            this.txtPagIbig.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPagIbig.Border.Class = "TextBoxBorder";
            this.txtPagIbig.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPagIbig.DisabledBackColor = System.Drawing.Color.White;
            this.txtPagIbig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagIbig.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtPagIbig, true);
            this.txtPagIbig.Location = new System.Drawing.Point(86, 73);
            this.txtPagIbig.Name = "txtPagIbig";
            this.txtPagIbig.PreventEnterBeep = true;
            this.txtPagIbig.Size = new System.Drawing.Size(199, 22);
            this.txtPagIbig.TabIndex = 13;
            // 
            // txtPhilHealth
            // 
            this.txtPhilHealth.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPhilHealth.Border.Class = "TextBoxBorder";
            this.txtPhilHealth.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPhilHealth.DisabledBackColor = System.Drawing.Color.White;
            this.txtPhilHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhilHealth.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtPhilHealth, true);
            this.txtPhilHealth.Location = new System.Drawing.Point(86, 46);
            this.txtPhilHealth.Name = "txtPhilHealth";
            this.txtPhilHealth.PreventEnterBeep = true;
            this.txtPhilHealth.Size = new System.Drawing.Size(199, 22);
            this.txtPhilHealth.TabIndex = 11;
            // 
            // txtTin
            // 
            this.txtTin.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTin.Border.Class = "TextBoxBorder";
            this.txtTin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTin.DisabledBackColor = System.Drawing.Color.White;
            this.txtTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTin.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtTin, true);
            this.txtTin.Location = new System.Drawing.Point(86, 19);
            this.txtTin.Name = "txtTin";
            this.txtTin.PreventEnterBeep = true;
            this.txtTin.Size = new System.Drawing.Size(199, 22);
            this.txtTin.TabIndex = 9;
            // 
            // txtSSS
            // 
            this.txtSSS.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSSS.Border.Class = "TextBoxBorder";
            this.txtSSS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSSS.DisabledBackColor = System.Drawing.Color.White;
            this.txtSSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSS.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtSSS, true);
            this.txtSSS.Location = new System.Drawing.Point(86, 100);
            this.txtSSS.Name = "txtSSS";
            this.txtSSS.PreventEnterBeep = true;
            this.txtSSS.Size = new System.Drawing.Size(199, 22);
            this.txtSSS.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(279, 65);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Barangay:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(135, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Town:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Province:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Address:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(141, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 152);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Info:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(11, 54);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(527, 92);
            this.labelX2.TabIndex = 106;
            this.labelX2.Text = "<font color=\"#2F3699\">\r\n<b>LASTNAME , FIRSTNAME MIDDLENAME</b><br/>\r\nJANUARY 29, " +
    "1980<br/>\r\nFemale<br/>\r\n\r\n%Address%\r\n</font>";
            this.labelX2.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboBarangay);
            this.groupBox2.Controls.Add(this.cboProvince);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboTown);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(141, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 115);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address Info:";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.pictureBox1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(132, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(575, 54);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 103;
            this.panelEx1.ThemeAware = true;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(65, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(429, 47);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "<div><h3><font color=\"#2F3699\"></font><font color=\"#6F3198\"><b>EMPLOYEE RECORD IN" +
    "FORMATION</b></font></h3>\r\n</div><div>\r\nAllows you to view and update record fro" +
    "m the database\r\n</div>";
            this.labelX1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::Winform.Properties.Resources.Money_Transfer_40px;
            this.pictureBox1.Location = new System.Drawing.Point(9, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.picImage);
            this.groupBox3.Controls.Add(this.lblNameProfile);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(10, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 122);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Personal Info";
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(6, 18);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(95, 95);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 35;
            this.picImage.TabStop = false;
            // 
            // lblNameProfile
            // 
            this.lblNameProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblNameProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNameProfile.Location = new System.Drawing.Point(107, 20);
            this.lblNameProfile.Name = "lblNameProfile";
            this.lblNameProfile.Size = new System.Drawing.Size(197, 93);
            this.lblNameProfile.TabIndex = 26;
            this.lblNameProfile.Text = "<font color=\'blue\'>\r\n<b>LASTNAME , FIRSTNAME MIDDLENAME</b> <br/>\r\nBirthdate: 25 " +
    "- April - 1980 <br/>\r\nMale <br/>\r\nFull Address Here\r\n</font>";
            this.lblNameProfile.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(149, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Department:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtExemption);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cboStep);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtSG);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dtDateHired);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cboTax);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cboPosition);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cboDepartment);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(9, 167);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 182);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other Info:";
            // 
            // txtExemption
            // 
            this.txtExemption.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtExemption.Border.Class = "TextBoxBorder";
            this.txtExemption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExemption.DisabledBackColor = System.Drawing.Color.White;
            this.txtExemption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExemption.ForeColor = System.Drawing.Color.Black;
            this.txtExemption.Location = new System.Drawing.Point(219, 143);
            this.txtExemption.Name = "txtExemption";
            this.txtExemption.PreventEnterBeep = true;
            this.txtExemption.ReadOnly = true;
            this.txtExemption.Size = new System.Drawing.Size(71, 22);
            this.txtExemption.TabIndex = 13;
            this.txtExemption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(216, 125);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Exemption:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(234, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Step";
            // 
            // txtSG
            // 
            this.txtSG.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSG.Border.Class = "TextBoxBorder";
            this.txtSG.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSG.DisabledBackColor = System.Drawing.Color.White;
            this.txtSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSG.ForeColor = System.Drawing.Color.Black;
            this.txtSG.Location = new System.Drawing.Point(202, 87);
            this.txtSG.Name = "txtSG";
            this.txtSG.PreventEnterBeep = true;
            this.txtSG.ReadOnly = true;
            this.txtSG.Size = new System.Drawing.Size(29, 22);
            this.txtSG.TabIndex = 7;
            this.txtSG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(203, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "SG";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(7, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Date Hired:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tax Exemption:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Position:";
            // 
            // FlexGridDeductions
            // 
            this.FlexGridDeductions.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlexGridDeductions.AllowEditing = false;
            this.FlexGridDeductions.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.FlexGridDeductions.ColumnInfo = resources.GetString("FlexGridDeductions.ColumnInfo");
            this.FlexGridDeductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlexGridDeductions.ExtendLastCol = true;
            this.FlexGridDeductions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FlexGridDeductions.Location = new System.Drawing.Point(0, 40);
            this.FlexGridDeductions.Name = "FlexGridDeductions";
            this.FlexGridDeductions.Rows.Count = 1;
            this.FlexGridDeductions.Rows.DefaultSize = 20;
            this.FlexGridDeductions.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.FlexGridDeductions.Size = new System.Drawing.Size(524, 408);
            this.FlexGridDeductions.StyleInfo = resources.GetString("FlexGridDeductions.StyleInfo");
            this.FlexGridDeductions.TabIndex = 0;
            this.FlexGridDeductions.DoubleClick += new System.EventHandler(this.FlexGridDeductions_DoubleClick);
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(10, 10);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = false;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(524, 477);
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 26;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.FlexGridDeductions);
            this.superTabControlPanel1.Controls.Add(this.itemPanel1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 29);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(524, 448);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAddDeduction,
            this.btnEditDeduction,
            this.btnDeleteDeduction});
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(0, 0);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.ReserveLeftSpace = false;
            this.itemPanel1.Size = new System.Drawing.Size(524, 40);
            this.itemPanel1.TabIndex = 9;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // btnAddDeduction
            // 
            this.btnAddDeduction.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddDeduction.Image = global::Winform.Properties.Resources.Add_List_30;
            this.btnAddDeduction.Name = "btnAddDeduction";
            this.btnAddDeduction.Text = "Add Deduction";
            this.btnAddDeduction.Click += new System.EventHandler(this.btnAddDeduction_Click);
            // 
            // btnEditDeduction
            // 
            this.btnEditDeduction.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditDeduction.Image = global::Winform.Properties.Resources.Edit_File_24px;
            this.btnEditDeduction.Name = "btnEditDeduction";
            this.btnEditDeduction.Text = "Edit Deduction";
            this.btnEditDeduction.Click += new System.EventHandler(this.btnEditDeduction_Click);
            // 
            // btnDeleteDeduction
            // 
            this.btnDeleteDeduction.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDeleteDeduction.Image = global::Winform.Properties.Resources.Delete_File_24px;
            this.btnDeleteDeduction.Name = "btnDeleteDeduction";
            this.btnDeleteDeduction.Text = "Delete Deduction";
            this.btnDeleteDeduction.Click += new System.EventHandler(this.btnDeleteDeduction_Click);
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Deductions";
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
            this.bar1.Size = new System.Drawing.Size(984, 39);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 35;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnOk
            // 
            this.btnOk.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnOk.Image = global::Winform.Properties.Resources.Ok_30;
            this.btnOk.Name = "btnOk";
            this.btnOk.Text = "Save Record";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCancel.Image = global::Winform.Properties.Resources.Cancel_24px;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Text = "Cancel Changes";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.switchActive);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(115, 39);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(325, 497);
            this.panel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtSSS);
            this.groupBox5.Controls.Add(this.txtPagIbig);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtPhilHealth);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtTin);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(9, 355);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(308, 134);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Reference Numbers:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(11, 100);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "SSS:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(7, 74);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 12;
            this.label13.Text = "PagIbig:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(7, 49);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 10;
            this.label12.Text = "PhilHealth:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(7, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "T.I.N.:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.superTabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(440, 39);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(544, 497);
            this.panel2.TabIndex = 37;
            // 
            // explorerBarGroupItem1
            // 
            // 
            // 
            // 
            this.explorerBarGroupItem1.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.explorerBarGroupItem1.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.BorderBottomColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupItem1.BackStyle.BorderBottomWidth = 1;
            this.explorerBarGroupItem1.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupItem1.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.BorderLeftColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupItem1.BackStyle.BorderLeftWidth = 1;
            this.explorerBarGroupItem1.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.BorderRightColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupItem1.BackStyle.BorderRightWidth = 1;
            this.explorerBarGroupItem1.BackStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.BorderTopColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupItem1.BackStyle.BorderTopWidth = 1;
            this.explorerBarGroupItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem1.CanCustomize = false;
            this.explorerBarGroupItem1.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupItem1.ExpandButtonVisible = false;
            this.explorerBarGroupItem1.Expanded = true;
            this.explorerBarGroupItem1.Name = "explorerBarGroupItem1";
            this.explorerBarGroupItem1.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.explorerBarGroupItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblSalary});
            this.explorerBarGroupItem1.Text = "Salary";
            // 
            // 
            // 
            this.explorerBarGroupItem1.TitleHotStyle.BackColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupItem1.TitleHotStyle.BackColor2 = System.Drawing.SystemColors.InactiveCaption;
            this.explorerBarGroupItem1.TitleHotStyle.CornerDiameter = 3;
            this.explorerBarGroupItem1.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem1.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem1.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem1.TitleHotStyle.TextColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.explorerBarGroupItem1.TitleStyle.BackColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupItem1.TitleStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.explorerBarGroupItem1.TitleStyle.CornerDiameter = 3;
            this.explorerBarGroupItem1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem1.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem1.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem1.TitleStyle.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // lblSalary
            // 
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Text = " ";
            this.lblSalary.ThemeAware = true;
            this.lblSalary.Click += new System.EventHandler(this.labelItem1_Click);
            // 
            // frmPayrollEmployee_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(984, 536);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPayrollEmployee_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payroll Info";
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.RecordInfoPanel, 0);
            this.Controls.SetChildIndex(this.expandableSplitter1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateHired)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexGridDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private System.Windows.Forms.ComboBox cboBarangay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboTown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboProvince;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.LabelX lblNameProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1FlexGrid.C1FlexGrid FlexGridDeductions;
        private System.Windows.Forms.ComboBox cboTax;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtDateHired;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSG;
        private System.Windows.Forms.ComboBox cboStep;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtExemption;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ButtonItem btnAddDeduction;
        private DevComponents.DotNetBar.ButtonItem btnDeleteDeduction;
        private System.Windows.Forms.PictureBox picImage;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnOk;
        private DevComponents.DotNetBar.ButtonItem btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.SwitchButton switchActive;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPagIbig;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPhilHealth;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTin;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.ButtonItem btnEditDeduction;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSSS;
        private System.Windows.Forms.Label label14;
        private DevComponents.DotNetBar.ExplorerBarGroupItem explorerBarGroupItem1;
        private DevComponents.DotNetBar.LabelItem lblSalary;
    }
}