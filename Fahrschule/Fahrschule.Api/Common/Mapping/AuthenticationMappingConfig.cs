using Fahrschule.Application.Authentication.Commands.Register;
using Fahrschule.Application.Authentication.Common;
using Fahrschule.Application.Authentication.Queries.Login;
using Fahrschule.Contracts.Authentication;
using Mapster;

namespace Fahrschule.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequestResource, RegisterCommand>();
            config.NewConfig<LoginRequestResource, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponseResource>()
                .Map(dest => dest, src => src.User);
        }
    }
}
