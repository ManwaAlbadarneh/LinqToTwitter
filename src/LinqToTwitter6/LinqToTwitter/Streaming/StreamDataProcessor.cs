using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using LinqToTwitter.Provider;

namespace LinqToTwitter
{
    public class StreamDataProcessor
    {
        public StreamData? Content { get; init; }

        public StreamDataProcessor(string content)
        {
            Content = ParseJson(content);
        }

        private StreamData? ParseJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(),
                    new TweetMediaTypeConverter(),
                    new TweetReplySettingsConverter()
                }
            };

            try
            {
                return JsonSerializer.Deserialize<StreamData>(json, options);
            }
            catch (Exception ex)
            {
                string parseError =
                    $"Error deserializing twitter stream data.\n Message Text:\n {json} \nException Details: {ex} \n";

                if (TwitterExecute.Log != null)
                    TwitterExecute.Log.WriteLine(parseError);

                return null;
            }
        }

    }
}
