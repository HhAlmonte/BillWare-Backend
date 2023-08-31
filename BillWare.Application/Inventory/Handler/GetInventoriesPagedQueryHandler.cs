using AutoMapper;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class GetCategoriesPagedQueryHandler : IRequestHandler<GetInventoriesPagedQuery, PaginationResult<InventoryResponse>>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesPagedQueryHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<InventoryResponse>> Handle(GetInventoriesPagedQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _inventoryRepository.GetEntitiesPaged(request.Page, request.PageSize);

            var inventoriesVM = _mapper.Map<PaginationResult<InventoryResponse>>(inventories);

            return inventoriesVM;
        }
    }
}
