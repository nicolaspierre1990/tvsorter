using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using TVSorter.Model;
using TVSorter.Repostitory;

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

    public ShowsViewModel(ILogger<ShowsViewModel> logger, ITvShowRepository tvShowRepository)
    {
        _logger = logger;
        _showRepository = tvShowRepository;
        UpdateAllCommand = ReactiveCommand.CreateFromTask(ExecuteUpdateAllAsync);
        SaveShowCommand = ReactiveCommand.CreateFromTask(ExecuteSaveShowAsync, 
            this.WhenAnyValue(x => x.SelectedShow, (TvShow? show) => show != null));
        UpdateShowCommand = ReactiveCommand.CreateFromTask(ExecuteUpdateShowAsync,
            this.WhenAnyValue(x => x.SelectedShow, (TvShow? show) => show != null && !show.Locked));
    }

    public override async Task InitializeView(CancellationToken cancellationToken)
    {
        SetIsBusy(true);

        var shows = await Task.Run(() => _showRepository.GetTvShows());
        _allShows = new ObservableCollection<TvShow>(shows);
        Shows = new ObservableCollection<TvShow>(shows);

        SetIsBusy(false);
    }

    public ICommand UpdateAllCommand { get; }
    public ICommand SaveShowCommand { get; }
    public ICommand UpdateShowCommand { get; }

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
            await Task.Run(() => _showRepository.Save(SelectedShow));

            // Update in both collections to ensure consistency
            var indexInAll = _allShows.ToList().FindIndex(s => s.TvdbId == SelectedShow.TvdbId);
            if (indexInAll >= 0)
            {
                _allShows[indexInAll] = SelectedShow;
            }

            var indexInFiltered = _shows.ToList().FindIndex(s => s.TvdbId == SelectedShow.TvdbId);
            if (indexInFiltered >= 0)
            {
                _shows[indexInFiltered] = SelectedShow;
            }

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
}