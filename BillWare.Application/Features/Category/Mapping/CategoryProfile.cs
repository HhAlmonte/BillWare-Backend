using AutoMapper;
using BillWare.Application.Features.Category.Command;
using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Features.Category.Models;

namespace BillWare.Application.Features.Category.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryResponse>().ReverseMap();
            CreateMap<CategoryEntity, CreateCategoryCommand>().ReverseMap();
            CreateMap<CategoryEntity, UpdateCategoryCommand>().ReverseMap();
            CreateMap<PaginationResult<CategoryEntity>, PaginationResult<CategoryResponse>>().ReverseMap();
        }
    }
}
