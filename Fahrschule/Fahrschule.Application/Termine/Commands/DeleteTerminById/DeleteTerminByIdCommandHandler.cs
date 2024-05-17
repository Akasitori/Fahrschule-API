using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Fahrschule.Application.Termine.Commands.DeleteTerminById
{
    public class DeleteTerminByIdCommandHandler : IRequestHandler<DeleteTerminByIdCommand, ErrorOr<Unit>>
    {
        private readonly ITerminRepository _terminRepository;
        public DeleteTerminByIdCommandHandler(ITerminRepository terminRepository) 
        {
            _terminRepository = terminRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteTerminByIdCommand request, CancellationToken cancellationToken)
        {
            var errorOrTermin = await _terminRepository.GetByIdAsync(request.Id);
            if (errorOrTermin.Value == null)
            {
                return new ErrorOr<Unit>();
            }
            var termin = errorOrTermin.Value;
            await _terminRepository.DeleteAsync(termin);
            return Unit.Value;
        }
    }
}
