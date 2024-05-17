using ErrorOr;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Commands.PatchRemoveSchuelerVonLehrerList
{
    public record RemoveSchuelerVonLehrerListCommand
    (
        Guid id
    ) : IRequest<ErrorOr<Schueler>>;
}
