using System.Text.Json.Serialization;

namespace TheTvdbDotNet.Authentication;

public class LoginResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("data")]
    public LoginDataResponse Data { get; set; }
}

public class LoginDataResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
}