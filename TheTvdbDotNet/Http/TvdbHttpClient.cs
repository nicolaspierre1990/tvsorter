using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Http;

public class TvdbHttpClient : ITvdbHttpClient
{
    private const string ApiUrl = "https://api.thetvdb.com/";

    private readonly HttpClient httpClient;

    public TvdbHttpClient()
        : this(new HttpClient())
    {
    }

    public TvdbHttpClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        InitialiseHttpClient();
    }

    private void InitialiseHttpClient()
    {
        httpClient.BaseAddress = new Uri(ApiUrl);
        httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
    }

    public async Task<T> GetResponseAsync<T>(string uri, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        var data = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        return await HandleResponseAsync<T>(data, cancellationToken).ConfigureAwait(false);
    }

    public async Task<T> PostResponseAsync<T>(string uri, object postData, CancellationToken cancellationToken = default)
    {
        var postJson = JsonSerializer.Serialize(postData);
        var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = new StringContent(postJson, Encoding.UTF8, "application/json"),
        };
        var data = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        return await HandleResponseAsync<T>(data, cancellationToken).ConfigureAwait(false);
    }

    public Task<Stream> GetStreamAsync(string uri, CancellationToken cancellationToken = default)
    {
        return httpClient.GetStreamAsync(uri, cancellationToken);
    }

    public void SetAuthorizationHeader(string token)
    {
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken = default)
    {
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            return Deserialize<T>(responseContent);
        }
        else
        {
            var error = Deserialize<ErrorResponse>(responseContent);
            throw new TvdbRequestException(error.Error);
        }
    }

    private T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json);
}