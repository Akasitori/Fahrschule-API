using Fahrschule.Api.Common.Errors;
using Fahrschule.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Fahrschule.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, FahrschuleProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}
