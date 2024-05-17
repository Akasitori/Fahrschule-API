using ErrorOr;
using Fahrschule.Domain.Common;
using Fahrschule.Domain.Common.Models;
using Fahrschule.Infrastructure.Persistence.Common.Model;
using MapsterMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;


namespace Fahrschule.Infrastructure.Persistence
{
    public abstract class Repository<TDomainEntity, TDomainEntityId, TDatabaseEntity, TDatabaseEntityId> : IRepository<TDomainEntity, TDomainEntityId> // Braucht Container und Item
             where TDatabaseEntity : IDatabaseEntity<TDatabaseEntityId>
             where TDomainEntity : IDomainEntity<TDomainEntityId>

    {
        protected readonly Container _container;
        protected readonly IMapper _mapper;

        protected abstract string OptionsSectionName { get; }

        public Repository(
            IOptionsMonitor<CosmosDbOptions> options,
            IMapper mapper)
        {
            _mapper = mapper;
            _container = CosmosDbManager.Init(options.Get(OptionsSectionName)).GetAwaiter().GetResult();
        }

        public async Task UpsertItem<T>(CosmosClient client, string dbId, string container, T item)
        {
            Container myContainer = client.GetContainer(dbId, container);

            await myContainer.UpsertItemAsync(item);
        }

        public async Task<ErrorOr<TDomainEntity>> GetByIdAsync(Guid id)
        {
            try
            {
                var response = await _container.ReadItemAsync<TDatabaseEntity>(
                    id.ToString(),
                    new PartitionKey(id.ToString()));
                return _mapper.Map<TDomainEntity>(response.Resource);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task<TDomainEntity> AddAsync(TDomainEntity domainEntity)
        {
            var entity = _mapper.Map<TDatabaseEntity>(domainEntity);

            var response = await _container.CreateItemAsync(
                entity,
                new PartitionKey(entity.Id.ToString()));

            return _mapper.Map<TDomainEntity>(response.Resource);
        }

        public async Task<TDomainEntity> UpdateAsync(TDomainEntity domainEntity)
        {
            var entity = _mapper.Map<TDatabaseEntity>(domainEntity);
            var response = await _container.ReplaceItemAsync(
                entity,
                entity.Id.ToString(),
                new PartitionKey(entity.Id.ToString()));

            return _mapper.Map<TDomainEntity>(response.Resource);
        }

        public async Task<TDomainEntity> PatchAsync(Guid domainEntityId, IReadOnlyList<PatchOperation> patchOperations)
        {
            
            var response = await _container.PatchItemAsync<TDatabaseEntity>(domainEntityId.ToString(), new PartitionKey(domainEntityId.ToString()), patchOperations);

            return _mapper.Map<TDomainEntity>(response.Resource);
        }

        public async Task DeleteAsync(TDomainEntity domainEntity)
        {
            try
            {
                var entity = _mapper.Map<TDatabaseEntity>(domainEntity);
                var response = await _container.DeleteItemAsync<TDatabaseEntity>(
                    entity.Id.ToString(), 
                    new PartitionKey(entity.Id.ToString()));
            }
            catch (CosmosException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return;
                }
            }
        }

        public async Task<ErrorOr<List<TDomainEntity>>> GetAllAsync()
        {
            //TODO: Use GetItemLinqQueryable instead
            var defaultQuery = new QueryDefinition($"SELECT * FROM c");

            var iterator = _container.GetItemQueryIterator<TDatabaseEntity>(defaultQuery);

            var DatabaseEntityList = new List<TDatabaseEntity>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                DatabaseEntityList.AddRange(response.ToList());
            }

            var schuelerList = _mapper.Map<List<TDomainEntity>>(DatabaseEntityList);

            return (schuelerList);
        }
    }
}
