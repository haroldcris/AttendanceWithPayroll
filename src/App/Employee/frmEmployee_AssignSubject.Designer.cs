namespace Winform.Employee
{
    partial class frmEmployee_AssignSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee_AssignSubject));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboBatch = new DevComponents.DotNetBar.Controls.ComboTree();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.FlexGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnAddSubject = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexGrid)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cboBatch);
            this.groupPanel2.Controls.Add(this.label6);
            this.groupPanel2.Controls.Add(this.btnDelete);
            this.groupPanel2.Controls.Add(this.FlexGrid);
            this.groupPanel2.Controls.Add(this.btnAddSubject);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(262, 12);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(500, 311);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 5;
            this.groupPanel2.Text = "Handled Subjects";
            // 
            // cboBatch
            // 
            this.cboBatch.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboBatch.BackgroundStyle.Class = "TextBoxBorder";
            this.cboBatch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboBatch.ButtonDropDown.Visible = true;
            this.cboBatch.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.cboBatch.Location = new System.Drawing.Point(52, 1);
            this.cboBatch.Name = "cboBatch";
            this.cboBatch.Size = new System.Drawing.Size(430, 23);
            this.cboBatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBatch.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(5, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Batch:";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(127, 235);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowSubItems = false;
            this.btnDelete.Size = new System.Drawing.Size(125, 30);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Remove Subject";
            this.btnDelete.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // FlexGrid
            // 
            this.FlexGrid.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlexGrid.AllowEditing = false;
            this.FlexGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlexGrid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.FlexGrid.ColumnInfo = "5,1,0,0,0,100,Columns:0{Width:21;}\t1{Width:80;Name:\"subjectcode\";Caption:\"Subject" +
    " Code\";}\t2{Width:222;Name:\"subject\";Caption:\"Subject\";}\t3{Width:103;Name:\"sectio" +
    "n\";Caption:\"Section\";}\t4{Width:10;}\t";
            this.FlexGrid.ExtendLastCol = true;
            this.FlexGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FlexGrid.Location = new System.Drawing.Point(9, 30);
            this.FlexGrid.Name = "FlexGrid";
            this.FlexGrid.Rows.Count = 1;
            this.FlexGrid.Rows.DefaultSize = 20;
            this.FlexGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.FlexGrid.ShowCursor = true;
            this.FlexGrid.Size = new System.Drawing.Size(472, 199);
            this.FlexGrid.StyleInfo = resources.GetString("FlexGrid.StyleInfo");
            this.FlexGrid.TabIndex = 2;
            this.FlexGrid.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSubject.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAddSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSubject.Location = new System.Drawing.Point(9, 235);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.ShowSubItems = false;
            this.btnAddSubject.Size = new System.Drawing.Size(112, 30);
            this.btnAddSubject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddSubject.TabIndex = 3;
            this.btnAddSubject.Text = "Add Subject...";
            this.btnAddSubject.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lblName);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(244, 311);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "Employee Information";
            this.groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(648, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowSubItems = false;
            this.btnCancel.Size = new System.Drawing.Size(101, 39);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(541, 335);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShowSubItems = false;
            this.btnOk.Size = new System.Drawing.Size(101, 39);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Done";
            this.btnOk.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
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
            this.lblName.Location = new System.Drawing.Point(12, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(215, 252);
            this.lblName.TabIndex = 29;
            this.lblName.Text = resources.GetString("lblName.Text");
            this.lblName.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // frmEmployee_AssignSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 386);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployee_AssignSubject";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.Text = "Assign Section";
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexGrid)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.ComboTree cboBatch;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private C1.Win.C1FlexGrid.C1FlexGrid FlexGrid;
        private DevComponents.DotNetBar.ButtonX btnAddSubject;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.LabelX lblName;
    }
}