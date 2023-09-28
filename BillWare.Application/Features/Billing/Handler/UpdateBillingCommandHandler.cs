using AutoMapper;
using BillWare.Application.Common.Enum;
using BillWare.Application.Contracts;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Billing.Handler
{
    public class UpdateBillingCommandHandler : IRequestHandler<UpdateBillingCommand, BillingResponse>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IBaseCrudRepository<BillingItemEntity> _billingItemRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IEmailServices _emailServices;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBillingCommandHandler> _logger;

        public UpdateBillingCommandHandler(IBillingRepository billingRepository,
                                           IInventoryRepository inventoryRepository,
                                           IBaseCrudRepository<BillingItemEntity> billingItemRepository,
                                           IMapper mapper,
                                           ILogger<UpdateBillingCommandHandler> logger,
                                           IEmailServices emailServices)
        {
            _logger = logger;
            _billingItemRepository = billingItemRepository;
            _billingRepository = billingRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _emailServices = emailServices;
        }

        public async Task<BillingResponse> Handle(UpdateBillingCommand request, CancellationToken cancellationToken)
        {
            var billing = _mapper.Map<BillingEntity>(request);

            billing.TotalPrice = billing.BillingItems.Sum(x => x.Price * x.Quantity);

            var billingFromDb = await _billingRepository.GetEntityByIdAsync(billing.Id);

            if (billingFromDb == null)
            {
                _logger.LogError($"{billing.Id} factura no existe en el sistema");
                throw new NotFoundException(nameof(BillingRequest), billing.Id);
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

            if (request.BillingStatus == BillingStatus.Invoiced)
            {
                var emailResponse = await _emailServices.SendEmailAsync("hbalmontess272@gmail.com", "Factura", "Su factura ha sido generada.");

                if (!emailResponse)
                {
                    throw new Exception("No se pudo enviar el correo electrónico. Imprime la factura y entregasela al cliente!");
                }
            }

            return _mapper.Map<BillingResponse>(updatedBilling);
        }
    }
}
