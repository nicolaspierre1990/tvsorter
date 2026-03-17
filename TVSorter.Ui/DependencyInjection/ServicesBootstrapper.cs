using System;
using System.Collections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Splat;
using TheTvdbDotNet;
using TheTvdbDotNet.Authentication;
using TheTvdbDotNet.Http;
using TheTvdbDotNet.Repositories;
using TVSorter.Data;
using TVSorter.Data.TvdbV2;
using TVSorter.Files;
using TVSorter.Repostitory;
using TVSorter.Storage;
using TVSorter.Ui.ViewModels;

namespace TVSorter.Ui.DependencyInjection;

public static class ServicesBootstrapper
{
    public static IMutableDependencyResolver RegisterServices(this IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        var apiKey = resolver.GetRequiredService<IConfiguration>().GetSection("tvdb").GetValue<string>("apiKey") ?? string.Empty;


        // TVSorterLib registrations (from LibraryModule)
        services.RegisterLazySingleton(() => new SQLLiteProvider(resolver.GetRequiredService<TvSorterDbContext>()), typeof(IStorageProvider));
        services.RegisterLazySingleton(() => new Version2Migration(), typeof(IStorageMigration));
        services.RegisterLazySingleton(() => new Version3Migration(), typeof(IStorageMigration));
        services.RegisterLazySingleton(() => new Version4Migration(), typeof(IStorageMigration));
        services.RegisterLazySingleton(() => new Version5Migration(), typeof(IStorageMigration));
        services.RegisterLazySingleton(() => new XmlValidator(resolver.GetRequiredService<ITextReaderProvider>()), typeof(IXmlValidator));
        services.RegisterLazySingleton(() => new XmlMigration(resolver.GetServices<IStorageMigration>(), resolver.GetRequiredService<IXmlValidator>()), typeof(IXmlMigration));
        services.Register(() => new TextReaderProvider(), typeof(ITextReaderProvider)); // Transient

        services.RegisterLazySingleton(() => new TvdbV2(resolver.GetRequiredService<ITvdbSeries>(), resolver.GetRequiredService<ITvdbSearch>(), resolver.GetRequiredService<ITvdbUpdate>(),
            resolver.GetRequiredService<IStreamWriter>()), typeof(IDataProvider));
        services.RegisterLazySingleton(() => new ScanManager(resolver.GetRequiredService<IStorageProvider>(), resolver.GetRequiredService<IDataProvider>(), resolver.GetRequiredService<ITvShowRepository>()), typeof(IScanManager));
        services.RegisterLazySingleton(() => new FileResultManager(resolver.GetRequiredService<IStorageProvider>()), typeof(IFileResultManager));
        services.RegisterLazySingleton(() => new FileManager(resolver.GetRequiredService<IStorageProvider>(), resolver.GetRequiredService<IScanManager>(), resolver.GetRequiredService<IFileResultManager>()), typeof(IFileManager));
        services.RegisterLazySingleton(() => new FileSearch(resolver.GetRequiredService<IStorageProvider>(), resolver.GetRequiredService<IDataProvider>(), resolver.GetRequiredService<IScanManager>(), resolver.GetRequiredService<IFileManager>()), typeof(IFileSearch));
        services.RegisterLazySingleton(() => new TvShowRepository(resolver.GetRequiredService<IStorageProvider>(), resolver.GetRequiredService<IDataProvider>()), typeof(ITvShowRepository));
        services.RegisterLazySingleton(() => new SettingsRepository(resolver.GetRequiredService<TvSorterDbContext>()), typeof(ISettingsRepository));
        services.RegisterLazySingleton(() => new StreamWriter(), typeof(IStreamWriter));

        services.Register(() => new TvSorterDbContext(), typeof(TvSorterDbContext)); // Transient
        services.RegisterLazySingleton(() => new XMLToSQLMigration(), typeof(XMLToSQLMigration));

        // TheTvdbDotNet registrations (from TheTvdbDotNetModule)
        services.RegisterLazySingleton(() => new AuthenticationToken(), typeof(IAuthenticationToken));
        services.RegisterLazySingleton(() => new Authenticator(resolver.GetRequiredService<ITvdbHttpClient>(), resolver.GetRequiredService<IAuthenticationToken>(),
            apiKey), typeof(IAuthenticator));
        services.RegisterLazySingleton(() => new TvdbHttpClient(), typeof(ITvdbHttpClient));
        services.RegisterLazySingleton(() => new AuthenticatedTvdbHttpClient(resolver.GetRequiredService<ITvdbHttpClient>(), resolver.GetRequiredService<IAuthenticator>()), typeof(IAuthenticatedTvdbHttpClient));
        services.RegisterLazySingleton(() => new TvdbBannersHttpClient(), typeof(ITvdbBannersHttpClient));
        services.RegisterLazySingleton(() => new TvdbSeriesRepository(resolver.GetRequiredService<IAuthenticatedTvdbHttpClient>(), resolver.GetRequiredService<ITvdbBannersHttpClient>()), typeof(ITvdbSeries));
        services.RegisterLazySingleton(() => new TvdbSearchRepository(resolver.GetRequiredService<IAuthenticatedTvdbHttpClient>()), typeof(ITvdbSearch));
        services.RegisterLazySingleton(() => new TvdbUpdateRepository(resolver.GetRequiredService<IAuthenticatedTvdbHttpClient>()), typeof(ITvdbUpdate));

        // ViewModels
        services.RegisterLazySingleton(() => new ShowsViewModel(
            resolver.GetRequiredService<ILoggerFactory>().CreateLogger<ShowsViewModel>(),
            resolver.GetRequiredService<ITvShowRepository>()), typeof(ShowsViewModel));

        services.RegisterLazySingleton(() => new SplashScreenViewModel(
            resolver.GetRequiredService<ILoggerFactory>().CreateLogger<SplashScreenViewModel>(),
            resolver.GetRequiredService<IStorageProvider>()), typeof(SplashScreenViewModel));

        services.RegisterLazySingleton(() => new MainWindowViewModel(), typeof(MainWindowViewModel));

        services.RegisterLazySingleton(() => new AddShowsDialogViewModel(
            resolver.GetRequiredService<ILoggerFactory>().CreateLogger<AddShowsDialogViewModel>(),
            resolver.GetRequiredService<ITvShowRepository>()), typeof(AddShowsDialogViewModel));

        services.RegisterLazySingleton(() => new ShowSorterViewModel(
            resolver.GetRequiredService<ILoggerFactory>().CreateLogger<ShowSorterViewModel>(),
            resolver.GetRequiredService<ISettingsRepository>(),
            resolver.GetRequiredService<IFileResultManager>(),
            resolver.GetRequiredService<IFileManager>(),
            resolver.GetRequiredService<IFileSearch>()), typeof(ShowSorterViewModel));

        services.RegisterLazySingleton(() => new SettingsViewModel(
            resolver.GetRequiredService<ILoggerFactory>().CreateLogger<SettingsViewModel>(),
            resolver.GetRequiredService<ISettingsRepository>()), typeof(SettingsViewModel));

        services.RegisterLazySingleton(() => new ShowDetailDialogViewModel(
            resolver.GetRequiredService<ILoggerFactory>().CreateLogger<ShowDetailDialogViewModel>()), typeof(ShowDetailDialogViewModel));

        return services;
    }
}

public static class IReadonlyDependencyResolverExtensions
{
    public static T GetRequiredService<T>(this IReadonlyDependencyResolver resolver) 
        => resolver.GetService<T>() ?? throw new InvalidOperationException($"Service of type {typeof(T)} is not registered.");
}