using ErrorOr;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Queries.GetAllSchueler
{
    public record GetAllSchuelerQuery() : IRequest<ErrorOr<List<Schueler>>>
    { }
}
