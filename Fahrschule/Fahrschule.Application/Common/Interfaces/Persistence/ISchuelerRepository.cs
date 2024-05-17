using Fahrschule.Domain.Common;
using Fahrschule.Domain.SchuelerAggregate;
using Fahrschule.Domain.SchuelerAggregate.ValueObjects;

namespace Fahrschule.Application.Common.Interfaces.Persistence
{
    public interface ISchuelerRepository : IRepository<Schueler, Guid>
    {
        Task<List<Schueler>> GetAllSchuelerByLehrerIdQueryAsync(Guid lehrerId);
    }
}
