using Fahrschule.Contracts.CommonResources;
using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.Schuelers.RequestResources
{
    public class UpdateSchuelerRequestResource
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("vorname")]
        public string Vorname { get; set; }

        [JsonPropertyName("nachname")]
        public string Nachname { get; set; }

        [JsonPropertyName("adresse")]
        public AdresseResource Adresse { get; set; }

        [JsonPropertyName("kontaktdaten")]
        public KontaktdatenResource Kontaktdaten { get; set; }
    }
}
