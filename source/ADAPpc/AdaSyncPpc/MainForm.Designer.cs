namespace AdaSyncPpc
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItemSync = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemCheckConnection = new System.Windows.Forms.MenuItem();
            this.menuItemSymbolExplorer = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItemAutoSync = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemReinitialize = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.labelModifiedTime = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.timerAutoSync = new System.Windows.Forms.Timer();
            this.labelSyncTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemSyncSymbol = new System.Windows.Forms.MenuItem();
            this.menuItemSyncSchedule = new System.Windows.Forms.MenuItem();
            this.menuItemSyncCommunicator = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItemSync);
            this.mainMenu.MenuItems.Add(this.menuItem1);
            // 
            // menuItemSync
            // 
            resources.ApplyResources(this.menuItemSync, "menuItemSync");
            this.menuItemSync.Click += new System.EventHandler(this.menuItemSync_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItemCheckConnection);
            this.menuItem1.MenuItems.Add(this.menuItemSymbolExplorer);
            this.menuItem1.MenuItems.Add(this.menuItem7);
            this.menuItem1.MenuItems.Add(this.menuItemAutoSync);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.MenuItems.Add(this.menuItemReinitialize);
            this.menuItem1.MenuItems.Add(this.menuItem5);
            this.menuItem1.MenuItems.Add(this.menuItemExit);
            resources.ApplyResources(this.menuItem1, "menuItem1");
            // 
            // menuItemCheckConnection
            // 
            resources.ApplyResources(this.menuItemCheckConnection, "menuItemCheckConnection");
            this.menuItemCheckConnection.Click += new System.EventHandler(this.menuItemCheckConnection_Click);
            // 
            // menuItemSymbolExplorer
            // 
            resources.ApplyResources(this.menuItemSymbolExplorer, "menuItemSymbolExplorer");
            this.menuItemSymbolExplorer.Click += new System.EventHandler(this.menuItemSymbolExplorer_Click);
            // 
            // menuItem7
            // 
            resources.ApplyResources(this.menuItem7, "menuItem7");
            // 
            // menuItemAutoSync
            // 
            resources.ApplyResources(this.menuItemAutoSync, "menuItemAutoSync");
            this.menuItemAutoSync.Click += new System.EventHandler(this.menuItemAutoSync_Click);
            // 
            // menuItem4
            // 
            resources.ApplyResources(this.menuItem4, "menuItem4");
            // 
            // menuItemReinitialize
            // 
            resources.ApplyResources(this.menuItemReinitialize, "menuItemReinitialize");
            this.menuItemReinitialize.Click += new System.EventHandler(this.menuItemReinitialize_Click);
            // 
            // menuItem5
            // 
            resources.ApplyResources(this.menuItem5, "menuItem5");
            // 
            // menuItemExit
            // 
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelModifiedTime
            // 
            resources.ApplyResources(this.labelModifiedTime, "labelModifiedTime");
            this.labelModifiedTime.Name = "labelModifiedTime";
            // 
            // textBoxStatus
            // 
            resources.ApplyResources(this.textBoxStatus, "textBoxStatus");
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            // 
            // timerAutoSync
            // 
            this.timerAutoSync.Interval = 2000;
            this.timerAutoSync.Tick += new System.EventHandler(this.timerAutoSync_Tick);
            // 
            // labelSyncTime
            // 
            resources.ApplyResources(this.labelSyncTime, "labelSyncTime");
            this.labelSyncTime.Name = "labelSyncTime";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItemSyncSymbol);
            this.menuItem2.MenuItems.Add(this.menuItemSyncSchedule);
            this.menuItem2.MenuItems.Add(this.menuItemSyncCommunicator);
            resources.ApplyResources(this.menuItem2, "menuItem2");
            // 
            // menuItemSyncSymbol
            // 
            resources.ApplyResources(this.menuItemSyncSymbol, "menuItemSyncSymbol");
            // 
            // menuItemSyncSchedule
            // 
            resources.ApplyResources(this.menuItemSyncSchedule, "menuItemSyncSchedule");
            // 
            // menuItemSyncCommunicator
            // 
            resources.ApplyResources(this.menuItemSyncCommunicator, "menuItemSyncCommunicator");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.labelSyncTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelModifiedTime);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelModifiedTime;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Timer timerAutoSync;
        private System.Windows.Forms.Label labelSyncTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemSymbolExplorer;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemCheckConnection;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItemAutoSync;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemSyncSymbol;
        private System.Windows.Forms.MenuItem menuItemSyncSchedule;
        private System.Windows.Forms.MenuItem menuItemSyncCommunicator;
        private System.Windows.Forms.MenuItem menuItemReinitialize;
        private System.Windows.Forms.MenuItem menuItem5;
    }
}

