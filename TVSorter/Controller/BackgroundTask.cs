// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackgroundTask.cs" company="TVSorter">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   A task that runs in the background
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVSorter.View;

namespace TVSorter.Controller;

/// <summary>
///     A task that runs in the background
/// </summary>
/// <remarks>
///     Initialises a new instance of the <see cref="BackgroundTask" /> class.
/// </remarks>
/// <param name="action">
///     The method to run.
/// </param>
public class BackgroundTask(Action action) : IProgressTask
{
    /// <summary>
    ///     The task that should be run.
    /// </summary>
    private readonly Action action = action;

    /// <summary>
    ///     Occurs when the task is complete.
    /// </summary>
    public event EventHandler TaskComplete;

    /// <summary>
    ///     Starts the task.
    /// </summary>
    public void Start()
    {
        var task = Task.Factory.StartNew(
            () =>
            {
                try
                {
                    action();
                }
                catch (Exception e) when (e is not IOException)
                {
                    MessageBox.Show(CompositionRoot.Get<MainForm>(), e.AggregateMessages());
                }
            });
        task.ContinueWith(x => TaskComplete?.Invoke(this, EventArgs.Empty));
    }
}
