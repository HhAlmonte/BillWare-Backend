using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class CreateVehiculoEntranceCommand : IRequest<VehiculoEntranceVM>
    {
        public VehiculoEntranceCommandModel CostumerCreate { get; set; }

        public CreateVehiculoEntranceCommand(VehiculoEntranceCommandModel costumerCreate)
        {
            CostumerCreate = costumerCreate;
        }
    }
}
