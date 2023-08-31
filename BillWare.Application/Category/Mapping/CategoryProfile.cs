using AutoMapper;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;

namespace BillWare.Application.Category.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryRequest, CategoryEntity>().ReverseMap();
            CreateMap<CategoryEntity, CategoryResponse>().ReverseMap();
            CreateMap<PaginationResult<CategoryEntity>, PaginationResult<CategoryResponse>>().ReverseMap();
        }
    }
}
