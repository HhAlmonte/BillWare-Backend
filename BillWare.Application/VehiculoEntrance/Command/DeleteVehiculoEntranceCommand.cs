using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class DeleteVehiculoEntranceCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteVehiculoEntranceCommand(int id)
        {
            Id = id;
        }
    }
}
