using ErrorOr;
using Fahrschule.Application.Authentication.Common;
using MediatR;

namespace Fahrschule.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
