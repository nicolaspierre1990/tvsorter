using System.Text.Json.Serialization;

namespace TheTvdbDotNet;

public class SeriesEpisodes
{
    [JsonPropertyName("data")]
    public SeriesEpisodesData Data { get; set; }

    [JsonPropertyName("errrors")]
    public JsonErrors Errors { get; set; }
}

public class SeriesEpisodesData
{
    [JsonPropertyName("episodes")]
    public BasicEpisode[] Episodes { get; set; }

    [JsonPropertyName("series")]
    public Data Series { get; set; }
}