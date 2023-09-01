using MediatR;

namespace BillWare.Application.BillingService.Command
{
    public class DeleteBillingServiceCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteBillingServiceCommand(int id)
        {
            Id = id;
        }
    }
}
