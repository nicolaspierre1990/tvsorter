using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Splat;
using TVSorter.Storage;

namespace TVSorter.Ui.ViewModels;

public class SplashScreenViewModel : ViewModelBase
{
    private readonly ILogger<SplashScreenViewModel> _logger;
    private readonly IStorageProvider _storageProvider;
    private int _progressValue;
    private string _progressText = "Initializing...";

    public SplashScreenViewModel(ILogger<SplashScreenViewModel> logger, IStorageProvider storageProvider)
    {
        _logger = logger;
        _storageProvider = storageProvider;
    }

    public int ProgressValue
    {
        get => _progressValue;
        set => this.RaiseAndSetIfChanged(ref _progressValue, value);
    }

    public string ProgressText
    {
        get => _progressText;
        set => this.RaiseAndSetIfChanged(ref _progressText, value);
    }

    public string Version => App.CurrentVersion;

    public string Copyright => $"© 2012 - {DateTime.Now.Year}";

    public async Task InitializeAsync()
    {
        try
        {
            ProgressValue = 25;
            ProgressText = "Loading DataProvider";
            _logger.LogInformation("Loading DataProvider");

            // Wait for storage provider to be available
            while (!_storageProvider.IsAvailable)
            {
                await Task.Delay(100);
            }

            ProgressValue = 35;
            ProgressText = "Checking old xml file presence";
            _logger.LogInformation("Checking for legacy XML file");

            // Check for old XML file and migrate if necessary
            var xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "TVSorter.xml");
            if (File.Exists(xmlPath))
            {
                await MigrateFromXmlAsync();
            }

            ProgressValue = 80;
            ProgressText = "Loading Data";
            _logger.LogInformation("Loading data");

            await Task.Delay(100);

            ProgressValue = 95;
            ProgressText = "Loading UI";
            _logger.LogInformation("Loading UI");

            await Task.Delay(100);

            ProgressValue = 100;
            ProgressText = "Complete";
            _logger.LogInformation("Initialization complete");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during initialization");
            ProgressText = "Initialization failed";
            throw;
        }
    }

    private async Task MigrateFromXmlAsync()
    {
        try
        {
            _logger.LogInformation("Starting XML to SQL migration");
            
            // Resolve XMLToSQLMigration from DI container
            var migration = Locator.Current.GetService<XMLToSQLMigration>();
            if (migration == null)
            {
                _logger.LogWarning("XMLToSQLMigration service not registered, skipping migration");
                return;
            }

            migration.MigrationPartCompleted += (sender, args) =>
            {
                ProgressValue += 5;
                ProgressText = args.MigrationPart;
                _logger.LogInformation("Migration step: {Step}", args.MigrationPart);
            };

            await migration.MigrateToSqlAsync();

            // Remove .xsd files
            foreach (var xmlSchemaPath in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xsd", SearchOption.TopDirectoryOnly))
            {
                File.Delete(xmlSchemaPath);
                _logger.LogInformation("Deleted schema file: {File}", xmlSchemaPath);
            }

            // Delete old XML file
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "TVSorter.xml"));
            _logger.LogInformation("Deleted legacy XML file");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during XML migration");
            throw;
        }
    }
}
