namespace Winform.SchoolYear
{
    partial class frmOfferedClass_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOfferedClass_Add));
            this.btnSections = new System.Windows.Forms.Button();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.cboSubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSections
            // 
            this.btnSections.Location = new System.Drawing.Point(192, 84);
            this.btnSections.Name = "btnSections";
            this.btnSections.Size = new System.Drawing.Size(56, 23);
            this.btnSections.TabIndex = 14;
            this.btnSections.Text = "Select...";
            this.btnSections.UseVisualStyleBackColor = true;
            this.btnSections.Click += new System.EventHandler(this.btnSections_Click);
            // 
            // txtSection
            // 
            this.txtSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.ForeColor = System.Drawing.Color.Blue;
            this.txtSection.Location = new System.Drawing.Point(12, 84);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(174, 21);
            this.txtSection.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Section:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(234, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowSubItems = false;
            this.btnCancel.Size = new System.Drawing.Size(87, 34);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.AutoSize = true;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(141, 201);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(87, 38);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Save";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cboSubject
            // 
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.FormattingEnabled = true;
            this.cboSubject.Location = new System.Drawing.Point(12, 31);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(302, 21);
            this.cboSubject.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select Subject To Add:";
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(192, 140);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(56, 23);
            this.btnEmployee.TabIndex = 17;
            this.btnEmployee.Text = "Select...";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // txtEmployee
            // 
            this.txtEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployee.ForeColor = System.Drawing.Color.Blue;
            this.txtEmployee.Location = new System.Drawing.Point(12, 140);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(174, 21);
            this.txtEmployee.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Assigned Instructor:";
            // 
            // frmOfferedClass_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 249);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.txtEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSections);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cboSubject);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOfferedClass_Add";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Offered Class";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSections;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.ComboBox cboSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.Label label3;
    }
}