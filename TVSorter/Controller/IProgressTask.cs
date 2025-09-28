// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="IProgressTask.cs">
//   2025 - Andrew Jackson & Nicolas Pierre
// </copyright>
// <summary>
//   The public interface of the progress task.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TVSorter.Controller;

/// <summary>
///     The public interface of the progress task.
/// </summary>
public interface IProgressTask
{
    /// <summary>
    ///     Occurs when the task is complete.
    /// </summary>
    event EventHandler TaskComplete;
}
