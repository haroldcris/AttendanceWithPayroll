namespace Winform.Biometric
{
    partial class frmBiometric_Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiometric_Log));
            C1.C1Schedule.Printing.PrintStyle printStyle1 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle2 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle3 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle4 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle5 = new C1.C1Schedule.Printing.PrintStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.ImageProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.RecordInfoPanel = new DevComponents.DotNetBar.ExplorerBar();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.explorerBarGroupPicture = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem3 = new DevComponents.DotNetBar.ControlContainerItem();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.lblCameraCounter = new DevComponents.DotNetBar.LabelItem();
            this.explorerBarGroupRecordInfo = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblCreated = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.lblModified = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.c1Schedule1 = new C1.Win.C1Schedule.C1Schedule();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.dtMonthDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem10 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem5 = new DevComponents.DotNetBar.ControlContainerItem();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.controlContainerItem4 = new DevComponents.DotNetBar.ControlContainerItem();
            this.labelItem9 = new DevComponents.DotNetBar.LabelItem();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).BeginInit();
            this.RecordInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.AppointmentStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.CategoryStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ContactStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.LabelStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.OwnerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ResourceStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.StatusStorage)).BeginInit();
            this.itemPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthDate)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblName);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(10, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(864, 60);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Name Info:";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(8, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(845, 35);
            this.lblName.TabIndex = 28;
            this.lblName.Text = "Lastname:\r\n                                    <font color=\'blue\'><h5>%lastname%<" +
    "/h5></font>";
            this.lblName.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 19);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(285, 173);
            this.labelX4.TabIndex = 26;
            this.labelX4.Text = resources.GetString("labelX4.Text");
            this.labelX4.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ImageProgressBar
            // 
            // 
            // 
            // 
            this.ImageProgressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ImageProgressBar.Location = new System.Drawing.Point(28, 156);
            this.ImageProgressBar.Name = "ImageProgressBar";
            this.ImageProgressBar.Size = new System.Drawing.Size(80, 10);
            this.ImageProgressBar.TabIndex = 111;
            this.ImageProgressBar.Text = "progressBarX1";
            this.ImageProgressBar.Visible = false;
            // 
            // RecordInfoPanel
            // 
            this.RecordInfoPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.RecordInfoPanel.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.RecordInfoPanel.BackStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground2;
            this.RecordInfoPanel.BackStyle.BackColorGradientAngle = 90;
            this.RecordInfoPanel.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground;
            this.RecordInfoPanel.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RecordInfoPanel.Controls.Add(this.picImage);
            this.RecordInfoPanel.Controls.Add(this.ImageProgressBar);
            this.RecordInfoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RecordInfoPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordInfoPanel.ForeColor = System.Drawing.Color.Black;
            this.RecordInfoPanel.GroupImages = null;
            this.RecordInfoPanel.Groups.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.explorerBarGroupPicture,
            this.explorerBarGroupRecordInfo});
            this.RecordInfoPanel.Images = null;
            this.RecordInfoPanel.Location = new System.Drawing.Point(0, 28);
            this.RecordInfoPanel.MinimumSize = new System.Drawing.Size(100, 0);
            this.RecordInfoPanel.Name = "RecordInfoPanel";
            this.RecordInfoPanel.Size = new System.Drawing.Size(135, 712);
            this.RecordInfoPanel.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.RecordInfoPanel.TabIndex = 114;
            this.RecordInfoPanel.TabStop = false;
            this.RecordInfoPanel.Text = "explorerBar1";
            this.RecordInfoPanel.ThemeAware = true;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(8, 29);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(120, 120);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 108;
            this.picImage.TabStop = false;
            // 
            // explorerBarGroupPicture
            // 
            // 
            // 
            // 
            this.explorerBarGroupPicture.BackStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.explorerBarGroupPicture.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupPicture.BackStyle.BorderBottomWidth = 1;
            this.explorerBarGroupPicture.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupPicture.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupPicture.BackStyle.BorderLeftWidth = 1;
            this.explorerBarGroupPicture.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupPicture.BackStyle.BorderRightWidth = 1;
            this.explorerBarGroupPicture.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupPicture.CanCustomize = false;
            this.explorerBarGroupPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupPicture.ExpandButtonVisible = false;
            this.explorerBarGroupPicture.Expanded = true;
            this.explorerBarGroupPicture.Name = "explorerBarGroupPicture";
            this.explorerBarGroupPicture.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.explorerBarGroupPicture.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.labelItem8,
            this.labelItem6,
            this.lblCameraCounter});
            this.explorerBarGroupPicture.Text = "Profile Picture";
            // 
            // 
            // 
            this.explorerBarGroupPicture.TitleHotStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(181)))));
            this.explorerBarGroupPicture.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(93)))), ((int)(((byte)(206)))));
            this.explorerBarGroupPicture.TitleHotStyle.CornerDiameter = 3;
            this.explorerBarGroupPicture.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupPicture.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupPicture.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupPicture.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.explorerBarGroupPicture.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(181)))));
            this.explorerBarGroupPicture.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(93)))), ((int)(((byte)(206)))));
            this.explorerBarGroupPicture.TitleStyle.CornerDiameter = 3;
            this.explorerBarGroupPicture.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupPicture.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupPicture.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupPicture.TitleStyle.TextColor = System.Drawing.Color.White;
            this.explorerBarGroupPicture.XPSpecialGroup = true;
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.controlContainerItem1,
            this.controlContainerItem3});
            this.itemContainer1.ThemeAware = true;
            // 
            // 
            // 
            this.itemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.picImage;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            this.controlContainerItem1.ThemeAware = true;
            // 
            // controlContainerItem3
            // 
            this.controlContainerItem3.AllowItemResize = false;
            this.controlContainerItem3.Control = this.ImageProgressBar;
            this.controlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem3.Name = "controlContainerItem3";
            this.controlContainerItem3.ThemeAware = true;
            // 
            // labelItem8
            // 
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Text = "  ";
            this.labelItem8.ThemeAware = true;
            // 
            // labelItem6
            // 
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Text = "Camera Counter:";
            this.labelItem6.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelItem6.ThemeAware = true;
            // 
            // lblCameraCounter
            // 
            this.lblCameraCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraCounter.ForeColor = System.Drawing.Color.Blue;
            this.lblCameraCounter.Name = "lblCameraCounter";
            this.lblCameraCounter.Text = "01234567890";
            this.lblCameraCounter.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblCameraCounter.ThemeAware = true;
            // 
            // explorerBarGroupRecordInfo
            // 
            // 
            // 
            // 
            this.explorerBarGroupRecordInfo.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.explorerBarGroupRecordInfo.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupRecordInfo.BackStyle.BorderBottomColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.BackStyle.BorderBottomWidth = 1;
            this.explorerBarGroupRecordInfo.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupRecordInfo.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupRecordInfo.BackStyle.BorderLeftColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.BackStyle.BorderLeftWidth = 1;
            this.explorerBarGroupRecordInfo.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupRecordInfo.BackStyle.BorderRightColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.BackStyle.BorderRightWidth = 1;
            this.explorerBarGroupRecordInfo.BackStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupRecordInfo.BackStyle.BorderTopColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.BackStyle.BorderTopWidth = 1;
            this.explorerBarGroupRecordInfo.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupRecordInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupRecordInfo.ExpandBackColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.ExpandBorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.explorerBarGroupRecordInfo.ExpandButtonVisible = false;
            this.explorerBarGroupRecordInfo.Expanded = true;
            this.explorerBarGroupRecordInfo.ExpandForeColor = System.Drawing.SystemColors.Highlight;
            this.explorerBarGroupRecordInfo.ExpandHotBackColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.ExpandHotBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.explorerBarGroupRecordInfo.Name = "explorerBarGroupRecordInfo";
            this.explorerBarGroupRecordInfo.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.lblCreated,
            this.labelItem3,
            this.labelItem4,
            this.lblModified});
            this.explorerBarGroupRecordInfo.Text = "File Info";
            // 
            // 
            // 
            this.explorerBarGroupRecordInfo.TitleHotStyle.BackColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.TitleHotStyle.BackColor2 = System.Drawing.SystemColors.InactiveCaption;
            this.explorerBarGroupRecordInfo.TitleHotStyle.CornerDiameter = 3;
            this.explorerBarGroupRecordInfo.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupRecordInfo.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupRecordInfo.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupRecordInfo.TitleHotStyle.TextColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.explorerBarGroupRecordInfo.TitleStyle.BackColor = System.Drawing.SystemColors.Window;
            this.explorerBarGroupRecordInfo.TitleStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.explorerBarGroupRecordInfo.TitleStyle.CornerDiameter = 3;
            this.explorerBarGroupRecordInfo.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupRecordInfo.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupRecordInfo.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupRecordInfo.TitleStyle.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "Created:";
            this.labelItem1.ThemeAware = true;
            // 
            // lblCreated
            // 
            this.lblCreated.BeginGroup = true;
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.ThemeAware = true;
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "   ";
            this.labelItem3.ThemeAware = true;
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "Modified:";
            this.labelItem4.ThemeAware = true;
            // 
            // lblModified
            // 
            this.lblModified.BeginGroup = true;
            this.lblModified.Name = "lblModified";
            this.lblModified.ThemeAware = true;
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            this.controlContainerItem2.ThemeAware = true;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.ExpandableControl = this.RecordInfoPanel;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(135, 28);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(8, 712);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla;
            this.expandableSplitter1.TabIndex = 115;
            this.expandableSplitter1.TabStop = false;
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
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
            this.superTabControl1.Location = new System.Drawing.Point(7, 6);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 2;
            this.superTabControl1.Size = new System.Drawing.Size(870, 620);
            this.superTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 151;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.AutoScroll = true;
            this.superTabControlPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.superTabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTabControlPanel1.Controls.Add(this.c1Schedule1);
            this.superTabControlPanel1.Controls.Add(this.itemPanel1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControlPanel1.Location = new System.Drawing.Point(131, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.superTabControlPanel1.Size = new System.Drawing.Size(739, 620);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            this.superTabControlPanel1.ThemeAware = true;
            // 
            // c1Schedule1
            // 
            this.c1Schedule1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.c1Schedule1.CalendarInfo.CultureInfo = new System.Globalization.CultureInfo("en-PH");
            this.c1Schedule1.CalendarInfo.DateFormatString = "MM/dd/yyyy";
            this.c1Schedule1.CalendarInfo.EndDayTime = System.TimeSpan.Parse("19:00:00");
            this.c1Schedule1.CalendarInfo.StartDayTime = System.TimeSpan.Parse("07:00:00");
            this.c1Schedule1.CalendarInfo.TimeScale = System.TimeSpan.Parse("00:30:00");
            this.c1Schedule1.CalendarInfo.WeekStart = System.DayOfWeek.Sunday;
            this.c1Schedule1.CalendarInfo.WorkDays.AddRange(new System.DayOfWeek[] {
            System.DayOfWeek.Monday,
            System.DayOfWeek.Tuesday,
            System.DayOfWeek.Wednesday,
            System.DayOfWeek.Thursday,
            System.DayOfWeek.Friday});
            // 
            // 
            // 
            this.c1Schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1Schedule1.EditOptions = C1.Win.C1Schedule.EditOptions.None;
            this.c1Schedule1.GroupPageSize = 2;
            this.c1Schedule1.Location = new System.Drawing.Point(10, 60);
            this.c1Schedule1.Name = "c1Schedule1";
            printStyle1.Description = "Daily Style";
            printStyle1.PreviewImage = ((System.Drawing.Image)(resources.GetObject("printStyle1.PreviewImage")));
            printStyle1.StyleName = "Daily";
            printStyle1.StyleSource = "day.c1d";
            printStyle2.Description = "Weekly Style";
            printStyle2.PreviewImage = ((System.Drawing.Image)(resources.GetObject("printStyle2.PreviewImage")));
            printStyle2.StyleName = "Week";
            printStyle2.StyleSource = "week.c1d";
            printStyle3.Description = "Monthly Style";
            printStyle3.PreviewImage = ((System.Drawing.Image)(resources.GetObject("printStyle3.PreviewImage")));
            printStyle3.StyleName = "Month";
            printStyle3.StyleSource = "month.c1d";
            printStyle4.Description = "Details Style";
            printStyle4.PreviewImage = ((System.Drawing.Image)(resources.GetObject("printStyle4.PreviewImage")));
            printStyle4.StyleName = "Details";
            printStyle4.StyleSource = "details.c1d";
            printStyle5.Context = C1.C1Schedule.Printing.PrintContextType.Appointment;
            printStyle5.Description = "Memo Style";
            printStyle5.PreviewImage = ((System.Drawing.Image)(resources.GetObject("printStyle5.PreviewImage")));
            printStyle5.StyleName = "Memo";
            printStyle5.StyleSource = "memo.c1d";
            this.c1Schedule1.PrintInfo.PrintStyles.AddRange(new C1.C1Schedule.Printing.PrintStyle[] {
            printStyle1,
            printStyle2,
            printStyle3,
            printStyle4,
            printStyle5});
            this.c1Schedule1.ShowTitle = false;
            this.c1Schedule1.Size = new System.Drawing.Size(719, 550);
            this.c1Schedule1.TabIndex = 185;
            // 
            // 
            // 
            this.c1Schedule1.Theme.XmlDefinition = resources.GetString("resource.XmlDefinition");
            this.c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.MonthView;
            this.c1Schedule1.VisualStyle = C1.Win.C1Schedule.UI.VisualStyle.Custom;
            this.c1Schedule1.BeforeViewChange += new System.EventHandler<C1.Win.C1Schedule.BeforeViewChangeEventArgs>(this.c1Schedule1_BeforeViewChange);
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Controls.Add(this.dtMonthDate);
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(10, 10);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.ReserveLeftSpace = false;
            this.itemPanel1.Size = new System.Drawing.Size(719, 50);
            this.itemPanel1.TabIndex = 186;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // dtMonthDate
            // 
            this.dtMonthDate.AllowEmptyState = false;
            this.dtMonthDate.AutoSelectDate = true;
            // 
            // 
            // 
            this.dtMonthDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtMonthDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonthDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtMonthDate.ButtonDropDown.Visible = true;
            this.dtMonthDate.CustomFormat = "MMMM yyyy";
            this.dtMonthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMonthDate.ForeColor = System.Drawing.Color.Blue;
            this.dtMonthDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtMonthDate.IsPopupCalendarOpen = false;
            this.dtMonthDate.Location = new System.Drawing.Point(91, 3);
            this.dtMonthDate.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtMonthDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonthDate.MonthCalendar.BeginGroup = true;
            this.dtMonthDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.dtMonthDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtMonthDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtMonthDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtMonthDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtMonthDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtMonthDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtMonthDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonthDate.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.dtMonthDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtMonthDate.MonthCalendar.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtMonthDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtMonthDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtMonthDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtMonthDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonthDate.Name = "dtMonthDate";
            this.dtMonthDate.ShowUpDown = true;
            this.dtMonthDate.Size = new System.Drawing.Size(157, 26);
            this.dtMonthDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtMonthDate.TabIndex = 187;
            this.dtMonthDate.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtMonthDate.ValueChanged += new System.EventHandler(this.dtMonthDate_ValueChanged);
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem10,
            this.controlContainerItem5});
            // 
            // 
            // 
            this.itemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // labelItem10
            // 
            this.labelItem10.Name = "labelItem10";
            this.labelItem10.Text = "Log Entry Date:";
            // 
            // controlContainerItem5
            // 
            this.controlContainerItem5.AllowItemResize = false;
            this.controlContainerItem5.Control = this.dtMonthDate;
            this.controlContainerItem5.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem5.Name = "controlContainerItem5";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Image = global::Winform.Properties.Resources.Address_Book_24px;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Blue;
            this.superTabItem1.Text = "Attendance Log";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(143, 28);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(884, 80);
            this.panel1.TabIndex = 159;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.superTabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(143, 108);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel2.Size = new System.Drawing.Size(884, 632);
            this.panel2.TabIndex = 163;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // controlContainerItem4
            // 
            this.controlContainerItem4.AllowItemResize = false;
            this.controlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem4.Name = "controlContainerItem4";
            // 
            // labelItem9
            // 
            this.labelItem9.Name = "labelItem9";
            this.labelItem9.Text = "Date Entry:  ";
            // 
            // frmBiometric_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 740);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.RecordInfoPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header = "ATTENDANCE MONITORING";
            this.Name = "frmBiometric_Log";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.RecordInfoPanel, 0);
            this.Controls.SetChildIndex(this.expandableSplitter1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).EndInit();
            this.RecordInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.AppointmentStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.CategoryStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ContactStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.LabelStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.OwnerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ResourceStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.StatusStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1)).EndInit();
            this.itemPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtMonthDate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.PictureBox picImage;
        private DevComponents.DotNetBar.Controls.ProgressBarX ImageProgressBar;
        private DevComponents.DotNetBar.ExplorerBar RecordInfoPanel;
        private DevComponents.DotNetBar.ExplorerBarGroupItem explorerBarGroupPicture;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ExplorerBarGroupItem explorerBarGroupRecordInfo;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lblCreated;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.LabelItem lblModified;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem3;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.LabelItem labelItem8;
        private DevComponents.DotNetBar.LabelItem labelItem6;
        private DevComponents.DotNetBar.LabelItem lblCameraCounter;
        private C1.Win.C1Schedule.C1Schedule c1Schedule1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem4;
        private DevComponents.DotNetBar.LabelItem labelItem9;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtMonthDate;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.LabelItem labelItem10;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem5;
    }
}