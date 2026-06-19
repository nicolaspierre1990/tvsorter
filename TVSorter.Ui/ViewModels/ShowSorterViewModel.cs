using Microsoft.Extensions.Logging;
using ReactiveUI;
using Splat;
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
using TVSorter.Ui.Extensions;
using TVSorter.Ui.Models;

namespace TVSorter.Ui.ViewModels;

public class ShowSorterViewModel : ViewModelBase
{
    private readonly ILogger<ShowSorterViewModel> _logger;
    private readonly ISettingsRepository _settingsRepository;
    private readonly IFileSearch _fileSearch;
    private readonly IScanManager _scanManager;
    private readonly IFileResultManager _fileResultManager;
    private readonly IFileManager _fileManager;
    private ObservableCollection<FileResultItem> _fileResults = new ObservableCollection<FileResultItem>();
    private Settings _sorterSettings;
    public ICommand ScanFoldersCommand { get; set; }
    public ICommand SortShowsCommand { get; set; }
    public ICommand SetShowCommand { get; set; }
    public ICommand SetEpisodeCommand { get; set; }
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
        IFileSearch fileSearch,
        IScanManager scanManager)
    {
        _logger = logger;
        _settingsRepository = settingsRepository;
        _settingsRepository.SettingsUpdated += async (s, e) => _sorterSettings = JsonSerializer.Deserialize<Settings>(e.Settings.SettingValue) ?? throw new InvalidOperationException("Failed to deserialize settings.");
        _fileSearch = fileSearch;
        _scanManager = scanManager;
        _fileResultManager = fileResultManager;
        _fileManager = fileManager;

        ScanFoldersCommand = ReactiveCommand.CreateFromTask(ScanFoldersAsync);
        SortShowsCommand = ReactiveCommand.CreateFromTask(SortShowsAsync/*, this.WhenAnyValue(x => x.FileResults.Any(f => f.IsChecked))*/);
        SelectAllCommand = ReactiveCommand.CreateFromTask(() => ToggleSelect(true));
        UnselectAllCommand = ReactiveCommand.CreateFromTask(() => ToggleSelect(false));
        SetShowCommand = ReactiveCommand.CreateFromTask(SetShowAsync);
        SetEpisodeCommand = ReactiveCommand.CreateFromTask(SetEpisodeAsync);
    }


    public override async Task InitializeView(CancellationToken cancellationToken)
    {
        _sorterSettings = await _settingsRepository.LoadSettingsAsync<Settings>(Settings.SETTING_NAME, cancellationToken);
    }

    private Task ScanFoldersAsync()
    {
        try
        {
            SetIsBusy(true);

            _fileSearch.Search(string.Empty);
            FileResults = new ObservableCollection<FileResultItem>(FomatFileResults(_fileSearch.Results));
        }
        catch (Exception)
        {
            Logger.OnLogMessage(this, "An error occurred while scanning folders.", LogType.Error);
        }
        finally
        {
            SetIsBusy(false);
        }

        return Task.CompletedTask;
    }

    private async Task SetEpisodeAsync()
    {
        // TODO: implement set episode logic for the single checked item
        var item = FileResults.SingleOrDefault(x => x.IsChecked);
        if (item == null) return;
    }

    private async Task SetShowAsync()
    {
        var viewModel = Locator.Current.GetRequiredService<SelectShowViewModel>();
        var task = App.ShowDialog(viewModel, "Set Show");
        if (task != null)
        {
            await task;

            foreach (var fileResult in FileResults.Where(x => x.IsChecked))
            {
                _scanManager.ResetShow(fileResult.FileResult, viewModel.SelectedShow);
                fileResult.DestinationPath = _fileResultManager.FormatOutputPath(fileResult.FileResult);
                fileResult.Refresh();
            }
        }
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
