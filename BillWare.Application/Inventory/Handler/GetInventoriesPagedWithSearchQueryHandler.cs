using AutoMapper;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class GetICategoriesPagedWithSearchQueryHandler : IRequestHandler<GetInventoriesPagedWithSearchQuery, PaginationResult<InventoryResponse>>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public GetICategoriesPagedWithSearchQueryHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<InventoryResponse>> Handle(GetInventoriesPagedWithSearchQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            var inventoryVM = _mapper.Map<PaginationResult<InventoryResponse>>(inventory);

            return inventoryVM;
        }
    }
}
