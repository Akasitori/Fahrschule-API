using ErrorOr;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Commands.UpdateSchueler
{
    public record UpdateSchuelerCommand
    (
        Guid Id,
        string Vorname,
        string Nachname,
        AdresseCommand Adresse,
        KontaktdatenCommand Kontaktdaten
    ) : IRequest<ErrorOr<Schueler>>;

    public record AdresseCommand(
        string Strasse,
        string HausNr,
        string Stadt,
        string Plz
    );

    public record KontaktdatenCommand(
        string Tel,
        string Email
    );
}
