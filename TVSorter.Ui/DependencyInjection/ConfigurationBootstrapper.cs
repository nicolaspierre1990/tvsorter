using System;
using Microsoft.Extensions.Configuration;
using Splat;

namespace TVSorter.Ui.DependencyInjection;

public class ConfigurationBootstrapper
{
    public static IMutableDependencyResolver RegisterConfiguration(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton(() => new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables("DOTNET_").Build(), typeof(IConfiguration));

        return services;

    }
}