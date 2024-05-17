using Fahrschule.Domain.Common.Models;

namespace Fahrschule.Domain.LehrerAggregate.ValueObjects
{
    public sealed class LehrerId
    {
        public Guid Value { get; set; }

        public LehrerId() { }
        private LehrerId(Guid value)
        {
            Value = value;
        }

        public static LehrerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
