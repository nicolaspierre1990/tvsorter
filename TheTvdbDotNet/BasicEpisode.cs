using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheTvdbDotNet;

public class BasicEpisode
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("seriesId")]
    public int SeriesId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("aired")]
    public string Aired { get; set; }

    [JsonPropertyName("runtime")]
    public int? Runtime { get; set; }

    [JsonPropertyName("nameTranslations")]
    public List<string> NameTranslations { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("overviewTranslations")]
    public List<string> OverviewTranslations { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("imageType")]
    public int? ImageType { get; set; }

    [JsonPropertyName("isMovie")]
    public int IsMovie { get; set; }

    [JsonPropertyName("seasons")]
    public object Seasons { get; set; }

    [JsonPropertyName("number")]
    public int EpisodeNumber { get; set; }

    [JsonPropertyName("absoluteNumber")]
    public int AbsoluteNumber { get; set; }

    [JsonPropertyName("seasonNumber")]
    public int SeasonNumber { get; set; }

    [JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [JsonPropertyName("finaleType")]
    public string FinaleType { get; set; }

    [JsonPropertyName("year")]
    public string Year { get; set; }
}
