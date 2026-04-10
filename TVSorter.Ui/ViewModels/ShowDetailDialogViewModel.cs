using Microsoft.Extensions.Logging;
using ReactiveUI;
using TVSorter.Model;

namespace TVSorter.Ui.ViewModels;

public class ShowDetailDialogViewModel(ILogger<ShowDetailDialogViewModel> logger) : ViewModelBase
{
    public static readonly string DialogTitle = "Show {0} Details";
    private TvShow _show = default!;

    public TvShow Show
    {
        get => _show; 
        set => this.RaiseAndSetIfChanged(ref _show, value);
    }

    public void SetShow(TvShow selectedShow) => Show = selectedShow;
}
