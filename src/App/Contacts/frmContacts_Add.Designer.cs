namespace Winform.Contacts
{
    partial class frmContacts_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContacts_Add));
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLastname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.cboTown = new System.Windows.Forms.ComboBox();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.txtFirstname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMiddlename = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboNameExtension = new System.Windows.Forms.ComboBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.dtBirthdate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtMi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMaidenMiddlename = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtImageFile = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSpouse = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnOk = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtContact = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lstContacts = new DevComponents.DotNetBar.ListBoxAdv();
            this.btnDeleteNumber = new DevComponents.DotNetBar.ButtonX();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picImage = new System.Windows.Forms.PictureBox();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.lblCameraCounter = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.lblSpace = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).BeginInit();
            this.RecordInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthdate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // RecordInfoPanel
            // 
            this.RecordInfoPanel.AllowUserCustomize = false;
            // 
            // 
            // 
            this.RecordInfoPanel.BackStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground2;
            this.RecordInfoPanel.BackStyle.BackColorGradientAngle = 90;
            this.RecordInfoPanel.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground;
            this.RecordInfoPanel.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RecordInfoPanel.Controls.Add(this.picImage);
            this.RecordInfoPanel.Controls.Add(this.txtImageFile);
            this.RecordInfoPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.RecordInfoPanel.Location = new System.Drawing.Point(0, 39);
            this.RecordInfoPanel.Size = new System.Drawing.Size(172, 491);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.Location = new System.Drawing.Point(172, 39);
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 491);
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
            this.BarImage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.controlContainerItem1,
            this.lblCameraCounter,
            this.controlContainerItem2,
            this.lblSpace});
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact Id:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtId.Border.Class = "TextBoxBorder";
            this.txtId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtId.DisabledBackColor = System.Drawing.Color.White;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.txtId, true);
            this.txtId.Location = new System.Drawing.Point(12, 28);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.PreventEnterBeep = true;
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(61, 24);
            this.txtId.TabIndex = 1;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLastname
            // 
            this.txtLastname.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLastname.Border.Class = "TextBoxBorder";
            this.txtLastname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLastname.DisabledBackColor = System.Drawing.Color.White;
            this.txtLastname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastname.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtLastname, true);
            this.txtLastname.Location = new System.Drawing.Point(83, 104);
            this.txtLastname.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.PreventEnterBeep = true;
            this.txtLastname.Size = new System.Drawing.Size(199, 22);
            this.txtLastname.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lastname:";
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // cboCountry
            // 
            this.cboCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCountry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCountry.ForeColor = System.Drawing.Color.Blue;
            this.cboCountry.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboCountry, true);
            this.cboCountry.Location = new System.Drawing.Point(75, 63);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(139, 22);
            this.cboCountry.TabIndex = 3;
            // 
            // cboTown
            // 
            this.cboTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTown.ForeColor = System.Drawing.Color.Blue;
            this.cboTown.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboTown, true);
            this.cboTown.Location = new System.Drawing.Point(75, 132);
            this.cboTown.Name = "cboTown";
            this.cboTown.Size = new System.Drawing.Size(139, 22);
            this.cboTown.TabIndex = 7;
            // 
            // cboProvince
            // 
            this.cboProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProvince.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvince.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboProvince.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvince.ForeColor = System.Drawing.Color.Blue;
            this.cboProvince.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboProvince, true);
            this.cboProvince.Items.AddRange(new object[] {
            "Pampanga",
            "Bulacan",
            "Nueva Ecija",
            "Manila",
            "Makati"});
            this.cboProvince.Location = new System.Drawing.Point(75, 97);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(139, 22);
            this.cboProvince.TabIndex = 5;
            // 
            // txtFirstname
            // 
            this.txtFirstname.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFirstname.Border.Class = "TextBoxBorder";
            this.txtFirstname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstname.DisabledBackColor = System.Drawing.Color.White;
            this.txtFirstname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstname.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtFirstname, true);
            this.txtFirstname.Location = new System.Drawing.Point(83, 138);
            this.txtFirstname.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.PreventEnterBeep = true;
            this.txtFirstname.Size = new System.Drawing.Size(199, 22);
            this.txtFirstname.TabIndex = 7;
            // 
            // txtMiddlename
            // 
            this.txtMiddlename.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMiddlename.Border.Class = "TextBoxBorder";
            this.txtMiddlename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMiddlename.DisabledBackColor = System.Drawing.Color.White;
            this.txtMiddlename.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddlename.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtMiddlename, true);
            this.txtMiddlename.Location = new System.Drawing.Point(83, 173);
            this.txtMiddlename.Margin = new System.Windows.Forms.Padding(4);
            this.txtMiddlename.Name = "txtMiddlename";
            this.txtMiddlename.PreventEnterBeep = true;
            this.txtMiddlename.Size = new System.Drawing.Size(130, 22);
            this.txtMiddlename.TabIndex = 9;
            this.txtMiddlename.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMiddlename_KeyUp);
            // 
            // cboNameExtension
            // 
            this.cboNameExtension.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNameExtension.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNameExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboNameExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNameExtension.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboNameExtension.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNameExtension.ForeColor = System.Drawing.Color.Blue;
            this.cboNameExtension.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboNameExtension, true);
            this.cboNameExtension.Items.AddRange(new object[] {
            "",
            "Sr.",
            "Jr.",
            "Jr.II",
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "IX",
            "X"});
            this.cboNameExtension.Location = new System.Drawing.Point(83, 207);
            this.cboNameExtension.Name = "cboNameExtension";
            this.cboNameExtension.Size = new System.Drawing.Size(130, 22);
            this.cboNameExtension.TabIndex = 13;
            // 
            // cboGender
            // 
            this.cboGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboGender.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGender.ForeColor = System.Drawing.Color.Blue;
            this.cboGender.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboGender, true);
            this.cboGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cboGender.Location = new System.Drawing.Point(83, 26);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(130, 22);
            this.cboGender.TabIndex = 1;
            this.cboGender.SelectedIndexChanged += new System.EventHandler(this.cboGender_SelectedIndexChanged);
            // 
            // dtBirthdate
            // 
            this.dtBirthdate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtBirthdate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtBirthdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthdate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtBirthdate.ButtonDropDown.Visible = true;
            this.dtBirthdate.CustomFormat = "MMM - dd - yyyy";
            this.dtBirthdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBirthdate.ForeColor = System.Drawing.Color.Blue;
            this.dtBirthdate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.highlighter1.SetHighlightOnFocus(this.dtBirthdate, true);
            this.dtBirthdate.IsPopupCalendarOpen = false;
            this.dtBirthdate.Location = new System.Drawing.Point(75, 29);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtBirthdate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthdate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtBirthdate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtBirthdate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtBirthdate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtBirthdate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtBirthdate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtBirthdate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtBirthdate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtBirthdate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthdate.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtBirthdate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtBirthdate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtBirthdate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtBirthdate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthdate.MonthCalendar.TodayButtonVisible = true;
            this.dtBirthdate.Name = "dtBirthdate";
            this.dtBirthdate.Size = new System.Drawing.Size(139, 22);
            this.dtBirthdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtBirthdate.TabIndex = 1;
            this.dtBirthdate.Value = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // txtMi
            // 
            this.txtMi.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMi.Border.Class = "TextBoxBorder";
            this.txtMi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMi.DisabledBackColor = System.Drawing.Color.White;
            this.txtMi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMi.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtMi, true);
            this.txtMi.Location = new System.Drawing.Point(248, 172);
            this.txtMi.Margin = new System.Windows.Forms.Padding(4);
            this.txtMi.Name = "txtMi";
            this.txtMi.PreventEnterBeep = true;
            this.txtMi.Size = new System.Drawing.Size(34, 22);
            this.txtMi.TabIndex = 11;
            this.txtMi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaidenMiddlename
            // 
            this.txtMaidenMiddlename.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMaidenMiddlename.Border.Class = "TextBoxBorder";
            this.txtMaidenMiddlename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaidenMiddlename.DisabledBackColor = System.Drawing.Color.White;
            this.txtMaidenMiddlename.Enabled = false;
            this.txtMaidenMiddlename.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaidenMiddlename.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtMaidenMiddlename, true);
            this.txtMaidenMiddlename.Location = new System.Drawing.Point(83, 74);
            this.txtMaidenMiddlename.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaidenMiddlename.Name = "txtMaidenMiddlename";
            this.txtMaidenMiddlename.PreventEnterBeep = true;
            this.txtMaidenMiddlename.Size = new System.Drawing.Size(199, 22);
            this.txtMaidenMiddlename.TabIndex = 3;
            // 
            // txtImageFile
            // 
            this.txtImageFile.AutoSelectAll = true;
            this.txtImageFile.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtImageFile.Border.Class = "TextBoxBorder";
            this.txtImageFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtImageFile.ButtonCustom.Image = global::Winform.Properties.Resources.Camera_16px;
            this.txtImageFile.ButtonCustom.Visible = true;
            this.txtImageFile.ButtonCustom2.Visible = true;
            this.txtImageFile.DisabledBackColor = System.Drawing.Color.White;
            this.txtImageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageFile.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtImageFile, true);
            this.txtImageFile.Location = new System.Drawing.Point(11, 198);
            this.txtImageFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.PreventEnterBeep = true;
            this.txtImageFile.ReadOnly = true;
            this.txtImageFile.Size = new System.Drawing.Size(149, 22);
            this.txtImageFile.TabIndex = 8;
            this.txtImageFile.ButtonCustomClick += new System.EventHandler(this.txtImageFile_ButtonCustomClick);
            this.txtImageFile.ButtonCustom2Click += new System.EventHandler(this.txtImageFile_ButtonCustom2Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(8, 66);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "Country:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Town:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Province:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 141);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "Firstname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Middlename:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 210);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Extension:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaidenMiddlename);
            this.groupBox1.Controls.Add(this.lblSpouse);
            this.groupBox1.Controls.Add(this.txtMi);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboGender);
            this.groupBox1.Controls.Add(this.txtLastname);
            this.groupBox1.Controls.Add(this.cboNameExtension);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMiddlename);
            this.groupBox1.Controls.Add(this.txtFirstname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(13, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 243);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name Information (Maiden Name):";
            // 
            // lblSpouse
            // 
            this.lblSpouse.AutoSize = true;
            this.lblSpouse.Enabled = false;
            this.lblSpouse.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpouse.ForeColor = System.Drawing.Color.Black;
            this.lblSpouse.Location = new System.Drawing.Point(80, 56);
            this.lblSpouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpouse.Name = "lblSpouse";
            this.lblSpouse.Size = new System.Drawing.Size(182, 14);
            this.lblSpouse.TabIndex = 2;
            this.lblSpouse.Text = "Maiden Middlename (If Married):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(218, 176);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 14);
            this.label11.TabIndex = 10;
            this.label11.Text = "M.I.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(8, 29);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Gender:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(8, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Birthdate:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboCountry);
            this.groupBox2.Controls.Add(this.cboProvince);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.dtBirthdate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboTown);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(13, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Birth Info:";
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
            this.bar1.Size = new System.Drawing.Size(693, 39);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 111;
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
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(178, 39);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(515, 491);
            this.panel1.TabIndex = 112;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtContact);
            this.groupBox3.Controls.Add(this.lstContacts);
            this.groupBox3.Controls.Add(this.btnDeleteNumber);
            this.groupBox3.Location = new System.Drawing.Point(312, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 243);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contact Numbers:";
            // 
            // txtContact
            // 
            this.txtContact.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtContact.Border.Class = "TextBoxBorder";
            this.txtContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtContact.ButtonCustom.Image = global::Winform.Properties.Resources.Plus_16px;
            this.txtContact.ButtonCustom.Visible = true;
            this.txtContact.DisabledBackColor = System.Drawing.Color.White;
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.ForeColor = System.Drawing.Color.Black;
            this.txtContact.Location = new System.Drawing.Point(24, 26);
            this.txtContact.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtContact.Name = "txtContact";
            this.txtContact.PreventEnterBeep = true;
            this.txtContact.Size = new System.Drawing.Size(151, 22);
            this.txtContact.TabIndex = 128;
            this.txtContact.ButtonCustomClick += new System.EventHandler(this.btnAddContacts_Click);
            this.txtContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContact_KeyDown);
            // 
            // lstContacts
            // 
            this.lstContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContacts.AutoScroll = true;
            // 
            // 
            // 
            this.lstContacts.BackgroundStyle.Class = "ListBoxAdv";
            this.lstContacts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lstContacts.ContainerControlProcessDialogKey = true;
            this.lstContacts.DragDropSupport = true;
            this.lstContacts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.lstContacts.Location = new System.Drawing.Point(24, 56);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(151, 149);
            this.lstContacts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lstContacts.TabIndex = 142;
            this.lstContacts.Text = "listBoxAdv1";
            // 
            // btnDeleteNumber
            // 
            this.btnDeleteNumber.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteNumber.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDeleteNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteNumber.Image = global::Winform.Properties.Resources.Cancel_16;
            this.btnDeleteNumber.Location = new System.Drawing.Point(100, 213);
            this.btnDeleteNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeleteNumber.Name = "btnDeleteNumber";
            this.btnDeleteNumber.ShowSubItems = false;
            this.btnDeleteNumber.Size = new System.Drawing.Size(75, 22);
            this.btnDeleteNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteNumber.TabIndex = 143;
            this.btnDeleteNumber.Text = "Delete";
            this.btnDeleteNumber.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnDeleteNumber.ThemeAware = true;
            this.btnDeleteNumber.Click += new System.EventHandler(this.btnDeleteNumber_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Phone");
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(10, 29);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(152, 152);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 113;
            this.picImage.TabStop = false;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.picImage;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            this.controlContainerItem1.ThemeAware = true;
            // 
            // lblCameraCounter
            // 
            this.lblCameraCounter.Name = "lblCameraCounter";
            this.lblCameraCounter.Text = "Image File";
            this.lblCameraCounter.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblCameraCounter.ThemeAware = true;
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.Control = this.txtImageFile;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            this.controlContainerItem2.ThemeAware = true;
            // 
            // lblSpace
            // 
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Text = " ";
            this.lblSpace.ThemeAware = true;
            // 
            // frmContacts_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Blue;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmContacts_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contact Information";
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.RecordInfoPanel, 0);
            this.Controls.SetChildIndex(this.expandableSplitter1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).EndInit();
            this.RecordInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthdate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtId;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastname;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboTown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboProvince;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMiddlename;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNameExtension;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboGender;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtBirthdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMi;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaidenMiddlename;
        private System.Windows.Forms.Label lblSpouse;
        private DevComponents.DotNetBar.Controls.TextBoxX txtImageFile;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnOk;
        private DevComponents.DotNetBar.ButtonItem btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtContact;
        private DevComponents.DotNetBar.ListBoxAdv lstContacts;
        private DevComponents.DotNetBar.ButtonX btnDeleteNumber;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picImage;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.LabelItem lblCameraCounter;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.LabelItem lblSpace;
    }
}