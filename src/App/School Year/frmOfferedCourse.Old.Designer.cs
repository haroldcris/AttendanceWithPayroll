namespace SmartApp
{
    partial class frmOfferedCourse
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
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBar6 = new DevComponents.DotNetBar.RibbonBar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.tv = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node6 = new DevComponents.AdvTree.Node();
            this.node12 = new DevComponents.AdvTree.Node();
            this.node13 = new DevComponents.AdvTree.Node();
            this.node14 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.tvBatch = new DevComponents.AdvTree.AdvTree();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node8 = new DevComponents.AdvTree.Node();
            this.node9 = new DevComponents.AdvTree.Node();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.node7 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ribbonBarMergeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarMergeContainer1.Controls.Add(this.ribbonBar6);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(27, 88);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.RibbonTabText = "Data";
            this.ribbonBarMergeContainer1.Size = new System.Drawing.Size(245, 100);
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
            this.ribbonBarMergeContainer1.TabIndex = 12;
            this.ribbonBarMergeContainer1.ThemeAware = true;
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
            this.btnAdd,
            this.btnDelete,
            this.btnRefresh});
            this.ribbonBar6.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar6.Name = "ribbonBar6";
            this.ribbonBar6.Size = new System.Drawing.Size(231, 100);
            this.ribbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar6.TabIndex = 7;
            this.ribbonBar6.Text = "Offered Courses Actions";
            // 
            // 
            // 
            this.ribbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = global::SmartApp.Properties.Resources.Add_List_40px;
            this.btnAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnAdd.SubItemsExpandWidth = 14;
            this.btnAdd.Text = "Add Offered Course";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelete.Image = global::SmartApp.Properties.Resources.Delete_File_40px;
            this.btnDelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.SubItemsExpandWidth = 14;
            this.btnDelete.Text = "Remove Offered Course";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = global::SmartApp.Properties.Resources.Process_40px;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonWordWrap = false;
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.SubItemsExpandWidth = 14;
            this.btnRefresh.SymbolColor = System.Drawing.Color.Green;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tv
            // 
            this.tv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tv.AllowDrop = true;
            this.tv.AllowExternalDrop = false;
            this.tv.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.tv.BackgroundStyle.Class = "TreeBorderKey";
            this.tv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.DragDropEnabled = false;
            this.tv.DragDropNodeCopyEnabled = false;
            this.tv.ExpandButtonSize = new System.Drawing.Size(16, 16);
            this.tv.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.tv.Indent = 15;
            this.tv.Location = new System.Drawing.Point(203, 20);
            this.tv.Name = "tv";
            this.tv.NodeHorizontalSpacing = 5;
            this.tv.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.tv.NodesConnector = this.nodeConnector1;
            this.tv.NodeSpacing = 10;
            this.tv.NodeStyle = this.elementStyle1;
            this.tv.PathSeparator = ";";
            this.tv.Size = new System.Drawing.Size(1151, 713);
            this.tv.Styles.Add(this.elementStyle1);
            this.tv.TabIndex = 19;
            this.tv.Text = "advTree1";
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node6,
            this.node12,
            this.node13,
            this.node14});
            this.node1.Text = "node1";
            // 
            // node6
            // 
            this.node6.Expanded = true;
            this.node6.Name = "node6";
            this.node6.Text = "node6";
            // 
            // node12
            // 
            this.node12.Expanded = true;
            this.node12.Name = "node12";
            this.node12.Text = "node12";
            // 
            // node13
            // 
            this.node13.Expanded = true;
            this.node13.Name = "node13";
            this.node13.Text = "node13";
            // 
            // node14
            // 
            this.node14.Expanded = true;
            this.node14.Name = "node14";
            this.node14.Text = "node14";
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
            // tvBatch
            // 
            this.tvBatch.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tvBatch.AllowDrop = true;
            this.tvBatch.AllowExternalDrop = false;
            this.tvBatch.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.tvBatch.BackgroundStyle.Class = "TreeBorderKey";
            this.tvBatch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tvBatch.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvBatch.DragDropEnabled = false;
            this.tvBatch.DragDropNodeCopyEnabled = false;
            this.tvBatch.ExpandButtonSize = new System.Drawing.Size(16, 16);
            this.tvBatch.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.tvBatch.Location = new System.Drawing.Point(0, 20);
            this.tvBatch.Name = "tvBatch";
            this.tvBatch.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node4,
            this.node7});
            this.tvBatch.NodesConnector = this.nodeConnector2;
            this.tvBatch.NodeStyle = this.elementStyle2;
            this.tvBatch.PathSeparator = ";";
            this.tvBatch.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.tvBatch.Size = new System.Drawing.Size(198, 713);
            this.tvBatch.Styles.Add(this.elementStyle2);
            this.tvBatch.TabIndex = 20;
            this.tvBatch.Text = "advTree1";
            this.tvBatch.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.tvBatch_NodeClick);
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node5,
            this.node8,
            this.node9});
            this.node4.Style = this.elementStyle2;
            this.node4.Text = "node1";
            // 
            // node5
            // 
            this.node5.Name = "node5";
            this.node5.Text = "node3";
            // 
            // node8
            // 
            this.node8.Expanded = true;
            this.node8.Name = "node8";
            this.node8.Text = "node8";
            // 
            // node9
            // 
            this.node9.Expanded = true;
            this.node9.Name = "node9";
            this.node9.Text = "node9";
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // node7
            // 
            this.node7.Expanded = true;
            this.node7.Name = "node7";
            this.node7.Text = "node7";
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 20);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 713);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // frmOfferedCourse
            // 
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvBatch);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOfferedCourse";
            this.ShowIcon = false;
            this.Text = "Offered Courses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.tvBatch, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.tv, 0);
            this.Controls.SetChildIndex(this.ribbonBarMergeContainer1, 0);
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvBatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar6;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.AdvTree.AdvTree tv;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.AdvTree tvBatch;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.AdvTree.Node node7;
        private DevComponents.AdvTree.Node node8;
        private DevComponents.AdvTree.Node node9;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.AdvTree.Node node12;
        private DevComponents.AdvTree.Node node13;
        private DevComponents.AdvTree.Node node14;
        protected internal DevComponents.DotNetBar.ButtonItem btnAdd;
    }
}