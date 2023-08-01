using BillWare.Application.Costumer.Command;
using BillWare.Application.Shared;
using BillWare.Application.VehiculoEntrance.Entities;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class DeleteVehiculoEntranceCommandHandler : IRequestHandler<DeleteVehiculoEntranceCommand, bool>
    {
        private readonly IBaseCrudRepository<VehicleEntranceEntity> _costumerRepository;

        public DeleteVehiculoEntranceCommandHandler(IBaseCrudRepository<VehicleEntranceEntity> costumerRepository)
        {
            _costumerRepository = costumerRepository;
        }

        public async Task<bool> Handle(DeleteVehiculoEntranceCommand request, CancellationToken cancellationToken)
        {
            var action = await _costumerRepository.Delete(request.Id);

            return action;
        }
    }
}
