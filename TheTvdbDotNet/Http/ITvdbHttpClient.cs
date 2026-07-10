using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Http;

public interface ITvdbHttpClient
{
    Task<T> GetResponseAsync<T>(string uri, CancellationToken cancellationToken = default);

    Task<T> PostResponseAsync<T>(string uri, object postData, CancellationToken cancellationToken = default);

    Task<Stream> GetStreamAsync(string uri, CancellationToken cancellationToken = default);

    void SetAuthorizationHeader(string token);
}
