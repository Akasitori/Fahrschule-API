using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;

namespace Fahrschule.Application.Lehrers.Queries.GetLehrerById
{
    public class GetLehrerByIdQueryHandler : IRequestHandler<GetLehrerByIdQuery, ErrorOr<Lehrer>>
    {
        private readonly ILehrerRepository _lehrerRepository;
        public GetLehrerByIdQueryHandler(ILehrerRepository lehrerRepository)
        {
            _lehrerRepository = lehrerRepository;
        }

        public async Task<ErrorOr<Lehrer>> Handle(GetLehrerByIdQuery request, CancellationToken cancellationToken)
        {
            var lehrerById = await _lehrerRepository.GetByIdAsync(request.Id);
            return lehrerById;
        }
    }
}
