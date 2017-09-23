namespace Winform.Student
{
    partial class frmStudent_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudent_Add));
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
            this.txtStudNum = new DevComponents.DotNetBar.Controls.TextBoxX();
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
            this.panel1.Controls.Add(this.txtStudNum);
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
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Student Number";
            // 
            // txtStudNum
            // 
            this.txtStudNum.AutoSelectAll = true;
            this.txtStudNum.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtStudNum.Border.Class = "TextBoxBorder";
            this.txtStudNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStudNum.DisabledBackColor = System.Drawing.Color.White;
            this.txtStudNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudNum.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtStudNum, true);
            this.txtStudNum.Location = new System.Drawing.Point(14, 26);
            this.txtStudNum.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtStudNum.Name = "txtStudNum";
            this.txtStudNum.PreventEnterBeep = true;
            this.txtStudNum.Size = new System.Drawing.Size(118, 26);
            this.txtStudNum.TabIndex = 1;
            this.txtStudNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // frmStudent_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 489);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStudent_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private DevComponents.DotNetBar.ListBoxItem listBoxItem4;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.LabelItem lblSpace;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStudNum;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
    }
}