using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using TVSorter.Ui.DependencyInjection;

namespace TVSorter.Ui.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _title = default!;
    public ReactiveCommand<Unit, Unit> ExitCommand { get; set; }
    public ReactiveCommand<Unit, Unit> AddShowsCommand { get; set; }

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
