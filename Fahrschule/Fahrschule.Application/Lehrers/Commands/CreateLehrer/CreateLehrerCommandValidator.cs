using FluentValidation;

namespace Fahrschule.Application.Lehrers.Commands.CreateLehrer
{
    public class CreateLehrerCommandValidator : AbstractValidator<CreateLehrerCommand>
    {
        public CreateLehrerCommandValidator()
        {
            RuleFor(x => x.Vorname).NotEmpty();
            RuleFor(x => x.Nachname).NotEmpty();
        }
    }
}
