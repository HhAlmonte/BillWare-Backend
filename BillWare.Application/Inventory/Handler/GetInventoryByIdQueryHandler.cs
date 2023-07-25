using AutoMapper;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, InventoryVM>
    {
        private readonly IBaseCrudRepository<InventoryEntity> _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoryByIdQueryHandler(IBaseCrudRepository<InventoryEntity> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryVM> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.Get(request.Id);

            var inventoryVM = _mapper.Map<InventoryVM>(inventory);

            return inventoryVM;
        }
    }
}
