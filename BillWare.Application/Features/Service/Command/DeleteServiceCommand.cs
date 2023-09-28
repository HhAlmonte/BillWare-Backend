using MediatR;

namespace BillWare.Application.Features.BillingService.Command
{
    public class DeleteServiceCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteServiceCommand(int id)
        {
            Id = id;
        }
    }
}
