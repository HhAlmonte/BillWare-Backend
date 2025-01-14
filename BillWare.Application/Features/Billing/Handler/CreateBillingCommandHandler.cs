﻿using AutoMapper;
using BillWare.Application.Common.Enum;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Contracts.Service;
using BillWare.Application.Contracts.Services;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace BillWare.Application.Features.Billing.Handler
{
    public class CreateBillingCommandHandler : IRequestHandler<CreateBillingCommand, BillingResponse>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<CreateBillingCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IHtmlService _htmlService;
        private readonly IEmailService _emailService;

        public CreateBillingCommandHandler(IBillingRepository billingRepository,
                                           IInventoryRepository inventoryRepository,
                                           ILogger<CreateBillingCommandHandler> logger,
                                           IHtmlService htmlService,
                                           IEmailService emailService,
                                           IMapper mapper)
        {
            _emailService = emailService;
            _htmlService = htmlService;
            _inventoryRepository = inventoryRepository;
            _billingRepository = billingRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BillingResponse> Handle(CreateBillingCommand request, CancellationToken cancellationToken)
        {
            var billingToCreate = _mapper.Map<BillingEntity>(request);

            billingToCreate.TotalPrice = billingToCreate.BillingItems.Sum(x => x.Price * x.Quantity);

            var billingCreated = await _billingRepository.CreateEntityAsync(billingToCreate);

            _logger.LogInformation($"Se ha creado la entidad Factura con Id: {billingCreated.Id}");

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
    }
}
