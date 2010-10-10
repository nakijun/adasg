using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace AdaSyncPpc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the appName.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            bool autoSync = (args.Length > 0 && args[0] == "-EVENT");
            MainForm f = new MainForm(autoSync);

#if !DEBUG
            if (!f.IsDeployed || args.Length > 0)
#endif
            {
                Application.Run(f);
            }
        }
    }
}