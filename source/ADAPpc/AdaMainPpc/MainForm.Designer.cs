namespace AdaMainPpc
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBox2App = new OpenNETCF.Windows.Forms.ListBox2();
            this.imageListIcons = new System.Windows.Forms.ImageList();
            this.listBox2ItemTimer = new OpenNETCF.Windows.Forms.ListItem();
            this.listBox2ItemSchedule = new OpenNETCF.Windows.Forms.ListItem();
            this.listBox2ItemWorkSystem = new OpenNETCF.Windows.Forms.ListItem();
            this.listBox2ItemCommunicator = new OpenNETCF.Windows.Forms.ListItem();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItemRun = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemAdvanced = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemMaleVoice = new System.Windows.Forms.MenuItem();
            this.menuItemFemailVoice = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemEnglish = new System.Windows.Forms.MenuItem();
            this.menuItemSimplifiedChinese = new System.Windows.Forms.MenuItem();
            this.menuItemTraditionalChinese = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // listBox2App
            // 
            this.listBox2App.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listBox2App.BackgroundImage")));
            resources.ApplyResources(this.listBox2App, "listBox2App");
            this.listBox2App.ImageList = this.imageListIcons;
            this.listBox2App.ItemHeight = 67;
            this.listBox2App.Name = "listBox2App";
            this.listBox2App.ShowLines = false;
            this.listBox2App.WrapText = true;
            this.listBox2App.Click += new System.EventHandler(this.listBox2App_Click);
            this.listBox2App.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox2App_KeyDown);
            // 
            // imageListIcons
            // 
            resources.ApplyResources(this.imageListIcons, "imageListIcons");
            this.imageListIcons.Images.Clear();
            this.imageListIcons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageListIcons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageListIcons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imageListIcons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            // 
            // listBox2ItemTimer
            // 
            this.listBox2ItemTimer.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.listBox2ItemTimer.ImageIndex = 3;
            this.listBox2ItemTimer.Text = "Timer";
            // 
            // listBox2ItemSchedule
            // 
            this.listBox2ItemSchedule.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.listBox2ItemSchedule.ImageIndex = 0;
            this.listBox2ItemSchedule.Text = "Schedule";
            // 
            // listBox2ItemWorkSystem
            // 
            this.listBox2ItemWorkSystem.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.listBox2ItemWorkSystem.ImageIndex = 1;
            this.listBox2ItemWorkSystem.Text = "Work System";
            // 
            // listBox2ItemCommunicator
            // 
            this.listBox2ItemCommunicator.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.listBox2ItemCommunicator.ImageIndex = 2;
            this.listBox2ItemCommunicator.Text = "Communicator";
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItemRun);
            this.mainMenu.MenuItems.Add(this.menuItem2);
            // 
            // menuItemRun
            // 
            resources.ApplyResources(this.menuItemRun, "menuItemRun");
            this.menuItemRun.Click += new System.EventHandler(this.menuItemRun_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItemAdvanced);
            this.menuItem2.MenuItems.Add(this.menuItem4);
            this.menuItem2.MenuItems.Add(this.menuItemMaleVoice);
            this.menuItem2.MenuItems.Add(this.menuItemFemailVoice);
            this.menuItem2.MenuItems.Add(this.menuItem5);
            this.menuItem2.MenuItems.Add(this.menuItemExit);
            resources.ApplyResources(this.menuItem2, "menuItem2");
            // 
            // menuItemAdvanced
            // 
            resources.ApplyResources(this.menuItemAdvanced, "menuItemAdvanced");
            this.menuItemAdvanced.Click += new System.EventHandler(this.menuItemAdvanced_Click);
            // 
            // menuItem4
            // 
            resources.ApplyResources(this.menuItem4, "menuItem4");
            // 
            // menuItemMaleVoice
            // 
            resources.ApplyResources(this.menuItemMaleVoice, "menuItemMaleVoice");
            this.menuItemMaleVoice.Click += new System.EventHandler(this.menuItemMaleVoice_Click);
            // 
            // menuItemFemailVoice
            // 
            resources.ApplyResources(this.menuItemFemailVoice, "menuItemFemailVoice");
            this.menuItemFemailVoice.Click += new System.EventHandler(this.menuItemFemailVoice_Click);
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
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItemEnglish);
            this.menuItem1.MenuItems.Add(this.menuItemSimplifiedChinese);
            this.menuItem1.MenuItems.Add(this.menuItemTraditionalChinese);
            this.menuItem1.MenuItems.Add(this.menuItem3);
            resources.ApplyResources(this.menuItem1, "menuItem1");
            // 
            // menuItemEnglish
            // 
            resources.ApplyResources(this.menuItemEnglish, "menuItemEnglish");
            // 
            // menuItemSimplifiedChinese
            // 
            resources.ApplyResources(this.menuItemSimplifiedChinese, "menuItemSimplifiedChinese");
            // 
            // menuItemTraditionalChinese
            // 
            resources.ApplyResources(this.menuItemTraditionalChinese, "menuItemTraditionalChinese");
            // 
            // menuItem3
            // 
            resources.ApplyResources(this.menuItem3, "menuItem3");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.listBox2App);
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenNETCF.Windows.Forms.ListBox2 listBox2App;
        private OpenNETCF.Windows.Forms.ListItem listBox2ItemTimer;
        private System.Windows.Forms.ImageList imageListIcons;
        private OpenNETCF.Windows.Forms.ListItem listBox2ItemSchedule;
        private OpenNETCF.Windows.Forms.ListItem listBox2ItemWorkSystem;
        private OpenNETCF.Windows.Forms.ListItem listBox2ItemCommunicator;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemRun;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemEnglish;
        private System.Windows.Forms.MenuItem menuItemSimplifiedChinese;
        private System.Windows.Forms.MenuItem menuItemTraditionalChinese;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemAdvanced;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItemMaleVoice;
        private System.Windows.Forms.MenuItem menuItemFemailVoice;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItemExit;
    }
}

