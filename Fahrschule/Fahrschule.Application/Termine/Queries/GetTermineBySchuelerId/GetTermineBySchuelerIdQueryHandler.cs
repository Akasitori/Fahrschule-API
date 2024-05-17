using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.TerminAggregate;
using MediatR;

namespace Fahrschule.Application.Termine.Queries.GetTermineBySchuelerId
{
    public class GetTermineBySchuelerIdQueryHandler : IRequestHandler<GetTermineBySchuelerIdQuery, ErrorOr<List<Termin>>>
    {
        private readonly ITerminRepository _terminRepository;
        public GetTermineBySchuelerIdQueryHandler(ITerminRepository terminRepository)
        {
            _terminRepository = terminRepository;
        }
        public async Task<ErrorOr<List<Termin>>> Handle(GetTermineBySchuelerIdQuery request, CancellationToken cancellationToken)
        {
            var terminListe = await _terminRepository.GetTermineBySchuelerId(request.SchuelerId, request.Beginn, request.Ende);

            return terminListe;
        }
    }
}
