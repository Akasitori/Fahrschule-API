using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrschule.Domain.Common.Errors;

namespace Fahrschule.Application.Schuelers.Commands.PatchRemoveSchuelerVonLehrerList
{
    public class RemoveSchuelerVonLehrerListCommandHandler : IRequestHandler<RemoveSchuelerVonLehrerListCommand, ErrorOr<Schueler>>
    {
        private readonly ISchuelerRepository _schuelerRepository;
        
        public RemoveSchuelerVonLehrerListCommandHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }

        public async Task<ErrorOr<Schueler>> Handle(RemoveSchuelerVonLehrerListCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            try
            {
                IReadOnlyList<PatchOperation> patchOperations = new List<PatchOperation>()
                {
                    PatchOperation.Set("/lehrerId", new MemoryStream(Encoding.UTF8.GetBytes("null")))
                };

                return await _schuelerRepository.PatchAsync(request.id, patchOperations);
            } 
            catch
            {
                return Errors.Schueler.ResourceNotFound;
            }
            
        }
    }
}
