using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class UpdateVehicleEntranceCommand : IRequest<VehiculoEntranceVM>
    {
        public VehiculoEntranceCommandModel CostumerUpdate { get; set; }

        public UpdateVehicleEntranceCommand(VehiculoEntranceCommandModel costumerUpdate)
        {
            CostumerUpdate = costumerUpdate;
        }
    }
}
