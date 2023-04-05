using System.Text.Json;

namespace LinqToTwitter.Common.Entities
{
    using System.Text.Json.Serialization;

    public class Variant
    {
        public Variant() { }
        public Variant(JsonElement variant)
        {
            BitRate = variant.GetInt("bitrate");
            ContentType = variant.GetString("content_type");
            Url = variant.GetString("url");
        }

        [JsonPropertyName("bit_rate")]
        public int BitRate { get; set; }

        [JsonPropertyName("content_type")]
        public string? ContentType { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
