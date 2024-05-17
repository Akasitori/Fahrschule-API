using Fahrschule.Contracts.Termine.CommonResources;
using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.Termine.ResponseResources
{
    public record TerminResponseResource
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("beginn")]
        public DateTime Beginn { get; set; }

        [JsonPropertyName("ende")]
        public DateTime Ende { get; set; }

        [JsonPropertyName("terminDauerInMinuten")]
        public int TerminDauerInMinuten { get; set; }

        [JsonPropertyName("schuelerId")]
        public Guid SchuelerId { get; set; }

        [JsonPropertyName("lehrerId")]
        public Guid LehrerId { get; set; }

        [JsonPropertyName("uebungsTyp")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UebungsTypResource UebungsTyp { get; set; }

        [JsonPropertyName("terminStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TerminStatusResource TerminStatus { get; set; }
    }
}
