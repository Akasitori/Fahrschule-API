using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.SchuelerAggregate;
using Fahrschule.Domain.SchuelerAggregate.ValueObjects;
using Fahrschule.Domain.TerminAggregate;
using Fahrschule.Infrastructure.Persistence.TerminData.Model;
using MapsterMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using System;
using System.Drawing;

namespace Fahrschule.Infrastructure.Persistence.TerminData
{
    public class TerminRepository : Repository<Termin, Guid, TerminEntity, Guid>, ITerminRepository
    {
        protected override string OptionsSectionName => CosmosDbOptions.Termin;
        public TerminRepository(IOptionsMonitor<CosmosDbOptions> options, IMapper mapper) : base(options, mapper)
        {
        }

        public async Task<List<Termin>> GetTermineByLehrerId(Guid lehrerId, DateTime beginn, DateTime ende)
        {
            string beginnIsoString = beginn.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string endeIsoString = ende.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            try
            {
                var dbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.lehrerId = \"{lehrerId}\" AND c.beginn >= \"{beginnIsoString}\" AND c.beginn <= \"{endeIsoString}\"");

                var iterator = _container.GetItemQueryIterator<TerminEntity>(dbQuery);

                var terminEntityList = new List<TerminEntity>();

                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    terminEntityList.AddRange(response.ToList());
                }

                var terminList = _mapper.Map<List<Termin>>(terminEntityList);

                return (terminList);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not connect or access the database properly");
            }
        }

        public async Task<List<Termin>> GetTermineBySchuelerId(Guid schuelerId, DateTime? beginn, DateTime? ende)
        {
            string beginnIsoString = "";
            string endeIsoString = "";

            if (beginn != null) {
                beginnIsoString = beginn.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            if (ende != null)
            {
                endeIsoString = ende.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }

            try
            {
                //var defaultDbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\"");

                //var dbQueryBeginnOnly = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\" AND c.beginn > \"{beginn}\"");

                //var dbQueryEndeOnly = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\" AND c.ende < \"{ende}\"");

                //var dbQueryBeginnAndEnde = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\" AND c.beginn > \"{beginn}\" AND c.ende < \"{ende}\"");

                var test = beginn.Value.ToUniversalTime();
                var test2 = beginn.Value.ToString();

                var dbQuery = new QueryDefinition($"SELECT * FROM c");

                if (beginn == null && ende == null)
                {
                    dbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\"");
                }
                else if (beginn != null && ende == null)
                {
                    dbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\" AND c.beginn > \"{beginn}\"");
                }
                else if (beginn == null && ende != null)
                {
                    dbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\" AND c.ende < \"{ende}\"");
                }
                else if (beginn != null && ende != null)
                {
                    dbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\" AND c.beginn >= \"{beginnIsoString}\" AND c.beginn <= \"{endeIsoString}\"");
                    // dbQuery = new QueryDefinition($"SELECT * FROM c WHERE c.schuelerId = \"{schuelerId}\" AND c.beginn < \"{beginn}\" AND c.ende > \"{ende}\"");
                }
                var iterator = _container.GetItemQueryIterator<TerminEntity>(dbQuery);

                var terminEntityList = new List<TerminEntity>();

                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    terminEntityList.AddRange(response.ToList());
                }

                var terminList = _mapper.Map<List<Termin>>(terminEntityList);

                return (terminList);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not connect or access the database properly");
            }
        }


    }
}
