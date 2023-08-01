using AutoMapper;
using BillWare.Application.Inventory.Command;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, InventoryVM>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public CreateInventoryCommandHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryVM> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var inventoryToCreate = _mapper.Map<InventoryEntity>(request.InventoryCommandModel);

                var createdInventory = await _inventoryRepository.Create(inventoryToCreate);

                var inventoryVM = _mapper.Map<InventoryVM>(createdInventory);

                return inventoryVM;
            }
            catch (CrudOperationException)
            {
                throw new CrudOperationException("Error creando la entidad Cliente. Hablar con el administrador del sistema.");
            }
        }
    }
}
