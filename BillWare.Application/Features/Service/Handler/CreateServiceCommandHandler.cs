using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.BillingService.Command;
using BillWare.Application.Features.BillingService.Entities;
using BillWare.Application.Features.BillingService.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.BillingService.Handler
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ServiceResponse>
    {
        private readonly IBaseCrudRepository<ServiceEntity> _billingServiceRepository;
        private readonly ILogger<CreateServiceCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateServiceCommandHandler(IBaseCrudRepository<ServiceEntity> billingServiceRepository, 
                                           ILogger<CreateServiceCommandHandler> logger,
                                           IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToCreate = _mapper.Map<ServiceEntity>(request);

            var serviceCreated = await _billingServiceRepository.CreateEntityAsync(serviceToCreate);

            _logger.LogInformation($"Se ha creado la entidad Servicio con Id: {serviceCreated.Id}");

            var serviceMapped = _mapper.Map<ServiceResponse>(serviceCreated);

            return serviceMapped;
        }
    }
}
