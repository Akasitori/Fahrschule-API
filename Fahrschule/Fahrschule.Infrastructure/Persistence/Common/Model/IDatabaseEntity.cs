using System.Text.Json.Serialization;

namespace Fahrschule.Infrastructure.Persistence.Common.Model
{
    public interface IDatabaseEntity<TId>
    {
        [JsonPropertyName("id")]
        public TId Id { get; set; }

        //public string DocumentType { get; set; }
    }
}
