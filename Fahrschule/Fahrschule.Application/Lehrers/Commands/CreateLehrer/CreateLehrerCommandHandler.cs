using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.LehrerAggregate;
using Fahrschule.Domain.LehrerAggregate.ValueObjects;
using MediatR;

namespace Fahrschule.Application.Lehrers.Commands.CreateLehrer
{
    public class CreateLehrerCommandHandler : IRequestHandler<CreateLehrerCommand, ErrorOr<Lehrer>>
    {
        private readonly ILehrerRepository _lehrerRepository;

        public CreateLehrerCommandHandler(ILehrerRepository lehrerRepository)
        {
            _lehrerRepository = lehrerRepository;
        }

        public async Task<ErrorOr<Lehrer>> Handle(CreateLehrerCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //Create Lehrer
            var lehrer = Lehrer.Create(
                request.Vorname,
                request.Nachname,
                Lehrer.CreateGeschlechter(
                    request.Geschlecht.ToString()
                ),
                request.Geburtsdatum,
                Lehrer.CreateAdresse(
                    request.Adresse.Strasse,
                    request.Adresse.HausNr,
                    request.Adresse.Stadt,
                    request.Adresse.Plz
                ),
                Lehrer.CreateKontaktDaten(
                    request.Kontaktdaten.Tel,
                    request.Kontaktdaten.Email
                ),
                request.FuehrerscheinKlasse?.Select(
                    _ => Enum.Parse<FuehrerscheinKlasse>(_.ToString())
                    )?.ToList(),
                request.ZertifizierterFahrlehrer
            );

            await _lehrerRepository.AddAsync(lehrer);

            return lehrer;
        }
    }
}
