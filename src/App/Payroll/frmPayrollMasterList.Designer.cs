namespace Winform.Payroll
{
    partial class frmMasterFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterFile));
            this.SGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.RibbonPayMasterList = new DevComponents.DotNetBar.RibbonBar();
            this.btnPayViewProfile = new DevComponents.DotNetBar.ButtonItem();
            this.groupPayButtons = new DevComponents.DotNetBar.ItemContainer();
            this.btnPayAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnPayDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnPayRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.RibbonPayProcess = new DevComponents.DotNetBar.RibbonBar();
            this.btnPayCheck = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem10 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem12 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem13 = new DevComponents.DotNetBar.ButtonItem();
            this.btnPayGenerate = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.mnuGridColumn = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.cmdContext = new DevComponents.DotNetBar.Command(this.components);
            this.ribbonBarMergeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // SGrid
            // 
            this.SGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.SGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.SGrid.Location = new System.Drawing.Point(0, 28);
            this.SGrid.Name = "SGrid";
            // 
            // 
            // 
            this.SGrid.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.SGrid.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.SGrid.Size = new System.Drawing.Size(1354, 705);
            this.SGrid.TabIndex = 20;
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
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarMergeContainer1.Controls.Add(this.RibbonPayMasterList);
            this.ribbonBarMergeContainer1.Controls.Add(this.RibbonPayProcess);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(48, 100);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.RibbonTabText = "ACTION";
            this.ribbonBarMergeContainer1.Size = new System.Drawing.Size(1004, 99);
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
            this.ribbonBarMergeContainer1.TabIndex = 21;
            this.ribbonBarMergeContainer1.Visible = false;
            // 
            // RibbonPayMasterList
            // 
            this.RibbonPayMasterList.AutoOverflowEnabled = true;
            this.RibbonPayMasterList.AutoSizeItems = false;
            // 
            // 
            // 
            this.RibbonPayMasterList.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.RibbonPayMasterList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RibbonPayMasterList.ContainerControlProcessDialogKey = true;
            this.RibbonPayMasterList.Dock = System.Windows.Forms.DockStyle.Left;
            this.RibbonPayMasterList.DragDropSupport = true;
            this.RibbonPayMasterList.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPayViewProfile,
            this.groupPayButtons,
            this.btnPayRefresh});
            this.RibbonPayMasterList.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.RibbonPayMasterList.Location = new System.Drawing.Point(117, 0);
            this.RibbonPayMasterList.Name = "RibbonPayMasterList";
            this.RibbonPayMasterList.OverflowButtonImage = ((System.Drawing.Image)(resources.GetObject("RibbonPayMasterList.OverflowButtonImage")));
            this.RibbonPayMasterList.Size = new System.Drawing.Size(248, 99);
            this.RibbonPayMasterList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RibbonPayMasterList.TabIndex = 10;
            this.RibbonPayMasterList.Text = "Master List";
            // 
            // 
            // 
            this.RibbonPayMasterList.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.RibbonPayMasterList.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnPayViewProfile
            // 
            this.btnPayViewProfile.BeginGroup = true;
            this.btnPayViewProfile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPayViewProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnPayViewProfile.Image")));
            this.btnPayViewProfile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPayViewProfile.Name = "btnPayViewProfile";
            this.btnPayViewProfile.RibbonWordWrap = false;
            this.btnPayViewProfile.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnPayViewProfile.SubItemsExpandWidth = 14;
            this.btnPayViewProfile.SymbolColor = System.Drawing.Color.Green;
            this.btnPayViewProfile.Text = "Open Profile";
            this.btnPayViewProfile.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupPayButtons
            // 
            // 
            // 
            // 
            this.groupPayButtons.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPayButtons.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.groupPayButtons.Name = "groupPayButtons";
            this.groupPayButtons.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPayAdd,
            this.btnPayDelete});
            // 
            // 
            // 
            this.groupPayButtons.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPayButtons.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnPayAdd
            // 
            this.btnPayAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPayAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnPayAdd.Image")));
            this.btnPayAdd.Name = "btnPayAdd";
            this.btnPayAdd.RibbonWordWrap = false;
            this.btnPayAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnPayAdd.SubItemsExpandWidth = 14;
            this.btnPayAdd.Text = "Add Employee";
            this.btnPayAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPayDelete
            // 
            this.btnPayDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPayDelete.Image = global::Winform.Properties.Resources.Delete_File_24px;
            this.btnPayDelete.Name = "btnPayDelete";
            this.btnPayDelete.RibbonWordWrap = false;
            this.btnPayDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnPayDelete.SubItemsExpandWidth = 14;
            this.btnPayDelete.Text = "Delete";
            this.btnPayDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPayRefresh
            // 
            this.btnPayRefresh.BeginGroup = true;
            this.btnPayRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPayRefresh.Image = global::Winform.Properties.Resources.Process_40px;
            this.btnPayRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPayRefresh.Name = "btnPayRefresh";
            this.btnPayRefresh.RibbonWordWrap = false;
            this.btnPayRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnPayRefresh.SubItemsExpandWidth = 14;
            this.btnPayRefresh.SymbolColor = System.Drawing.Color.Green;
            this.btnPayRefresh.Text = "Refresh";
            this.btnPayRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // RibbonPayProcess
            // 
            this.RibbonPayProcess.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.RibbonPayProcess.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.RibbonPayProcess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RibbonPayProcess.ContainerControlProcessDialogKey = true;
            this.RibbonPayProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.RibbonPayProcess.DragDropSupport = true;
            this.RibbonPayProcess.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPayCheck,
            this.btnPayGenerate});
            this.RibbonPayProcess.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.RibbonPayProcess.Location = new System.Drawing.Point(0, 0);
            this.RibbonPayProcess.Name = "RibbonPayProcess";
            this.RibbonPayProcess.Size = new System.Drawing.Size(117, 99);
            this.RibbonPayProcess.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RibbonPayProcess.TabIndex = 12;
            this.RibbonPayProcess.Text = "Process";
            // 
            // 
            // 
            this.RibbonPayProcess.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.RibbonPayProcess.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnPayCheck
            // 
            this.btnPayCheck.AutoExpandOnClick = true;
            this.btnPayCheck.BeginGroup = true;
            this.btnPayCheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPayCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnPayCheck.Image")));
            this.btnPayCheck.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPayCheck.Name = "btnPayCheck";
            this.btnPayCheck.RibbonWordWrap = false;
            this.btnPayCheck.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnPayCheck.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem10,
            this.buttonItem12,
            this.buttonItem13});
            this.btnPayCheck.SubItemsExpandWidth = 14;
            this.btnPayCheck.SymbolColor = System.Drawing.Color.Green;
            this.btnPayCheck.Text = "Check";
            // 
            // buttonItem10
            // 
            this.buttonItem10.Name = "buttonItem10";
            this.buttonItem10.Text = "Check All";
            // 
            // buttonItem12
            // 
            this.buttonItem12.Name = "buttonItem12";
            this.buttonItem12.Text = "Uncheck All";
            // 
            // buttonItem13
            // 
            this.buttonItem13.BeginGroup = true;
            this.buttonItem13.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.buttonItem13.Name = "buttonItem13";
            this.buttonItem13.Text = "Toggle Check";
            // 
            // btnPayGenerate
            // 
            this.btnPayGenerate.BeginGroup = true;
            this.btnPayGenerate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPayGenerate.Image = ((System.Drawing.Image)(resources.GetObject("btnPayGenerate.Image")));
            this.btnPayGenerate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPayGenerate.Name = "btnPayGenerate";
            this.btnPayGenerate.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnPayGenerate.SubItemsExpandWidth = 14;
            this.btnPayGenerate.SymbolColor = System.Drawing.Color.Green;
            this.btnPayGenerate.Text = "Generate Payroll";
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelete.Image = global::Winform.Properties.Resources.Delete_File_24px;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RibbonWordWrap = false;
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.SubItemsExpandWidth = 14;
            this.btnDelete.Text = "Delete";
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.AntiAlias = true;
            this.contextMenuBar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuBar1.IsMaximized = false;
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuGridColumn});
            this.contextMenuBar1.Location = new System.Drawing.Point(262, 316);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(212, 25);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextMenuBar1.TabIndex = 25;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            // 
            // mnuGridColumn
            // 
            this.mnuGridColumn.AutoExpandOnClick = true;
            this.mnuGridColumn.Name = "mnuGridColumn";
            this.mnuGridColumn.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.mnuGridColumn.Text = "Grid Column";
            // 
            // labelItem1
            // 
            this.labelItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.labelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.labelItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.PaddingBottom = 1;
            this.labelItem1.PaddingLeft = 10;
            this.labelItem1.PaddingTop = 1;
            this.labelItem1.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.labelItem1.Text = "Column Header";
            // 
            // cmdContext
            // 
            this.cmdContext.Name = "cmdContext";
            this.cmdContext.Executed += new System.EventHandler(this.cmdContext_Executed);
            // 
            // frmMasterFile
            // 
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.contextMenuBar1);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.SGrid);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header = "PAYROLL MASTER LIST";
            this.HeaderColor = System.Drawing.Color.Green;
            this.Name = "frmMasterFile";
            this.Text = "Payroll Master List";
            this.Controls.SetChildIndex(this.SGrid, 0);
            this.Controls.SetChildIndex(this.ribbonBarMergeContainer1, 0);
            this.Controls.SetChildIndex(this.contextMenuBar1, 0);
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl SGrid;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        private DevComponents.DotNetBar.RibbonBar RibbonPayProcess;
        private DevComponents.DotNetBar.ButtonItem btnPayCheck;
        private DevComponents.DotNetBar.ButtonItem buttonItem10;
        private DevComponents.DotNetBar.ButtonItem buttonItem12;
        private DevComponents.DotNetBar.ButtonItem buttonItem13;
        private DevComponents.DotNetBar.ButtonItem btnPayGenerate;
        private DevComponents.DotNetBar.RibbonBar RibbonPayMasterList;
        private DevComponents.DotNetBar.ItemContainer groupPayButtons;
        private DevComponents.DotNetBar.ButtonItem btnPayAdd;
        private DevComponents.DotNetBar.ButtonItem btnPayDelete;
        private DevComponents.DotNetBar.ButtonItem btnPayViewProfile;
        private DevComponents.DotNetBar.ButtonItem btnPayRefresh;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.ButtonItem mnuGridColumn;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.Command cmdContext;
    }
}