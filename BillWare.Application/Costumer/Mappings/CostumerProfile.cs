using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;

namespace BillWare.Application.Costumer.Mappings
{
    public class CostumerProfile : Profile
    {
        public CostumerProfile()
        {
            CreateMap<PaginationResult<CostumerEntity>, PaginationResult<CostumerResponse>>().ReverseMap();
            CreateMap<CostumerEntity, CostumerRequest>().ReverseMap();
            CreateMap<CostumerEntity, CostumerResponse>().ReverseMap();
            CreateMap<CostumerResponse, CostumerRequest>().ReverseMap();
        }
    }
}
