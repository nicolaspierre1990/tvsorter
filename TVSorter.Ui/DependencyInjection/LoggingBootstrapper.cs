using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using Splat;

namespace TVSorter.Ui.DependencyInjection;

public static class LoggingBootstrapper
{
    internal static string LogFolder = Path.Combine(Environment.CurrentDirectory, "logs");

    public static IMutableDependencyResolver RegisterLogging(this IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton<ILoggerFactory>(() =>
        {
            var configuration = resolver.GetService<IConfiguration>();

            var logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(LogFolder, "application-log-.txt"),  rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .CreateLogger();

            var factory = new SerilogLoggerFactory(logger);

            return factory;
        });



        return services;
    }
}
