// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TvShowEventArgs.cs" company="TVSorter">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Arguments for a TV Show related event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using TVSorter.Model;

namespace TVSorter;

/// <summary>
///     Arguments for a TV Show related event.
/// </summary>
/// <remarks>
///     Initialises a new instance of the <see cref="TvShowEventArgs" /> class.
/// </remarks>
/// <param name="tvShow">
///     The TV Show for the event.
/// </param>
public class TvShowEventArgs(TvShow tvShow) : EventArgs
{

    /// <summary>
    ///     Gets the TV Show for the event.
    /// </summary>
    public TvShow TvShow { get; } = tvShow;
}
