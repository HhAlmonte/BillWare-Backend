using AutoMapper;
using BillWare.Application.Inventory.Command;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, InventoryResponse>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public UpdateInventoryCommandHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryResponse> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryToUpdate = _mapper.Map<InventoryEntity>(request.Request);

            var updatedInventory = await _inventoryRepository.UpdateEntityAsync(inventoryToUpdate);

            var inventoryVM = _mapper.Map<InventoryResponse>(updatedInventory);

            return inventoryVM;
        }
    }
}
