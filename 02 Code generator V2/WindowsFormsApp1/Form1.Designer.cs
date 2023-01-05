namespace WindowsFormsApp1
{  
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_NewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_NewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_NewFile = new System.Windows.Forms.ToolStripButton();
            this.OpenFolderToolStrip = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripComboBox1_Mode = new System.Windows.Forms.ToolStripComboBox();
            this.removeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(538, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_NewFile,
            this.ToolStripMenuItem_NewFolder,
            this.toolStripSeparator,
            this.ToolStripMenuItem_Save,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // ToolStripMenuItem_NewFile
            // 
            this.ToolStripMenuItem_NewFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_NewFile.Image")));
            this.ToolStripMenuItem_NewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItem_NewFile.Name = "ToolStripMenuItem_NewFile";
            this.ToolStripMenuItem_NewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ToolStripMenuItem_NewFile.Size = new System.Drawing.Size(182, 22);
            this.ToolStripMenuItem_NewFile.Text = "&New File";
            this.ToolStripMenuItem_NewFile.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // ToolStripMenuItem_NewFolder
            // 
            this.ToolStripMenuItem_NewFolder.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_NewFolder.Image")));
            this.ToolStripMenuItem_NewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItem_NewFolder.Name = "ToolStripMenuItem_NewFolder";
            this.ToolStripMenuItem_NewFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ToolStripMenuItem_NewFolder.Size = new System.Drawing.Size(182, 22);
            this.ToolStripMenuItem_NewFolder.Text = "&Open Folder";
            this.ToolStripMenuItem_NewFolder.Click += new System.EventHandler(this.ToolStripButton_NewFolder_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(179, 6);
            // 
            // ToolStripMenuItem_Save
            // 
            this.ToolStripMenuItem_Save.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_Save.Image")));
            this.ToolStripMenuItem_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
            this.ToolStripMenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(182, 22);
            this.ToolStripMenuItem_Save.Text = "&Save";
            this.ToolStripMenuItem_Save.Click += new System.EventHandler(this.ToolStripButton_Save_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.ContextMenuStrip = this.contextMenuStrip2;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(538, 273);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(101, 273);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pastToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.Rename,
            this.newFileToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.openFolderLocation,
            this.removeFolderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 224);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.renameToolStripMenuItem.Text = "Copy";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.pastToolStripMenuItem.Text = "Past";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.pastToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButton_Delete_Click);
            // 
            // Rename
            // 
            this.Rename.Name = "Rename";
            this.Rename.Size = new System.Drawing.Size(188, 22);
            this.Rename.Text = "Rename";
            this.Rename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // openFolderLocation
            // 
            this.openFolderLocation.Name = "openFolderLocation";
            this.openFolderLocation.Size = new System.Drawing.Size(188, 22);
            this.openFolderLocation.Text = "Open Folder Location";
            this.openFolderLocation.Click += new System.EventHandler(this.openFolderLocation_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "image0.png");
            this.imageList1.Images.SetKeyName(1, "image1.png");
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(120, 26);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.fullScreenToolStripMenuItem.Text = "Collabse";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 273);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 238);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_NewFile,
            this.OpenFolderToolStrip,
            this.ToolStripButton_Save,
            this.toolStripSeparator6,
            this.ToolStripButton_Delete,
            this.toolStripButton1,
            this.toolStripButton2,
            this.ToolStripComboBox1_Mode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(538, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButton_NewFile
            // 
            this.ToolStripButton_NewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_NewFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_NewFile.Image")));
            this.ToolStripButton_NewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_NewFile.Name = "ToolStripButton_NewFile";
            this.ToolStripButton_NewFile.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_NewFile.Text = "&New";
            this.ToolStripButton_NewFile.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // OpenFolderToolStrip
            // 
            this.OpenFolderToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFolderToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("OpenFolderToolStrip.Image")));
            this.OpenFolderToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFolderToolStrip.Name = "OpenFolderToolStrip";
            this.OpenFolderToolStrip.Size = new System.Drawing.Size(23, 22);
            this.OpenFolderToolStrip.Text = "Open Folder";
            this.OpenFolderToolStrip.Click += new System.EventHandler(this.ToolStripButton_NewFolder_Click);
            // 
            // ToolStripButton_Save
            // 
            this.ToolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Save.Image")));
            this.ToolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Save.Name = "ToolStripButton_Save";
            this.ToolStripButton_Save.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_Save.Text = "&Save";
            this.ToolStripButton_Save.Click += new System.EventHandler(this.ToolStripButton_Save_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButton_Delete
            // 
            this.ToolStripButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Delete.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Delete.Image")));
            this.ToolStripButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Delete.Name = "ToolStripButton_Delete";
            this.ToolStripButton_Delete.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_Delete.Text = "C&ut";
            this.ToolStripButton_Delete.Click += new System.EventHandler(this.ToolStripButton_Delete_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WindowsFormsApp1.Properties.Resources.full_screen;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Full Screen";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Run";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // ToolStripComboBox1_Mode
            // 
            this.ToolStripComboBox1_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolStripComboBox1_Mode.Items.AddRange(new object[] {
            "Edit",
            "Code"});
            this.ToolStripComboBox1_Mode.Name = "ToolStripComboBox1_Mode";
            this.ToolStripComboBox1_Mode.Size = new System.Drawing.Size(75, 25);
            // 
            // removeFolderToolStripMenuItem
            // 
            this.removeFolderToolStripMenuItem.Name = "removeFolderToolStripMenuItem";
            this.removeFolderToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.removeFolderToolStripMenuItem.Text = "Remove Folder";
            this.removeFolderToolStripMenuItem.Click += new System.EventHandler(this.removeFolderToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 323);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "NotePad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       public System.Windows.Forms.MenuStrip menuStrip1;
       public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
       public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_NewFile;
       public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_NewFolder;
       public System.Windows.Forms.ToolStripSeparator toolStripSeparator;
       public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save;
       public System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
       public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
       public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
       public System.Windows.Forms.SplitContainer splitContainer1;
       public System.Windows.Forms.ToolStrip toolStrip1;
       public System.Windows.Forms.ToolStripButton ToolStripButton_NewFile;
       public System.Windows.Forms.ToolStripButton OpenFolderToolStrip;
       public System.Windows.Forms.ToolStripButton ToolStripButton_Save;
       public System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
       public System.Windows.Forms.ToolStripButton ToolStripButton_Delete;
       public System.Windows.Forms.TabControl tabControl1;
       public System.Windows.Forms.TabPage tabPage1;
       public System.Windows.Forms.ToolStripComboBox ToolStripComboBox1_Mode;
        public System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.ToolStripButton toolStripButton2;
       public System.Windows.Forms.TreeView treeView1;
       public System.Windows.Forms.ImageList imageList1;
       public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
       public System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
       public System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
       public System.Windows.Forms.ToolStripMenuItem Rename;
       public System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
       public System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
       public System.Windows.Forms.ToolStripMenuItem openFolderLocation;
       public System.Windows.Forms.ToolStripMenuItem pastToolStripMenuItem;
       public System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
       public System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    }  
}

