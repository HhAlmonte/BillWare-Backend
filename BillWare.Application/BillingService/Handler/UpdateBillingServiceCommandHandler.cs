using AutoMapper;
using BillWare.Application.BillingService.Command;
using BillWare.Application.BillingService.Entities;
using BillWare.Application.BillingService.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.BillingService.Handler
{
    public class UpdateBillingServiceCommandHandler : IRequestHandler<UpdateBillingServiceCommand, BillingServiceResponse>
    {
        private readonly IBaseCrudRepository<BillingServiceEntity> _billingServiceRepository;
        private readonly IMapper _mapper;

        public UpdateBillingServiceCommandHandler(IBaseCrudRepository<BillingServiceEntity> billingServiceRepository, IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _mapper = mapper;
        }

        public async Task<BillingServiceResponse> Handle(UpdateBillingServiceCommand request, CancellationToken cancellationToken)
        {
            var billingServiceEntity = _mapper.Map<BillingServiceEntity>(request.Request);

            var billingService = await _billingServiceRepository.UpdateEntityAsync(billingServiceEntity);

            var billingServiceResponse = _mapper.Map<BillingServiceResponse>(billingService);

            return billingServiceResponse;
        }
    }
}
