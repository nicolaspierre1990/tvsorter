// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataProvider.cs" company="TVSorter">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Interface for getting show data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TVSorter.Model;

namespace TVSorter.Data;

/// <summary>
///     Interface for getting show data.
/// </summary>
public interface IDataProvider
{
    /// <summary>
    ///     Search for a show.
    /// </summary>
    /// <param name="name">
    ///     The name to search for.
    /// </param>
    /// <returns>
    ///     The list of results.
    /// </returns>
    List<TvShow> SearchShow(string name);

    /// <summary>
    /// Searches the show asynchronous.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    Task<List<TvShow>> SearchShowAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates the specified show.
    /// </summary>
    /// <param name="show">
    ///     The show to update.
    /// </param>
    void UpdateShow(TvShow show);

    /// <summary>
    /// Updates the show asynchronous.
    /// </summary>
    /// <param name="show">The show.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task UpdateShowAsync(TvShow show, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates the collection of shows.
    /// </summary>
    /// <param name="shows">
    ///     The shows to update.
    /// </param>
    /// <returns>
    ///     The collection of TVShows that have been updated.
    /// </returns>
    IEnumerable<TvShow> UpdateShows(IList<TvShow> shows);

    /// <summary>
    /// Updates the shows asynchronous.
    /// </summary>
    /// <param name="shows">The shows.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task<IEnumerable<TvShow>> UpdateShowsAsync(IList<TvShow> shows, CancellationToken cancellationToken = default);
}
