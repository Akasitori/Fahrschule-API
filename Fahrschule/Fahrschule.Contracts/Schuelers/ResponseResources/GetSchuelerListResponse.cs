using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.Schuelers.ResponseResources
{
    public class GetSchuelerListResponse
    {
        [JsonPropertyName("value")]
        public List<SchuelerResource> Value { get; set; }
    }
}
