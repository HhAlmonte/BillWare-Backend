using AutoMapper;
using BillWare.Application.Billing.Entities;
using BillWare.Application.Billing.Models;

namespace BillWare.Application.Billing.Mappings
{
    public class BillingProfile : Profile
    {
        public BillingProfile()
        {
            CreateMap<PaginationResult<BillingEntity>, PaginationResult<BillingModel>>().ReverseMap();
            CreateMap<BillingEntity, BillingModel>().ReverseMap();
            CreateMap<BillingItem, BillingItemModel>().ReverseMap();
        }
    }
}
