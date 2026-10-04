using System.Threading.Tasks;
using TheTvdbDotNet.Http;

namespace TheTvdbDotNet.Repositories;

public class TvdbSearchRepository : TvdbBaseRepository, ITvdbSearch
{
    public TvdbSearchRepository(IAuthenticatedTvdbHttpClient httpClient)
        : base(httpClient)
    {
    }

    public async Task<SeriesSearch> SeriesSearchAsync(string name = null, string tvdbId = null, string zap2itId = null)
    {
        var request = new Request("search");
        request.AddCriteriaIfNotNull("query", name);
        request.AddCriteriaIfNotNull("type", "series");

        return await HttpClient.GetAsync<SeriesSearch>(request).ConfigureAwait(false);
    }
}
