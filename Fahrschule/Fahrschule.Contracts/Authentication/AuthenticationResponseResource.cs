namespace Fahrschule.Contracts.Authentication;

public record AuthenticationResponseResource(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);