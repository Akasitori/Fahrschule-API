using Fahrschule.Application.Schuelers.Commands.CreateSchueler;
using Fahrschule.Application.Schuelers.Commands.DeleteSchuelerById;
using Fahrschule.Application.Schuelers.Queries.GetAllSchuelerByLehrerId;
using Fahrschule.Application.Schuelers.Queries.GetSchuelerById;
using Fahrschule.Contracts.CommonResources;
using Fahrschule.Contracts.Schuelers;
using Fahrschule.Contracts.Schuelers.RequestResources;
using Fahrschule.Contracts.Schuelers.ResponseResources;
using Fahrschule.Domain.SchuelerAggregate;
using Mapster;

namespace Fahrschule.Api.Common.Mapping
{
    public class SchuelerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            // CreateSchueler ( Resource -> Command )
            //                   Source                  Destination
            config.NewConfig<CreateSchuelerRequestResource, CreateSchuelerCommand>()
            .Map(dest => dest, src => src);


            // DeleteSchueler ( Guid -> Command )

            config.NewConfig<Guid,DeleteSchuelerByIdCommand>()
                .Map(dest => dest.Id, src => src);

            //-----------------------------------------------------------------------


            // DomainEntity -> Response Resource
            config.NewConfig<Schueler, SchuelerResource>()
                .Map(dest => dest.Id, src => src.Id);


            //config.NewConfig<Adresse, AdresseResponse>();
            //config.NewConfig<Kontaktdaten, KontaktdatenResponse>();



            config.NewConfig<List<Schueler>, GetSchuelerListResponse>()
                .Map(dest => dest.Value, src => src);

            //----------------------------------------------------------------

            // GetAllSchuelerByLehrerId ( Resource -> Query )
            config.NewConfig<Guid, GetAllSchuelerByLehrerIdQuery>()
                .Map(dest => dest.LehrerId, src => src);



            // GetSchuelerById ( Guid -> Query )
            config.NewConfig<Guid, GetSchuelerByIdQuery>()
                .Map(dest => dest.Id, src => src);

        }
    }
}
