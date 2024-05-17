using ErrorOr;
using Fahrschule.Application.Schuelers.Commands.CreateSchueler;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;

namespace Fahrschule.Application.Lehrers.Commands.CreateLehrer
{
    public record CreateLehrerCommand
    (
        string Vorname,
        string Nachname,
        GeschlechterCommand Geschlecht,
        DateTime Geburtsdatum,
        AdresseCommand Adresse,
        KontaktdatenCommand Kontaktdaten,
        List<FuehrerscheinKlasseCommand> FuehrerscheinKlasse,
        bool ZertifizierterFahrlehrer
    ) : IRequest<ErrorOr<Lehrer>>;

    public enum GeschlechterCommand
    {
        Male,
        Female,
        Diverse
    }

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

    public enum FuehrerscheinKlasseCommand
    {
        A,
        B,
        C,
        D
    }
}
