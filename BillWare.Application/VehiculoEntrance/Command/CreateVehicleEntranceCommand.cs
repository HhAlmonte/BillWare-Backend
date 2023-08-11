using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class CreateVehicleEntranceCommand : IRequest<VehiculoEntranceVM>
    {
        public VehiculoEntranceCommandModel CostumerCreate { get; set; }

        public CreateVehicleEntranceCommand(VehiculoEntranceCommandModel costumerCreate)
        {
            CostumerCreate = costumerCreate;
        }
    }
}
