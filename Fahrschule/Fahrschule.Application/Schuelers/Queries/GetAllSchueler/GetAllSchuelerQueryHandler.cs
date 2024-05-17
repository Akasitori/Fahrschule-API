using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Queries.GetAllSchueler
{
    public class GetAllSchuelerQueryHandler : IRequestHandler<GetAllSchuelerQuery, ErrorOr<List<Schueler>>>
    {
        private readonly ISchuelerRepository _schuelerRepository;
        public GetAllSchuelerQueryHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }
        public async Task<ErrorOr<List<Schueler>>> Handle(GetAllSchuelerQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var schuelerliste = await _schuelerRepository.GetAllAsync();

            return schuelerliste;
        }
    }
}
