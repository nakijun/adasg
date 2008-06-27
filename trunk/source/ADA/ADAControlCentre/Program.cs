using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ADAControlCentre
{
    static class Program
    {
        [DllImport("user32.dll")]
        private extern static int SetForegroundWindow(IntPtr hWnd);

        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                {
                    return p;
                }
            }

            return null;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process process = PriorProcess();
            if (process != null)
            {
                SetForegroundWindow(process.MainWindowHandle);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
