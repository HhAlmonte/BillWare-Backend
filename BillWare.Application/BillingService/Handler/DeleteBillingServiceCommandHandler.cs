using AutoMapper;
using BillWare.Application.BillingService.Command;
using BillWare.Application.BillingService.Entities;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.BillingService.Handler
{
    public class DeleteBillingServiceCommandHandler : IRequestHandler<DeleteBillingServiceCommand, bool>
    {
        private readonly IBaseCrudRepository<BillingServiceEntity> _billingServiceRepository;

        public DeleteBillingServiceCommandHandler(IBaseCrudRepository<BillingServiceEntity> billingServiceRepository)
        {
            _billingServiceRepository = billingServiceRepository;
        }

        public async Task<bool> Handle(DeleteBillingServiceCommand request, CancellationToken cancellationToken)
        {
            return await _billingServiceRepository.DeleteEntityByIdAsync(request.Id);
        }
    }
}
