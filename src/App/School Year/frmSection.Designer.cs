namespace SmartApp
{
    partial class frmSection
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
            this.BatchViewer = new SmartApp.UC.ucBatchViewer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.CourseOfferedViewer = new SmartApp.UC.ucCourseOfferedViewer();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.SectionViewer = new SmartApp.UC.ucSectionViewer();
            this.ribbonBarMergeContainer2 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBar6 = new DevComponents.DotNetBar.RibbonBar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBarMergeContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BatchViewer
            // 
            this.BatchViewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.BatchViewer.Encoder = "UserControl";
            this.BatchViewer.IsActiveNodeSelectedBefore = false;
            this.BatchViewer.Location = new System.Drawing.Point(0, 20);
            this.BatchViewer.Name = "BatchViewer";
            this.BatchViewer.Size = new System.Drawing.Size(175, 509);
            this.BatchViewer.TabIndex = 20;
            this.BatchViewer.Load += new System.EventHandler(this.BatchViewer_Load);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(175, 20);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 509);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // CourseOfferedViewer
            // 
            this.CourseOfferedViewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.CourseOfferedViewer.IsActiveNodeSelectedBefore = false;
            this.CourseOfferedViewer.Location = new System.Drawing.Point(180, 20);
            this.CourseOfferedViewer.Name = "CourseOfferedViewer";
            this.CourseOfferedViewer.Size = new System.Drawing.Size(360, 509);
            this.CourseOfferedViewer.TabIndex = 22;
            this.CourseOfferedViewer.UseSmallIcons = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(540, 20);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 509);
            this.splitter2.TabIndex = 23;
            this.splitter2.TabStop = false;
            // 
            // SectionViewer
            // 
            this.SectionViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SectionViewer.IsDirty = false;
            this.SectionViewer.Location = new System.Drawing.Point(545, 20);
            this.SectionViewer.Name = "SectionViewer";
            this.SectionViewer.OfferedCourseItem = null;
            this.SectionViewer.Size = new System.Drawing.Size(809, 509);
            this.SectionViewer.TabIndex = 24;
            // 
            // ribbonBarMergeContainer2
            // 
            this.ribbonBarMergeContainer2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarMergeContainer2.Controls.Add(this.ribbonBar6);
            this.ribbonBarMergeContainer2.Location = new System.Drawing.Point(512, 226);
            this.ribbonBarMergeContainer2.Name = "ribbonBarMergeContainer2";
            this.ribbonBarMergeContainer2.RibbonTabText = "Data";
            this.ribbonBarMergeContainer2.Size = new System.Drawing.Size(330, 77);
            // 
            // 
            // 
            this.ribbonBarMergeContainer2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarMergeContainer2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarMergeContainer2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarMergeContainer2.TabIndex = 26;
            this.ribbonBarMergeContainer2.ThemeAware = true;
            this.ribbonBarMergeContainer2.Visible = false;
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
            this.itemContainer1,
            this.btnRefresh});
            this.ribbonBar6.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar6.Name = "ribbonBar6";
            this.ribbonBar6.Size = new System.Drawing.Size(231, 77);
            this.ribbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar6.TabIndex = 7;
            this.ribbonBar6.Text = "Section Actions";
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
            this.btnAdd.Text = "Create New Section";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnEdit,
            this.btnDelete});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEdit.Image = global::SmartApp.Properties.Resources.Edit_File_24px;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RibbonWordWrap = false;
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnEdit.SubItemsExpandWidth = 14;
            this.btnEdit.Text = "Modify";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelete.Image = global::SmartApp.Properties.Resources.Delete_File_24px;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RibbonWordWrap = false;
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlDel);
            this.btnDelete.SubItemsExpandWidth = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = global::SmartApp.Properties.Resources.Process_40px1;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonWordWrap = false;
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.SubItemsExpandWidth = 14;
            this.btnRefresh.SymbolColor = System.Drawing.Color.Green;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 529);
            this.Controls.Add(this.ribbonBarMergeContainer2);
            this.Controls.Add(this.SectionViewer);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.CourseOfferedViewer);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.BatchViewer);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "frmSection";
            this.Text = "frmSection";
            this.Controls.SetChildIndex(this.BatchViewer, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.CourseOfferedViewer, 0);
            this.Controls.SetChildIndex(this.splitter2, 0);
            this.Controls.SetChildIndex(this.SectionViewer, 0);
            this.Controls.SetChildIndex(this.ribbonBarMergeContainer2, 0);
            this.ribbonBarMergeContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ucBatchViewer BatchViewer;
        private System.Windows.Forms.Splitter splitter1;
        private UC.ucCourseOfferedViewer CourseOfferedViewer;
        private System.Windows.Forms.Splitter splitter2;
        private UC.ucSectionViewer SectionViewer;
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar6;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
    }
}