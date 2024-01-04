using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TVSorter.Data;
using TVSorter.Model;
using TVSorter.Repostitory;
using static TVSorter.Storage.XMLToSQLMigration;

namespace TVSorter.Storage;

public class XMLToSQLMigration
{
    private readonly TvSorterDbContext _dataContext;
    private readonly ITvShowRepository _tvShowRepository;

    public event EventHandler<MigrationPartCompletedEventArgs> MigrationPartCompleted;

    public XMLToSQLMigration()
    {
        _dataContext = CompositionRoot.Get<TvSorterDbContext>();
        _tvShowRepository = CompositionRoot.Get<ITvShowRepository>();
    }

    public async Task MigrateToSqlAsync()
    {
        await Task.Factory.StartNew(() =>
        {
            using Xml _xmlDocument = new(null);
            var tvShows = _xmlDocument.LoadTvShows();

            //migrate settings
            var missingEpisodeSettings = _dataContext.Settings.Find(MissingEpisodeSettings.SETTING_NAME);
            if (missingEpisodeSettings == null)
            {
                _dataContext.Settings.Add(new Setting { SettingName = MissingEpisodeSettings.SETTING_NAME, SettingValue = JsonSerializer.Serialize(_xmlDocument.MissingEpisodeSettings) });
            }
            else
            {
                missingEpisodeSettings.SettingValue = JsonSerializer.Serialize(_xmlDocument.MissingEpisodeSettings);
            }

            OnMigrationPartCompleted(new MigrationPartCompletedEventArgs { MigrationPart = "MissingEpisodeSettings migrated" });

            var generalSettings = _dataContext.Settings.Find(Settings.SETTING_NAME);
            if (generalSettings == null)
            {
                _dataContext.Settings.Add(new Setting { SettingName = Settings.SETTING_NAME, SettingValue = JsonSerializer.Serialize(_xmlDocument.Settings) });
            }
            else
            {
                generalSettings.SettingValue = JsonSerializer.Serialize(_xmlDocument.Settings);
            }

            OnMigrationPartCompleted(new MigrationPartCompletedEventArgs { MigrationPart = "General settings migrated" });

            foreach (TvShow tvShow in tvShows)
            {
                tvShow.Episodes.ForEach(e => e.ShowId = tvShow.TvdbId);
            }

            _tvShowRepository.UpdateShows(tvShows.ToList());

            OnMigrationPartCompleted(new MigrationPartCompletedEventArgs { MigrationPart = "Shows migrated" });

            _dataContext.SaveChanges();
        });
    }

    protected virtual void OnMigrationPartCompleted(MigrationPartCompletedEventArgs e) 
        => MigrationPartCompleted?.Invoke(this, e);

    public sealed class MigrationPartCompletedEventArgs : EventArgs
    {
        public string MigrationPart { get; set; }
    }
}
