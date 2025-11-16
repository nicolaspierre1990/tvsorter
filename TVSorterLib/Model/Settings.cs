// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="Settings.cs">
//   2025 - Andrew Jackson & Nicolas Pierre
// </copyright>
// <summary>
//   The settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace TVSorter.Model;

/// <summary>
///     The settings.
/// </summary>
public class Settings : INotifyPropertyChanged
{
    public const string SETTING_NAME = "Settings";

    private bool _addUnmatchedShows;
    private string _defaultOutputFormat;
    private bool _deleteEmptySubdirectories;
    private List<string> _destinationDirectories;
    private List<string> _ignoredDirectories;
    private string _defaultDestinationDirectory;
    private List<string> _fileExtensions;
    private bool _lockShowsWithNoEpisodes;
    private List<string> _overwriteKeywords;
    private bool _recurseSubdirectories;
    private List<string> _regularExpressions;
    private bool _renameIfExists;
    private string _sourceDirectory;
    private bool _unlockMatchedShows;

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    ///     Gets or sets a value indicating whether unmatched shows should be added.
    /// </summary>
    public bool AddUnmatchedShows
    {
        get => _addUnmatchedShows;
        set => SetField(ref _addUnmatchedShows, value);
    }

    /// <summary>
    ///     Gets or sets DefaultOutputFormat.
    /// </summary>
    public string DefaultOutputFormat
    {
        get => _defaultOutputFormat;
        set => SetField(ref _defaultOutputFormat, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether DeleteEmptySubdirectories.
    /// </summary>
    public bool DeleteEmptySubdirectories
    {
        get => _deleteEmptySubdirectories;
        set => SetField(ref _deleteEmptySubdirectories, value);
    }

    /// <summary>
    ///     Gets or sets the list of destination directories.
    /// </summary>
    public List<string> DestinationDirectories
    {
        get => _destinationDirectories;
        set => SetField(ref _destinationDirectories, value);
    }

    /// <summary>
    ///     Gets or sets the list of ignored directories.
    /// </summary>
    public List<string> IgnoredDirectories
    {
        get => _ignoredDirectories;
        set => SetField(ref _ignoredDirectories, value);
    }

    /// <summary>
    ///     Gets or sets the selected destination directory.
    /// </summary>
    public string DefaultDestinationDirectory
    {
        get => _defaultDestinationDirectory;
        set => SetField(ref _defaultDestinationDirectory, value);
    }

    /// <summary>
    ///     Gets or sets the list of file extensions to search.
    /// </summary>
    public List<string> FileExtensions
    {
        get => _fileExtensions;
        set => SetField(ref _fileExtensions, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to lock shows that have had no episodes in the past 3 weeks.
    /// </summary>
    public bool LockShowsWithNoEpisodes
    {
        get => _lockShowsWithNoEpisodes;
        set => SetField(ref _lockShowsWithNoEpisodes, value);
    }

    /// <summary>
    ///     Gets or sets OverwriteKeywords.
    /// </summary>
    public List<string> OverwriteKeywords
    {
        get => _overwriteKeywords;
        set => SetField(ref _overwriteKeywords, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to recursively search subdirectories.
    /// </summary>
    public bool RecurseSubdirectories
    {
        get => _recurseSubdirectories;
        set => SetField(ref _recurseSubdirectories, value);
    }

    /// <summary>
    ///     Gets or sets the list of regular expressions used to match shows.
    /// </summary>
    public List<string> RegularExpressions
    {
        get => _regularExpressions;
        set => SetField(ref _regularExpressions, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether RenameIfExists.
    /// </summary>
    public bool RenameIfExists
    {
        get => _renameIfExists;
        set => SetField(ref _renameIfExists, value);
    }

    /// <summary>
    ///     Gets or sets the source directory to scan.
    /// </summary>
    public string SourceDirectory
    {
        get => _sourceDirectory;
        set => SetField(ref _sourceDirectory, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether matched shows should be unlocked.
    /// </summary>
    public bool UnlockMatchedShows
    {
        get => _unlockMatchedShows;
        set => SetField(ref _unlockMatchedShows, value);
    }

    /// <summary>
    ///     Raises the PropertyChanged event.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    ///     Sets the field and raises PropertyChanged if the value has changed.
    /// </summary>
    /// <typeparam name="T">The type of the field.</typeparam>
    /// <param name="field">The field to set.</param>
    /// <param name="value">The new value.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>True if the value changed; otherwise, false.</returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    /// <summary>
    ///     Sets default settings.
    /// </summary>
    public static Settings GetDefault()
    {
        var settings = new Settings();
        var regularExpressions = new List<string>
        {
            @"s(?<S>[0-9]+)e((?<E>[0-9]+)[e-]{0,1})+",
            @"(?<Y>19\d\d|20\d\d)[.](?<M>0[1-9]|1[012])[.](?<D>0[1-9]|[12][0-9]|3[01])",
            @"(?<M>Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\.(?<D>\d\d)\.(?<Y>20\d\d)",
            @"(?<S>[0-9]+)\s-\s(?<E>[0-9]+)",
            @"(?<S>[0-9]+)x(?<E>[0-9]+)",
            @"(?<S>[0-9][0-9])(?<E>[0-9][0-9])",
            @"(?<S>[0-9])(?<E>[0-9][0-9])",
            @"s(?<S>[0-9]+)[.]e(?<E>[0-9]+)"
        };

        settings.SourceDirectory = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);
        settings.DestinationDirectories = [];
        settings.IgnoredDirectories = [];
        settings.DefaultDestinationDirectory = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);
        settings.FileExtensions = [".avi", ".mkv", ".wmv", ".mpg", ".mp4"];
        settings.RegularExpressions = regularExpressions;
        settings.DefaultOutputFormat = "{FName}" +
                              Path.DirectorySeparatorChar +
                              "Season {SNum(1)}" +
                              Path.DirectorySeparatorChar +
                              "{SName(.)}." +
                              "S{SNum(2)}E{ENum(2)}.{EName(.)}{Ext}";
        settings.DeleteEmptySubdirectories = false;
        settings.OverwriteKeywords = ["repack", "proper"];
        settings.RecurseSubdirectories = false;
        settings.RenameIfExists = false;
        settings.UnlockMatchedShows = false;
        settings.AddUnmatchedShows = false;
        settings.LockShowsWithNoEpisodes = false;

        return settings;
    }
}
