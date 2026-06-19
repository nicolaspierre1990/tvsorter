using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSorter.Model;
using TVSorter.Repostitory;

namespace TVSorter.Ui.ViewModels;

public class SelectShowViewModel : ViewModelBase
{
    private readonly ITvShowRepository _tvShowRepository;
    private ObservableCollection<Model.TvShow> _shows = [];
    private TvShow? _selectedShow;

    public SelectShowViewModel(ILogger<SelectShowViewModel> logger, ITvShowRepository tvShowRepository)
    {
        _tvShowRepository = tvShowRepository;
        ConfirmCommand = ReactiveCommand.Create(() => SelectShow()/*, this.WhenAnyValue(x => x.SelectedShow != null)*/);
    }

    public ICommand ConfirmCommand { get; set; }

    public ObservableCollection<Model.TvShow> Shows
    {
        get => new(_shows);
        set => this.RaiseAndSetIfChanged(ref _shows, value);
    }

    public TvShow? SelectedShow
    {
        get => _selectedShow;
        set => this.RaiseAndSetIfChanged(ref _selectedShow, value);
    }

    public override async Task InitializeView(CancellationToken cancellationToken) 
        => Shows = new ObservableCollection<TvShow>(await _tvShowRepository.GetTvShowsAsync(cancellationToken));

    public void SelectShow()
    {
        App.CloseDialog(this, true);
    }
}
