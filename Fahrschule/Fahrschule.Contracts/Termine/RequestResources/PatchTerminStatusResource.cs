using Fahrschule.Contracts.Termine.CommonResources;
using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.Termine.RequestResources
{
    public class PatchTerminStatusResource
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("terminStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TerminStatusResource TerminStatus { get; set; }
    }
}
