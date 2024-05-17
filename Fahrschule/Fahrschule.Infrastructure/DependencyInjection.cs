using Fahrschule.Application.Common.Interfaces.Authentication;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Application.Common.Interfaces.Services;
using Fahrschule.Infrastructure.Authentication;
using Fahrschule.Infrastructure.Persistence;
using Fahrschule.Infrastructure.Persistence.LehrerData;
using Fahrschule.Infrastructure.Persistence.SchuelerData;
using Fahrschule.Infrastructure.Persistence.TerminData;
using Fahrschule.Infrastructure.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Fahrschule.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance(configuration)
            .AddMappings();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        //User
        services.AddScoped<IUserRepository, UserRepository>();

        //Schueler
        services.AddOptions<CosmosDbOptions>(CosmosDbOptions.Schueler)
            .Bind(configuration.GetSection("Repositories:" + CosmosDbOptions.Schueler))
            .ValidateDataAnnotations();
        services.AddScoped<ISchuelerRepository, SchuelerRepository>();

        //Lehrer
        services.AddOptions<CosmosDbOptions>(CosmosDbOptions.Lehrer)
            .Bind(configuration.GetSection("Repositories:" + CosmosDbOptions.Lehrer))
            .ValidateDataAnnotations();
        services.AddScoped<ILehrerRepository, LehrerRepository>();

        services.AddOptions<CosmosDbOptions>(CosmosDbOptions.Termin)
            .Bind(configuration.GetSection("Repositories:" + CosmosDbOptions.Termin))
            .ValidateDataAnnotations();
        services.AddScoped<ITerminRepository, TerminRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters 
            {
            
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))

            });

        return services;
    }
 
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
    

}