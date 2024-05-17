using ErrorOr;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;

namespace Fahrschule.Application.Lehrers.Queries.GetLehrerById
{
    public record GetLehrerByIdQuery 
    (
        Guid Id
    ) : IRequest<ErrorOr<Lehrer>>;
}
