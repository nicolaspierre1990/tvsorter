using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TVSorter.Data;
using TVSorter.Model;

namespace TVSorter.Storage;

public class SQLLiteProvider(TvSorterDbContext dbContext) : IStorageProvider
{
    /// <summary>
    /// The database context
    /// </summary>
    private readonly TvSorterDbContext dbContext = dbContext;

    /// <summary>
    ///     Gets the settings.
    /// </summary>
    public Settings Settings { get; private set; }

    /// <inheritdoc />
    /// <summary>
    ///     Gets the missing episode settings.
    /// </summary>
    public MissingEpisodeSettings MissingEpisodeSettings { get; private set; }

    public event EventHandler SettingsSaved;
    public event EventHandler<TvShowEventArgs> TvShowAdded;
    public event EventHandler<TvShowEventArgs> TvShowChanged;
    public event EventHandler<TvShowEventArgs> TvShowRemoved;

    public IEnumerable<Episode> GetDuplicateEpisodes()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Episode> GetMissingEpisodes()
    {
        throw new NotImplementedException();
    }

    public Settings LoadSettings()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TvShow> LoadTvShows() => dbContext.TvShows.AsEnumerable();

    public void RemoveShow(TvShow show)
    {
        throw new NotImplementedException();
    }

    public void SaveEpisode(Episode episode)
    {
        throw new NotImplementedException();
    }

    public void SaveMissingEpisodeSettings()
    {
        throw new NotImplementedException();
    }

    public void SaveSettings()
    {
        throw new NotImplementedException();
    }

    public void SaveShow(TvShow show)
    {
        throw new NotImplementedException();
    }

    public void SaveShows(IEnumerable<TvShow> shows)
    {
        throw new NotImplementedException();
    }
}
