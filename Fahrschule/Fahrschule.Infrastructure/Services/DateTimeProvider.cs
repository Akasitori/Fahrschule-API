using Fahrschule.Application.Common.Interfaces.Services;

namespace Fahrschule.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
