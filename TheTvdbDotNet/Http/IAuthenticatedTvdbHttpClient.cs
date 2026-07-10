using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Http;

public interface IAuthenticatedTvdbHttpClient
{
    Task<T> GetAsync<T>(Request request, CancellationToken cancellationToken = default);

    Task<T> PostAsync<T>(Request request, object postData, CancellationToken cancellationToken = default);

    Task<Stream> GetStreamAsync(Request request, CancellationToken cancellationToken = default);
}
