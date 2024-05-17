using Fahrschule.Application.Termine.Commands.CreateTermin;
using Fahrschule.Application.Termine.Commands.DeleteTerminById;
using Fahrschule.Application.Termine.Common;
using Fahrschule.Application.Termine.Queries.GetTermineByLehrerId;
using Fahrschule.Application.Termine.Queries.GetTermineBySchuelerId;
using Fahrschule.Contracts.Termine.CommonResources;
using Fahrschule.Contracts.Termine.RequestResources;
using Fahrschule.Contracts.Termine.ResponseResources;
using Fahrschule.Domain.TerminAggregate;
using Mapster;

namespace Fahrschule.Api.Common.Mapping
{
    public class TerminMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<CreateTerminRequestResource, TerminRequestResource>()
                .Map(dest => dest, src => src);

            config.NewConfig<CreateTerminRequestResource, CreateTerminCommand>()
                .Map(dest => dest, src => src);

            //config.NewConfig<TerminRequestResource, CreateTerminCommand>()
            //    .Map(dest => dest, src => src);

            config.NewConfig<UebungsTypResource, UebungsTyp>()
                .Map(dest => dest, src => src);

            config.NewConfig<TerminStatusResource, TerminStatus>()
                .Map(dest => dest, src => src);

            config.NewConfig<Guid, GetTermineBySchuelerIdQuery>()
                .Map(dest => dest.SchuelerId, src => src);

            config.NewConfig<Guid, DeleteTerminByIdCommand>()
                .Map(dest => dest.Id, src => src);

            config.NewConfig<List<Termin>, TerminListResponse>()
                .Map(dest => dest.Value, src => src);
        }
    }
}
