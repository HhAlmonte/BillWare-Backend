using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class DeleteCostumerCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCostumerCommand(int id)
        {
            Id = id;
        }
    }
}
