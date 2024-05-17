using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Application.Schuelers.Queries.GetSchuelerById;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Queries.GetAllSchuelerByLehrerId
{
    public class GetSchuelerByIdQueryHandler : IRequestHandler<GetSchuelerByIdQuery, ErrorOr<Schueler>>
    {
        private readonly ISchuelerRepository _schuelerRepository;
        public GetSchuelerByIdQueryHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }
        public async Task<ErrorOr<Schueler>> Handle(GetSchuelerByIdQuery request, CancellationToken cancellationToken)
        {
            var schueler = await _schuelerRepository.GetByIdAsync(request.Id);

            return schueler;
        }
    }
}
