using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Splat;
using TVSorter.Model;
using TVSorter.Repostitory;
using TVSorter.Ui.Extensions;

namespace TVSorter.Ui.ViewModels;

public class ShowsViewModel : ViewModelBase
{
    private readonly ILogger<ShowsViewModel> _logger;
    private readonly ITvShowRepository _showRepository;
    private ObservableCollection<TvShow> _shows = [];
    private ObservableCollection<TvShow> _allShows = [];
    private TvShow? _selectedShow;
    private Bitmap? _selectedShowImage;
    private string? _filterText;
    private string? _selectedAlternateName;
    private readonly ISettingsRepository _settingsRepository;
    private Settings _sorterSettings = new Settings();

    public ShowsViewModel(ILogger<ShowsViewModel> logger, ITvShowRepository tvShowRepository, ISettingsRepository settingsRepository)
    {
        _logger = logger;
        _showRepository = tvShowRepository;
        _settingsRepository = settingsRepository;
        _settingsRepository.SettingsUpdated += async (s, e) => _sorterSettings = JsonSerializer.Deserialize<Settings>(e.Settings.SettingValue) ?? throw new InvalidOperationException("Failed to deserialize settings.");

        AddShowCommand = ReactiveCommand.Create(ExecuteAddShowAsync);
        UpdateAllCommand = ReactiveCommand.CreateFromTask(ExecuteUpdateAllAsync);
        SaveShowCommand = ReactiveCommand.CreateFromTask(ExecuteSaveShowAsync, 
            this.WhenAnyValue(x => x.SelectedShow, (TvShow? show) => show != null));
        UpdateShowCommand = ReactiveCommand.CreateFromTask(ExecuteUpdateShowAsync,
            this.WhenAnyValue(x => x.SelectedShow, (TvShow? show) => show != null && !show.Locked));
        ImportShowsCommand = ReactiveCommand.CreateFromTask(ExecuteImportShowsAsync);
        ViewShowDetailsCommand = ReactiveCommand.CreateFromTask(ShowDetailDialogAsync,
            this.WhenAnyValue(x => x.SelectedShow, (TvShow? show) => show != null));
    }

    public override async Task InitializeView(CancellationToken cancellationToken)
    {
        SetIsBusy(true);

        var shows = await Task.Run(() => _showRepository.GetTvShows());
        _allShows = new ObservableCollection<TvShow>(shows);
        Shows = new ObservableCollection<TvShow>(shows);
        _sorterSettings = await _settingsRepository.LoadSettingsAsync<Settings>(Settings.SETTING_NAME, cancellationToken);

        SetIsBusy(false);
    }

    public ICommand AddShowCommand { get; }
    public ICommand UpdateAllCommand { get; }
    public ICommand SaveShowCommand { get; }
    public ICommand UpdateShowCommand { get; }
    public ICommand ImportShowsCommand { get; }

    public ICommand ViewShowDetailsCommand { get; }

