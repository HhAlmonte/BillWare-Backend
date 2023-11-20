using AutoMapper;
using BillWare.Application.Common.Enum;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Contracts.Service;
using BillWare.Application.Contracts.Services;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace BillWare.Application.Features.Billing.Handler
{
    public class UpdateBillingCommandHandler : IRequestHandler<UpdateBillingCommand, BillingResponse>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IBaseCrudRepository<BillingItemEntity> _billingItemRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IEmailService _emailService;
        private readonly IHtmlService _htmlService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBillingCommandHandler> _logger;

        public UpdateBillingCommandHandler(IBillingRepository billingRepository,
                                           IInventoryRepository inventoryRepository,
                                           IBaseCrudRepository<BillingItemEntity> billingItemRepository,
                                           IMapper mapper,
                                           IEmailService emailService,
                                           IHtmlService htmlService,
                                           ILogger<UpdateBillingCommandHandler> logger)
        {
            _htmlService = htmlService;
            _emailService = emailService;
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
            EnsureBillingExists(billingFromDb);

            var updatedBilling = await _billingRepository.UpdateEntityAsync(billing);

            foreach (var item in billing.BillingItems)
            {
                var currentItem = await _billingItemRepository.GetEntityByIdAsync(item.Id);
                await UpdateInventoryAsync(item, currentItem.Quantity);
            }

            if(request.BillingStatus == BillingStatus.Invoiced)
            {
                await SendEmailInvoice(request.InvoiceHtmlContent!);
            }

            return _mapper.Map<BillingResponse>(updatedBilling);
        }

        public async Task SendEmailInvoice(string invoiceHtmlContent)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "Factura.pdf");

            _htmlService.GeneratePdfFromHtml(invoiceHtmlContent, tempPath);

            var attachments = new List<Attachment>
            {
                new Attachment(tempPath)
            };

            await _emailService.SendEmailWithAttachmentsAsync("hbalmontess272@gmail.com",
                                                              "factura",
                                                              "prueba",
                                                              attachments);
        }
        public void EnsureBillingExists(BillingEntity billing)
        {
            if (billing == null)
            {
                _logger.LogError($"{billing.Id} factura no existe en el sistema");
                throw new NotFoundException(nameof(CreateBillingCommand), billing.Id);
            }
        }
        public async Task UpdateInventoryAsync(BillingItemEntity item, int currentQuantity)
        {
            var quantityToAddOrRemove = item.Quantity - currentQuantity;
            var currentInventoryQuantity = await _inventoryRepository.GetCurrentInventoryQuantityByIdAsync(item.Code);

            if (item.Quantity > currentQuantity)
            {
                EnsureInventoryAvailability(currentInventoryQuantity, quantityToAddOrRemove);
                await _inventoryRepository.UpdateInventoryQuantityAsync(item.Code, currentInventoryQuantity - quantityToAddOrRemove);
            }
            else if (item.Quantity < currentQuantity)
            {
                await _inventoryRepository.UpdateInventoryQuantityAsync(item.Code, currentInventoryQuantity + quantityToAddOrRemove);
            }
        }
        public void EnsureInventoryAvailability(int currentInventoryQuantity, int quantityToAddOrRemove)
        {
            if (currentInventoryQuantity < quantityToAddOrRemove)
            {
                throw new Exception("No hay suficiente inventario disponible para agregar la cantidad especificada.");
            }
        }
    }
}
