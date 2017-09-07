namespace Winform.Payroll
{
    partial class frmGenerated_Open
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
            this.SGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridRow3 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnOk = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderCaption
            // 
            // 
            // 
            // 
            this.HeaderCaption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HeaderCaption.Size = new System.Drawing.Size(334, 47);
            this.HeaderCaption.Text = "<div><h3><font color=\'blue\'><b>OPEN PAYROLL INFORMATION</b></font></h3>\r\n</div><d" +
    "iv>\r\nAllows you to open generated payroll</div>";
            // 
            // SGrid
            // 
            this.SGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.SGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SGrid.ForeColor = System.Drawing.Color.Black;
            this.SGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.SGrid.Location = new System.Drawing.Point(0, 100);
            this.SGrid.Name = "SGrid";
            // 
            // 
            // 
            this.SGrid.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.SGrid.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.SGrid.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.SGrid.PrimaryGrid.Columns.Add(this.gridColumn4);
            // 
            // 
            // 
            this.SGrid.PrimaryGrid.GroupByRow.GroupBoxLayout = DevComponents.DotNetBar.SuperGrid.GroupBoxLayout.Flat;
            this.SGrid.PrimaryGrid.GroupByRow.GroupBoxStyle = DevComponents.DotNetBar.SuperGrid.GroupBoxStyle.RoundedRectangular;
            this.SGrid.PrimaryGrid.GroupByRow.Visible = true;
            this.SGrid.PrimaryGrid.MultiSelect = false;
            this.SGrid.PrimaryGrid.RowHeaderWidth = 30;
            this.SGrid.PrimaryGrid.Rows.Add(this.gridRow1);
            this.SGrid.PrimaryGrid.Rows.Add(this.gridRow2);
            this.SGrid.PrimaryGrid.Rows.Add(this.gridRow3);
            this.SGrid.Size = new System.Drawing.Size(455, 316);
            this.SGrid.SizingStyle = DevComponents.DotNetBar.SuperGrid.Style.StyleType.Default;
            this.SGrid.TabIndex = 22;
            this.SGrid.Text = "superGridControl1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridRow1
            // 
            this.gridRow1.Cells.Add(this.gridCell1);
            this.gridRow1.RowHeaderText = "sdf";
            // 
            // gridCell1
            // 
            this.gridCell1.Value = "sdfsdf";
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
            this.bar1.Location = new System.Drawing.Point(0, 61);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(455, 39);
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
            this.btnOk.Text = "Open Record";
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
            // frmGenerated_Open
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 416);
            this.Controls.Add(this.SGrid);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerated_Open";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.SGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevComponents.DotNetBar.SuperGrid.SuperGridControl SGrid;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow1;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell1;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow2;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow3;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnOk;
        private DevComponents.DotNetBar.ButtonItem btnCancel;
    }
}