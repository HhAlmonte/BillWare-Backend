using AutoMapper;
using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Billing.Models;
using BillWare.Application.Common.Enum;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class CreateBillingCommandHandler : IRequestHandler<CreateBillingCommand, BillingResponse>
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

        public async Task<BillingResponse> Handle(CreateBillingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var billingToCreate = _mapper.Map<BillingEntity>(request.Request);

                billingToCreate.TotalPrice = billingToCreate.BillingItems.Sum(x => x.Price * x.Quantity);

                var billingCreated = await _billingRepository.CreateEntityAsync(billingToCreate);

                if (billingCreated == null) throw new CrudOperationException("Hubo un error procesando la factura.");

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
            catch (CrudOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
