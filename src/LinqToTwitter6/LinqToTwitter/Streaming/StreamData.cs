using LinqToTwitter.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LinqToTwitter
{
    public record StreamData
    {
        [JsonPropertyName("data")]
        public Tweet? Tweet { get; init; }

        [JsonPropertyName("includes")]
        public TwitterInclude? Includes { get; init; }

        [JsonPropertyName("matching_rules")]
        public List<MatchingRule>? MatchingRules { get; init; }
    }
}
