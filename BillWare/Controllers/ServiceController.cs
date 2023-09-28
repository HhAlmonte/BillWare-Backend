using Azure.Core;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.BillingService.Command;
using BillWare.Application.Features.BillingService.Handler;
using BillWare.Application.Features.BillingService.Models;
using BillWare.Application.Features.Service.Command;
using BillWare.Application.Features.Service.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("Create")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ServiceResponse>> CreateService(CreateServiceCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetListPaged")]
        [ProducesResponseType(typeof(PaginationResult<ServiceResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<ServiceResponse>>> GetServicesPaged(int pageIndex, int pageSize)
        {
            var query = new GetServicesPagedQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetListPagedWithSearch")]
        [ProducesResponseType(typeof(PaginationResult<ServiceResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<ServiceResponse>>> GetServicesPagedWithSearch(int pageIndex, int pageSize, string search)
        {
            var query = new GetServicesPagedWithSearchQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Search = search
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("Update")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ServiceResponse>> UpdateService(UpdateServiceCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteService(int id)
        {
            var response = await _mediator.Send(new DeleteServiceCommand(id));

            return Ok(response);
        }
    }
}
