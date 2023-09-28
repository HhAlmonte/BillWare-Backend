using AutoMapper;
using BillWare.Application.Features.Inventory.Models;
using BillWare.Application.Features.Inventory.Query;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Inventory.Handler
{
    public class GetInventoriesPagedQueryHandler : IRequestHandler<GetInventoriesPagedQuery, PaginationResult<InventoryResponse>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<GetInventoriesPagedQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetInventoriesPagedQueryHandler(IInventoryRepository inventoryRepository,
                                               ILogger<GetInventoriesPagedQueryHandler> logger,
                                               IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PaginationResult<InventoryResponse>> Handle(GetInventoriesPagedQuery request, CancellationToken cancellationToken)
        {
            var inventoriesPaged = await _inventoryRepository.GetEntitiesPaged(request.PageIndex, request.PageSize);

            if (inventoriesPaged == null)
            {
                _logger.LogError($"No se encontraron inventarios en el sistema");
            }

            var inventoriesPagedMapped = _mapper.Map<PaginationResult<InventoryResponse>>(inventoriesPaged);

            return inventoriesPagedMapped;
        }
    }
}
