using AutoMapper;
using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Models;
using BillWare.Application.Billing.Query;
using BillWare.Application.Category.Models;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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


        [HttpPost("CreateBilling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBilling([FromBody] BillingRequest request)
        {
            try
            {
                var billingCreated = await mediator.Send(new CreateBillingCommand(request));

                return Ok(billingCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBillingsPaged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBillings(int pageIndex, int pageSize)
        {
            try
            {
                var billings = await mediator.Send(new GetBillingsPagedQuery(pageIndex, pageSize));

                return Ok(billings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBillingsPagedWithParams")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaginationResult<BillingResponse>>> GetBillingsPagedWithParams([FromQuery]ParamsRequest @params)
        {
            try
            {
                var billings = await _billingRepository.GetBillingsPagedWithParams(@params);

                var billingsResponse = _mapper.Map<PaginationResult<BillingResponse>>(billings);

                return Ok(billingsResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBillingsWithSearchPaged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBillingsWithSearch(string search, int pageIndex, int pageSize)
        {
            try
            {
                var billings = await mediator.Send(new GetBillingsPagedWithSearchQuery(search, pageIndex, pageSize));

                return Ok(billings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBilling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBilling(int id)
        {
            try
            {
                await mediator.Send(new DeleteBillingCommand(id));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBilling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBilling([FromBody] BillingRequest request)
        {
            try
            {
                await mediator.Send(new UpdateBillingCommand(request));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetInvoiceNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInvoiceNumber()
        {
            try
            {
                var invoiceNumber = await _billingRepository.GetInvoiceNumber();

                return Ok(invoiceNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
