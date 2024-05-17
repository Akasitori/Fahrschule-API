namespace Fahrschule.Domain.Common
{
    public interface IDomainEntity<TDomainEntityId>
    {
        TDomainEntityId Id { get; }
    }
}
