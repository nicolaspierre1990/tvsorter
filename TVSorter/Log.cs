﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TVSorter
{
    class Log
    {
        private static ListBox _listBox;
        private static bool logToGui;
        private static frmCmdLog _cmdLog;

        public static void Init(ListBox listBox)
        {
            _listBox = listBox;
            logToGui = true;
        }

        public static void Init(frmCmdLog cmdLog)
        {
            logToGui = false;
            _cmdLog = cmdLog;
        }


        public static void Add(string message)
        {
            string entry = DateTime.Now.ToLongTimeString() + " - " + message;
            if (logToGui)
            {
                MethodInvoker log = new MethodInvoker(delegate() { _listBox.Items.Add(entry); });
                _listBox.Invoke(log);
            }
            else
            {
                MethodInvoker log = new MethodInvoker(delegate() { _cmdLog.Append(entry); });
                _cmdLog.Invoke(log);
            }
        }
    }
}
