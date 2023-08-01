using MediatR;

namespace BillWare.Application.Vehicle.Command
{
    public class DeleteVehicleCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteVehicleCommand(int id)
        {
            Id = id;
        }
    }
}
