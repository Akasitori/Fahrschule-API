using ErrorOr;
using Fahrschule.Application.Termine.Common;
using Fahrschule.Domain.TerminAggregate;
using MediatR;

namespace Fahrschule.Application.Termine.Commands.PatchTermin
{
    public record PatchTerminStatusCommand
    (
        Guid id,
        TerminStatus TerminStatus
        ) : IRequest<ErrorOr<Termin>>;
}
