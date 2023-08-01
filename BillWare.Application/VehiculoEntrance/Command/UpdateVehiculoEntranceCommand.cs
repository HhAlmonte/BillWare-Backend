using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class UpdateVehiculoEntranceCommand : IRequest<VehiculoEntranceVM>
    {
        public VehiculoEntranceCommandModel CostumerUpdate { get; set; }

        public UpdateVehiculoEntranceCommand(VehiculoEntranceCommandModel costumerUpdate)
        {
            CostumerUpdate = costumerUpdate;
        }
    }
}
