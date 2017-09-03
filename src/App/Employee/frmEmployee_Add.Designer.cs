namespace Winform.Employee
{
    partial class frmEmployee_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee_Add));
            this.picImage = new System.Windows.Forms.PictureBox();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnOk = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnContactsNew = new DevComponents.DotNetBar.ButtonX();
            this.btnContactsSelect = new DevComponents.DotNetBar.ButtonX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCivilStatus = new System.Windows.Forms.ComboBox();
            this.txtWeight = new DevComponents.Editors.DoubleInput();
            this.txtHeight = new DevComponents.Editors.DoubleInput();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCitizenship = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.listBoxItem1 = new DevComponents.DotNetBar.ListBoxItem();
            this.listBoxItem2 = new DevComponents.DotNetBar.ListBoxItem();
            this.listBoxItem3 = new DevComponents.DotNetBar.ListBoxItem();
            this.listBoxItem4 = new DevComponents.DotNetBar.ListBoxItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.lblSpace = new DevComponents.DotNetBar.LabelItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).BeginInit();
            this.RecordInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
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
            this.RecordInfoPanel.Controls.Add(this.picImage);
            this.RecordInfoPanel.Location = new System.Drawing.Point(0, 39);
            this.RecordInfoPanel.Size = new System.Drawing.Size(172, 450);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.Location = new System.Drawing.Point(172, 39);
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 450);
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
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(10, 29);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(152, 152);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 37;
            this.picImage.TabStop = false;
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
            this.bar1.Size = new System.Drawing.Size(534, 39);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 36;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnContactsNew);
            this.groupBox3.Controls.Add(this.btnContactsSelect);
            this.groupBox3.Controls.Add(this.lblName);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(11, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 211);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Name Info:";
            // 
            // btnContactsNew
            // 
            this.btnContactsNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnContactsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContactsNew.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnContactsNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContactsNew.Image = global::Winform.Properties.Resources.Add_List_16;
            this.btnContactsNew.Location = new System.Drawing.Point(180, 12);
            this.btnContactsNew.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnContactsNew.Name = "btnContactsNew";
            this.btnContactsNew.ShowSubItems = false;
            this.btnContactsNew.Size = new System.Drawing.Size(61, 22);
            this.btnContactsNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnContactsNew.TabIndex = 29;
            this.btnContactsNew.Text = "New...";
            this.btnContactsNew.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnContactsNew.Click += new System.EventHandler(this.btnContactsNew_Click);
            // 
            // btnContactsSelect
            // 
            this.btnContactsSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnContactsSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContactsSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnContactsSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContactsSelect.Image = global::Winform.Properties.Resources.Open_16px;
            this.btnContactsSelect.Location = new System.Drawing.Point(242, 12);
            this.btnContactsSelect.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnContactsSelect.Name = "btnContactsSelect";
            this.btnContactsSelect.ShowSubItems = false;
            this.btnContactsSelect.Size = new System.Drawing.Size(69, 22);
            this.btnContactsSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnContactsSelect.TabIndex = 27;
            this.btnContactsSelect.Text = "Select...";
            this.btnContactsSelect.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnContactsSelect.Click += new System.EventHandler(this.btnContactsSelect_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(302, 169);
            this.lblName.TabIndex = 28;
            this.lblName.Text = resources.GetString("lblName.Text");
            this.lblName.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEmpNum);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(178, 39);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(356, 450);
            this.panel1.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Employee Number";
            // 
            // txtEmpNum
            // 
            this.txtEmpNum.AutoSelectAll = true;
            this.txtEmpNum.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEmpNum.Border.Class = "TextBoxBorder";
            this.txtEmpNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmpNum.DisabledBackColor = System.Drawing.Color.White;
            this.txtEmpNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpNum.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtEmpNum, true);
            this.txtEmpNum.Location = new System.Drawing.Point(14, 26);
            this.txtEmpNum.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtEmpNum.Name = "txtEmpNum";
            this.txtEmpNum.PreventEnterBeep = true;
            this.txtEmpNum.Size = new System.Drawing.Size(118, 26);
            this.txtEmpNum.TabIndex = 1;
            this.txtEmpNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboCivilStatus);
            this.groupBox1.Controls.Add(this.txtWeight);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCitizenship);
            this.groupBox1.Location = new System.Drawing.Point(11, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 146);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Info:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(7, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 185;
            this.label11.Text = "Civil Status";
            // 
            // cboCivilStatus
            // 
            this.cboCivilStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCivilStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCivilStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboCivilStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCivilStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCivilStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCivilStatus.ForeColor = System.Drawing.Color.Blue;
            this.cboCivilStatus.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboCivilStatus, true);
            this.cboCivilStatus.Items.AddRange(new object[] {
            "Single",
            "Married",
            "Annulled",
            "Widowed",
            "Separated"});
            this.cboCivilStatus.Location = new System.Drawing.Point(108, 20);
            this.cboCivilStatus.Name = "cboCivilStatus";
            this.cboCivilStatus.Size = new System.Drawing.Size(167, 24);
            this.cboCivilStatus.TabIndex = 186;
            // 
            // txtWeight
            // 
            this.txtWeight.AutoOverwrite = true;
            // 
            // 
            // 
            this.txtWeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtWeight, true);
            this.txtWeight.Increment = 1D;
            this.txtWeight.Location = new System.Drawing.Point(108, 114);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ShowUpDown = true;
            this.txtWeight.Size = new System.Drawing.Size(90, 22);
            this.txtWeight.TabIndex = 184;
            // 
            // txtHeight
            // 
            this.txtHeight.AutoOverwrite = true;
            // 
            // 
            // 
            this.txtHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtHeight, true);
            this.txtHeight.Increment = 1D;
            this.txtHeight.Location = new System.Drawing.Point(108, 80);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ShowUpDown = true;
            this.txtHeight.Size = new System.Drawing.Size(90, 22);
            this.txtHeight.TabIndex = 183;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 182;
            this.label1.Text = "Height (m):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 179;
            this.label2.Text = "Weight (kg):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 180;
            this.label3.Text = "Citizenship:";
            // 
            // txtCitizenship
            // 
            this.txtCitizenship.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCitizenship.Border.Class = "TextBoxBorder";
            this.txtCitizenship.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCitizenship.DisabledBackColor = System.Drawing.Color.White;
            this.txtCitizenship.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCitizenship.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtCitizenship, true);
            this.txtCitizenship.Location = new System.Drawing.Point(108, 50);
            this.txtCitizenship.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCitizenship.Name = "txtCitizenship";
            this.txtCitizenship.PreventEnterBeep = true;
            this.txtCitizenship.Size = new System.Drawing.Size(169, 22);
            this.txtCitizenship.TabIndex = 181;
            this.txtCitizenship.Text = "Filipino";
            // 
            // listBoxItem1
            // 
            this.listBoxItem1.Image = global::Winform.Properties.Resources.Phone_16px;
            this.listBoxItem1.Name = "listBoxItem1";
            this.listBoxItem1.Text = "091234567890";
            // 
            // listBoxItem2
            // 
            this.listBoxItem2.Image = global::Winform.Properties.Resources.Phone_16px;
            this.listBoxItem2.Name = "listBoxItem2";
            this.listBoxItem2.Text = "Item 2";
            // 
            // listBoxItem3
            // 
            this.listBoxItem3.Name = "listBoxItem3";
            this.listBoxItem3.Text = "Item 3";
            // 
            // listBoxItem4
            // 
            this.listBoxItem4.IsSelected = true;
            this.listBoxItem4.Name = "listBoxItem4";
            this.listBoxItem4.Text = "Item 4";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.picImage;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            this.controlContainerItem1.ThemeAware = true;
            // 
            // lblSpace
            // 
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Text = " ";
            this.lblSpace.ThemeAware = true;
            // 
            // highlighter1
            // 
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // frmEmployee_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 489);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEmployee_Add";
            this.Text = "Employee";
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.RecordInfoPanel, 0);
            this.Controls.SetChildIndex(this.expandableSplitter1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).EndInit();
            this.RecordInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnOk;
        private DevComponents.DotNetBar.ButtonItem btnCancel;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.ButtonX btnContactsSelect;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.ButtonX btnContactsNew;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ListBoxItem listBoxItem1;
        private DevComponents.DotNetBar.ListBoxItem listBoxItem2;
        private DevComponents.DotNetBar.ListBoxItem listBoxItem3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboCivilStatus;
        private DevComponents.Editors.DoubleInput txtWeight;
        private DevComponents.Editors.DoubleInput txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCitizenship;
        private DevComponents.DotNetBar.ListBoxItem listBoxItem4;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.LabelItem lblSpace;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmpNum;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
    }
}