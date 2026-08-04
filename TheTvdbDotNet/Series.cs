using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheTvdbDotNet;

[Obsolete("Use SeriesDataResponse instead. This class is deprecated and may be removed in future versions.")]
public class Series
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("seriesName")]
    public string SeriesName { get; set; }

    [JsonPropertyName("aliases")]
    public string[] Aliases { get; set; }

    [JsonPropertyName("banner")]
    public string Banner { get; set; }

    [JsonPropertyName("seriesId")]
    public string SeriesId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("firstAired")]
    public string FirstAired { get; set; }

    [JsonPropertyName("network")]
    public string Network { get; set; }

    [JsonPropertyName("networkId")]
    public string NetworkId { get; set; }

    [JsonPropertyName("runtime")]
    public string Runtime { get; set; }

    [JsonPropertyName("genre")]
    public string[] Genre { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("lastUpdated")]
    public long LastUpdated { get; set; }

    [JsonPropertyName("airsDayOfWeek")]
    public string AirsDayOfWeek { get; set; }

    [JsonPropertyName("airsTime")]
    public string AirsTime { get; set; }

    [JsonPropertyName("rating")]
    public string Rating { get; set; }

    [JsonPropertyName("imdbId")]
    public string ImdbId { get; set; }

    [JsonPropertyName("zap2itId")]
    public string Zap2itId { get; set; }

    [JsonPropertyName("added")]
    public string Added { get; set; }

    [JsonPropertyName("addedBy")]
    public object AddedBy { get; set; }

    [JsonPropertyName("siteRating")]
    public double SiteRating { get; set; }

    [JsonPropertyName("siteRatingCount")]
    public int SiteRatingCount { get; set; }
}

public class Alias
{
    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Data
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("nameTranslations")]
    public List<string> NameTranslations { get; set; }

    [JsonPropertyName("overviewTranslations")]
    public List<string> OverviewTranslations { get; set; }

    [JsonPropertyName("aliases")]
    public List<Alias> Aliases { get; set; }

    [JsonPropertyName("firstAired")]
    public string FirstAired { get; set; }

    [JsonPropertyName("lastAired")]
    public string LastAired { get; set; }

    [JsonPropertyName("nextAired")]
    public string NextAired { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("originalCountry")]
    public string OriginalCountry { get; set; }

    [JsonPropertyName("originalLanguage")]
    public string OriginalLanguage { get; set; }

    [JsonPropertyName("defaultSeasonType")]
    public int DefaultSeasonType { get; set; }

    [JsonPropertyName("isOrderRandomized")]
    public bool IsOrderRandomized { get; set; }

    [JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [JsonPropertyName("averageRuntime")]
    public int AverageRuntime { get; set; }

    [JsonPropertyName("episodes")]
    public object Episodes { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("year")]
    public string Year { get; set; }
}

public class SeriesDataResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public class Status
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("recordType")]
    public string RecordType { get; set; }

    [JsonPropertyName("keepUpdated")]
    public bool KeepUpdated { get; set; }
}

