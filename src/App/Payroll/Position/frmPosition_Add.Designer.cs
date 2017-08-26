namespace Winform.Payroll
{
    partial class frmPosition_Add
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.HeaderCaption.Text = "<div><h3><font color=\'blue\'><b>PAYROLL POSITION INFO</b></font></h3>\r\n</div><div>" +
    "\r\nAllows you to add and update payroll positions from the database\r\n</div>";
            // 
            // HeaderPicture
            // 
            this.HeaderPicture.Image = global::Winform.Properties.Resources.Front_Desk_40px;
            this.HeaderPicture.Location = new System.Drawing.Point(10, 3);
            this.HeaderPicture.Size = new System.Drawing.Size(59, 55);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtCode);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(16, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 124);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description:";
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
            this.txtDescription.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtDescription, true);
            this.txtDescription.Location = new System.Drawing.Point(10, 87);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PreventEnterBeep = true;
            this.txtDescription.Size = new System.Drawing.Size(454, 21);
            this.txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.AutoSelectAll = true;
            this.txtCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.ForeColor = System.Drawing.Color.Blue;
            this.highlighter1.SetHighlightOnFocus(this.txtCode, true);
            this.txtCode.Location = new System.Drawing.Point(10, 37);
            this.txtCode.Name = "txtCode";
            this.txtCode.PreventEnterBeep = true;
            this.txtCode.Size = new System.Drawing.Size(149, 21);
            this.txtCode.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Winform.Properties.Resources.Cancel_24px;
            this.btnCancel.Location = new System.Drawing.Point(416, 198);
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
            this.btnOk.Location = new System.Drawing.Point(327, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(83, 39);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Save";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // frmPosition_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 258);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosition_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payroll Position Info";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCode;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
    }
}