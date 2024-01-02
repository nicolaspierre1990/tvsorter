// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="MainForm.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The main form of the program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Windows.Forms;

namespace TVSorter.View
{
    /// <summary>
    ///     The main form of the program.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Initialises a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            FormClosed += MainForm_FormClosed;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        ///     Handles the load event for the form.
        /// </summary>
        /// <param name="sender">
        ///     The sender of the event.
        /// </param>
        /// <param name="e">
        ///     The arguments of the event.
        /// </param>
        private void MainFormLoad(object sender, EventArgs e) => Text = $"TV Sorter v{CompositionRoot.Version}";

        /// <summary>
        /// Handles the FormClosed event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}
