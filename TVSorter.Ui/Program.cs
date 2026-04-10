using Avalonia;
using Avalonia.Controls;
using ReactiveUI.Avalonia;
using Serilog;
using Splat;
using System;
using System.IO;
using System.Reflection;
using TVSorter.Ui.DependencyInjection;

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
            .WriteTo.File(Path.Combine(LoggingBootstrapper.LogFolder, "application-log-.txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

        try
        {
            logger.Verbose("Starting TVSorter application {version}", Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0.0");


            RegisterDependencies(Locator.CurrentMutable, Locator.Current);

            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args, ShutdownMode.OnMainWindowClose);
        }
        catch (Exception ex)
        {
            logger.Fatal(ex, "Application terminated unexpectedly: {Error}", ex.Message);
        }
    }

    private static void RegisterDependencies(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        ConfigurationBootstrapper.RegisterConfiguration(services, resolver);
        LoggingBootstrapper.RegisterLogging(services, resolver);
        ServicesBootstrapper.RegisterServices(services, resolver);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI(_ => { });
}
