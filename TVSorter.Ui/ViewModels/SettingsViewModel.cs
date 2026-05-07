using Microsoft.Extensions.Logging;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSorter.Model;
using TVSorter.Repostitory;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia;
using Avalonia.Platform.Storage;

namespace TVSorter.Ui.ViewModels;

/// <summary>
///     The view model for the settings view.
/// </summary>
public class SettingsViewModel : ViewModelBase
{
    private readonly ILogger<SettingsViewModel> _logger;
    private readonly ISettingsRepository _settingsRepository;
    private Settings _settings = default!;
    private string _selectedDestinationDirectory = default!;
    private string _selectedIgnoredDirectory = default!;
    private string _selectedFileExtension = default!;
    private string _selectedRegularExpression = default!;
    private string _selectedOverwriteKeyword = default!;

    public SettingsViewModel(ILogger<SettingsViewModel> logger, ISettingsRepository settingsRepository)
    {
        _logger = logger;
        _settingsRepository = settingsRepository;

        // Initialize collections
        DestinationDirectories = new ObservableCollection<string>();
        IgnoredDirectories = new ObservableCollection<string>();
        FileExtensions = new ObservableCollection<string>();
        RegularExpressions = new ObservableCollection<string>();
        OverwriteKeywords = new ObservableCollection<string>();

        // Commands
        BrowseSourceDirectoryCommand = ReactiveCommand.CreateFromTask(BrowseSourceDirectoryAsync);
        AddDestinationDirectoryCommand = ReactiveCommand.CreateFromTask(AddDestinationDirectoryAsync);
        RemoveDestinationDirectoryCommand = ReactiveCommand.Create(RemoveDestinationDirectory,
            this.WhenAnyValue(x => x.SelectedDestinationDirectory, dir => !string.IsNullOrEmpty(dir)));

        AddIgnoredDirectoryCommand = ReactiveCommand.CreateFromTask(AddIgnoredDirectoryAsync);
        RemoveIgnoredDirectoryCommand = ReactiveCommand.Create(RemoveIgnoredDirectory,
            this.WhenAnyValue(x => x.SelectedIgnoredDirectory, dir => !string.IsNullOrEmpty(dir)));

        AddFileExtensionCommand = ReactiveCommand.CreateFromTask(AddFileExtensionAsync);
        RemoveFileExtensionCommand = ReactiveCommand.Create(RemoveFileExtension,
            this.WhenAnyValue(x => x.SelectedFileExtension, ext => !string.IsNullOrEmpty(ext)));

        AddRegularExpressionCommand = ReactiveCommand.CreateFromTask(AddRegularExpressionAsync);
        RemoveRegularExpressionCommand = ReactiveCommand.Create(RemoveRegularExpression,
            this.WhenAnyValue(x => x.SelectedRegularExpression, regex => !string.IsNullOrEmpty(regex)));

        AddOverwriteKeywordCommand = ReactiveCommand.CreateFromTask(AddOverwriteKeywordAsync);
        RemoveOverwriteKeywordCommand = ReactiveCommand.Create(RemoveOverwriteKeyword,
            this.WhenAnyValue(x => x.SelectedOverwriteKeyword, keyword => !string.IsNullOrEmpty(keyword)));

        SaveCommand = ReactiveCommand.CreateFromTask(SaveAsync);
        RevertCommand = ReactiveCommand.CreateFromTask(LoadSettingsAsync);

        // Load settings on initialization
        _ = LoadSettingsAsync();
    }

    #region Properties

    public Settings Settings
    {
        get => _settings;
        set => this.RaiseAndSetIfChanged(ref _settings, value);
    }

    public ObservableCollection<string> DestinationDirectories { get; }
    public ObservableCollection<string> IgnoredDirectories { get; }
    public ObservableCollection<string> FileExtensions { get; }
    public ObservableCollection<string> RegularExpressions { get; }
    public ObservableCollection<string> OverwriteKeywords { get; }

    public string SelectedDestinationDirectory
    {
        get => _selectedDestinationDirectory;
        set => this.RaiseAndSetIfChanged(ref _selectedDestinationDirectory, value);
    }

    public string SelectedIgnoredDirectory
    {
        get => _selectedIgnoredDirectory;
        set => this.RaiseAndSetIfChanged(ref _selectedIgnoredDirectory, value);
    }

    public string SelectedFileExtension
    {
        get => _selectedFileExtension;
        set => this.RaiseAndSetIfChanged(ref _selectedFileExtension, value);
    }

    public string SelectedRegularExpression
    {
        get => _selectedRegularExpression;
        set => this.RaiseAndSetIfChanged(ref _selectedRegularExpression, value);
    }

    public string SelectedOverwriteKeyword
    {
        get => _selectedOverwriteKeyword;
        set => this.RaiseAndSetIfChanged(ref _selectedOverwriteKeyword, value);
    }

    #endregion

    #region Commands

    public ICommand BrowseSourceDirectoryCommand { get; }
    public ICommand AddDestinationDirectoryCommand { get; }
    public ICommand RemoveDestinationDirectoryCommand { get; }
    public ICommand AddIgnoredDirectoryCommand { get; }
    public ICommand RemoveIgnoredDirectoryCommand { get; }
    public ICommand AddFileExtensionCommand { get; }
    public ICommand RemoveFileExtensionCommand { get; }
    public ICommand AddRegularExpressionCommand { get; }
    public ICommand RemoveRegularExpressionCommand { get; }
    public ICommand AddOverwriteKeywordCommand { get; }
    public ICommand RemoveOverwriteKeywordCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand RevertCommand { get; }

    #endregion

    #region Methods

