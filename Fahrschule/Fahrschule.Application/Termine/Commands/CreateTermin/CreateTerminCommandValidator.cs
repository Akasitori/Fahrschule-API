using FluentValidation;

namespace Fahrschule.Application.Termine.Commands.CreateTermin
{
    public class CreateTerminCommandValidator : AbstractValidator<CreateTerminCommand>
    {
        public CreateTerminCommandValidator() 
        {
            RuleFor(x => x.Beginn).NotEmpty();
            RuleFor(x => x.Ende).NotEmpty();
            RuleFor(x => x.LehrerId).NotEmpty();
            RuleFor(x => x.SchuelerId).NotEmpty();
        }
    }
}
