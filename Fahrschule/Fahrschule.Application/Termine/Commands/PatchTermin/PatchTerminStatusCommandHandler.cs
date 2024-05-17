using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.Common.Errors;
using Fahrschule.Domain.TerminAggregate;
using MediatR;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Linq;

namespace Fahrschule.Application.Termine.Commands.PatchTermin
{
    public class PatchTerminStatusCommandHandler : IRequestHandler<PatchTerminStatusCommand, ErrorOr<Termin>>
    {
        private readonly ITerminRepository _terminRepository;
        public PatchTerminStatusCommandHandler(ITerminRepository terminRepository)
        {
            _terminRepository = terminRepository;

        }
        public async Task<ErrorOr<Termin>> Handle(PatchTerminStatusCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            try
            {
                IReadOnlyList<PatchOperation> patchOperations = new List<PatchOperation>()
                {
                    PatchOperation.Set("/terminStatus", request.TerminStatus)
                };

                return await _terminRepository.PatchAsync(request.id, patchOperations);
            }
            catch {
                return Errors.Termin.ResourceNotFound;
            }
        }
    }
}
