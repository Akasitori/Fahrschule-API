using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.SchuelerAggregate;
using MediatR;

namespace Fahrschule.Application.Schuelers.Commands.UpdateSchueler
{
    public class UpdateSchuelerCommandHandler : IRequestHandler<UpdateSchuelerCommand, ErrorOr<Schueler>>
    {
        private readonly ISchuelerRepository _schuelerRepository;

        public UpdateSchuelerCommandHandler(ISchuelerRepository schuelerRepository)
        {
            _schuelerRepository = schuelerRepository;
        }

        public async Task<ErrorOr<Schueler>> Handle(UpdateSchuelerCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var schueler = await _schuelerRepository.GetByIdAsync(request.Id);

            if(schueler.Value != null){
                schueler.Value.Update(
                    vorname: request.Vorname,
                    nachname: request.Nachname,
                    street: request.Adresse.Strasse,
                    hausnr: request.Adresse.HausNr,
                    stadt: request.Adresse.Stadt,
                    plz: request.Adresse.Plz,
                    tel: request.Kontaktdaten.Tel,
                    email: request.Kontaktdaten.Email
                );

                schueler = await _schuelerRepository.UpdateAsync(schueler.Value);

            }

            return schueler;
        }
    }
}
