using AutoMapper;
using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Billing.Models;
using BillWare.Application.Interfaces;
using BillWare.Application.Shared;
using BillWare.Application.Shared.Models;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class CreateBillingCommandHandler : IRequestHandler<CreateBillingCommand, BillingModel>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public CreateBillingCommandHandler(IBillingRepository billingRepository, IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<BillingModel> Handle(CreateBillingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var billingToCreate = _mapper.Map<BillingEntity>(request.Billing);

                var billingCreated = await _billingRepository.Create(billingToCreate);

                if (billingCreated == null) throw new CrudOperationException("Hubo un error procesando la factura.");

                if(billingCreated.BillingStatus != BillingStatus.Cancelled)
                {
                    foreach (var product in billingCreated.BillingItems)
                    {
                        var currentQuantity = await _inventoryRepository.GetCurrentQuantity(product.ItemId);

                        var newQuantity = currentQuantity - product.Quantity;

                        await _inventoryRepository.UpdateQuantity(newQuantity, product.ItemId);
                    }
                }

                return _mapper.Map<BillingModel>(billingCreated);
            }
            catch (CrudOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
