using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Queries.GetAllSchuelerByLehrerId
{
    public class GetAllSchuelerByLehrerIdQueryHandler : IRequestHandler<GetAllSchuelerByLehrerIdQuery, ErrorOr<List<Schueler>>>
    {
        private readonly ISchuelerRepository _schuelerRepository;
        public GetAllSchuelerByLehrerIdQueryHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }
        public async Task<ErrorOr<List<Schueler>>> Handle(GetAllSchuelerByLehrerIdQuery request, CancellationToken cancellationToken)
        {
            var schuelerliste = await _schuelerRepository.GetAllSchuelerByLehrerIdQueryAsync(request.LehrerId);

            return schuelerliste;
        }
    }
}
