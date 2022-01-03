using Newtonsoft.Json;

namespace MediaSorter.Core.Data
{
    public class Movie
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("externalSource")]
        public string ExternalSource { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
}
