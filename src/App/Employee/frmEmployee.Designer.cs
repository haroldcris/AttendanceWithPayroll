namespace Winform.Employee
{
    partial class frmEmployee
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
            this.btnAssign = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBarMergeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonBarMergeContainer1
            // 
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
            // 
            // SGrid
            // 
            this.SGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            // 
            // 
            // 
            this.SGrid.PrimaryGrid.EnableColumnFiltering = true;
            this.SGrid.PrimaryGrid.EnableFiltering = true;
            // 
            // 
            // 
            this.SGrid.PrimaryGrid.Filter.Visible = true;
            this.SGrid.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            // 
            // 
            // 
            this.SGrid.PrimaryGrid.GroupByRow.GroupBoxLayout = DevComponents.DotNetBar.SuperGrid.GroupBoxLayout.Flat;
            this.SGrid.PrimaryGrid.GroupByRow.GroupBoxStyle = DevComponents.DotNetBar.SuperGrid.GroupBoxStyle.RoundedRectangular;
            this.SGrid.PrimaryGrid.GroupByRow.Visible = true;
            this.SGrid.PrimaryGrid.MultiSelect = false;
            this.SGrid.Size = new System.Drawing.Size(707, 461);
            // 
            // ribbonBar6
            // 
            // 
            // 
            // 
            this.ribbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar6.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAssign});
            this.ribbonBar6.Size = new System.Drawing.Size(270, 77);
            // 
            // 
            // 
            this.ribbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnAssign
            // 
            this.btnAssign.BeginGroup = true;
            this.btnAssign.Image = global::Winform.Properties.Resources.Address_Book_30;
            this.btnAssign.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.RibbonWordWrap = false;
            this.btnAssign.SubItemsExpandWidth = 14;
            this.btnAssign.Text = "Assign Subject";
            this.btnAssign.Visible = false;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 489);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmEmployee";
            this.Text = "frmDeduction";
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem btnAssign;
    }
}