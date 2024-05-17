using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.TerminAggregate;
using MediatR;

namespace Fahrschule.Application.Termine.Queries.GetTermineByLehrerId
{
    public class GetTermineByLehrerIdQueryHandler : IRequestHandler<GetTermineByLehrerIdQuery, ErrorOr<List<Termin>>>
    {
        private readonly ITerminRepository _terminRepository;
        public GetTermineByLehrerIdQueryHandler(ITerminRepository terminRepository)
        {
            _terminRepository = terminRepository;
        }
        public async Task<ErrorOr<List<Termin>>> Handle(GetTermineByLehrerIdQuery request, CancellationToken cancellationToken)
        {
            var terminListe = await _terminRepository.GetTermineByLehrerId(request.LehrerId, request.Beginn, request.Ende);

            return terminListe;
        }
    }
}
