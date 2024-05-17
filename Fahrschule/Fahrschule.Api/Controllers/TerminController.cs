using Fahrschule.Application.Termine.Commands.CreateTermin;
using Fahrschule.Application.Termine.Commands.DeleteTerminById;
using Fahrschule.Application.Termine.Commands.PatchTermin;
using Fahrschule.Application.Termine.Queries.GetTermineByLehrerId;
using Fahrschule.Application.Termine.Queries.GetTermineBySchuelerId;
using Fahrschule.Contracts.Termine.RequestResources;
using Fahrschule.Contracts.Termine.ResponseResources;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fahrschule.Api.Controllers
{
    [Route("termin")]
    [AllowAnonymous]
    public class TerminController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TerminController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //public async Task<IActionResult> GetAllTermine() { } Optional for now

        [HttpPost("createTermin")]
        public async Task<IActionResult> CreateTerminAsync(CreateTerminRequestResource request)
        {
            var command = _mapper.Map<CreateTerminCommand>(request);
            var createTerminResult = await _mediator.Send(command);

            return createTerminResult.Match(
            termin => Ok(_mapper.Map<TerminResponseResource>(termin)),
            errors => Problem(errors)
            );
        }

        [HttpGet("getTermineByLehrerId/{lehrerId}")]
        public async Task<IActionResult> GetTermineByLehrerIdAsync(Guid lehrerId, [FromQuery] DateTime beginn, [FromQuery] DateTime ende)
        {
            var query = new GetTermineByLehrerIdQuery(lehrerId, beginn, ende);
            var termineByIdResult = await _mediator.Send(query);

            return termineByIdResult.Match(
            termin => Ok(_mapper.Map<TerminListResponse>(termin)),
            errors => Problem(errors)
            );
        }

        [HttpGet("getTermineBySchuelerId/{schuelerId}")]
        public async Task<IActionResult> GetTermineBySchuelerIdAsync(Guid schuelerId, [FromQuery] DateTime beginn, [FromQuery] DateTime ende)
        {
            var query = new GetTermineBySchuelerIdQuery(schuelerId, beginn, ende);
            var getAllTerminByIdResult = await _mediator.Send(query);

            return getAllTerminByIdResult.Match(
            termin => Ok(_mapper.Map<TerminListResponse>(termin)),
            errors => Problem(errors)
            );
        }

        [HttpDelete("deleteTerminById/{id}")]
        public async Task<IActionResult> DeleteTerminByIdAsync(Guid id) 
        {
            var command = _mapper.Map<DeleteTerminByIdCommand>(id);
            var deleteTerminByIdResult = await _mediator.Send(command);

            return deleteTerminByIdResult.Match(
                TerminController => NoContent(),
                errors => Problem(errors));
        }

        [HttpPatch("patchTerminStatus")]
        public async Task<IActionResult> PatchTerminStatus(PatchTerminStatusResource request) 
        {

            var command = _mapper.Map<PatchTerminStatusCommand>(request);
            var patchTerminStatusResult = await _mediator.Send(command);

            return patchTerminStatusResult.Match(
                termin => Ok(_mapper.Map<PatchTerminStatusResource>(termin)),
                errors => Problem(errors));
        }

    }
}
