using BillWare.Application.Billing.Command;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class DeleteBillingCommandHandler : IRequestHandler<DeleteBillingCommand, bool>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public DeleteBillingCommandHandler(IBillingRepository billingRepository, IInventoryRepository inventoryRepository)
        {
            _billingRepository = billingRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<bool> Handle(DeleteBillingCommand request, CancellationToken cancellationToken)
        {
            var billingDeleted = await _billingRepository.Delete(request.Id);

            if(billingDeleted)
            {
                var billing = await _billingRepository.Get(request.Id);

                foreach (var item in billing.BillingItems) 
                {
                    var inventory = await _inventoryRepository.GetCurrentQuantity(item.ItemId);
                    var newQuantity = inventory += item.Quantity;
                    await _inventoryRepository.UpdateQuantity(item.ItemId ,newQuantity);
                }
            }

            return billingDeleted;
        }
    }
}
