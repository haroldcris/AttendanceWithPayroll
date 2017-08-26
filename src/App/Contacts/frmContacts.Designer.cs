namespace Winform.Contacts
{
    partial class frmContacts
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
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
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(48, 48);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1173, 686);
            this.Name = "frmContacts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
    }
}