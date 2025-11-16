using System;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;
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
            // Show splash screen first
            ShowSplashScreenAndInitialize(desktop);
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void ShowSplashScreenAndInitialize(IClassicDesktopStyleApplicationLifetime desktop)
    {
        try
        {
            // Resolve dependencies from Splat DI container
            var splashViewModel = Locator.Current.GetService<SplashScreenViewModel>();
            if (splashViewModel == null)
            {
                throw new InvalidOperationException("SplashScreenViewModel is not registered in DI container");
            }

            var splashScreen = new SplashScreenView
            {
                DataContext = splashViewModel
            };

            splashScreen.Show();

            // Initialize in background
            await splashViewModel.InitializeAsync();

            // Small delay to show completion
            await Task.Delay(500);

            // Create main window
            var mainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };

            // Set as main window and show
            desktop.MainWindow = mainWindow;
            mainWindow.Show();

            // Close splash screen
            splashScreen.Close();
        }
        catch (Exception ex)
        {
            // Log error and show main window anyway
            Console.WriteLine($"Error during splash screen initialization: {ex}");
            
            // Fallback to main window
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
            desktop.MainWindow.Show();
        }
    }

    public static Task? ShowDialog(object data, string dialogTitle, Window? owner = null, EventHandler? onClosedAction = null)
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
            dialog.Title = dialogTitle;
            
            if (onClosedAction != null)
            {
                dialog.Closed += onClosedAction;
            }

            return dialog.ShowDialog(owner);
        }

        return null;
    }

    public static Task CloseDialog(object data, bool result = true)
    {
        if (Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime { MainWindow: { } mainWindow })
        {
            foreach (var window in mainWindow.OwnedWindows)
            {
                if (window.DataContext == data)
                {
                    window.Close(result);
                    return Task.CompletedTask;
                }
            }
        }
        return Task.CompletedTask;
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
            var version = Assembly.GetEntryAssembly()?.GetName().Version ?? new System.Version(0, 0, 0, 0);
            return $"v{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}