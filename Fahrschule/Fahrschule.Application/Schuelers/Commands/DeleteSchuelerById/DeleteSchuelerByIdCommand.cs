using ErrorOr;
using MediatR;

namespace Fahrschule.Application.Schuelers.Commands.DeleteSchuelerById
{
    public record DeleteSchuelerByIdCommand 
    (
       Guid Id
    ): IRequest<ErrorOr<Unit>>;
}
