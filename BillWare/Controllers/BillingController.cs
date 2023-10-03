using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Models;
using BillWare.Application.Features.Billing.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public BillingController(IMediator mediator, IBillingRepository billingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _billingRepository = billingRepository;
            _mediator = mediator;
        }


        [Authorize]
        [HttpPost("Create")]
        [ProducesResponseType(typeof(BillingResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BillingResponse>> CreateBilling(CreateBillingCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetListPaged")]
        [ProducesResponseType(typeof(PaginationResult<BillingResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<BillingResponse>>> GetBillings(int pageIndex, int pageSize)
        {
            var response = await _mediator.Send(new GetBillingsPagedQuery(pageIndex, pageSize));

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetListPagedWithParams")]
        [ProducesResponseType(typeof(PaginationResult<BillingResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<BillingResponse>>> GetBillingsPagedWithParams([FromQuery] ParamsRequest @params)
        {
            var content = await _billingRepository.GetBillingsPagedWithParams(@params);

            var contentMapped = _mapper.Map<PaginationResult<BillingResponse>>(content);

            return Ok(contentMapped);
        }

        [Authorize]
        [HttpGet("GetListPagedWithSearch")]
        [ProducesResponseType(typeof(PaginationResult<BillingResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<BillingResponse>>> GetBillingsWithSearch(string search, int pageIndex, int pageSize)
        {
            var response = await _mediator.Send(new GetBillingsPagedWithSearchQuery(search, pageIndex, pageSize));

            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteBilling(int id)
        {
            var response = await _mediator.Send(new DeleteBillingCommand(id));

            return Ok(response);
        }

        [Authorize]
        [HttpPut("Update")]
        [ProducesResponseType(typeof(BillingResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BillingResponse>> UpdateBilling(UpdateBillingCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetInvoiceNumber")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> GetInvoiceNumber()
        {
            var response = await _billingRepository.GetInvoiceNumber();

            return Ok(response);
        }
    }
}
