using ErrorOr;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;


namespace Fahrschule.Application.Schuelers.Commands.CreateSchueler
{
    public record CreateSchuelerCommand(
        string Vorname,
        string Nachname,
        GeschlechtCommand Geschlecht,
        DateTime Geburtsdatum,
        AdresseCommand Adresse,
        KontaktdatenCommand Kontaktdaten,
        DateTime DatumDerAnmeldung,
        StatusCommand Status,
        string Fuehrerscheinklasse,
        GetriebeTypCommand GetriebeTyp,
        Guid? LehrerId
        ) : IRequest<ErrorOr<Schueler>>;

    public enum GeschlechtCommand {
        Male,
        Female,
        Divers
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

    public enum StatusCommand
    {
        Neu,
        Aktiv,
        TheorieBestanden,
        Abgeschlossen
    }

    public enum GetriebeTypCommand
    {
        Schaltgetriebe,
        Automatik,
        Beides
    }
}
