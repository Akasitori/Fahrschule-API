using Fahrschule.Application.Lehrers.Commands.CreateLehrer;
using Fahrschule.Application.Lehrers.Commands.DeleteLehrer;
using Fahrschule.Application.Lehrers.Commands.UpdateLehrer;
using Fahrschule.Application.Lehrers.Commands.UpdateLehrerByAdmin;
using Fahrschule.Application.Lehrers.Queries.GetAllLehrer;
using Fahrschule.Application.Lehrers.Queries.GetLehrerById;
using Fahrschule.Contracts.Lehrers;
using Fahrschule.Contracts.Lehrers.RequestResources;
using Fahrschule.Contracts.Lehrers.ResponseResources;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fahrschule.Api.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class LehrerController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LehrerController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLehrerAsync()
        {
            var getAllLehrerResult = await _mediator.Send(new GetAllLehrerQuery());
            return getAllLehrerResult.Match(
                lehrer => Ok(_mapper.Map<GetAllLehrerResponseResource>(lehrer)),
                errors => Problem(errors)
            );
        }
        
        [HttpGet("GetLehrerById/{id}")]
        public async Task<IActionResult> GetLehrerByIdAsync(Guid id)
        {
            var getLehrerByIdResult = await _mediator.Send(new GetLehrerByIdQuery(id));
            return getLehrerByIdResult.Match(
                lehrer => Ok(_mapper.Map<LehrerResource>(lehrer)),
                errors => Problem(errors)
            );
        }
        
        [HttpPost("CreateLehrer")]
        public async Task<IActionResult> CreateLehrerAsync(CreateLehrerRequestResource request)
        {
            var command = _mapper.Map<CreateLehrerCommand>(request);
            var createLehrerResult = await _mediator.Send(command);

            return createLehrerResult.Match(
                lehrer => Ok(_mapper.Map<LehrerResource>(lehrer)),
                errors => Problem(errors)
            );
        }

        [HttpPut("UpdateLehrer")]
        public async Task<IActionResult> UpdateLehrerAsync(
            [FromBody] UpdateLehrerRequestResource request
        )
        {
            var command = _mapper.Map<UpdateLehrerCommand>(request);
            var updateLehrerResult = await _mediator.Send(command);

            return updateLehrerResult.Match(
                lehrer => Ok(_mapper.Map<LehrerResource>(lehrer)),
                errors => Problem(errors)
            );
        }

        [HttpPut("UpdateByAdminLehrer")]
        public async Task<IActionResult> UpdateLehrerByAdminAsync(
            [FromBody] UpdateLehrerByAdminRequestResource request
        )
        {
            var command = _mapper.Map<UpdateLehrerByAdminCommand>(request);
            var updateLehrerResult = await _mediator.Send(command);

            return updateLehrerResult.Match(
                lehrer => Ok(_mapper.Map<LehrerResource>(lehrer)),
                errors => Problem(errors)
            );
        }


        [HttpDelete("DeleteLehrerById/{id}")]
        public async Task<IActionResult> DeleteLeherByIdAsync(Guid id)
        {
            var command = _mapper.Map<DeleteLehrerByIdCommand>(id);
            var deleteLehrerByIdResult = await _mediator.Send(command);

            return deleteLehrerByIdResult.Match(
                lehrer => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
