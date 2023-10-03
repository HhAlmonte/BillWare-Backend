using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Inventory.Entities;
using BillWare.Application.Features.Inventory.Models;
using BillWare.Application.Features.Inventory.Query;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Inventory.Handler
{
    public class GetInventoriesPagedWithSearchQueryHandler : IRequestHandler<GetInventoriesPagedWithSearchQuery, PaginationResult<InventoryResponse>>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly ILogger<GetInventoriesPagedWithSearchQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetInventoriesPagedWithSearchQueryHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository,
                                                         ILogger<GetInventoriesPagedWithSearchQueryHandler> logger,
                                                         IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PaginationResult<InventoryResponse>> Handle(GetInventoriesPagedWithSearchQuery request, CancellationToken cancellationToken)
        {
            var inventoriesPaged = await _inventoryRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            if (inventoriesPaged == null)
            {
                _logger.LogError($"No se encontraron inventarios en el sistema");
                throw new NotFoundException(nameof(InventoryResponse), request.Search);
            }

            var inventoriesPagedMapped = _mapper.Map<PaginationResult<InventoryResponse>>(inventoriesPaged);

            return inventoriesPagedMapped;
        }
    }
}
