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
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.txtMi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSpouseLastname = new DevComponents.DotNetBar.Controls.TextBoxX();
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
            this.ImageProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.label20 = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthdate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(296, 5);
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
            this.txtId.Location = new System.Drawing.Point(299, 22);
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
            "SR.",
            "JR.",
            "JR.II",
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
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.highlighter1.SetHighlightOnFocus(this.btnCancel, true);
            this.btnCancel.Image = global::Winform.Properties.Resources.Cancel_24px;
            this.btnCancel.Location = new System.Drawing.Point(723, 258);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowSubItems = false;
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highlighter1.SetHighlightOnFocus(this.btnOk, true);
            this.btnOk.Image = global::Winform.Properties.Resources.Ok_24px;
            this.btnOk.Location = new System.Drawing.Point(615, 258);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(100, 36);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Save";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            // txtSpouseLastname
            // 
            this.txtSpouseLastname.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSpouseLastname.Border.Class = "TextBoxBorder";
            this.txtSpouseLastname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSpouseLastname.DisabledBackColor = System.Drawing.Color.White;
            this.txtSpouseLastname.Enabled = false;
            this.txtSpouseLastname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpouseLastname.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtSpouseLastname, true);
            this.txtSpouseLastname.Location = new System.Drawing.Point(83, 74);
            this.txtSpouseLastname.Margin = new System.Windows.Forms.Padding(4);
            this.txtSpouseLastname.Name = "txtSpouseLastname";
            this.txtSpouseLastname.PreventEnterBeep = true;
            this.txtSpouseLastname.Size = new System.Drawing.Size(199, 22);
            this.txtSpouseLastname.TabIndex = 3;
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
            this.txtImageFile.Location = new System.Drawing.Point(142, 185);
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
            this.groupBox1.Controls.Add(this.txtSpouseLastname);
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
            this.groupBox1.Location = new System.Drawing.Point(299, 51);
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
            this.lblSpouse.Size = new System.Drawing.Size(185, 14);
            this.lblSpouse.TabIndex = 2;
            this.lblSpouse.Text = "Spouse Lastname (If applicable):";
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
            this.groupBox2.Location = new System.Drawing.Point(598, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Birth Info:";
            // 
            // ImageProgressBar
            // 
            // 
            // 
            // 
            this.ImageProgressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ImageProgressBar.Location = new System.Drawing.Point(154, 65);
            this.ImageProgressBar.Name = "ImageProgressBar";
            this.ImageProgressBar.Size = new System.Drawing.Size(125, 19);
            this.ImageProgressBar.TabIndex = 110;
            this.ImageProgressBar.Text = "progressBarX1";
            this.ImageProgressBar.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(139, 166);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 15);
            this.label20.TabIndex = 7;
            this.label20.Text = "Image Filename:";
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(139, 4);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(152, 152);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 107;
            this.picImage.TabStop = false;
            // 
            // frmContacts_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(835, 304);
            this.Controls.Add(this.ImageProgressBar);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtImageFile);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Blue;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmContacts_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contact Information";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.picImage, 0);
            this.Controls.SetChildIndex(this.txtImageFile, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.ImageProgressBar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthdate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtId;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastname;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtSpouseLastname;
        private System.Windows.Forms.Label lblSpouse;
        private DevComponents.DotNetBar.Controls.ProgressBarX ImageProgressBar;
        private System.Windows.Forms.Label label20;
        private DevComponents.DotNetBar.Controls.TextBoxX txtImageFile;
        private System.Windows.Forms.PictureBox picImage;
    }
}