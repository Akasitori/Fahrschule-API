using ErrorOr;
using Fahrschule.Application.Authentication.Commands.Register;
using Fahrschule.Application.Authentication.Common;
using Fahrschule.Application.Authentication.Queries.Login;
using Fahrschule.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Fahrschule.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // Hardcoded Ok -> Returns Request
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestResource request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponseResource>(authResult)),
            errors => Problem(errors)
            );
    }

    // Hardcoded Ok -> Returns Request
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestResource request){

        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
                );
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponseResource>(authResult)),
            errors => Problem(errors)
            );
    }
}