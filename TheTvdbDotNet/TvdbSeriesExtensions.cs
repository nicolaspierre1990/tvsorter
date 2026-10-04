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
        var basicEpisodes = Enumerable.Empty<BasicEpisode>();
        var currentPage = 0;
        var result = await seriesRepository.GetEpisodesAsync(seriesId, currentPage.ToString(), cancellationToken).ConfigureAwait(false);
        basicEpisodes = basicEpisodes.Concat(result.Data.Episodes ?? Enumerable.Empty<BasicEpisode>());

        while (result.Links?.Next != null)
        {
            currentPage++;
            result = await seriesRepository.GetEpisodesAsync(seriesId, currentPage.ToString(), cancellationToken).ConfigureAwait(false);
            basicEpisodes = basicEpisodes.Concat(result.Data.Episodes ?? Enumerable.Empty<BasicEpisode>());
        }

        return basicEpisodes;
    }
}
