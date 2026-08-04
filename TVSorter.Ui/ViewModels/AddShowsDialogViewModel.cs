using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSorter.Model;
using TVSorter.Repostitory;

namespace TVSorter.Ui.ViewModels;

public class AddShowsDialogViewModel : ViewModelBase
{
    public static readonly string DialogTitle = "Add TV Shows";

    private ObservableCollection<TvShow> _searchResults = [];
    private TvShow? _selectedShow;
    private string _showName = string.Empty;

    public ObservableCollection<TvShow> SearchResults
    {
        get => _searchResults;
        set => this.RaiseAndSetIfChanged(ref _searchResults, value);
    }

    public TvShow? SelectedShow
    {
        get => _selectedShow;
        set => this.RaiseAndSetIfChanged(ref _selectedShow, value);
    }

    public ICommand SearchCommand { get; set; }
    public ICommand AddCommand { get; set; }
    public ICommand CancelCommand { get; set; }


    public string ShowName
    {
        get => _showName;
        set => this.RaiseAndSetIfChanged(ref _showName, value);
    }

    private ILogger<AddShowsDialogViewModel> _logger;
    private ITvShowRepository _tvShowRepository;

    public AddShowsDialogViewModel(
        ILogger<AddShowsDialogViewModel> logger,
        ITvShowRepository tvShowRepository)
    {
        SearchCommand = ReactiveCommand.CreateFromTask(SearchShowsAsync);
        AddCommand = ReactiveCommand.CreateFromTask(AddShowAsync, this.WhenAnyValue(x => x.SelectedShow, (TvShow? show) => show != null));
        CancelCommand = ReactiveCommand.Create(() => App.CloseDialog(this));
        _logger = logger;
        _tvShowRepository = tvShowRepository;
    }

    private async Task AddShowAsync()
    {
        _tvShowRepository.FromSearchResult(SelectedShow!);
        await _tvShowRepository.UpdateAsync(SelectedShow!);

        App.CloseDialog(this);

        SearchResults = [];
        ShowName = string.Empty;
    }

    private async Task SearchShowsAsync()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        SetIsBusy(true);

        try
        {
            SearchResults = new ObservableCollection<TvShow>(await _tvShowRepository.SearchShowAsync(ShowName, cts.Token));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while searching for TV shows.");
            SetIsBusy(false);
        }
        finally
        {
            SetIsBusy(false);
        }
    }
}
