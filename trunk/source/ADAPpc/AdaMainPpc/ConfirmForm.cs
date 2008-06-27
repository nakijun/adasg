using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UtilitiesPpc;

namespace AdaMainPpc
{
    public partial class ConfirmForm : AdaBaseForm
    {
        public ConfirmForm()
        {
            InitializeComponent();
        }

        private void menuItemOK_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "saacada")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong password!");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void menuItemCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBoxPassword_GotFocus(object sender, EventArgs e)
        {
            this.inputPanel1.Enabled = true;
        }
    }
}