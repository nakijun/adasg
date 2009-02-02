namespace AdaWorkSystemPpc
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemCurrent = new System.Windows.Forms.MenuItem();
            this.menuItemMenu = new System.Windows.Forms.MenuItem();
            this.menuItemNextPage = new System.Windows.Forms.MenuItem();
            this.menuItemPrevPage = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemBack = new System.Windows.Forms.MenuItem();
            this.adaScheduleDataSet1 = new AdaWorkSystemPpc.ADAMobileDataSet();
            this.symbolListView1 = new UtilitiesPpc.SymbolListView();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemCurrent);
            this.mainMenu1.MenuItems.Add(this.menuItemMenu);
            // 
            // menuItemCurrent
            // 
            this.menuItemCurrent.Text = "Select";
            this.menuItemCurrent.Click += new System.EventHandler(this.menuItemCurrent_Click);
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.MenuItems.Add(this.menuItemNextPage);
            this.menuItemMenu.MenuItems.Add(this.menuItemPrevPage);
            this.menuItemMenu.MenuItems.Add(this.menuItem2);
            this.menuItemMenu.MenuItems.Add(this.menuItemBack);
            this.menuItemMenu.Text = "Menu";
            // 
            // menuItemNextPage
            // 
            this.menuItemNextPage.Text = "Next Page";
            this.menuItemNextPage.Click += new System.EventHandler(this.menuItemNextPage_Click);
            // 
            // menuItemPrevPage
            // 
            this.menuItemPrevPage.Text = "Prev Page";
            this.menuItemPrevPage.Click += new System.EventHandler(this.menuItemPrevPage_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "-";
            // 
            // menuItemBack
            // 
            this.menuItemBack.Text = "Back";
            this.menuItemBack.Click += new System.EventHandler(this.menuItemBack_Click);
            // 
            // adaScheduleDataSet1
            // 
            this.adaScheduleDataSet1.DataSetName = "ADAMobileDataSet";
            this.adaScheduleDataSet1.Prefix = "";
            this.adaScheduleDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // symbolListView1
            // 
            this.symbolListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symbolListView1.Location = new System.Drawing.Point(0, 0);
            this.symbolListView1.Name = "symbolListView1";
            this.symbolListView1.Size = new System.Drawing.Size(240, 268);
            this.symbolListView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.symbolListView1);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "ADA Work System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AdaWorkSystemPpc.ADAMobileDataSet adaScheduleDataSet1;
        private UtilitiesPpc.SymbolListView symbolListView1;
        private System.Windows.Forms.MenuItem menuItemCurrent;
        private System.Windows.Forms.MenuItem menuItemMenu;
        private System.Windows.Forms.MenuItem menuItemNextPage;
        private System.Windows.Forms.MenuItem menuItemPrevPage;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemBack;
    }
}
