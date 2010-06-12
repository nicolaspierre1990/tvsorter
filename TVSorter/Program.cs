﻿using System;
using System.Windows.Forms;

namespace TVSorter
{
    static class Program
    {
        public static string VersionNumber = "0.3";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {                
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                Application.Run(new frmMain());
            }
            else
            {
                frmCmdLog log = new frmCmdLog();
                new CommandLine(args, log);
                Application.Run(log);
            }
        }
    }
}
