using System.Text.Json.Serialization;

namespace TheTvdbDotNet;

public class SeriesSearchData
{
    [JsonPropertyName("aliases")]
    public string[] Aliases { get; set; }

    [JsonPropertyName("image_url")]
    public string Banner { get; set; }

    [JsonPropertyName("first_air_time")]
    public string FirstAired { get; set; }

    [JsonPropertyName("tvdb_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Id { get; set; }

    [JsonPropertyName("network")]
    public string Network { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("name")]
    public string SeriesName { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}
