using ErrorOr;
using Fahrschule.Application.Lehrers.Commands.CreateLehrer;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Application.Lehrers.Commands.UpdateLehrerByAdmin
{
    public record UpdateLehrerByAdminCommand
    (
        Guid Id,
        string Vorname,
        string Nachname,
        GeschlechterCommand Geschlecht,
        DateTime Geburtsdatum,
        AdresseCommand Adresse,
        KontaktdatenCommand Kontaktdaten,
        //List<FuehrerscheinKlasseCommand> FuehrerscheinKlasse,
        bool ZertifizierterFahrlehrer
    ) : IRequest<ErrorOr<Lehrer>>;

    public enum GeschlechterCommand
    {
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

    //public enum FuehrerscheinKlasseCommand
    //{
    //    A,
    //    B,
    //    C,
    //    D
    //}
}
