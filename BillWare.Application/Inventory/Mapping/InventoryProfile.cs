using AutoMapper;
using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;

namespace BillWare.Application.Inventory.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryRequest, InventoryEntity>().ReverseMap();

            CreateMap<InventoryEntity, InventoryResponse>()
                .ForMember(dest => dest.Category, op => op.MapFrom(source => source.Category.Name))
                .ReverseMap();

            CreateMap<PaginationResult<InventoryEntity>, PaginationResult<InventoryResponse>>()
                .ReverseMap();
        }
    }
}
