// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileSearch.cs" company="TVSorter">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Searches the files and presents the results.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TVSorter.Data;
using TVSorter.Model;
using TVSorter.Storage;

namespace TVSorter.Files;

/// <summary>
///     Searches the files and presents the results.
/// </summary>
/// <remarks>
///     Initialises a new instance of the <see cref="FileSearch" /> class.
/// </remarks>
/// <param name="storageProvider">
///     The storage provider.
/// </param>
/// <param name="dataProvider">
///     The data provider.
/// </param>
/// <param name="scanManager">
///     The scan manager.
/// </param>
/// <param name="fileManager">
///     The file manager.
/// </param>
public class FileSearch(
    IStorageProvider storageProvider,
    IDataProvider dataProvider,
    IScanManager scanManager,
    IFileManager fileManager) : IFileSearch
{
    /// <summary>
    ///     The file manager.
    /// </summary>
    private readonly IFileManager fileManager = fileManager;

    /// <summary>
    ///     The scan manager.
    /// </summary>
    private readonly IScanManager scanManager = scanManager;

    /// <summary>
    ///     The data provider.
    /// </summary>
    private readonly IDataProvider dataProvider = dataProvider;

    /// <summary>
    ///     The storage provider.
    /// </summary>
    private readonly IStorageProvider storageProvider = storageProvider;

    /// <summary>
    ///     Gets the results of the search.
    /// </summary>
    public List<FileResult> Results { get; private set; } = [];

    /// <summary>
    ///     Refreshes the file counts of the episodes.
    /// </summary>
    public void RefreshFileCounts() => scanManager.RefreshFileCounts();

    /// <summary>
    ///     Copies the checked file results.
    /// </summary>
    public void Copy() => fileManager.CopyFile(Results.Where(x => x.Checked).ToList());

    /// <summary>
    ///     Moves the checked file results.
    /// </summary>
    public void Move() => fileManager.MoveFile(Results.Where(x => x.Checked).ToList());

    /// <summary>
    ///     Performs a search.
    /// </summary>
    /// <param name="subDirectory">
    ///     The sub directory to search.
    /// </param>
    public void Search(string subDirectory)
    {
        subDirectory ??= Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);

        Results = scanManager.Refresh(subDirectory);
        Logger.OnLogMessage(this, "Scan complete. Found {0} files.", LogType.Info, Results.Count);
    }

    /// <summary>
    ///     Sets the episode of the checked results.
    /// </summary>
    /// <param name="seasonNumber">
    ///     The season number.
    /// </param>
    /// <param name="episodeNumber">
    ///     The episode number.
    /// </param>
    public void SetEpisode(int seasonNumber, int episodeNumber)
    {
        foreach (var result in Results.Where(x => x.Checked && x.Show != null))
        {
            var episode = result.Show.Episodes.FirstOrDefault(
                x => x.SeasonNumber == seasonNumber && x.EpisodeNumber == episodeNumber);
            result.Episode = episode;
            result.Episodes = new List<Episode> { episode };
        }
    }

    /// <summary>
    ///     Sets the show of the checked results.
    /// </summary>
    /// <param name="show">
    ///     The show to set them to.
    /// </param>
    public void SetShow(TvShow show)
    {
        foreach (var result in Results.Where(x => x.Checked))
        {
            scanManager.ResetShow(result, show);
        }
    }
}
