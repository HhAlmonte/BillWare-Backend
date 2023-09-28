using AutoMapper;
using BillWare.Application.Common.Enum;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Billing.Handler
{
    public class CreateBillingCommandHandler : IRequestHandler<CreateBillingCommand, BillingResponse>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<CreateBillingCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateBillingCommandHandler(IBillingRepository billingRepository,
                                           IInventoryRepository inventoryRepository, 
                                           ILogger<CreateBillingCommandHandler> logger,
                                           IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _billingRepository = billingRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BillingResponse> Handle(CreateBillingCommand request, CancellationToken cancellationToken)
        {
            var billingToCreate = _mapper.Map<BillingEntity>(request.Request);

            billingToCreate.TotalPrice = billingToCreate.BillingItems.Sum(x => x.Price * x.Quantity);

            var billingCreated = await _billingRepository.CreateEntityAsync(billingToCreate);

            _logger.LogInformation($"Se ha creado la entidad Factura con Id: {billingCreated.Id}"); 

            if (billingCreated.BillingStatus != BillingStatus.Cancelled)
            {
                foreach (var product in billingCreated.BillingItems)
                {
                    var currentQuantity = await _inventoryRepository.GetCurrentInventoryQuantityByIdAsync(product.Code);

                    var newQuantity = currentQuantity - product.Quantity;

                    await _inventoryRepository.UpdateInventoryQuantityAsync(product.Code, newQuantity);
                }
            }

            return _mapper.Map<BillingResponse>(billingCreated);
        }
    }
}
