using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ADASchedule
{
    public partial class SelectUserForm : Form
    {
        public SelectUserForm()
        {
            InitializeComponent();
        }

        public ADASchedule.ADAScheduleDataSet ScheduleDataSet
        {
            get { return adaScheduleDataSet1; }
        }

        private ADAScheduleDataSet.UserRow selectedUser;

        public ADAScheduleDataSet.UserRow SelectedUser
        {
            get { return selectedUser; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.BindingContext[adaScheduleDataSet1.User].EndCurrentEdit();

            System.Data.DataRowView view = this.BindingContext[adaScheduleDataSet1, "User"].Current as System.Data.DataRowView;
            if (view != null)
            {
                selectedUser = view.Row as ADAScheduleDataSet.UserRow;
            }
        }
    }
}