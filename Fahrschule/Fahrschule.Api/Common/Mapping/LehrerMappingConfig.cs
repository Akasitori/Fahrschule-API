using Fahrschule.Application.Lehrers.Commands.CreateLehrer;
using Fahrschule.Application.Lehrers.Commands.DeleteLehrer;
using Fahrschule.Application.Schuelers.Commands.DeleteSchuelerById;
using Fahrschule.Application.Schuelers.Common.Records;
using Fahrschule.Contracts.Lehrers;
using Fahrschule.Contracts.Lehrers.RequestResources;
using Fahrschule.Contracts.Lehrers.ResponseResources;
using Fahrschule.Domain.LehrerAggregate;
using Mapster;

namespace Fahrschule.Api.Common.Mapping
{
    public class LehrerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //Resource -> Command
            config.NewConfig<CreateLehrerRequestResource, CreateLehrerCommand>()
                .Map(dest => dest, src => src);

            // DomainEntity -> ResponseResource
            config.NewConfig<Lehrer, LehrerResource>()
                .Map(dest => dest, src => src);

            /**********************************************************************/

            //Get All lehrer
            config.NewConfig<List<Lehrer>, GetAllLehrerResponseResource>()
                .Map(dest => dest.Value, src => src);

            /**********************************************************************/

            // DeleteLehrer ( Guid -> Command )
            config.NewConfig<Guid, DeleteLehrerByIdCommand>()
                .Map(dest => dest.Id, src => src);
        }
    }
}
