using ErrorOr;
using Microsoft.Azure.Cosmos;
using System.Linq.Expressions;

namespace Fahrschule.Domain.Common
{
    public interface IRepository<TDomainEntity, TDomainEntityId> where TDomainEntity : IDomainEntity<TDomainEntityId>
    {
        Task<ErrorOr<List<TDomainEntity>>> GetAllAsync();
        Task<ErrorOr<TDomainEntity>> GetByIdAsync(Guid id);
        Task<TDomainEntity> AddAsync(TDomainEntity entity);
        Task<TDomainEntity> UpdateAsync(TDomainEntity entity);
        Task DeleteAsync(TDomainEntity entity);
        Task<TDomainEntity>PatchAsync(Guid domainEntityId, IReadOnlyList<PatchOperation> patchOperations);

    }
}
