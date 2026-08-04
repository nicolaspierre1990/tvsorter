using System.Threading;
using System.Threading.Tasks;
using TheTvdbDotNet.Http;

namespace TheTvdbDotNet.Authentication;

public class Authenticator : IAuthenticator
{
    private readonly ITvdbHttpClient httpClient;
    private readonly IAuthenticationToken authenticationToken;
    private readonly string apiKey;

    public Authenticator(ITvdbHttpClient httpClient, IAuthenticationToken authenticationToken, string apiKey)
    {
        this.httpClient = httpClient;
        this.authenticationToken = authenticationToken;
        this.apiKey = apiKey;
    }

    public Task AuthenticateIfNecessaryAsync(CancellationToken cancellationToken = default)
    {
        if (authenticationToken.IsAuthenticated)
        {
            return Task.CompletedTask;
        }

        return AuthenticateAsync(cancellationToken);
    }

    private async Task AuthenticateAsync(CancellationToken cancellationToken = default)
    {
        var response = await LoginAsync(cancellationToken).ConfigureAwait(false);
        SetToken(response.Data.Token);
        httpClient.SetAuthorizationHeader(authenticationToken.TokenString);
    }

    private Task<LoginResponse> LoginAsync(CancellationToken cancellationToken = default)
    {
        var loginRequest = new LoginRequest { ApiKey = apiKey };
        return httpClient.PostResponseAsync<LoginResponse>("login", loginRequest, cancellationToken);
    }

    private void SetToken(string token)
    {
        authenticationToken.SetToken(token);
        if (!authenticationToken.IsAuthenticated)
        {
            throw new TvdbRequestException("Failed to authenticate");
        }
    }
}
