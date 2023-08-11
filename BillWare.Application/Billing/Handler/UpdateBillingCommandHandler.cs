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
        private readonly IBaseCrudRepository<BillingItemEntity> _billingItemRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public UpdateBillingCommandHandler(IBillingRepository billingRepository, 
                                           IInventoryRepository inventoryRepository,
                                           IBaseCrudRepository<BillingItemEntity> billingItemRepository,
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

            billing.TotalPrice = billing.BillingItems.Sum(x => x.Price * x.Quantity);

            var updatedBilling = await _billingRepository.Update(billing);

            foreach (var item in billing.BillingItems)
            {
                var getCurrentItemQuantityInvoice = await _billingItemRepository.Get(item.Id);

                if (item.Quantity != getCurrentItemQuantityInvoice.Quantity)
                {
                    var quantityToAddOrRemove = item.Quantity - getCurrentItemQuantityInvoice.Quantity;

                    if (getCurrentItemQuantityInvoice.Quantity < item.Quantity)
                    {
                        var currentInventoryQuantity = await _inventoryRepository.GetCurrentQuantity(item.Code);
                        if (currentInventoryQuantity >= quantityToAddOrRemove)
                        {
                            await _inventoryRepository.UpdateQuantity(item.Code, currentInventoryQuantity - quantityToAddOrRemove);
                        }
                        else
                        {
                            throw new Exception("No hay suficiente inventario disponible para agregar la cantidad especificada.");
                        }
                    }
                    else
                    {
                        var currentInventoryQuantity = await _inventoryRepository.GetCurrentQuantity(item.Code);
                        await _inventoryRepository.UpdateQuantity(item.Code, currentInventoryQuantity + quantityToAddOrRemove);
                    }
                }
            }

            return _mapper.Map<BillingModel>(updatedBilling);
        }

    }
}
