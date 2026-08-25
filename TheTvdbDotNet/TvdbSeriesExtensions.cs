using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TheTvdbDotNet;

public static class TvdbSeriesExtensions
{
    public static async Task<IEnumerable<BasicEpisode>> GetAllEpisodesAsync(
        this ITvdbSeries seriesRepository,
        int seriesId,
        CancellationToken cancellationToken = default)
    {
        var episodeData = await seriesRepository.GetEpisodesAsync(seriesId, "0").ConfigureAwait(false);
        return episodeData.Data.Episodes ?? Enumerable.Empty<BasicEpisode>();
    }
}
