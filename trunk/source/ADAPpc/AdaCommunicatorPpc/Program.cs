using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdaCommunicatorPpc
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

#if !DEBUG
            if (!f.IsDeployed || args.Length > 0)
#endif
            {
                Application.Run(f);
            }
        }
    }
}