using AutoMapper;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Models;
using BillWare.Application.Features.Billing.Query;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public BillingController(IMediator mediator, IBillingRepository billingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _billingRepository = billingRepository;
            this.mediator = mediator;
        }


        [Authorize]
        [HttpPost("CreateBilling")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<BillingResponse>> CreateBilling([FromBody] BillingRequest request)
        {
            try
            {
                var content = await mediator.Send(new CreateBillingCommand(request));

                return Ok(content);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetBillingsPaged")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<PaginationResult<BillingResponse>>> GetBillings(int pageIndex, int pageSize)
        {
            try
            {
                var content = await mediator.Send(new GetBillingsPagedQuery(pageIndex, pageSize));

                return Ok(content);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetBillingsPagedWithParams")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<PaginationResult<BillingResponse>>> GetBillingsPagedWithParams([FromQuery] ParamsRequest @params)
        {
            try
            {
                var content = await _billingRepository.GetBillingsPagedWithParams(@params);

                var contentMapped = _mapper.Map<PaginationResult<BillingResponse>>(content);

                return Ok(contentMapped);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetBillingsWithSearchPaged")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<PaginationResult<BillingResponse>>> GetBillingsWithSearch(string search, int pageIndex, int pageSize)
        {
            try
            {
                var content = await mediator.Send(new GetBillingsPagedWithSearchQuery(search, pageIndex, pageSize));

                return Ok(content);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("DeleteBilling")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<bool>> DeleteBilling(int id)
        {
            try
            {
                var response = await mediator.Send(new DeleteBillingCommand(id));

                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPut("UpdateBilling")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<BillingResponse>> UpdateBilling([FromBody] BillingRequest request)
        {
            try
            {
                var content = await mediator.Send(new UpdateBillingCommand(request, request.InvoiceDocument));

                return Ok(content);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetInvoiceNumber")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<int>> GetInvoiceNumber()
        {
            try
            {
                var content = await _billingRepository.GetInvoiceNumber();

                return Ok(content);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
