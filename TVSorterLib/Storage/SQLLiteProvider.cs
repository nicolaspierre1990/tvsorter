using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TVSorter.Data;
using TVSorter.Model;

namespace TVSorter.Storage;

public class SQLLiteProvider : IStorageProvider
{
    /// <summary>
    /// The database context
    /// </summary>
    private readonly TvSorterDbContext dbContext;

    /// <summary>
    ///     Gets the settings.
    /// </summary>
    public Settings Settings { get; private set; }

    /// <inheritdoc />
    /// <summary>
    ///     Gets the missing episode settings.
    /// </summary>
    public MissingEpisodeSettings MissingEpisodeSettings { get; private set; }

    /// <summary>
    /// Gets a value indicating whether this instance is available.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is available; otherwise, <c>false</c>.
    /// </value>
    public bool IsAvailable { get; private set; }

    public event EventHandler SettingsSaved;
    public event EventHandler<TvShowEventArgs> TvShowAdded;
    public event EventHandler<TvShowEventArgs> TvShowChanged;
    public event EventHandler<TvShowEventArgs> TvShowRemoved;

    public SQLLiteProvider(TvSorterDbContext dbContext)
    {
        this.dbContext = dbContext;
        Initialise();
    }

    public IEnumerable<Episode> GetDuplicateEpisodes() => GetEpisodes(x => x > 1);

    public IEnumerable<Episode> GetMissingEpisodes() => GetEpisodes(x => x == 0);

    public Settings LoadSettings()
    {
        var missingEpisodeSettings = dbContext.Settings.Find(MissingEpisodeSettings.SETTING_NAME);
        if (missingEpisodeSettings == null)
        {
            MissingEpisodeSettings = MissingEpisodeSettings.GetDefault();
            SaveMissingEpisodeSettings();
        }
        else
        {
            MissingEpisodeSettings = JsonSerializer.Deserialize<MissingEpisodeSettings>(missingEpisodeSettings.SettingValue);
        }

        var generalSettings = dbContext.Settings.Find(Settings.SETTING_NAME);
        if (generalSettings == null)
        {
            Settings = Settings.GetDefault();
            SaveSettings();
        }
        else
        {
            Settings = JsonSerializer.Deserialize<Settings>(generalSettings.SettingValue);
        }

        return Settings;
    }

    public IEnumerable<TvShow> LoadTvShows() 
        => dbContext.TvShows.Include(x => x.Episodes).AsEnumerable();

    public void RemoveShow(TvShow show)
    {
        dbContext.TvShows.Remove(show);
        dbContext.SaveChanges();

        OnTvShowRemoved(show);
    }

    public void SaveEpisode(Episode episode)
    {
        if (dbContext.Episodes.Any(x => x.TvdbId == episode.TvdbId))
        { 
            dbContext.Episodes.Update(episode);
            dbContext.SaveChanges();
        }
        else
        {

            dbContext.Episodes.Add(episode);
            dbContext.SaveChanges();
        }
    }

    public void SaveMissingEpisodeSettings()
    {
        var missingEpisodeSettings = dbContext.Settings.Find(MissingEpisodeSettings.SETTING_NAME);
        var missingEpisodeSettingsValue = JsonSerializer.Serialize(MissingEpisodeSettings);

        if (missingEpisodeSettings == null)
        {
            dbContext.Add(new Setting { SettingName = MissingEpisodeSettings.SETTING_NAME, SettingValue = missingEpisodeSettingsValue });
            dbContext.SaveChanges();
        }
        else
        {
            missingEpisodeSettings.SettingValue = missingEpisodeSettingsValue;

            dbContext.Update(missingEpisodeSettings);
        }

        dbContext.SaveChanges();
        OnSettingsSaved();
    }

    public void SaveSettings()
    {
        var settings = dbContext.Settings.Find(Settings.SETTING_NAME);
        var settingsValue = JsonSerializer.Serialize(Settings);

        if (settings == null)
        {
            dbContext.Add(new Setting { SettingName = Settings.SETTING_NAME, SettingValue = settingsValue });
        }
        else
        {
            settings.SettingValue = settingsValue;
            dbContext.Update(settings);
        }

        dbContext.SaveChanges();
        OnSettingsSaved();
    }

    public void SaveShow(TvShow show)
    {
        Logger.OnLogMessage(this, $"Saving {show.Name}", LogType.Info);

        if (dbContext.TvShows.Any(x => x.TvdbId == show.TvdbId))
        {
            dbContext.TvShows.Update(show);
            OnTvShowChanged(show);
        }
        else
        {
            dbContext.TvShows.Add(show);
            OnTvShowAdded(show);
        }

        dbContext.SaveChanges();
    }

    public void SaveShows(IEnumerable<TvShow> shows) => shows.ToList().ForEach(SaveShow);

    /// <summary>
    /// Initialises this instance.
    /// </summary>
    private void Initialise()
    {
        Logger.OnLogMessage(this, $"Initialising dataProvider", LogType.Info);
        LoadSettings();
        IsAvailable = true;
    }

    /// <summary>
    ///     Fires the SettingsSaved event.
    /// </summary>
    private void OnSettingsSaved() => SettingsSaved?.Invoke(this, EventArgs.Empty);

    /// <summary>
    ///     Fires a TVShow added event.
    /// </summary>
    /// <param name="show">
    ///     The show that was added.
    /// </param>
    private void OnTvShowAdded(TvShow show)
    => TvShowAdded?.Invoke(this, new TvShowEventArgs(show));

    /// <summary>
    ///     Fires a TvShowChanged event.
    /// </summary>
    /// <param name="show">
    ///     The show that changed.
    /// </param>
    private void OnTvShowChanged(TvShow show)
    => TvShowChanged?.Invoke(this, new TvShowEventArgs(show));

    /// <summary>
    ///     Fires a TvShowRemoved event.
    /// </summary>
    /// <param name="show">
    ///     The show that was removed.
    /// </param>
    private void OnTvShowRemoved(TvShow show)
    => TvShowRemoved?.Invoke(this, new TvShowEventArgs(show));

    /// <summary>
    ///     Gets the episodes based on the specified function of file count.
    /// </summary>
    /// <param name="fileCountSelector">
    ///     The function to determine if the episode should be selected based on file count.
    /// </param>
    /// <returns>
    ///     The collection of episodes that match the predicate.
    /// </returns>
    private IEnumerable<Episode> GetEpisodes(Func<int, bool> fileCountSelector)
    {
        var tvshows = LoadTvShows();
        return tvshows.SelectMany(x => x.Episodes).Where(x => fileCountSelector(x.FileCount));
    }
}
