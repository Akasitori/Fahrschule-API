using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;


namespace Fahrschule.Application.Lehrers.Commands.UpdateLehrer
{
    public class UpdateLehrerCommandHandler : IRequestHandler<UpdateLehrerCommand, ErrorOr<Lehrer>>
    {
        private readonly ILehrerRepository _lehrerRepository;

        public UpdateLehrerCommandHandler(ILehrerRepository lehrerRepository)
        {
            _lehrerRepository = lehrerRepository;
        }

        public async Task<ErrorOr<Lehrer>> Handle(UpdateLehrerCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var lehrer = await _lehrerRepository.GetByIdAsync(request.Id);

            if (lehrer.Value != null)
            {
                lehrer.Value.Update(
                    vorname: request.Vorname,
                    nachname: request.Nachname,
                    street: request.Adresse.Strasse,
                    hausnr: request.Adresse.HausNr,
                    stadt: request.Adresse.Stadt,
                    plz: request.Adresse.Plz,
                    tel: request.Kontaktdaten.Tel,
                    email: request.Kontaktdaten.Email
                );

                lehrer = await _lehrerRepository.UpdateAsync(lehrer.Value);
            }

            return lehrer;
        }
    }
}
