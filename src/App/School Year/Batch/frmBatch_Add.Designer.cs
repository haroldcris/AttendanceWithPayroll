namespace Winform.SchoolYear
{
    partial class frmBatch_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatch_Add));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtBatchName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighterError = new DevComponents.DotNetBar.Validator.Highlighter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.RecordInfoPanel.Size = new System.Drawing.Size(109, 204);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 204);
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
            this.BarImage.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.highlighter1.SetHighlightOnFocus(this.btnCancel, true);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(284, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowSubItems = false;
            this.btnCancel.Size = new System.Drawing.Size(101, 39);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
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
            this.btnOk.Image = global::Winform.Properties.Resources.Ok_30;
            this.btnOk.Location = new System.Drawing.Point(177, 153);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(101, 39);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Done";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Semester:";
            // 
            // cboSemester
            // 
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cboSemester, true);
            this.cboSemester.Items.AddRange(new object[] {
            "1st Semester",
            "2nd Semester"});
            this.cboSemester.Location = new System.Drawing.Point(75, 74);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(125, 23);
            this.cboSemester.TabIndex = 3;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // txtBatchName
            // 
            this.txtBatchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtBatchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBatchName.AutoSelectAll = true;
            this.txtBatchName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBatchName.Border.Class = "TextBoxBorder";
            this.txtBatchName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBatchName.DisabledBackColor = System.Drawing.Color.White;
            this.txtBatchName.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.txtBatchName, true);
            this.txtBatchName.Location = new System.Drawing.Point(75, 33);
            this.txtBatchName.Name = "txtBatchName";
            this.txtBatchName.PreventEnterBeep = true;
            this.txtBatchName.Size = new System.Drawing.Size(122, 21);
            this.txtBatchName.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighterError
            // 
            this.highlighterError.ContainerControl = this;
            this.highlighterError.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.highlighterError.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBatchName);
            this.groupBox1.Controls.Add(this.cboSemester);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(121, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Info:";
            // 
            // frmBatch_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(397, 204);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBatch_Add";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Batch Info";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.RecordInfoPanel, 0);
            this.Controls.SetChildIndex(this.expandableSplitter1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RecordInfoPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSemester;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighterError;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBatchName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}