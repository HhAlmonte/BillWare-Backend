using AutoMapper;
using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Features.Category.Models;
using BillWare.Application.Features.Inventory.Command;
using BillWare.Application.Features.Inventory.Entities;
using BillWare.Application.Features.Inventory.Models;

namespace BillWare.Application.Features.Inventory.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<CreateInventoryCommand, InventoryEntity>().ReverseMap();
            CreateMap<UpdateInventoryCommand, InventoryEntity>().ReverseMap();

            CreateMap<InventoryEntity, InventoryResponse>().ReverseMap();

            CreateMap<PaginationResult<InventoryEntity>, PaginationResult<InventoryResponse>>()
                .ReverseMap();

            CreateMap<CategoryEntity, CategoryResponse>();
        }
    }
}
