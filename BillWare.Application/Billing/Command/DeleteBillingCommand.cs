using MediatR;

namespace BillWare.Application.Billing.Command
{
    public class DeleteBillingCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteBillingCommand(int id)
        {
            Id = id;
        }
    }
}
