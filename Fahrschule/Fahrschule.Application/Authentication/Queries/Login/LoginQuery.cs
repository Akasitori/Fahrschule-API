using ErrorOr;
using Fahrschule.Application.Authentication.Common;
using MediatR;

namespace Fahrschule.Application.Authentication.Queries.Login
{
    public record LoginQuery(
         string Email,
         string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
