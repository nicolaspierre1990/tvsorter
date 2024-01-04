using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TVSorter.Data;
using TVSorter.Model;
using TVSorter.Repostitory;

namespace TVSorter.Storage;

public class XMLToSQLMigration
{
    private readonly TvSorterDbContext _dataContext;
    private readonly ITvShowRepository _tvShowRepository;

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

            var generalSettings = _dataContext.Settings.Find(Settings.SETTING_NAME);
            if (generalSettings == null)
            {
                _dataContext.Settings.Add(new Setting { SettingName = Settings.SETTING_NAME, SettingValue = JsonSerializer.Serialize(_xmlDocument.Settings) });
            }
            else
            {
                generalSettings.SettingValue = JsonSerializer.Serialize(_xmlDocument.Settings);
            }

            foreach (TvShow tvShow in tvShows)
            {
                tvShow.Episodes.ForEach(e => e.ShowId = tvShow.TvdbId);
            }

            _tvShowRepository.UpdateShows(tvShows.ToList());
            _dataContext.SaveChanges();
        });
    }
}
