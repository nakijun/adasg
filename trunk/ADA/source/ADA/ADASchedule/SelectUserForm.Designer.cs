namespace ADASchedule
{
    partial class SelectUserForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.adaScheduleDataSet1 = new ADASchedule.ADAScheduleDataSet();
            this.listBoxSchedule = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.adaScheduleDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(174, 232);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(46, 232);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // adaScheduleDataSet1
            // 
            this.adaScheduleDataSet1.DataSetName = "ADAScheduleDataSet";
            this.adaScheduleDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listBoxSchedule
            // 
            this.listBoxSchedule.DataSource = this.adaScheduleDataSet1;
            this.listBoxSchedule.DisplayMember = "User.Name";
            this.listBoxSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxSchedule.FormattingEnabled = true;
            this.listBoxSchedule.Location = new System.Drawing.Point(0, 0);
            this.listBoxSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxSchedule.Name = "listBoxSchedule";
            this.listBoxSchedule.Size = new System.Drawing.Size(292, 225);
            this.listBoxSchedule.TabIndex = 7;
            this.listBoxSchedule.ValueMember = "User.UserId";
            // 
            // SelectUserForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(292, 262);
            this.ControlBox = false;
            this.Controls.Add(this.listBoxSchedule);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "SelectUserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select User";
            ((System.ComponentModel.ISupportInitialize)(this.adaScheduleDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private ADAScheduleDataSet adaScheduleDataSet1;
        private System.Windows.Forms.ListBox listBoxSchedule;
    }
}