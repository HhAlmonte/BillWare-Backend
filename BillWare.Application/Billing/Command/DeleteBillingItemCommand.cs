using MediatR;

namespace BillWare.Application.Billing.Command
{
    public class DeleteBillingItemCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteBillingItemCommand(int id)
        {
            Id = id;
        }
    }
}
