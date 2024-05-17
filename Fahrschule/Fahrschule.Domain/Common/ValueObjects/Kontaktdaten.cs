using Fahrschule.Domain.Common.Models;

namespace Fahrschule.Domain.Common.ValueObjects
{
    public sealed class Kontaktdaten : ValueObject
    {
        public string Tel { get; set; }
        public string Email { get; set; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Tel;
            yield return Email;
        }
    }
}
