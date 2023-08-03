using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class DeleteBillingItemCommandHandler : IRequestHandler<DeleteBillingItemCommand, bool>
    {
        private readonly IBaseCrudRepository<BillingItem> _billingItemRepository;

        public DeleteBillingItemCommandHandler(IBaseCrudRepository<BillingItem> billingItemRepository)
        {
            _billingItemRepository = billingItemRepository;
        }

        public async Task<bool> Handle(DeleteBillingItemCommand request, CancellationToken cancellationToken)
        {
            return await _billingItemRepository.Delete(request.Id);
        }
    }
}
