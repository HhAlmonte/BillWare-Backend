using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Interfaces;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class DeleteBillingItemCommandHandler : IRequestHandler<DeleteBillingItemCommand, bool>
    {
        private readonly IBaseCrudRepository<BillingItem> _billingItemRepository;
        private readonly IBillingRepository _billingRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public DeleteBillingItemCommandHandler(IBaseCrudRepository<BillingItem> billingItemRepository
                                               ,IInventoryRepository inventoryRepository,
                                                IBillingRepository billingRepository)
        {
            _inventoryRepository = inventoryRepository;
            _billingItemRepository = billingItemRepository;
            _billingRepository = billingRepository;
        }
       
        public async Task<bool> Handle(DeleteBillingItemCommand request, CancellationToken cancellationToken)
        {
            var billingItemQuantity = await _billingItemRepository.Get(request.Id);

            var inventoryQuantity = await _inventoryRepository.GetCurrentQuantity(billingItemQuantity.ItemId);

            var newQuantity = inventoryQuantity += billingItemQuantity.Quantity;

            await _inventoryRepository.UpdateQuantity(billingItemQuantity.ItemId, newQuantity);

            var billingDeleted = await _billingItemRepository.Delete(request.Id);

            return billingDeleted;
        }
    }
}
