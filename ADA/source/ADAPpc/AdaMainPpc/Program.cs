using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdaMainPpc
{
    static class Program
    {
        private static string _launchFrom;

        public static string LaunchFrom
        {
            get
            {
                return _launchFrom;
            }
        }
        /// <summary>
        /// The main entry point for the appName.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                _launchFrom = args[0];
            }

            Application.Run(new MainForm());
        }
    }
}