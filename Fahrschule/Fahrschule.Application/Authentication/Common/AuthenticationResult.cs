using Fahrschule.Domain.UserAggregate.Entities;

namespace Fahrschule.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);