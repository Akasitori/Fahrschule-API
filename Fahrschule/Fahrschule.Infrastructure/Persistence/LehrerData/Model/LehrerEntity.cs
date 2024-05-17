using Fahrschule.Infrastructure.Persistence.Common.Model;
using System.Text.Json.Serialization;


namespace Fahrschule.Infrastructure.Persistence.LehrerData.Model
{
    public class LehrerEntity : IDatabaseEntity<Guid>
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

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

        [JsonPropertyName("fuehrerscheinKlasse")]
        public List<FuehrerscheinKlasseEntity> FuehrerscheinKlasse { get; set; }

        [JsonPropertyName("zertifizierterFahrlehrer")]
        public bool ZertifizierterFahrlehrer { get; set; }

    }

    public enum GeschlechtEntity
    {
        Male,
        Female,
        Diverse
    }

    public class AdresseEntity
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

    public class KontaktdatenEntity
    {

        [JsonPropertyName("tel")]
        public string Tel { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public enum FuehrerscheinKlasseEntity
    {
        A,
        B,
        C,
        D
    }

}

