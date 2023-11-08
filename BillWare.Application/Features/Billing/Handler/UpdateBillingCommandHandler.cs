using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Billing.Handler
{
    public class UpdateBillingCommandHandler : IRequestHandler<UpdateBillingCommand, BillingResponse>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IBaseCrudRepository<BillingItemEntity> _billingItemRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBillingCommandHandler> _logger;

        public UpdateBillingCommandHandler(IBillingRepository billingRepository,
                                           IInventoryRepository inventoryRepository,
                                           IBaseCrudRepository<BillingItemEntity> billingItemRepository,
                                           IMapper mapper,
                                           ILogger<UpdateBillingCommandHandler> logger)
        {
            _logger = logger;
            _billingItemRepository = billingItemRepository;
            _billingRepository = billingRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<BillingResponse> Handle(UpdateBillingCommand request, CancellationToken cancellationToken)
        {
            var billing = _mapper.Map<BillingEntity>(request);

            billing.TotalPrice = billing.BillingItems.Sum(x => x.Price * x.Quantity);

            var billingFromDb = await _billingRepository.GetEntityByIdAsync(billing.Id);

            if (billingFromDb == null)
            {
                _logger.LogError($"{billing.Id} factura no existe en el sistema");
                throw new NotFoundException(nameof(CreateBillingCommand), billing.Id);
            }

            var updatedBilling = await _billingRepository.UpdateEntityAsync(billing);

            foreach (var item in billing.BillingItems)
            {
                var getCurrentItemQuantityInvoice = await _billingItemRepository.GetEntityByIdAsync(item.Id);

                if (item.Quantity != getCurrentItemQuantityInvoice.Quantity)
                {
                    var quantityToAddOrRemove = item.Quantity - getCurrentItemQuantityInvoice.Quantity;

                    if (getCurrentItemQuantityInvoice.Quantity < item.Quantity)
                    {
                        var currentInventoryQuantity = await _inventoryRepository.GetCurrentInventoryQuantityByIdAsync(item.Code);
                        if (currentInventoryQuantity >= quantityToAddOrRemove)
                        {
                            await _inventoryRepository.UpdateInventoryQuantityAsync(item.Code, currentInventoryQuantity - quantityToAddOrRemove);
                        }
                        else
                        {
                            throw new Exception("No hay suficiente inventario disponible para agregar la cantidad especificada.");
                        }
                    }
                    else
                    {
                        var currentInventoryQuantity = await _inventoryRepository.GetCurrentInventoryQuantityByIdAsync(item.Code);
                        await _inventoryRepository.UpdateInventoryQuantityAsync(item.Code, currentInventoryQuantity + quantityToAddOrRemove);
                    }
                }
            }


            return _mapper.Map<BillingResponse>(updatedBilling);
        }
    }
}
