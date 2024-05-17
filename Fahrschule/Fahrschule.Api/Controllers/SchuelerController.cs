using Fahrschule.Application.Lehrers.Commands.UpdateLehrer;
using Fahrschule.Application.Schuelers.Commands.CreateSchueler;
using Fahrschule.Application.Schuelers.Commands.DeleteSchuelerById;
using Fahrschule.Application.Schuelers.Commands.PatchRemoveSchuelerVonLehrerList;
using Fahrschule.Application.Schuelers.Commands.UpdateSchueler;
using Fahrschule.Application.Schuelers.Commands.UpdateSchuelerByAdmin;
using Fahrschule.Application.Schuelers.Queries.GetAllSchueler;
using Fahrschule.Application.Schuelers.Queries.GetAllSchuelerByLehrerId;
using Fahrschule.Application.Schuelers.Queries.GetSchuelerById;
using Fahrschule.Contracts.CommonResources;
using Fahrschule.Contracts.Lehrers.RequestResources;
using Fahrschule.Contracts.Schuelers;
using Fahrschule.Contracts.Schuelers.RequestResources;
using Fahrschule.Contracts.Schuelers.ResponseResources;
using Fahrschule.Contracts.Termine.RequestResources;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fahrschule.Api.Controllers
{
    [Route("schueler")]
    [AllowAnonymous]
    public class SchuelerController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SchuelerController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchuelerAsync()
        {
            var getAllSchuelerResult = await _mediator.Send(new GetAllSchuelerQuery());
            return getAllSchuelerResult.Match(
                schueler => Ok(_mapper.Map<GetSchuelerListResponse>(schueler)),
                errors => Problem(errors));
        }

        [HttpPost("createSchueler")]
        public async Task<IActionResult> CreateSchuelerAsync(CreateSchuelerRequestResource request)
        {
            var command = _mapper.Map<CreateSchuelerCommand>(request);
            var createSchuelerResult = await _mediator.Send(command);

            return createSchuelerResult.Match(
                schueler => Ok(_mapper.Map<SchuelerResource>(schueler)),
                errors => Problem(errors)
                );
        }

        [HttpGet("getAllSchuelerByLehrerId/{lehrerId}")]
        public async Task<IActionResult> GetAllSchuelerByLehrerIdAsync(Guid lehrerId)
        {
            var query = _mapper.Map<GetAllSchuelerByLehrerIdQuery>(lehrerId);
            var getAllSchuelerByLehrerIdResult = await _mediator.Send(query);

            return getAllSchuelerByLehrerIdResult.Match(
            schueler => Ok(_mapper.Map<GetSchuelerListResponse>(schueler)),
            errors => Problem(errors)
            );
        }

        [HttpGet("getSchuelerById/{id}")]
        public async Task<IActionResult> GetSchuelerByIdAsync(Guid id)
        {
            var query = _mapper.Map<GetSchuelerByIdQuery>(id);
            var getAllSchuelerByIdResult = await _mediator.Send(query);

            return getAllSchuelerByIdResult.Match(
            schueler => Ok(_mapper.Map<SchuelerResource>(schueler)),
            errors => Problem(errors)
            );
        }

        [HttpDelete("deleteSchuelerById/{id}")]
        public async Task<IActionResult> DeleteSchuelerByIdAsync(Guid id)
        {
            var command = _mapper.Map<DeleteSchuelerByIdCommand>(id);
            var deleteSchuelerByIdResult = await _mediator.Send(command);

            return deleteSchuelerByIdResult.Match(
            schueler => NoContent(),
            errors => Problem(errors)
            );
        }

        [HttpPatch("removeSchuelerVonLehrerList/{id}")]
        public async Task<IActionResult> RemoveSchuelerVonLehrerListAsync(Guid id)
        {

            var command = new RemoveSchuelerVonLehrerListCommand(id);
            var removeSchuelerVonLehrerListResult = await _mediator.Send(command);

            return removeSchuelerVonLehrerListResult.Match(
                schueler => Ok(_mapper.Map<SchuelerResource>(schueler)),
                errors => Problem(errors)
            );
        }

        [HttpPut("UpdateSchueler")]
        public async Task<IActionResult> UpdateSchuelerAsync(
            [FromBody] UpdateSchuelerRequestResource request
        )
        {
            var command = _mapper.Map<UpdateSchuelerCommand>(request);
            var updateSchuelerResult = await _mediator.Send(command);

            return updateSchuelerResult.Match(
                schueler => Ok(_mapper.Map<SchuelerResource>(schueler)),
                errors => Problem(errors)
            );
        }

        [HttpPut("UpdateSchuelerByAdmin")]
        public async Task<IActionResult> UpdateSchuelerByAdminAsync(
            [FromBody] UpdateSchuelerByAdminRequestResource request
        )
        {
            var command = _mapper.Map<UpdateSchuelerByAdminCommand>(request);
            var updateSchuelerResult = await _mediator.Send(command);

            return updateSchuelerResult.Match(
                schueler => Ok(_mapper.Map<SchuelerResource>(schueler)),
                errors => Problem(errors)
            );
        }

    }
}
