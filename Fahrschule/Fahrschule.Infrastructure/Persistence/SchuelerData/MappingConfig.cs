using Fahrschule.Domain.SchuelerAggregate;
using Fahrschule.Infrastructure.Persistence.SchuelerData.Model;
using Mapster;

namespace Fahrschule.Infrastructure.Persistence.SchuelerData
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //----------Domain -> Infrastructure--------------------------------------

            config.NewConfig<Schueler, SchuelerEntity>()
                .Map(dest => dest, src => src);

            config.ForType<Schueler, SchuelerEntity>()
                .Map(dest => dest.Id, src => src.Id);

            //----------Infrastructure -> Domain--------------------------------------

            config.NewConfig<SchuelerEntity, Schueler>()
                .Map(dest => dest, src => src);

            config.ForType<SchuelerEntity, Schueler>()
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<List<SchuelerEntity>, List<Schueler>>()
                .Map(dest => dest, src => src);

        }
    }
}
