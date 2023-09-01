using AutoMapper;
using BillWare.Application.BillingService.Entities;
using BillWare.Application.BillingService.Models;

namespace BillWare.Application.BillingService.Mapping
{
    public class BillingServiceProfile : Profile
    {
        public BillingServiceProfile()
        {
            CreateMap<BillingServiceRequest, BillingServiceEntity>().ReverseMap();
            CreateMap<BillingServiceResponse, BillingServiceEntity>().ReverseMap();
            CreateMap<PaginationResult<BillingServiceResponse>, PaginationResult<BillingServiceEntity>>().ReverseMap();
        }
    }
}
