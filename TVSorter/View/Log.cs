﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="Log.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The log tab.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TVSorter.View
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Windows.Forms;

    using TVSorter.Controller;

    #endregion

    /// <summary>
    /// The log tab.
    /// </summary>
    public partial class Log : UserControl
    {
        #region Fields

        /// <summary>
        ///   The log controller.
        /// </summary>
        private readonly LogController controller;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="Log" /> class.
        /// </summary>
        public Log()
        {
            this.InitializeComponent();
            this.controller = new LogController();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Handles a log message being recieved.
        /// </summary>
        /// <param name="sender">
        /// The sender of the event. 
        /// </param>
        /// <param name="e">
        /// The arguments of the event. 
        /// </param>
        public void LogMessageReceived(object sender, LogMessageEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.LogMessageReceived(sender, e)));
            }
            else
            {
                this.logList.Items.Add(e.ToString());
                this.logList.SelectedIndex = this.logList.Items.Count - 1;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the Log tab loading.
        /// </summary>
        /// <param name="sender">
        /// The sender of the event. 
        /// </param>
        /// <param name="e">
        /// The arguments of the event. 
        /// </param>
        private void LogLoad(object sender, EventArgs e)
        {
            this.controller.Initialise(null);
            this.controller.LogMessageReceived += this.LogMessageReceived;
            this.logList.Items.AddRange(this.controller.Log.ToArray<object>());
        }

        #endregion
    }
}