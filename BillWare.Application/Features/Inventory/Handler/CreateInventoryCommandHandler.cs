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
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, InventoryResponse>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly ILogger<CreateInventoryCommandHandler> _logger; 
        private readonly IMapper _mapper;

        public CreateInventoryCommandHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository,
                                             ILogger<CreateInventoryCommandHandler> logger,
                                             IMapper mapper)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryResponse> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryToCreate = _mapper.Map<InventoryEntity>(request);

            var inventoryCreated = await _inventoryRepository.CreateEntityAsync(inventoryToCreate);

            _logger.LogInformation($"Se ha creado la entidad Inventario con Id: {inventoryCreated.Id}");

            var inventoryMapped = _mapper.Map<InventoryResponse>(inventoryCreated);

            return inventoryMapped;
        }
    }
}
