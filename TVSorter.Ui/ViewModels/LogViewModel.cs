using Microsoft.Extensions.Logging;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace TVSorter.Ui.ViewModels;

public class LogViewModel: ViewModelBase
{

    private ObservableCollection<LogMessageEventArgs> _log = [];


    public ObservableCollection<LogMessageEventArgs> Log
    { 
        set => this.RaiseAndSetIfChanged(ref _log, value);
        get => _log;
    }

    public LogViewModel(ILogger<LogViewModel> logger)
    {
        Logger.LogMessage += OnLogMessageReceived;
        Logger.ReadCachedMessages();
    }

    private void OnLogMessageReceived(object? sender, LogMessageEventArgs e) => Log.Add(e);
}
