using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;

namespace BillWare.Application.Costumer.Mappings
{
    public class CostumerProfile : Profile
    {
        public CostumerProfile()
        {
            CreateMap<CostumerEntity, CostumerModel>();
        }
    }
}
