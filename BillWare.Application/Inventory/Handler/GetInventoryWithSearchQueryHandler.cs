﻿using AutoMapper;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class GetInventoryWithSearchQueryHandler : IRequestHandler<GetInventoryWithSearchQuery, PaginationResult<InventoryVM>>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoryWithSearchQueryHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<InventoryVM>> Handle(GetInventoryWithSearchQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetWithSearch(request.Search, request.PageIndex, request.PageSize);

            var inventoryVM = _mapper.Map<PaginationResult<InventoryVM>>(inventory);

            return inventoryVM;
        }
    }
}
