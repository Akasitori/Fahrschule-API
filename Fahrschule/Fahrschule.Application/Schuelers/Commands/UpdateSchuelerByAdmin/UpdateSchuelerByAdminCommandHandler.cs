using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Application.Schuelers.Commands.UpdateSchueler;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Application.Schuelers.Commands.UpdateSchuelerByAdmin
{
    public class UpdateSchuelerByAdminCommandHandler : IRequestHandler<UpdateSchuelerByAdminCommand, ErrorOr<Schueler>>
    {
        private readonly ISchuelerRepository _schuelerRepository;

        public UpdateSchuelerByAdminCommandHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }

        public async Task<ErrorOr<Schueler>> Handle(UpdateSchuelerByAdminCommand request, CancellationToken cancellationToken) 
        {
            await Task.CompletedTask;

            var schueler = await _schuelerRepository.GetByIdAsync(request.Id);

            if (schueler.Value != null)
            {
                schueler.Value.UpdateAdmin(
                    vorname: request.Vorname,
                    nachname: request.Nachname,
                    geschlecht: Schueler.CreateGeschlecht(request.Geschlecht.ToString()),
                    geburtsdatum: request.Geburtsdatum,

                    street: request.Adresse.Strasse,
                    hausnr: request.Adresse.HausNr,
                    stadt: request.Adresse.Stadt,
                    plz: request.Adresse.Plz,

                    tel: request.Kontaktdaten.Tel,
                    email: request.Kontaktdaten.Email,

                    datumDerAnmeldung: request.DatumDerAnmeldung,
                    getriebeTyp: Schueler.CreateGetriebeTyp(request.GetriebeTyp.ToString()),
                    lehrerId: request.LehrerId,
                    status: Schueler.CreateStatus(request.Status.ToString())

                ); ;

                schueler = await _schuelerRepository.UpdateAsync(schueler.Value);

            }

            return schueler;
        }
    }
}
