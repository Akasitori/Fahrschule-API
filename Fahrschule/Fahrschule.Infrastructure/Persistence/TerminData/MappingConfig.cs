using Fahrschule.Domain.TerminAggregate;
using Fahrschule.Infrastructure.Persistence.TerminData.Model;
using Mapster;

namespace Fahrschule.Infrastructure.Persistence.TerminData
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Termin, TerminEntity>()
                 .Map(dest => dest, src => src);

            config.NewConfig<TerminEntity, Termin>()
                 .Map(dest => dest, src => src);



        }
    }
}
