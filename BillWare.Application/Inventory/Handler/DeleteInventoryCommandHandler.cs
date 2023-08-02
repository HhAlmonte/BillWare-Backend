﻿using BillWare.Application.Inventory.Command;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand, bool>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;

        public DeleteInventoryCommandHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<bool> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            var action = await _inventoryRepository.Delete(request.Id);

            return action;
        }
    }
}