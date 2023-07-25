using AutoMapper;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;

namespace BillWare.Application.Inventory.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryCommandModel, InventoryEntity>().ReverseMap();
            CreateMap<InventoryEntity, InventoryVM>().ReverseMap();
            CreateMap<PaginationResult<InventoryEntity>, PaginationResult<InventoryVM>>().ReverseMap();
        }
    }
}
