using AutoMapper;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;

namespace BillWare.Application.Inventory.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryRequest, InventoryEntity>().ReverseMap();

            CreateMap<InventoryEntity, InventoryResponse>().ReverseMap();

            CreateMap<PaginationResult<InventoryEntity>, PaginationResult<InventoryResponse>>()
                .ReverseMap();

            CreateMap<CategoryEntity, CategoryResponse>();
        }
    }
}
