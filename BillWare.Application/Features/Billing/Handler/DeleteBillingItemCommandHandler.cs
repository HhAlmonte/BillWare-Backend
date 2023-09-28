using BillWare.Application.Contracts;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Billing.Handler
{
    public class DeleteBillingItemCommandHandler : IRequestHandler<DeleteBillingItemCommand, bool>
    {
        private readonly IBaseCrudRepository<BillingItemEntity> _billingItemRepository;
        private readonly IBillingRepository _billingRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<DeleteBillingItemCommandHandler> _logger;

        public DeleteBillingItemCommandHandler(IBaseCrudRepository<BillingItemEntity> billingItemRepository,
                                               ILogger<DeleteBillingItemCommandHandler> logger,
                                               IInventoryRepository inventoryRepository,
                                               IBillingRepository billingRepository)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
            _billingItemRepository = billingItemRepository;
            _billingRepository = billingRepository;
        }

        public async Task<bool> Handle(DeleteBillingItemCommand request, CancellationToken cancellationToken)
        {
            var billingItemQuantity = await _billingItemRepository.GetEntityByIdAsync(request.Id);

            if (billingItemQuantity == null)
            {
                _logger.LogError($"{request.Id} item de factura no existe en el sistema");
                throw new NotFoundException(nameof(BillingItemEntity), request.Id);
            }

            var inventoryQuantity = await _inventoryRepository.GetCurrentInventoryQuantityByIdAsync(billingItemQuantity.Code);

            var newQuantity = inventoryQuantity += billingItemQuantity.Quantity;

            await _inventoryRepository.UpdateInventoryQuantityAsync(billingItemQuantity.Code, newQuantity);

            var billingItemToDelete = await _billingItemRepository.GetEntityByIdAsync(request.Id);

            if (billingItemToDelete == null)
            {
                _logger.LogError($"{request.Id} item de factura no existe en el sistema");
                throw new NotFoundException(nameof(BillingItemEntity), request.Id);
            }

            var billingItemDeleted = await _billingItemRepository.DeleteEntityByIdAsync(billingItemToDelete);

            return billingItemDeleted;
        }
    }
}
