using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class DeleteVehicleEntranceCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteVehicleEntranceCommand(int id)
        {
            Id = id;
        }
    }
}
