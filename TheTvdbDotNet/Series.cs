﻿using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class Series
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("seriesName")]
        public string SeriesName { get; set; }

        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("seriesId")]
        public string SeriesId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("firstAired")]
        public string FirstAired { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("networkId")]
        public string NetworkId { get; set; }

        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        [JsonProperty("genre")]
        public string[] Genre { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("lastUpdated")]
        public long LastUpdated { get; set; }

        [JsonProperty("airsDayOfWeek")]
        public string AirsDayOfWeek { get; set; }

        [JsonProperty("airsTime")]
        public string AirsTime { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }

        [JsonProperty("zap2itId")]
        public string Zap2itId { get; set; }

        [JsonProperty("added")]
        public string Added { get; set; }

        [JsonProperty("addedBy")]
        public object AddedBy { get; set; }

        [JsonProperty("siteRating")]
        public double SiteRating { get; set; }

        [JsonProperty("siteRatingCount")]
        public int SiteRatingCount { get; set; }
    }
}
