using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.CommonResources
{
    public class KontaktdatenResource
    {
        [JsonPropertyName("tel")]
        public string Tel { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
