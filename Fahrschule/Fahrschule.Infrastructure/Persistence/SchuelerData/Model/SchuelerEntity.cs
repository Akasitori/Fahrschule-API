using Fahrschule.Infrastructure.Persistence.Common.Model;
using System.Text.Json.Serialization;

namespace Fahrschule.Infrastructure.Persistence.SchuelerData.Model
{
    public class SchuelerEntity : IDatabaseEntity<Guid>
    {
        [JsonPropertyName("vorname")]
        public string Vorname { get; set; }

        [JsonPropertyName("nachname")]
        public string Nachname { get; set; }

        [JsonPropertyName("geschlecht")]
        public GeschlechtEntity Geschlecht { get; set; }

        [JsonPropertyName("geburtsdatum")]
        public DateTime Geburtsdatum { get; set; }

        [JsonPropertyName("adresse")]
        public AdresseEntity Adresse { get; set; }

        [JsonPropertyName("kontaktdaten")]
        public KontaktdatenEntity Kontaktdaten { get; set; }

        [JsonPropertyName("datumDerAnmeldung")]
        public DateTime DatumDerAnmeldung { get; set; }

        [JsonPropertyName("status")]
        public StatusEntity Status { get; set; }

        [JsonPropertyName("fuehrerscheinklasse")]
        public string Fuehrerscheinklasse { get; set; }

        [JsonPropertyName("getriebeTyp")]
        public GetriebeTypEntity GetriebeTyp { get; set; }

        [JsonPropertyName("lehrerId")]
        public Guid? LehrerId { get; set; }

        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName("updatedDateTime")]
        public DateTime UpdatedDateTime { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }


    public enum GeschlechtEntity
    {
        Male,
        Female,
        Diverse
    }

    public class AdresseEntity {

        [JsonPropertyName("strasse")]
        public string Strasse { get; set; }

        [JsonPropertyName("hausNr")]
        public string HausNr { get; set; }

        [JsonPropertyName("stadt")]
        public string Stadt { get; set; }

        [JsonPropertyName("plz")]
        public string Plz { get; set; }
     }

    public class KontaktdatenEntity {

        [JsonPropertyName("tel")]
        public string Tel { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public enum StatusEntity
    {
        Neu,
        Aktiv,
        TheorieBestanden,
        Abgeschlossen
    }
    public enum GetriebeTypEntity
    {
        Schaltgetriebe,
        Automatik,
        Beides
    }
}
