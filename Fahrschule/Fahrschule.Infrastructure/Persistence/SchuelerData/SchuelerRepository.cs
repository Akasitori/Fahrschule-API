using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.SchuelerAggregate;
using Fahrschule.Domain.SchuelerAggregate.ValueObjects;
using Fahrschule.Infrastructure.Persistence.SchuelerData.Model;
using MapsterMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace Fahrschule.Infrastructure.Persistence.SchuelerData
{
    public class SchuelerRepository : Repository<Schueler, Guid, SchuelerEntity, Guid>, ISchuelerRepository
    {
        protected override string OptionsSectionName => CosmosDbOptions.Schueler;

        public SchuelerRepository(IOptionsMonitor<CosmosDbOptions> options, IMapper mapper) : base(options, mapper)
        {
        }


        public async Task<List<Schueler>> GetAllSchuelerByLehrerIdQueryAsync(Guid lehrerId)
        {
            try
            {
                //TODO: Use GetItemLinqQueryable instead
                var dbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.lehrerId = \"{lehrerId}\"");

                var iterator = _container.GetItemQueryIterator<SchuelerEntity>(dbQuery);

                var schuelerEntityList = new List<SchuelerEntity>();

                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    schuelerEntityList.AddRange(response.ToList());
                }

                var schuelerList = _mapper.Map<List<Schueler>>(schuelerEntityList);

                return (schuelerList);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not connect or access the database properly");
            }
        }
    }
}
