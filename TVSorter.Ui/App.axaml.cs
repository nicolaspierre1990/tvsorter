using System;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TVSorter.Ui.ViewModels;
using TVSorter.Ui.Views;

namespace TVSorter.Ui;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public static Task? ShowDialog(object data, Window owner = null)
    {
        if (owner == null)
        {
            if (Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime { MainWindow: { } mainWindow })
                owner = mainWindow;
            else
                return null;
        }

        var dialog = CreateViewForViewModel(data) as Window;
        if (dialog is not null)
        {
            dialog.DataContext = data;
            return dialog.ShowDialog(owner);
        }

        return null;
    }

    public static object? CreateViewForViewModel(object data)
    {
        var dataTypeName = data.GetType().FullName;
        if (string.IsNullOrEmpty(dataTypeName) || !dataTypeName.Contains(".ViewModels.", StringComparison.Ordinal))
            return null;

        var viewTypeName = dataTypeName.Replace("ViewModel", "View", StringComparison.Ordinal);
        var viewType = Type.GetType(viewTypeName);
        if (viewType != null)
            return Activator.CreateInstance(viewType);

        return null;
    }

    public static string CurrentVersion
    {
        get
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version ?? new Version(0, 0, 0, 0);
            return $"v{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}