using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Application.Lehrers.Commands.DeleteLehrer
{
    public class DeleteLehrerByIdCommandHandler : IRequestHandler<DeleteLehrerByIdCommand, ErrorOr<Unit>>
    {
        private readonly ILehrerRepository _lehrerRepository;
        public DeleteLehrerByIdCommandHandler(ILehrerRepository lehrerRepository)
        {
            _lehrerRepository = lehrerRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteLehrerByIdCommand request, CancellationToken cancellationToken)
        {
            var command = await _lehrerRepository.GetByIdAsync(request.Id);
            if (command.Value == null)
            {
                return new ErrorOr<Unit>();
            }
            var lehrer = command.Value;
            await _lehrerRepository.DeleteAsync(lehrer);
            return Unit.Value;
        }
    }
}
