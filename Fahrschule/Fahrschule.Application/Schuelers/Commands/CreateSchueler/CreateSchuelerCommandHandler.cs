using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Commands.CreateSchueler
{
    public class CreateSchuelerCommandHandler : IRequestHandler<CreateSchuelerCommand, ErrorOr<Schueler>>
    {
        private readonly ISchuelerRepository _schuelerRepository;
        public CreateSchuelerCommandHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }
        public async Task<ErrorOr<Schueler>> Handle(CreateSchuelerCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //Create Schueler
            var schueler = Schueler.Create(
                request.Vorname,
                request.Nachname,
               Schueler.CreateGeschlecht(request.Geschlecht.ToString()),
                request.Geburtsdatum,
                Schueler.CreateAdresse(
                    request.Adresse.Strasse, 
                    request.Adresse.HausNr, 
                    request.Adresse.Stadt, 
                    request.Adresse.Plz
                    ),
                Schueler.CreateKontaktdaten(
                    request.Kontaktdaten.Tel,
                    request.Kontaktdaten.Email
                    ),
                request.DatumDerAnmeldung,
                Schueler.CreateStatus(request.Status.ToString()),
                request.Fuehrerscheinklasse,
                Schueler.CreateGetriebeTyp(request.GetriebeTyp.ToString()),
                request.LehrerId
                );

            await _schuelerRepository.AddAsync(schueler);


            return schueler;
        }
    }
}
