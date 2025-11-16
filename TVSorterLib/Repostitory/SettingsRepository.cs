// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="SettingRepository.cs">
//   2025 - Andrew Jackson & Nicolas Pierre
// </copyright>
// <summary>
//   Manages the collection of TV Shows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TVSorter.Data;

namespace TVSorter.Repostitory;

public class SettingsRepository(TvSorterDbContext tvSorterDbContext) : ISettingsRepository
{
    /// <summary>
    ///     Occurs when a TV Show is added.
    /// </summary>
    public event EventHandler<SettingsEventArgs> SettingsUpdated;

    public T LoadSettings<T>(string settingName) where T : class 
        => LoadSettingsAsync<T>(settingName).GetAwaiter().GetResult();

    public async Task<T> LoadSettingsAsync<T>(string settingName, CancellationToken cancellationToken = default) where T : class
    {
        var setting = await tvSorterDbContext.Settings.FirstOrDefaultAsync(x => x.SettingName.Equals(settingName), cancellationToken);

        return setting == null ? null : JsonSerializer.Deserialize<T>(setting.SettingValue);
    }

    public void SaveSettings(Setting settings) => SaveSettingsAsync(settings).GetAwaiter().GetResult();

    public async Task SaveSettingsAsync(Setting settings, CancellationToken cancellationToken = default)
    {
        var setting = await tvSorterDbContext.Settings.FirstOrDefaultAsync(x => x.SettingName.Equals(settings.SettingName), cancellationToken);

        if (setting == null)
        {
            await tvSorterDbContext.Settings.AddAsync(settings, cancellationToken);
        }
        else
        {
            setting.SettingValue = settings.SettingValue;
            tvSorterDbContext.Settings.Update(setting);
        }

        await tvSorterDbContext.SaveChangesAsync(cancellationToken);

        SettingsUpdated?.Invoke(this, new SettingsEventArgs(settings));
    }
}
