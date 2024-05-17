using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Fahrschule.Application.Schuelers.Commands.DeleteSchuelerById
{
    public class DeleteSchuelerByIdCommandHandler : IRequestHandler<DeleteSchuelerByIdCommand, ErrorOr<Unit>>
    {
        private readonly ISchuelerRepository _schuelerRepository;
        public DeleteSchuelerByIdCommandHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteSchuelerByIdCommand request, CancellationToken cancellationToken)
        {

            var errorOrSchueler = await _schuelerRepository.GetByIdAsync(request.Id);
            if (errorOrSchueler.Value == null)
            {
                return new ErrorOr<Unit>();
            }
            var schueler = errorOrSchueler.Value;
            await _schuelerRepository.DeleteAsync(schueler);
            return Unit.Value;
        }
    }
}
