using BillWare.Application.Billing.Command;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class DeleteBillingCommandHandler : IRequestHandler<DeleteBillingCommand, bool>
    {
        private readonly IBillingRepository _billingRepository;

        public DeleteBillingCommandHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task<bool> Handle(DeleteBillingCommand request, CancellationToken cancellationToken)
        {
            return await _billingRepository.Delete(request.Id);
        }
    }
}
