using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdaWorkSystemPpc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the appName.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            MainForm f = new MainForm();

            if (!f.IsDeployed || args.Length > 0)
            {
                Application.Run(f);
            }
        }
    }
}