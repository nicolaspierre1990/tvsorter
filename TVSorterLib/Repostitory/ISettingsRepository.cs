// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ISettingsRepository.cs">
//   2025 - Andrew Jackson & Nicolas Pierre
// </copyright>
// <summary>
//   The interface for the Settings Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using TVSorter.Data;

namespace TVSorter.Repostitory;

/// <summary>
///    The interface for the settings repository.
/// </summary>
public interface ISettingsRepository
{
    event EventHandler<SettingsEventArgs> SettingsUpdated;

    /// <summary>
    ///     Loads the application settings of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of settings to load.</typeparam>
    /// <param name="settingName">The name of the setting to load.</param>
    /// <returns>The application settings of type <typeparamref name="T"/>.</returns>
    T LoadSettings<T>(string settingName) where T : class;

    /// <summary>
    ///     Saves the application settings.
    /// </summary>
    /// <param name="settings">The settings to save.</param>
    void SaveSettings(Setting settings);

    /// <summary>
    ///     Loads the application settings of the specified type asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of settings to load.</typeparam>
    /// <param name="settingName">The name of the setting to load.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation that returns the application settings of type <typeparamref name="T"/>.</returns>
    Task<T> LoadSettingsAsync<T>(string settingName, CancellationToken cancellationToken = default) where T : class;

    /// <summary>
    ///     Saves the application settings asynchronously.
    /// </summary>
    /// <param name="settings">The settings to save.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task SaveSettingsAsync(Setting settings, CancellationToken cancellationToken = default);
}