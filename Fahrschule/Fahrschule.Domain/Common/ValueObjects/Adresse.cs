using Fahrschule.Domain.Common.Models;

namespace Fahrschule.Domain.Common.ValueObjects
{
    public sealed class Adresse : ValueObject
    {
        public string Strasse { get; set; }
        public string HausNr { get; set; }
        public string Stadt { get; set; }
        public string Plz { get; set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Strasse;
            yield return HausNr;
            yield return Stadt;
            yield return Plz;
        }
    }
}
