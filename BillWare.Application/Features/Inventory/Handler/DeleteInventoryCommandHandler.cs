using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Inventory.Command;
using BillWare.Application.Features.Inventory.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Inventory.Handler
{
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand, bool>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly ILogger<DeleteInventoryCommandHandler> _logger;

        public DeleteInventoryCommandHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, 
                                             ILogger<DeleteInventoryCommandHandler> logger)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<bool> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryToDelete = await _inventoryRepository.GetEntityByIdAsync(request.Id);

            if (inventoryToDelete == null)
            {
                _logger.LogError($"{request.Id} inventario no existe en el sistema"); 
                throw new NotFoundException(nameof(InventoryEntity), request.Id);
            }

            var inventoryDeleted = await _inventoryRepository.DeleteEntityByIdAsync(inventoryToDelete);

            _logger.LogInformation($"Se ha eliminado la entidad Inventario con Id: {inventoryToDelete.Id}");

            return inventoryDeleted;
        }
    }
}
