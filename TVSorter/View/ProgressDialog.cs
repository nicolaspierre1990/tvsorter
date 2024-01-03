// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ProgressDialog.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The dialog showing the progress bar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using TVSorter.Controller;

namespace TVSorter.View;

delegate void AddToLogCallBack(object sender, LogMessageEventArgs e);
delegate void OnProgressTaskOnTaskCompleteCallBack(object sender, EventArgs e);

/// <summary>
///     The dialog showing the progress bar.
/// </summary>
public partial class ProgressDialog : Form
{
    /// <summary>
    ///     That task that the dialog is showing the progress for.
    /// </summary>
    private readonly IProgressTask progressTask;

    /// <summary>
    ///     Initialises a new instance of the <see cref="ProgressDialog" /> class.
    /// </summary>
    /// <param name="task">
    ///     The task.
    /// </param>
    public ProgressDialog(IProgressTask task)
    {
        InitializeComponent();
        progressTask = task;
        progressTask.TaskComplete += OnProgressTaskOnTaskComplete;
        Logger.LogMessage += OnLogMessage;
    }

    /// <summary>
    ///     Handles the receipt of a log message.
    /// </summary>
    /// <param name="sender">
    ///     The sender of the event.
    /// </param>
    /// <param name="e">
    ///     The arguments of the event.
    /// </param>
    private void OnLogMessage(object sender, LogMessageEventArgs e)
    {
        if (log.InvokeRequired)
        { 
            AddToLogCallBack log = new(OnLogMessage);
            this.Invoke(log, new object[] { sender, e });
        }
        else
        {
            log.TopIndex = log.Items.Add(e.ToString());
        }
    }

    /// <summary>
    ///     Handles the completion of the task.
    /// </summary>
    /// <param name="sender">
    ///     The sender of the event.
    /// </param>
    /// <param name="e">
    ///     The arguments of the event.
    /// </param>
    private void OnProgressTaskOnTaskComplete(object sender, EventArgs e)
    {
        if (this.InvokeRequired)
        {
            OnProgressTaskOnTaskCompleteCallBack callBack = new(OnProgressTaskOnTaskComplete);
            Invoke(callBack, new object[] { sender, e });
        }
        else
        { 
            progressTask.TaskComplete -= OnProgressTaskOnTaskComplete;
            Logger.LogMessage -= OnLogMessage;
            Close();
        }
    }
}
