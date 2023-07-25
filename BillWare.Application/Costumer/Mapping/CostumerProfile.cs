using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;

namespace BillWare.Application.Costumer.Mapping
{
    public class CostumerProfile : Profile
    {
        public CostumerProfile()
        {
            CreateMap<CostumerEntity, CostumerVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString("D3")))
            .ReverseMap();

            CreateMap<PaginationResult<CostumerEntity>, PaginationResult<CostumerVM>>().ReverseMap();

            CreateMap<CostumerCommandModel, CostumerEntity>().ReverseMap();
        }
    }
}
