using System.Text.Json.Serialization;

namespace TheTvdbDotNet;

public class SeriesEpisodes
{
    [JsonPropertyName("data")]
    public SeriesEpisodesData Data { get; set; }

    [JsonPropertyName("errrors")]
    public JsonErrors Errors { get; set; }

    [JsonPropertyName("links")]
    public Links Links { get; set; }
}

public class SeriesEpisodesData
{
    [JsonPropertyName("episodes")]
    public BasicEpisode[] Episodes { get; set; }

    [JsonPropertyName("series")]
    public Data Series { get; set; }
}

public class Links
{
    [JsonPropertyName("self")]
    public string Self { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }
}