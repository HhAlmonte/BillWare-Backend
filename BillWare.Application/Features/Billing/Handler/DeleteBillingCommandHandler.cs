using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Models;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Billing.Handler
{
    public class DeleteBillingCommandHandler : IRequestHandler<DeleteBillingCommand, bool>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<DeleteBillingCommandHandler> _logger;

        public DeleteBillingCommandHandler(IBillingRepository billingRepository,
                                           IInventoryRepository inventoryRepository,
                                           ILogger<DeleteBillingCommandHandler> logger)
        {
            _logger = logger;
            _billingRepository = billingRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<bool> Handle(DeleteBillingCommand request, CancellationToken cancellationToken)
        {
            var billing = await _billingRepository.GetBillingById(request.Id);

            if (billing == null)
            {
                _logger.LogError($"{request.Id} factura no existe en el sistema");
                throw new NotFoundException(nameof(BillingRequest), request.Id);
            }
            else
            {
                foreach (var item in billing.BillingItems)
                {
                    var inventory = await _inventoryRepository.GetCurrentInventoryQuantityByIdAsync(item.Code);
                    var newQuantity = inventory += item.Quantity;
                    await _inventoryRepository.UpdateInventoryQuantityAsync(item.Code, newQuantity);
                }
            }

            var billingDeleted = await _billingRepository.DeleteEntityByIdAsync(billing);

            return billingDeleted;
        }
    }
}
