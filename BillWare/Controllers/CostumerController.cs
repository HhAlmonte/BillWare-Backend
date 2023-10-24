using BillWare.Application.Features.Costumer.Command;
using BillWare.Application.Features.Costumer.Models;
using BillWare.Application.Features.Costumer.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CostumerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CostumerResponse>> GetCostumerById(int id)
        {
            var query = new GetCostumerByIdQuery(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetListPagedWithSearch")]
        [ProducesResponseType(typeof(PaginationResult<CostumerResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<CostumerResponse>>> GetCostumersPagedWithSearch(string search, int pageIndex, int pageSize)
        {
            var query = new GetCostumersPagedWithSearchQuery
            {
                Search = search,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetListPaged")]
        [ProducesResponseType(typeof(PaginationResult<CostumerResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<CostumerResponse>>> GetCostumersPaged(int pageIndex, int pageSize)
        {
            var query = new GetCostumersPagedQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize]
        [HttpPost("Create")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CostumerResponse>> CreateCostumer(CreateCostumerCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("Update")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CostumerResponse>> UpdateCostumer(UpdateCostumerCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteCostumer(int id)
        {
            var response = await _mediator.Send(new DeleteCostumerCommand(id));

            return Ok(response);
        }
    }
}
