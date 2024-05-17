using ErrorOr;
using MediatR;

namespace Fahrschule.Application.Termine.Commands.DeleteTerminById
{
    public record DeleteTerminByIdCommand 
    (
        Guid Id
    ) : IRequest<ErrorOr<Unit>>;
}
