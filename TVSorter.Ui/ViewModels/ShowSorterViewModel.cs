using Microsoft.Extensions.Logging;
using ReactiveUI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSorter.Files;
using TVSorter.Model;
using TVSorter.Repostitory;

namespace TVSorter.Ui.ViewModels;

public class ShowSorterViewModel : ViewModelBase
{
    private readonly ILogger<ShowSorterViewModel> _logger;
    private readonly ISettingsRepository _settingsRepository;
    private readonly IFileSearch _fileSearch;
    private readonly IFileResultManager _fileResultManager;
    private readonly IFileManager _fileManager;
    private ObservableCollection<FileResultItem> _fileResults = new ObservableCollection<FileResultItem>();
    private Settings _sorterSettings;

    public ICommand ScanFoldersCommand { get; set; }
    public ICommand SortShowsCommand { get; set; }
    public ICommand SetShowCommand { get; set; }
    public ICommand ToggleSelectAllCommand { get; set; }
    public ICommand SelectAllCommand { get; set; }

    public ICommand UnselectAllCommand { get; set; }

    public ObservableCollection<FileResultItem> FileResults
    {
        get => _fileResults;
        set => this.RaiseAndSetIfChanged(ref _fileResults, value);
    }

    public ShowSorterViewModel(
        ILogger<ShowSorterViewModel> logger,
        ISettingsRepository settingsRepository,
        IFileResultManager fileResultManager,
        IFileManager fileManager,
        IFileSearch fileSearch)
    {
        _logger = logger;
        _settingsRepository = settingsRepository;
        _settingsRepository.SettingsUpdated += async (s, e) => _sorterSettings = JsonSerializer.Deserialize<Settings>(e.Settings.SettingValue);
        _fileSearch = fileSearch;
        _fileResultManager = fileResultManager;
        _fileManager = fileManager;

        ScanFoldersCommand = ReactiveCommand.CreateFromTask(ScanFoldersAsync);
        SortShowsCommand = ReactiveCommand.CreateFromTask(SortShowsAsync);
        SelectAllCommand = ReactiveCommand.CreateFromTask(() => ToggleSelect(true));
        UnselectAllCommand = ReactiveCommand.CreateFromTask(() => ToggleSelect(false));
        //SetShowCommand = ReactiveCommand.CreateFromTask(() => SetShowAsync(), this.WhenAnyValue(x => x.FileResults.Any(x => x.IsChecked)));
    }

    public override async Task InitializeView(CancellationToken cancellationToken)
    {
        _sorterSettings = await _settingsRepository.LoadSettingsAsync<Settings>(Settings.SETTING_NAME, cancellationToken);
    }

    private async Task ScanFoldersAsync()
    {
        try
        {
            SetIsBusy(true);

            await Task.Run(() =>
            {
                _fileSearch.Search(string.Empty);
                FileResults = new ObservableCollection<FileResultItem>(FomatFileResults(_fileSearch.Results));
            });
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            SetIsBusy(false);
        }

    }

    private async Task SetShowAsync()
    {
        throw new NotImplementedException();
    }


    private IEnumerable<FileResultItem> FomatFileResults(List<FileResult> fileResults)
    {
        foreach (var result in fileResults)
        {
            yield return new FileResultItem(result, _fileResultManager.FormatOutputPath(result));
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
        try
        {
            SetIsBusy(true);

            await Task.Run(() => _fileManager.MoveFile(FileResults.Where(x => x.IsChecked).Select(i => i.FileResult)));
            await ScanFoldersAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            SetIsBusy(false);
        }
    }
}

public class FileResultItem(FileResult fileResult, string destinationPath) : ReactiveObject
{
    private bool _isChecked = fileResult.Checked;

    public FileResult FileResult => fileResult;

    public string InputFileName { get; set; } = fileResult.InputFile.FullName;
    public string ShowName { get; set; } = fileResult.Show?.Name ?? fileResult.ShowName;
    public string? EpisodeName { get; set; } = fileResult.Episode?.Name ?? string.Empty;
    public int? Season { get; set; } = fileResult.Episode?.SeasonNumber ?? null;
    public int? Episode { get; set; } = fileResult.Episode?.EpisodeNumber ?? null;
    public string? DestinationPath { get; set; } = destinationPath;

    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            fileResult.Checked = value;
            this.RaiseAndSetIfChanged(ref _isChecked, value);
        }
    }
}
