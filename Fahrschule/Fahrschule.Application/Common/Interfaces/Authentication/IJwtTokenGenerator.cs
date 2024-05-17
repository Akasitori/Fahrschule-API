using Fahrschule.Domain.UserAggregate.Entities;

namespace Fahrschule.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
