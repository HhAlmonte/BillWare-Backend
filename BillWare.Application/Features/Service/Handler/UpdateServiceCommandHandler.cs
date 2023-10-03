using AutoMapper;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Service.Command;
using BillWare.Application.Features.BillingService.Entities;
using BillWare.Application.Features.BillingService.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using BillWare.Application.Contracts.Persistence;

namespace BillWare.Application.Features.BillingService.Handler
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ServiceResponse>
    {
        private readonly IBaseCrudRepository<ServiceEntity> _billingServiceRepository;
        private readonly ILogger<UpdateServiceCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IBaseCrudRepository<ServiceEntity> billingServiceRepository, 
                                           ILogger<UpdateServiceCommandHandler> logger,
                                           IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToUpdate = _mapper.Map<ServiceEntity>(request);

            var serviceFromDb = await _billingServiceRepository.GetEntityByIdAsync(serviceToUpdate.Id);

            if(serviceFromDb == null)
            {
                _logger.LogError($"Servicio con id: {serviceToUpdate.Id} no existe");
                throw new NotFoundException(nameof(ServiceEntity), request.Id);
            }

            var serviceUpdated = await _billingServiceRepository.UpdateEntityAsync(serviceToUpdate);

            var serviceUpdatedMapped = _mapper.Map<ServiceResponse>(serviceUpdated);

            return serviceUpdatedMapped;
        }
    }
}
