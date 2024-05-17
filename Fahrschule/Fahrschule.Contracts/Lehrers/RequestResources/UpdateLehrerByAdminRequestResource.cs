using Fahrschule.Contracts.CommonResources;
using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.Lehrers.RequestResources
{
    public  class UpdateLehrerByAdminRequestResource
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("vorname")]
        public string Vorname { get; set; }

        [JsonPropertyName("nachname")]
        public string Nachname { get; set; }

        [JsonPropertyName("geschlecht")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GeschlechtResource Geschlecht { get; set; }

        [JsonPropertyName("geburtsdatum")]
        public DateTime Geburtsdatum { get; set; }

        [JsonPropertyName("adresse")]
        public AdresseResource Adresse { get; set; }

        [JsonPropertyName("kontaktdaten")]
        public KontaktdatenResource Kontaktdaten { get; set; }

        //[JsonPropertyName("fuehrerscheinKlassen")]
        //public List<FuehrerscheinKlasseResource>? FuehrerscheinKlassen { get; set; }

        [JsonPropertyName("zertifizierterFahrlehrer")]
        public bool ZertifizierterFahrlehrer { get; set; }
    }
}
