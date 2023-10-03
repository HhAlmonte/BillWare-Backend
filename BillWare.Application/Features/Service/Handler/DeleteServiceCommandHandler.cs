using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.BillingService.Command;
using BillWare.Application.Features.BillingService.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.BillingService.Handler
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly IBaseCrudRepository<ServiceEntity> _billingServiceRepository;
        private readonly ILogger<DeleteServiceCommandHandler> _logger;

        public DeleteServiceCommandHandler(IBaseCrudRepository<ServiceEntity> billingServiceRepository,
                                           ILogger<DeleteServiceCommandHandler> logger)
        {
            _logger = logger;
            _billingServiceRepository = billingServiceRepository;
        }

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToDelete = await _billingServiceRepository.GetEntityByIdAsync(request.Id);

            if (serviceToDelete == null)
            {
                _logger.LogError($"{request.Id}, no se encuentra en el sistema.");
                throw new NotFoundException(nameof(ServiceEntity), request.Id);
            }

            var serviceDeleted = await _billingServiceRepository.DeleteEntityByIdAsync(serviceToDelete);
            _logger.LogInformation($"{serviceToDelete.Id}, eliminado correctamente.");

            return serviceDeleted;
        }
    }
}
