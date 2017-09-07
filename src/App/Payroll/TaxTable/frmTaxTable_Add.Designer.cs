namespace Winform.Payroll
{
    partial class frmTaxTable_Add
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtShort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaxId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExemption = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDependent = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExemption)).BeginInit();
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
            this.HeaderCaption.Text = "<div><h3><font color=\'blue\'>PAYROLL TAX INFO</font></h3>\r\n</div><div>\r\nAllows you" +
    " to add and update tax table from the database\r\n</div>";
            // 
            // HeaderPicture
            // 
            this.HeaderPicture.Image = global::Winform.Properties.Resources.Customs_Officer_40px;
            this.HeaderPicture.Location = new System.Drawing.Point(10, 3);
            this.HeaderPicture.Size = new System.Drawing.Size(59, 48);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtShort);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtTaxId);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(10, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 171);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // txtShort
            // 
            this.txtShort.AutoSelectAll = true;
            this.txtShort.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtShort.Border.Class = "TextBoxBorder";
            this.txtShort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtShort.DisabledBackColor = System.Drawing.Color.White;
            this.txtShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShort.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.txtShort, true);
            this.txtShort.Location = new System.Drawing.Point(10, 86);
            this.txtShort.Name = "txtShort";
            this.txtShort.PreventEnterBeep = true;
            this.txtShort.Size = new System.Drawing.Size(279, 21);
            this.txtShort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSelectAll = true;
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.DisabledBackColor = System.Drawing.Color.White;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.txtDescription, true);
            this.txtDescription.Location = new System.Drawing.Point(10, 130);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PreventEnterBeep = true;
            this.txtDescription.Size = new System.Drawing.Size(279, 21);
            this.txtDescription.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Short Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tax Id:";
            // 
            // txtTaxId
            // 
            this.txtTaxId.AutoSelectAll = true;
            this.txtTaxId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTaxId.Border.Class = "TextBoxBorder";
            this.txtTaxId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTaxId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxId.DisabledBackColor = System.Drawing.Color.White;
            this.txtTaxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxId.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.txtTaxId, true);
            this.txtTaxId.Location = new System.Drawing.Point(10, 37);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.PreventEnterBeep = true;
            this.txtTaxId.Size = new System.Drawing.Size(43, 21);
            this.txtTaxId.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Winform.Properties.Resources.Cancel_24px;
            this.btnCancel.Location = new System.Drawing.Point(374, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowSubItems = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 39);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
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
            this.btnOk.Location = new System.Drawing.Point(285, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(83, 39);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Done";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtExemption);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboDependent);
            this.groupBox1.Location = new System.Drawing.Point(316, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 171);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Exemption:";
            // 
            // txtExemption
            // 
            this.txtExemption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExemption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExemption.Location = new System.Drawing.Point(15, 82);
            this.txtExemption.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtExemption.Name = "txtExemption";
            this.txtExemption.Size = new System.Drawing.Size(122, 22);
            this.txtExemption.TabIndex = 3;
            this.txtExemption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExemption.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "No. of Dependent/s:";
            // 
            // cboDependent
            // 
            this.cboDependent.AutoCompleteCustomSource.AddRange(new string[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cboDependent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDependent.DisplayMember = "Text";
            this.cboDependent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDependent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDependent.ForeColor = System.Drawing.Color.Black;
            this.cboDependent.FormattingEnabled = true;
            this.cboDependent.ItemHeight = 16;
            this.cboDependent.Location = new System.Drawing.Point(15, 37);
            this.cboDependent.Name = "cboDependent";
            this.cboDependent.Size = new System.Drawing.Size(122, 22);
            this.cboDependent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDependent.TabIndex = 1;
            // 
            // frmTaxTable_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaxTable_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payroll Tax Info";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExemption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTaxId;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtExemption;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDependent;
        private DevComponents.DotNetBar.Controls.TextBoxX txtShort;
    }
}