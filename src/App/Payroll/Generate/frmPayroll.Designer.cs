namespace Winform.Payroll
{
    partial class frmPayroll
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
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBar6 = new DevComponents.DotNetBar.RibbonBar();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.xl = new C1.C1Excel.C1XLBook();
            this.ribbonBarMergeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SGrid
            // 
            this.SGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.SGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.SGrid.ForeColor = System.Drawing.Color.Black;
            this.SGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.SGrid.Location = new System.Drawing.Point(0, 28);
            this.SGrid.Name = "SGrid";
            this.SGrid.Size = new System.Drawing.Size(919, 549);
            this.SGrid.TabIndex = 20;
            this.SGrid.Text = "superGridControl1";
            // 
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarMergeContainer1.Controls.Add(this.ribbonBar6);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(24, 53);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.RibbonTabText = "Action";
            this.ribbonBarMergeContainer1.Size = new System.Drawing.Size(281, 77);
            // 
            // 
            // 
            this.ribbonBarMergeContainer1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarMergeContainer1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarMergeContainer1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarMergeContainer1.TabIndex = 23;
            this.ribbonBarMergeContainer1.ThemeAware = true;
            this.ribbonBarMergeContainer1.Visible = false;
            // 
            // ribbonBar6
            // 
            this.ribbonBar6.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar6.ContainerControlProcessDialogKey = true;
            this.ribbonBar6.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar6.DragDropSupport = true;
            this.ribbonBar6.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDelete,
            this.btnPrint});
            this.ribbonBar6.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar6.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar6.Name = "ribbonBar6";
            this.ribbonBar6.Size = new System.Drawing.Size(203, 77);
            this.ribbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar6.TabIndex = 7;
            this.ribbonBar6.Text = "Batch Actions";
            // 
            // 
            // 
            this.ribbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelete.Image = global::Winform.Properties.Resources.Delete_File_40px;
            this.btnDelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnDelete.SubItemsExpandWidth = 14;
            this.btnDelete.Text = "Delete Entire Payroll";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BeginGroup = true;
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.Image = global::Winform.Properties.Resources.Print_40px;
            this.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RibbonWordWrap = false;
            this.btnPrint.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnPrint.SubItemsExpandWidth = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 577);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.SGrid);
            this.DoubleBuffered = true;
            this.Name = "frmPayroll";
            this.Text = "frmPayroll";
            this.Controls.SetChildIndex(this.SGrid, 0);
            this.Controls.SetChildIndex(this.ribbonBarMergeContainer1, 0);
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl SGrid;
        protected DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        protected DevComponents.DotNetBar.RibbonBar ribbonBar6;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private C1.C1Excel.C1XLBook xl;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
    }
}