using ErrorOr;
using Fahrschule.Domain.Common;
using Fahrschule.Domain.TerminAggregate;

namespace Fahrschule.Application.Common.Interfaces.Persistence
{
    public interface ITerminRepository : IRepository<Termin, Guid>
    {
        Task<List<Termin>> GetTermineByLehrerId(Guid lehrerId, DateTime beginn, DateTime ende);
        Task<List<Termin>> GetTermineBySchuelerId(Guid lehrerId, DateTime? beginn, DateTime? ende);
    }
}
