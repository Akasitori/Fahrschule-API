using Fahrschule.Infrastructure.Persistence.Common.Model;
using System.Text.Json.Serialization;

namespace Fahrschule.Infrastructure.Persistence.TerminData.Model
{
    public class TerminEntity : IDatabaseEntity<Guid>
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("beginn")]
        public DateTime Beginn { get; set; }

        [JsonPropertyName("ende")]
        public DateTime Ende { get; set; }

        [JsonPropertyName("terminDauerInMinuten")]
        public int TerminDauerInMinuten { get; set; }

        [JsonPropertyName("schuelerId")]
        public Guid SchuelerId { get; set; }

        [JsonPropertyName("lehrerId")]
        public Guid LehrerId { get; set; }

        [JsonPropertyName("uebungsTyp")]
        public UebungsTypEntity UebungsTyp { get; set; }

        [JsonPropertyName("terminStatus")]
        public TerminStatusEntity TerminStatus { get; set; }
    }

    public enum UebungsTypEntity 
    {
        Uebungsfahrt,
        Ueberlandstrasse,
        Autobahn,
        Nachtfahrt,
        Theoriepruefung,
        Fahrpruefung
    }

    public enum TerminStatusEntity
    {
        Angenommen,
        Abgelehnt,
        Ausstehend
    }
}
