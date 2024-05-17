using ErrorOr;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;

namespace Fahrschule.Application.Lehrers.Commands.UpdateLehrer
{
    public record UpdateLehrerCommand
    (
        Guid Id,
        string Vorname,
        string Nachname,
        AdresseCommand Adresse,
        KontaktdatenCommand Kontaktdaten
    ) : IRequest<ErrorOr<Lehrer>>;

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
