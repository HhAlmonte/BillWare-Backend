using AutoMapper;
using BillWare.Application.Inventory.Command;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, InventoryVM>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public UpdateInventoryCommandHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryVM> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryToUpdate = _mapper.Map<InventoryEntity>(request.InventoryCommandModel);

            var updatedInventory = await _inventoryRepository.Update(request.Id, inventoryToUpdate);

            var inventoryVM = _mapper.Map<InventoryVM>(updatedInventory);

            return inventoryVM;
        }
    }
}
