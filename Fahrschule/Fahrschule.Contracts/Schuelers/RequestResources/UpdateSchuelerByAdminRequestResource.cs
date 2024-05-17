using Fahrschule.Contracts.CommonResources;
using System.Text.Json.Serialization;

namespace Fahrschule.Contracts.Schuelers.RequestResources
{
    public class UpdateSchuelerByAdminRequestResource
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

        [JsonPropertyName("datumDerAnmeldung")]
        public DateTime DatumDerAnmeldung { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusResource Status { get; set; }

        //[JsonPropertyName("fuehrerscheinklasse")]
        //public string Fuehrerscheinklasse { get; set; }

        [JsonPropertyName("getriebeTyp")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GetriebeTypResource GetriebeTyp { get; set; }

        [JsonPropertyName("lehrerId")]
        public Guid? LehrerId { get; set; }
    }
}
