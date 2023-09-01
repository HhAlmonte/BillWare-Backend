using AutoMapper;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Billing.Models;

namespace BillWare.Application.Billing.Mappings
{
    public class BillingProfile : Profile
    {
        public BillingProfile()
        {
            CreateMap<PaginationResult<BillingEntity>, PaginationResult<BillingResponse>>().ReverseMap();

            CreateMap<BillingEntity, BillingResponse>().ReverseMap();

            CreateMap<BillingEntity, BillingRequest>().ReverseMap();

            CreateMap<BillingItemEntity, BillingItemResponse>().ReverseMap();
        }
    }
}
