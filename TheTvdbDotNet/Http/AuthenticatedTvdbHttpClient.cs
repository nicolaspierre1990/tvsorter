using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TheTvdbDotNet.Authentication;

namespace TheTvdbDotNet.Http;

public class AuthenticatedTvdbHttpClient(ITvdbHttpClient httpClient, IAuthenticator authenticator) : IAuthenticatedTvdbHttpClient
{
    private readonly ITvdbHttpClient httpClient = httpClient;
    private readonly IAuthenticator authenticator = authenticator;

    public async Task<T> GetAsync<T>(Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var builtRequest = request.BuildRequest();
            await authenticator.AuthenticateIfNecessaryAsync(cancellationToken).ConfigureAwait(false);
            return await httpClient.GetResponseAsync<T>(builtRequest, cancellationToken).ConfigureAwait(false);
        }
        catch (System.Exception ex)
        {
            throw new System.Exception($"Error occurred while making GET request to {request.BuildRequest()}: {ex.Message}", ex);
        }
    }

    public async Task<T> PostAsync<T>(Request request, object postData, CancellationToken cancellationToken = default)
    {
        await authenticator.AuthenticateIfNecessaryAsync(cancellationToken).ConfigureAwait(false);
        return await httpClient.PostResponseAsync<T>(request.BuildRequest(), postData, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Stream> GetStreamAsync(Request request, CancellationToken cancellationToken = default)
    {
        await authenticator.AuthenticateIfNecessaryAsync(cancellationToken).ConfigureAwait(false);
        return await httpClient.GetStreamAsync(request.BuildRequest(), cancellationToken).ConfigureAwait(false);
    }
}
