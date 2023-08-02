using AutoMapper;
using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Billing.Models;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class UpdateBillingCommandHandler : IRequestHandler<UpdateBillingCommand, BillingModel>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public UpdateBillingCommandHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<BillingModel> Handle(UpdateBillingCommand request, CancellationToken cancellationToken)
        {
            var billing = _mapper.Map<BillingEntity>(request.Billing);
            var updatedBilling = await _billingRepository.Update(billing);
            return _mapper.Map<BillingModel>(updatedBilling);
        }
    }
}
