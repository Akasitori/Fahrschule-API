namespace Fahrschule.Contracts.Authentication;

public record LoginRequestResource(
    string Email,
    string Password
);