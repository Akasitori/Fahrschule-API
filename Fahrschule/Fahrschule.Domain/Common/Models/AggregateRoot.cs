namespace Fahrschule.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        protected AggregateRoot(TId id) : base(id)
        {

        }
    }
}
