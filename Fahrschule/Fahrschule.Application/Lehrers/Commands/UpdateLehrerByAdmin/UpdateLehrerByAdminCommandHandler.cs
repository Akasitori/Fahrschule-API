using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Application.Lehrers.Commands.UpdateLehrer;
using Fahrschule.Domain.LehrerAggregate;
using Fahrschule.Domain.LehrerAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Application.Lehrers.Commands.UpdateLehrerByAdmin
{
    public class UpdateLehrerByAdminCommandHandler : IRequestHandler<UpdateLehrerByAdminCommand, ErrorOr<Lehrer>>
    {

        private readonly ILehrerRepository _lehrerRepository;

        public UpdateLehrerByAdminCommandHandler(ILehrerRepository lehrerRepository)
        {
            _lehrerRepository = lehrerRepository;
        }

        public async Task<ErrorOr<Lehrer>> Handle(UpdateLehrerByAdminCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var lehrer = await _lehrerRepository.GetByIdAsync(request.Id);

            if (lehrer.Value != null)
            {
                lehrer.Value.UpdateByAdmin(
                    vorname: request.Vorname,
                    nachname: request.Nachname,
                    geschlecht: Lehrer.CreateGeschlechter(request.Geschlecht.ToString()),
                    geburtsdatum: request.Geburtsdatum,

                    street: request.Adresse.Strasse,
                    hausnr: request.Adresse.HausNr,
                    stadt: request.Adresse.Stadt,
                    plz: request.Adresse.Plz,

                    tel: request.Kontaktdaten.Tel,
                    email: request.Kontaktdaten.Email,

                    //fuehrerscheinklasse: request.fuehrerscheinklasse,
                    zertifizierterFahrlehrer: request.ZertifizierterFahrlehrer
                );

                lehrer = await _lehrerRepository.UpdateAsync(lehrer.Value);
            }

            return lehrer;
        }
    }
}
