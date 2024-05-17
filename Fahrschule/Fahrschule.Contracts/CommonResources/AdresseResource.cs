using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.CommonResources
{
    public class AdresseResource
    {
        [JsonPropertyName("strasse")]
        public string Strasse { get; set; }

        [JsonPropertyName("hausNr")]
        public string HausNr { get; set; }

        [JsonPropertyName("stadt")]
        public string Stadt { get; set; }

        [JsonPropertyName("plz")]
        public string Plz { get; set; }
    }
}
