using Fahrschule.Domain.UserAggregate.Entities;

namespace Fahrschule.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
