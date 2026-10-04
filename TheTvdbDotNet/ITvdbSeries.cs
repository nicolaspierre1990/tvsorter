using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheTvdbDotNet;

public interface ITvdbSeries
{
    Task<SeriesEpisodes> GetEpisodesAsync(int seriesId, string page = null, CancellationToken cancellationToken = default);

    Task<SeriesDataResponse> GetSeriesAsync(int seriesId, CancellationToken cancellationToken = default);

    Task<SeriesEpisodes> QueryEpisodesAsync(
        int seriesId,
        string airedSeason = null,
        string airedEpisode = null,
        string imdbId = null,
        string dvdSeason = null,
        string dvdEpisode = null,
        string absoluteNumber = null,
        string firstAired = null,
        string page = null, CancellationToken cancellationToken = default);

    [Obsolete("This method is deprecated.")]
    Task<Stream> GetBannerAsnyc(Series series, CancellationToken cancellationToken = default);
}
