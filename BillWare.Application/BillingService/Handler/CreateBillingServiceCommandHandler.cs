using AutoMapper;
using BillWare.Application.BillingService.Command;
using BillWare.Application.BillingService.Entities;
using BillWare.Application.BillingService.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.BillingService.Handler
{
    public class CreateBillingServiceCommandHandler : IRequestHandler<CreateBillingServiceCommand, BillingServiceResponse>
    {
        private readonly IBaseCrudRepository<BillingServiceEntity> _billingServiceRepository;
        private readonly IMapper _mapper;

        public CreateBillingServiceCommandHandler(IBaseCrudRepository<BillingServiceEntity> billingServiceRepository, IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _mapper = mapper;
        }

        public async Task<BillingServiceResponse> Handle(CreateBillingServiceCommand request, CancellationToken cancellationToken)
        {
            var billingServiceEntity = _mapper.Map<BillingServiceEntity>(request.Request);

            var billingService = await _billingServiceRepository.CreateEntityAsync(billingServiceEntity);

            var billingServiceResponse = _mapper.Map<BillingServiceResponse>(billingService);

            return billingServiceResponse;
        }
    }
}
