using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Inventory.Command;
using BillWare.Application.Features.Inventory.Entities;
using BillWare.Application.Features.Inventory.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Inventory.Handler
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, InventoryResponse>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly ILogger<UpdateInventoryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateInventoryCommandHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, 
                                             ILogger<UpdateInventoryCommandHandler> logger,
                                             IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<InventoryResponse> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryToUpdate = _mapper.Map<InventoryEntity>(request);

            var inventoryFromDb = await _inventoryRepository.GetEntityByIdAsync(inventoryToUpdate.Id);

            if (inventoryFromDb == null)
            {
                _logger.LogError($"Inventario con id: {inventoryToUpdate.Id}, no existe");
                throw new NotFoundException(nameof(UpdateInventoryCommand), request.Id);
            }

            var inventoryUpdated = await _inventoryRepository.UpdateEntityAsync(inventoryToUpdate);

            var inventoryMapped = _mapper.Map<InventoryResponse>(inventoryUpdated);

            return inventoryMapped;
        }
    }
}
