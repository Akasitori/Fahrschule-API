using Fahrschule.Domain.Common;
using Fahrschule.Domain.LehrerAggregate;

namespace Fahrschule.Application.Common.Interfaces.Persistence
{
    public interface ILehrerRepository : IRepository<Lehrer, Guid>
    {}
}
