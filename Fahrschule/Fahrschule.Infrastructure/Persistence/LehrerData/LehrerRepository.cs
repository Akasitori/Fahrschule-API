using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.LehrerAggregate;
using Fahrschule.Infrastructure.Persistence.LehrerData.Model;
using MapsterMapper;
using Microsoft.Extensions.Options;

namespace Fahrschule.Infrastructure.Persistence.LehrerData
{
    public  class LehrerRepository : Repository<Lehrer, Guid, LehrerEntity, Guid>, ILehrerRepository
    {
        //Konstruktur
        public LehrerRepository(IOptionsMonitor<CosmosDbOptions> options, IMapper mapper) : base(options, mapper) { }

        protected override string OptionsSectionName => CosmosDbOptions.Lehrer;
    }
}
