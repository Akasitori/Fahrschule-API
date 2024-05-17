using FluentValidation;

namespace Fahrschule.Application.Schuelers.Commands.CreateSchueler
{
    public class CreateSchuelerCommandValidator : AbstractValidator<CreateSchuelerCommand>
    {
        public CreateSchuelerCommandValidator()
        {
            RuleFor(x => x.Vorname).NotEmpty();
            RuleFor(x => x.Nachname).NotEmpty();
        }
    }
}
