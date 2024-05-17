namespace Fahrschule.Contracts.Authentication;

public record RegisterRequestResource(
    string FirstName,
    string LastName,
    string Email,
    string Password
);