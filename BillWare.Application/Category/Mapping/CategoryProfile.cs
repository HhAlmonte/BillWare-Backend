using AutoMapper;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;

namespace BillWare.Application.Category.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryVM>().ReverseMap();
            CreateMap<CategoryCommandModel, CategoryEntity>().ReverseMap();
            CreateMap<PaginationResult<CategoryEntity>, PaginationResult<CategoryVM>>().ReverseMap();
        }
    }
}
