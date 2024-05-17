using Fahrschule.Domain.Common.Models;

namespace Fahrschule.Domain.SchuelerAggregate.ValueObjects
{
    public sealed class SchuelerId //: ValueObject
    {
        public Guid Value { get; set; }

        public SchuelerId() { }
        private SchuelerId(Guid value)
        {
            Value = value;
        }

        public static SchuelerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
