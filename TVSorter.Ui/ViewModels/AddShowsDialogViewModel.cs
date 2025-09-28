using System.Reactive;
using ReactiveUI;

namespace TVSorter.Ui.ViewModels;

public class AddShowsDialogViewModel : ViewModelBase
{
    private string _folderPath = string.Empty;
    public string FolderPath
    {
        get => _folderPath;
        set => this.RaiseAndSetIfChanged(ref _folderPath, value);
    }
    public ReactiveCommand<Unit, Unit> BrowseCommand { get; }
    public ReactiveCommand<Unit, Unit> OkCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }
    public AddShowsDialogViewModel()
    {
        BrowseCommand = ReactiveCommand.Create(OnBrowse);
        OkCommand = ReactiveCommand.Create(OnOk);
        CancelCommand = ReactiveCommand.Create(OnCancel);
    }
    private void OnBrowse()
    {
        // Implement folder browsing logic here
    }
    private void OnOk()
    {
        // Implement OK logic here
    }
    private void OnCancel()
    {
        // Implement Cancel logic here
    }
}