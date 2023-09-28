using AutoMapper;
using BillWare.Application.Features.Costumer.Command;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Features.Costumer.Models;

namespace BillWare.Application.Features.Costumer.Mappings
{
    public class CostumerProfile : Profile
    {
        public CostumerProfile()
        {
            CreateMap<PaginationResult<CostumerEntity>, PaginationResult<CostumerResponse>>().ReverseMap();
            CreateMap<CostumerEntity, CreateCostumerCommand>().ReverseMap();
            CreateMap<CostumerEntity, UpdateCostumerCommand>().ReverseMap();
            CreateMap<CostumerEntity, CostumerResponse>().ReverseMap();
        }
    }
}