    public TvShow? SelectedShow
    {
        get => _selectedShow;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedShow, value);
            LoadSelectedShowImage();
        }
    }

    public Bitmap? SelectedShowImage
    {
        get => _selectedShowImage;
        private set => this.RaiseAndSetIfChanged(ref _selectedShowImage, value);
    }

    public string? FilterText
    {
        get => _filterText;
        set
        {
            this.RaiseAndSetIfChanged(ref _filterText, value);
            ApplyFilter();
        }
    }

    public string? SelectedAlternateName
    {
        get => _selectedAlternateName;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedAlternateName, value);
        }
    }

    private void ApplyFilter()
    {
        if (string.IsNullOrWhiteSpace(FilterText))
        {
            Shows = new ObservableCollection<TvShow>(_allShows);
        }
        else
        {
            var filtered = _allShows.Where(s =>
                s.Name.Contains(FilterText, StringComparison.OrdinalIgnoreCase) ||
                (s.FolderName?.Contains(FilterText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (s.AlternateNames?.Any(n => n.Contains(FilterText, StringComparison.OrdinalIgnoreCase)) ?? false)
            );
            Shows = new ObservableCollection<TvShow>(filtered);
        }
    }

    public ObservableCollection<TvShow> Shows
    {
        get => _shows;
        set => this.RaiseAndSetIfChanged(ref _shows, value);
    }

    private void LoadSelectedShowImage()
    {
        if (SelectedShow == null)
        {
            SelectedShowImage = null;
            return;
        }

        var baseDir = AppContext.BaseDirectory;
        var imagePath = Path.Combine(baseDir, "Images", $"{SelectedShow.TvdbId}.jpg");

        _logger.LogInformation("Base Directory: {BaseDir}", baseDir);
        _logger.LogInformation("Full Image Path: {ImagePath}", imagePath);
        _logger.LogInformation("File Exists: {Exists}", File.Exists(imagePath));

        // List all files in Images directory
        var imagesDir = Path.Combine(baseDir, "Images");
        if (Directory.Exists(imagesDir))
        {
            var files = Directory.GetFiles(imagesDir, "*.jpg");
            _logger.LogInformation("Found {Count} images in directory", files.Length);
            foreach (var file in files)
            {
                _logger.LogInformation("  - {FileName}", Path.GetFileName(file));
            }
        }
        else
        {
            _logger.LogWarning("Images directory does not exist: {ImagesDir}", imagesDir);
        }

        if (File.Exists(imagePath))
        {
            try
            {
                SelectedShowImage = new Bitmap(imagePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load image from {ImagePath}", imagePath);
                SelectedShowImage = null;
            }
        }
        else
        {
            SelectedShowImage = null;
        }
    }

    private async Task ExecuteUpdateAllAsync()
    {
        SetIsBusy(true);
        try
        {
            _logger.LogInformation("Starting update all shows operation");

            var unlockedShows = _allShows.Where(x => !x.Locked).ToList();
            await Task.Run(() => _showRepository.UpdateShows(unlockedShows));

            // Reload shows to reflect updates
            var shows = await Task.Run(() => _showRepository.GetTvShows());
            _allShows = new ObservableCollection<TvShow>(shows);
            ApplyFilter();

            // Refresh selected show if it was updated
            if (SelectedShow != null)
            {
                var updatedShow = _allShows.FirstOrDefault(s => s.TvdbId == SelectedShow.TvdbId);
                if (updatedShow != null)
                {
                    SelectedShow = updatedShow;
                }
            }

            _logger.LogInformation("Successfully updated {Count} shows", unlockedShows.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update all shows");
        }
        finally
        {
            SetIsBusy(false);
        }
    }

    private async Task ExecuteSaveShowAsync()
    {
        if (SelectedShow == null)
            return;

        SetIsBusy(true);
        try
        {
            _logger.LogInformation("Saving show: {ShowName} (ID: {TvdbId})", 
                SelectedShow.Name, SelectedShow.TvdbId);

            // Save the show (persists current property values)
            await _showRepository.SaveAsync(SelectedShow);

            _logger.LogInformation("Successfully saved show: {ShowName}", SelectedShow.Name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save show: {ShowName}", SelectedShow?.Name);
        }
        finally
        {
            SetIsBusy(false);
        }
    }

    private async Task ExecuteImportShowsAsync()
    {
        SetIsBusy(true);

        try
        {
            _logger.LogInformation("Starting import shows operation");

            var shows = Directory.GetDirectories(_sorterSettings.DefaultDestinationDirectory);

            foreach (var show in shows)
            {
                var showDirectoryName = PathExtensions.GetLastPathSegment(show);
                var result = await _showRepository.SearchShowAsync(showDirectoryName);

                if(_allShows.Any(x => x.Name.Equals(showDirectoryName, StringComparison.OrdinalIgnoreCase)))
                {
                    _logger.LogInformation("Show already exists in the database: {ShowName}", showDirectoryName);
                    continue;
                }

                if (result.Count == 1)
                {
                    var matchedShow = result.First();
                    matchedShow.FolderName = showDirectoryName;
                    await _showRepository.SaveAsync(matchedShow);
                    _logger.LogInformation("Successfully imported show: {ShowName} (ID: {TvdbId})", matchedShow.Name, matchedShow.TvdbId.ToString());

                    _allShows.Add(matchedShow);
                }
                else if (result.Count > 1)
                {
                    var selectionViewModel = Locator.Current.GetRequiredService<AddShowsDialogViewModel>();
                    selectionViewModel.PrepareForSelection(result);

                    var dialogTask = App.ShowDialog(selectionViewModel, $"Select matching show for {showDirectoryName}");
                    if (dialogTask != null)
                    {
                        await dialogTask;
                    }

                    var selectedShow = selectionViewModel.SelectedShow;
                    if (selectedShow != null)
                    {
                        selectedShow.FolderName = showDirectoryName;
                        await _showRepository.SaveAsync(selectedShow);
                        _logger.LogInformation("Successfully imported show: {ShowName} (ID: {TvdbId})", selectedShow.Name, selectedShow.TvdbId.ToString());
                        _allShows.Add(selectedShow);
                    }
                    else
                    {
                        _logger.LogWarning("Multiple matching shows found for directory: {ShowDirectory}", show);
                    }
                }
                else
                {
                    _logger.LogWarning("No matching show found for directory: {ShowDirectory}", show);
                }
            }

            _logger.LogInformation("Successfully completed import shows operation");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to import shows");
        }
        finally
        {
            SetIsBusy(false);
        }
    }


    private async Task ShowDetailDialogAsync()
    {
        if (SelectedShow == null)
            return;
        
        var viewModel = Locator.Current.GetRequiredService<ShowDetailDialogViewModel>();
        viewModel.SetShow(SelectedShow);

        var dialogTask = App.ShowDialog(viewModel, string.Format(ShowDetailDialogViewModel.DialogTitle, SelectedShow.Name));
        if (dialogTask != null)
        {
            await dialogTask;
        }
    }

    private async Task ExecuteUpdateShowAsync()
    {
        if (SelectedShow == null || SelectedShow.Locked)
            return;

        SetIsBusy(true);
        try
        {
            _logger.LogInformation("Updating show from TVDB: {ShowName} (ID: {TvdbId})", 
                SelectedShow.Name, SelectedShow.TvdbId);

            // Update the show data from TVDB
            await Task.Run(() => _showRepository.Update(SelectedShow));

            // Reload the show from repository to get updated data
            var shows = await Task.Run(() => _showRepository.GetTvShows());
            var updatedShow = shows.FirstOrDefault(s => s.TvdbId == SelectedShow.TvdbId);

            if (updatedShow != null)
            {
                // Update in _allShows collection
                var indexInAll = _allShows.ToList().FindIndex(s => s.TvdbId == SelectedShow.TvdbId);
                if (indexInAll >= 0)
                {
                    _allShows[indexInAll] = updatedShow;
                }

                // Update in filtered Shows collection
                var indexInFiltered = _shows.ToList().FindIndex(s => s.TvdbId == SelectedShow.TvdbId);
                if (indexInFiltered >= 0)
                {
                    _shows[indexInFiltered] = updatedShow;
                }

                // Update selected show to trigger UI refresh
                SelectedShow = updatedShow;
            }

            _logger.LogInformation("Successfully updated show from TVDB: {ShowName}", updatedShow?.Name ?? SelectedShow.Name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update show from TVDB: {ShowName}", SelectedShow?.Name);
        }
        finally
        {
            SetIsBusy(false);
        }
    }

    private async Task ExecuteAddShowAsync()
    {
        var dialogTask = App.ShowDialog(Locator.Current.GetRequiredService<AddShowsDialogViewModel>(), AddShowsDialogViewModel.DialogTitle);

        if(dialogTask != null)
        {
            await dialogTask;
            // Refresh shows after adding new ones
            SetIsBusy(true);
            var shows = await Task.Run(() => _showRepository.GetTvShows()); 
            _allShows = new ObservableCollection<TvShow>(shows);
            ApplyFilter();
            SetIsBusy(false);
        }
    }

}

public static class PathExtensions
{
    public static string GetLastPathSegment(this string path)
    {
        string lastPathSegment = path
            .Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries)
            .LastOrDefault();

        return lastPathSegment;
    }
}