using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.Schuelers.ResponseResources
{
    public class CreateSchuelerResponseResource
    {
        [JsonPropertyName("value")]
        public SchuelerResource Value { get; set; }
    }
}
