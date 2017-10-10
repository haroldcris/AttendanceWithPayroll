namespace Winform.SchoolYear.Section
{
    partial class frmSectionSelector
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnOk = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.SectionViewer = new Winform.Controls.ucSectionViewer();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.BatchViewer = new SmartApp.UC.ucFullBatchViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
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
            this.bar1.Size = new System.Drawing.Size(576, 39);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 37;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnOk
            // 
            this.btnOk.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnOk.Image = global::Winform.Properties.Resources.Ok_30;
            this.btnOk.Name = "btnOk";
            this.btnOk.Text = "Select";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCancel.Image = global::Winform.Properties.Resources.Cancel_24px;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 269);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(576, 24);
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 38;
            this.panelEx1.Text = "Select Section Below";
            // 
            // SectionViewer
            // 
            this.SectionViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SectionViewer.IsDirty = false;
            this.SectionViewer.Location = new System.Drawing.Point(0, 293);
            this.SectionViewer.Name = "SectionViewer";
            this.SectionViewer.Size = new System.Drawing.Size(576, 117);
            this.SectionViewer.TabIndex = 1;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter1.Expandable = false;
            this.expandableSplitter1.ExpandableControl = this.BatchViewer;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.Black;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.Black;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 263);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(576, 6);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 2;
            this.expandableSplitter1.TabStop = false;
            // 
            // BatchViewer
            // 
            this.BatchViewer.Dock = System.Windows.Forms.DockStyle.Top;
            this.BatchViewer.Location = new System.Drawing.Point(0, 39);
            this.BatchViewer.Name = "BatchViewer";
            this.BatchViewer.Size = new System.Drawing.Size(576, 224);
            this.BatchViewer.TabIndex = 0;
            // 
            // frmSectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 410);
            this.Controls.Add(this.SectionViewer);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.BatchViewer);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSectionSelector";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Section Selector";
            this.Load += new System.EventHandler(this.frmSectionSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SmartApp.UC.ucFullBatchViewer BatchViewer;
        private Controls.ucSectionViewer SectionViewer;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnOk;
        private DevComponents.DotNetBar.ButtonItem btnCancel;
        private DevComponents.DotNetBar.PanelEx panelEx1;
    }
}