using ErrorOr;
using Fahrschule.Domain.TerminAggregate;
using MediatR;


namespace Fahrschule.Application.Termine.Queries.GetTermineByLehrerId
{
    public record GetTermineByLehrerIdQuery(
        Guid LehrerId,
        DateTime Beginn,
        DateTime Ende
    ) : IRequest<ErrorOr<List<Termin>>>;
}
