using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSorter.Files;
using TVSorter.Model;
using TVSorter.Repostitory;

namespace TVSorter.Ui.ViewModels;

public class ShowSorterViewModel: ViewModelBase
{
    private readonly ILogger<ShowSorterViewModel> _logger;
    private readonly ISettingsRepository _settingsRepository;
    private readonly IFileSearch _fileSearch;
    private readonly IFileResultManager _fileResultManager;
    private ObservableCollection<FileResultItem> _fileResults;
    private Settings _sorterSettings;

    public ICommand ScanFoldersCommand { get; set; }
    public ICommand SortShowsCommand { get; set;  }
    public ICommand ToggleSelectAllCommand { get; set; }
    public ICommand SelectAllCommand { get; set;  }

    public ICommand UnselectAllCommand { get; set;  }

    public ObservableCollection<FileResultItem> FileResults
    {
        get => _fileResults;
        set => this.RaiseAndSetIfChanged(ref _fileResults, value);
    }

    public ShowSorterViewModel(
        ILogger<ShowSorterViewModel> logger,
        ISettingsRepository settingsRepository,
        IFileResultManager fileResultManager,
        IFileSearch fileSearch)
    {
        _logger = logger;
        _settingsRepository = settingsRepository;
        _settingsRepository.SettingsUpdated += async (s, e) => _sorterSettings = JsonSerializer.Deserialize<Settings>(e.Settings.SettingValue);
        _fileSearch = fileSearch;
        _fileResultManager = fileResultManager;

        ScanFoldersCommand = ReactiveCommand.CreateFromTask(ScanFoldersAsync);
        SortShowsCommand = ReactiveCommand.CreateFromTask(SortShowsAsync);
        SelectAllCommand = ReactiveCommand.CreateFromTask(() => ToggleSelect(true));
        UnselectAllCommand = ReactiveCommand.CreateFromTask(() => ToggleSelect(false));
    }

    public override async Task InitializeView(CancellationToken cancellationToken)
    {
        _sorterSettings = await _settingsRepository.LoadSettingsAsync<Settings>(Settings.SETTING_NAME, cancellationToken);
    }

    private async Task ScanFoldersAsync()
    {
        SetIsBusy(true);

        _fileSearch.Search(string.Empty);
        FileResults = new ObservableCollection<FileResultItem>(FomatFileResults(_fileSearch.Results));

        SetIsBusy(false);
    }

    private IEnumerable<FileResultItem> FomatFileResults(List<FileResult> fileResults)
    {
        foreach (var result in fileResults)
        {
            var item = new FileResultItem
            {
                InputFileName = result.InputFile.FullName,
                ShowName = result.Show?.Name ?? result.ShowName,
                EpisodeName = result.Episode?.Name ?? string.Empty,
                Season = result.Episode?.SeasonNumber ?? null,
                Episode = result.Episode?.EpisodeNumber ?? null,
                DestinationPath = _fileResultManager.FormatOutputPath(result)
            };
            
            yield return item;
        }
    }

    private async Task ToggleSelect(bool isChecked)
    {
        foreach (FileResultItem fileResult in FileResults)
        {
            fileResult.IsChecked = isChecked;
        }
    }

    private async Task SortShowsAsync()
    {
        throw new NotImplementedException();
    }
}

public class FileResultItem : ReactiveObject
{
    private bool _isChecked;

    public string InputFileName { get; set; } = default!;
    public string ShowName { get; set; } = default!;
    public string? EpisodeName { get; set; }
    public int? Season { get; set; }
    public int? Episode { get; set; }
    public string? DestinationPath { get; set; }
    
    public bool IsChecked
    {
        get => _isChecked;
        set => this.RaiseAndSetIfChanged(ref _isChecked, value);
    }
}
