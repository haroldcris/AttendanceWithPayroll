namespace Winform
{
    partial class FormWithHeader
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
            this.PanelHeader = new DevComponents.DotNetBar.PanelEx();
            this.HeaderCaption = new DevComponents.DotNetBar.LabelX();
            this.HeaderPicture = new System.Windows.Forms.PictureBox();
            this.PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelHeader
            // 
            this.PanelHeader.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelHeader.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PanelHeader.Controls.Add(this.HeaderCaption);
            this.PanelHeader.Controls.Add(this.HeaderPicture);
            this.PanelHeader.DisabledBackColor = System.Drawing.Color.Empty;
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(706, 54);
            this.PanelHeader.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelHeader.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelHeader.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelHeader.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelHeader.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelHeader.Style.GradientAngle = 90;
            this.PanelHeader.TabIndex = 18;
            this.PanelHeader.ThemeAware = true;
            // 
            // HeaderCaption
            // 
            // 
            // 
            // 
            this.HeaderCaption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HeaderCaption.ForeColor = System.Drawing.Color.Black;
            this.HeaderCaption.Location = new System.Drawing.Point(65, 4);
            this.HeaderCaption.Name = "HeaderCaption";
            this.HeaderCaption.Size = new System.Drawing.Size(429, 47);
            this.HeaderCaption.TabIndex = 1;
            this.HeaderCaption.Text = "<div><h3><font color=\'blue\'><b>OPEN EMPLOYEE INFORMATION</b></font></h3>\r\n</div><" +
    "div>\r\nAllows you to open and update records from the database\r\n</div>";
            this.HeaderCaption.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // HeaderPicture
            // 
            this.HeaderPicture.ForeColor = System.Drawing.Color.Black;
            this.HeaderPicture.Image = global::Winform.Properties.Resources.Money_Transfer_40px;
            this.HeaderPicture.Location = new System.Drawing.Point(9, 3);
            this.HeaderPicture.Name = "HeaderPicture";
            this.HeaderPicture.Size = new System.Drawing.Size(51, 48);
            this.HeaderPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.HeaderPicture.TabIndex = 0;
            this.HeaderPicture.TabStop = false;
            // 
            // FormWithHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 491);
            this.Controls.Add(this.PanelHeader);
            this.DoubleBuffered = true;
            this.Name = "FormWithHeader";
            this.ShowIcon = false;
            this.Text = "FormWithHeader";
            this.PanelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx PanelHeader;
        protected DevComponents.DotNetBar.LabelX HeaderCaption;
        protected System.Windows.Forms.PictureBox HeaderPicture;
    }
}