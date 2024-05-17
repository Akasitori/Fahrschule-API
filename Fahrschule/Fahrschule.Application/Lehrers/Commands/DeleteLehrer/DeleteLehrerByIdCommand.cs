using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Application.Lehrers.Commands.DeleteLehrer
{
    public record DeleteLehrerByIdCommand
    (
       Guid Id
    ): IRequest<ErrorOr<Unit>>;
}
