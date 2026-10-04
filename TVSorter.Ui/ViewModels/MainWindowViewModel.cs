using ReactiveUI;
using ReactiveUI.Primitives;
using Splat;
using System;
using System.Threading.Tasks;
using TVSorter.Ui.Extensions;

namespace TVSorter.Ui.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _title = default!;
    public ReactiveCommand<RxVoid, RxVoid> ExitCommand { get; set; }
    public ReactiveCommand<RxVoid, RxVoid> AddShowsCommand { get; set; }

    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public MainWindowViewModel()
    {
        ExitCommand = ReactiveCommand.Create(() => Environment.Exit(0));
        AddShowsCommand = ReactiveCommand.CreateFromTask(OpenAddShowsDialogAsync);
        Title = $"TVSorter {App.CurrentVersion}";
    }

    private async Task OpenAddShowsDialogAsync()
    {
        var task = App.ShowDialog(Locator.Current.GetRequiredService<AddShowsDialogViewModel>(), AddShowsDialogViewModel.DialogTitle);
        if(task != null)
        {
            await task;
        }
    }
}
