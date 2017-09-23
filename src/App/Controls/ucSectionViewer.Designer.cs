namespace Winform.Controls
{
    partial class ucSectionViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreeView = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            ((System.ComponentModel.ISupportInitialize)(this.TreeView)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.TreeView.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.TreeView.BackgroundStyle.Class = "TreeBorderKey";
            this.TreeView.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            this.TreeView.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.TreeView.NodesConnector = this.nodeConnector1;
            this.TreeView.NodeStyle = this.elementStyle1;
            this.TreeView.PathSeparator = ";";
            this.TreeView.Size = new System.Drawing.Size(290, 317);
            this.TreeView.Styles.Add(this.elementStyle1);
            this.TreeView.TabIndex = 0;
            this.TreeView.Text = "advTree1";
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // ucSectionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreeView);
            this.Name = "ucSectionViewer";
            this.Size = new System.Drawing.Size(290, 317);
            ((System.ComponentModel.ISupportInitialize)(this.TreeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        public DevComponents.AdvTree.AdvTree TreeView;
    }
}
