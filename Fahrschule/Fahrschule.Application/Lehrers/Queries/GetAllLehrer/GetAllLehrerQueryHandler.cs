using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;

namespace Fahrschule.Application.Lehrers.Queries.GetAllLehrer
{
    public class GetAllLehrerQueryHandler : IRequestHandler<GetAllLehrerQuery, ErrorOr<List<Lehrer>>>
    {
        private readonly ILehrerRepository _lehrerRepository;
        public GetAllLehrerQueryHandler(ILehrerRepository lehrerRepository)
        {
            _lehrerRepository = lehrerRepository;
        }

        public async Task<ErrorOr<List<Lehrer>>> Handle(GetAllLehrerQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var lehrerListe = await _lehrerRepository.GetAllAsync();

            return lehrerListe;
        }
    }
}
