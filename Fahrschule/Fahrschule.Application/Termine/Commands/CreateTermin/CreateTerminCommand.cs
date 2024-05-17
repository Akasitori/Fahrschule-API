using ErrorOr;
using Fahrschule.Application.Termine.Common;
using Fahrschule.Domain.TerminAggregate;
using MediatR;

namespace Fahrschule.Application.Termine.Commands.CreateTermin
{
    public record CreateTerminCommand
    (
        DateTime Beginn,
        DateTime Ende,
        Guid SchuelerId,
        Guid LehrerId,
        UebungsTyp UebungsTyp,
        TerminStatus TerminStatus
        ) :IRequest<ErrorOr<Termin>>;
}
