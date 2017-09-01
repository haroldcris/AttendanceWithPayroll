namespace Winform
{
    partial class FormWithRecordInfo
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
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.RecordInfoPanel = new DevComponents.DotNetBar.ExplorerBar();
            this.BarGroupFileInfo = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.lblCreatedHeader = new DevComponents.DotNetBar.LabelItem();
            this.lblCreated = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.lblModifiedHeader = new DevComponents.DotNetBar.LabelItem();
            this.lblModified = new DevComponents.DotNetBar.LabelItem();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.RecordInfoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RecordInfoPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordInfoPanel.ForeColor = System.Drawing.Color.Black;
            this.RecordInfoPanel.GroupImages = null;
            this.RecordInfoPanel.Groups.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BarGroupFileInfo});
            this.RecordInfoPanel.Images = null;
            this.RecordInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.RecordInfoPanel.Name = "RecordInfoPanel";
            this.RecordInfoPanel.Size = new System.Drawing.Size(109, 288);
            this.RecordInfoPanel.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.RecordInfoPanel.TabIndex = 10;
            this.RecordInfoPanel.TabStop = false;
            this.RecordInfoPanel.Text = "explorerBar1";
            this.RecordInfoPanel.ThemeAware = true;
            // 
            // BarGroupFileInfo
            // 
            // 
            // 
            // 
            this.BarGroupFileInfo.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.BarGroupFileInfo.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.BarGroupFileInfo.BackStyle.BorderBottomColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.BackStyle.BorderBottomWidth = 1;
            this.BarGroupFileInfo.BackStyle.BorderColor = System.Drawing.Color.White;
            this.BarGroupFileInfo.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.BarGroupFileInfo.BackStyle.BorderLeftColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.BackStyle.BorderLeftWidth = 1;
            this.BarGroupFileInfo.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.BarGroupFileInfo.BackStyle.BorderRightColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.BackStyle.BorderRightWidth = 1;
            this.BarGroupFileInfo.BackStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.BarGroupFileInfo.BackStyle.BorderTopColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.BackStyle.BorderTopWidth = 1;
            this.BarGroupFileInfo.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BarGroupFileInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.BarGroupFileInfo.ExpandBackColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.ExpandBorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.BarGroupFileInfo.ExpandButtonVisible = false;
            this.BarGroupFileInfo.Expanded = true;
            this.BarGroupFileInfo.ExpandForeColor = System.Drawing.SystemColors.Highlight;
            this.BarGroupFileInfo.ExpandHotBackColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.ExpandHotBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.BarGroupFileInfo.Name = "BarGroupFileInfo";
            this.BarGroupFileInfo.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblCreatedHeader,
            this.lblCreated,
            this.labelItem3,
            this.lblModifiedHeader,
            this.lblModified});
            this.BarGroupFileInfo.Text = "File Info";
            // 
            // 
            // 
            this.BarGroupFileInfo.TitleHotStyle.BackColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.TitleHotStyle.BackColor2 = System.Drawing.SystemColors.InactiveCaption;
            this.BarGroupFileInfo.TitleHotStyle.CornerDiameter = 3;
            this.BarGroupFileInfo.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BarGroupFileInfo.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarGroupFileInfo.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarGroupFileInfo.TitleHotStyle.TextColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.BarGroupFileInfo.TitleStyle.BackColor = System.Drawing.SystemColors.Window;
            this.BarGroupFileInfo.TitleStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.BarGroupFileInfo.TitleStyle.CornerDiameter = 3;
            this.BarGroupFileInfo.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BarGroupFileInfo.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarGroupFileInfo.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.BarGroupFileInfo.TitleStyle.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // lblCreatedHeader
            // 
            this.lblCreatedHeader.Name = "lblCreatedHeader";
            this.lblCreatedHeader.Text = "Created:";
            this.lblCreatedHeader.ThemeAware = true;
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
            // lblModifiedHeader
            // 
            this.lblModifiedHeader.Name = "lblModifiedHeader";
            this.lblModifiedHeader.Text = "Modified:";
            this.lblModifiedHeader.ThemeAware = true;
            // 
            // lblModified
            // 
            this.lblModified.BeginGroup = true;
            this.lblModified.Name = "lblModified";
            this.lblModified.ThemeAware = true;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(229)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.RecordInfoPanel;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.Black;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.Black;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(109, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 288);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 11;
            this.expandableSplitter1.TabStop = false;
            // 
            // FormWithRecordInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 288);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.RecordInfoPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(5, 5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWithRecordInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form";
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.LabelItem lblCreatedHeader;
        private DevComponents.DotNetBar.LabelItem lblCreated;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem lblModifiedHeader;
        private DevComponents.DotNetBar.LabelItem lblModified;
        protected DevComponents.DotNetBar.ExplorerBar RecordInfoPanel;
        protected DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        protected DevComponents.DotNetBar.ExplorerBarGroupItem BarGroupFileInfo;
    }
}