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
        //var request = new Request("search/series");
        //request.AddCriteriaIfNotNull("name", name);
        //request.AddCriteriaIfNotNull("tvdbId", tvdbId);
        //request.AddCriteriaIfNotNull("zap2itId", zap2itId);

        var request = new Request("search");
        request.AddCriteriaIfNotNull("query", name);
        request.AddCriteriaIfNotNull("type", "series");

        return await HttpClient.GetAsync<SeriesSearch>(request).ConfigureAwait(false);
    }
}
