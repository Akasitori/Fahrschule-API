using ErrorOr;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Queries.GetAllSchuelerByLehrerId
{
    public record GetAllSchuelerByLehrerIdQuery(
        Guid LehrerId
        ) : IRequest<ErrorOr<List<Schueler>>>;
}
