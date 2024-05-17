using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.TerminAggregate;
using MediatR;

namespace Fahrschule.Application.Termine.Commands.CreateTermin
{
    public class CreateTerminCommandHandler : IRequestHandler<CreateTerminCommand, ErrorOr<Termin>>
    {
        private readonly ITerminRepository _terminRepository;
        public CreateTerminCommandHandler(ITerminRepository terminRepository)
        {
            _terminRepository = terminRepository;
            
        }
        public async Task<ErrorOr<Termin>> Handle(CreateTerminCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var termin = Termin.CreateNew(
                request.Beginn,
                request.Ende,
                request.SchuelerId,
                request.LehrerId,
                Termin.CreateUebungsTyp(request.UebungsTyp.ToString()),
                Termin.CreateTerminStatus(request.TerminStatus.ToString())
                );

            await _terminRepository.AddAsync( termin );

            return termin;
        }
    }
}
