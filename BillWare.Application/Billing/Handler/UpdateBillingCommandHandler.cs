using AutoMapper;
using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Billing.Models;
using BillWare.Application.Interfaces;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class UpdateBillingCommandHandler : IRequestHandler<UpdateBillingCommand, BillingModel>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IBaseCrudRepository<BillingItem> _billingItemRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public UpdateBillingCommandHandler(IBillingRepository billingRepository, 
                                           IInventoryRepository inventoryRepository,
                                           IBaseCrudRepository<BillingItem> billingItemRepository,
                                           IMapper mapper)
        {
            _billingItemRepository = billingItemRepository;
            _billingRepository = billingRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<BillingModel> Handle(UpdateBillingCommand request, CancellationToken cancellationToken)
        {
            var billing = _mapper.Map<BillingEntity>(request.Billing);

            foreach (var item in billing.BillingItems)
            {
                var getCurrentItemQuantityInvoice = await _billingItemRepository.Get(item.Id);

                if (item.Quantity != getCurrentItemQuantityInvoice.Quantity)
                {
                    if (getCurrentItemQuantityInvoice.Quantity < item.Quantity)
                    {
                        var currentInventoryQuantity = await _inventoryRepository.GetCurrentQuantity(item.ItemId);

                        var newQuantity = currentInventoryQuantity - (item.Quantity - getCurrentItemQuantityInvoice.Quantity);

                        await _inventoryRepository.UpdateQuantity(item.ItemId, newQuantity);
                    }
                    else
                    {
                        var currentInventoryQuantity = await _inventoryRepository.GetCurrentQuantity(item.ItemId);

                        var newQuantity = currentInventoryQuantity + (getCurrentItemQuantityInvoice.Quantity - item.Quantity);

                        await _inventoryRepository.UpdateQuantity(item.ItemId, newQuantity);
                    }
                }
            }

            var updatedBilling = await _billingRepository.Update(billing);

            return _mapper.Map<BillingModel>(updatedBilling);
        }
    }
}
