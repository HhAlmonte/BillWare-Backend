using AutoMapper;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class GetAllInventoryQueryHandler : IRequestHandler<GetAllInventoryQuery, PaginationResult<InventoryVM>>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public GetAllInventoryQueryHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<InventoryVM>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _inventoryRepository.Get(request.Page, request.PageSize);

            var inventoriesVM = _mapper.Map<PaginationResult<InventoryVM>>(inventories);

            return inventoriesVM;
        }
    }
}
