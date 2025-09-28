using System;
using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Serilog;

namespace TVSorter.Ui;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var logger = new LoggerConfiguration()
            .CreateLogger();

        try
        {
            logger.Verbose("Starting TVSorter application {version}", Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0.0");

            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args, ShutdownMode.OnMainWindowClose);
        }
        catch (Exception ex)
        {
            logger.Fatal(ex, "Application terminated unexpectedly: {Error}", ex.Message);
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}