    private async Task LoadSettingsAsync()
    {
        Settings = await _settingsRepository.LoadSettingsAsync<Settings>(Settings.SETTING_NAME);

        if (Settings == null)
        {
            Settings = Settings.GetDefault();
        }

        // Populate collections
        DestinationDirectories.Clear();
        foreach (var dir in Settings.DestinationDirectories ?? [])
            DestinationDirectories.Add(dir);

        IgnoredDirectories.Clear();
        foreach (var dir in Settings.IgnoredDirectories ?? [])
            IgnoredDirectories.Add(dir);

        FileExtensions.Clear();
        foreach (var ext in Settings.FileExtensions ?? [])
            FileExtensions.Add(ext);

        RegularExpressions.Clear();
        foreach (var regex in Settings.RegularExpressions ?? [])
            RegularExpressions.Add(regex);

        OverwriteKeywords.Clear();
        foreach (var keyword in Settings.OverwriteKeywords ?? [])
            OverwriteKeywords.Add(keyword);
    }

    private async Task SaveAsync()
    {
        // Update settings from collections
        Settings.DestinationDirectories = DestinationDirectories.ToList();
        Settings.IgnoredDirectories = IgnoredDirectories.ToList();
        Settings.FileExtensions = FileExtensions.ToList();
        Settings.RegularExpressions = RegularExpressions.ToList();
        Settings.OverwriteKeywords = OverwriteKeywords.ToList();

        var setting = new Data.Setting
        {
            SettingName = Settings.SETTING_NAME,
            SettingValue = System.Text.Json.JsonSerializer.Serialize(Settings)
        };

        await _settingsRepository.SaveSettingsAsync(setting);
        
        _logger.LogInformation("Settings saved successfully");
    }

    private async Task BrowseSourceDirectoryAsync()
    {
        var folder = await BrowseForFolderAsync();
        if (folder != null)
        {
            Settings.SourceDirectory = folder;
            this.RaisePropertyChanged(nameof(Settings));
        }
    }

    private async Task AddDestinationDirectoryAsync()
    {
        var folder = await BrowseForFolderAsync();
        if (folder != null && !DestinationDirectories.Contains(folder))
        {
            DestinationDirectories.Add(folder);
        }
    }

    private void RemoveDestinationDirectory()
    {
        if (!string.IsNullOrEmpty(SelectedDestinationDirectory))
        {
            DestinationDirectories.Remove(SelectedDestinationDirectory);
        }
    }

    private async Task AddIgnoredDirectoryAsync()
    {
        var folder = await BrowseForFolderAsync();
        if (folder != null && !IgnoredDirectories.Contains(folder))
        {
            IgnoredDirectories.Add(folder);
        }
    }

    private void RemoveIgnoredDirectory()
    {
        if (!string.IsNullOrEmpty(SelectedIgnoredDirectory))
        {
            IgnoredDirectories.Remove(SelectedIgnoredDirectory);
        }
    }

    private async Task AddFileExtensionAsync()
    {
        var result = await ShowInputDialogAsync("Add File Extension", "Enter file extension (e.g., .mp4):");
        if (!string.IsNullOrEmpty(result) && !FileExtensions.Contains(result))
        {
            FileExtensions.Add(result);
        }
    }

    private void RemoveFileExtension()
    {
        if (!string.IsNullOrEmpty(SelectedFileExtension))
        {
            FileExtensions.Remove(SelectedFileExtension);
        }
    }

    private async Task AddRegularExpressionAsync()
    {
        var result = await ShowInputDialogAsync("Add Regular Expression", "Enter regular expression:");
        if (!string.IsNullOrEmpty(result) && !RegularExpressions.Contains(result))
        {
            RegularExpressions.Add(result);
        }
    }

    private void RemoveRegularExpression()
    {
        if (!string.IsNullOrEmpty(SelectedRegularExpression))
        {
            RegularExpressions.Remove(SelectedRegularExpression);
        }
    }

    private async Task AddOverwriteKeywordAsync()
    {
        var result = await ShowInputDialogAsync("Add Overwrite Keyword", "Enter overwrite keyword:");
        if (!string.IsNullOrEmpty(result) && !OverwriteKeywords.Contains(result))
        {
            OverwriteKeywords.Add(result);
        }
    }

    private void RemoveOverwriteKeyword()
    {
        if (!string.IsNullOrEmpty(SelectedOverwriteKeyword))
        {
            OverwriteKeywords.Remove(SelectedOverwriteKeyword);
        }
    }

    /// <summary>
    ///     Opens a folder picker dialog and returns the selected folder path.
    /// </summary>
    /// <returns>The selected folder path, or null if cancelled.</returns>
    private async Task<string?> BrowseForFolderAsync()
    {
        try
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = desktop.MainWindow;
                if (mainWindow?.StorageProvider != null)
                {
                    var folders = await mainWindow.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
                    {
                        Title = "Select Folder",
                        AllowMultiple = false
                    });

                    if (folders.Count > 0)
                    {
                        return folders[0].Path.LocalPath;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Error opening folder picker");
        }

        return null;
    }

    /// <summary>
    ///     Shows an input dialog and returns the entered text.
    /// </summary>
    /// <param name="title">The dialog title.</param>
    /// <param name="prompt">The prompt message.</param>
    /// <returns>The entered text, or null if cancelled.</returns>
    private async Task<string?> ShowInputDialogAsync(string title, string prompt)
    {
        try
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = desktop.MainWindow;
                if (mainWindow != null)
                {
                    var dialog = new Views.InputDialog
                    {
                        Title = title,
                        DataContext = new InputDialogViewModel { Prompt = prompt }
                    };

                    var result = await dialog.ShowDialog<string?>(mainWindow);
                    return result;
                }
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Error showing input dialog");
        }

        return null;
    }

    #endregion
}
