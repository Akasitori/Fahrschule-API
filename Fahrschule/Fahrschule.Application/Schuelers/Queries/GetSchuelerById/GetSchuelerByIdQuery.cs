using ErrorOr;
using Fahrschule.Domain.SchuelerAggregate;
using Fahrschule.Domain.SchuelerAggregate.ValueObjects;
using MediatR;

namespace Fahrschule.Application.Schuelers.Queries.GetSchuelerById
{
    public class GetSchuelerByIdQuery : IRequest<ErrorOr<Schueler>>
    { 
       public Guid Id { get; set; }
    }

}
