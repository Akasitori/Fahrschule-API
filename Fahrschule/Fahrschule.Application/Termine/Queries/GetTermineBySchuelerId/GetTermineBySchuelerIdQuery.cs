using ErrorOr;
using Fahrschule.Domain.TerminAggregate;
using MediatR;

namespace Fahrschule.Application.Termine.Queries.GetTermineBySchuelerId
{
    public record GetTermineBySchuelerIdQuery(
        Guid SchuelerId,
        DateTime? Beginn,
        DateTime? Ende
    ) : IRequest<ErrorOr<List<Termin>>>;
}
