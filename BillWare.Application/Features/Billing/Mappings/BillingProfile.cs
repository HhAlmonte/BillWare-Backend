using AutoMapper;
using BillWare.Application.Features.Billing.Command;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;

namespace BillWare.Application.Features.Billing.Mappings
{
    public class BillingProfile : Profile
    {
        public BillingProfile()
        {
            CreateMap<BillingEntity, CreateBillingCommand>().ReverseMap();

            CreateMap<PaginationResult<BillingEntity>, PaginationResult<BillingResponse>>().ReverseMap();

            CreateMap<BillingEntity, BillingResponse>().ReverseMap();

            CreateMap<BillingEntity, UpdateBillingCommand>().ReverseMap();

            CreateMap<BillingItemEntity, BillingItemRequest>().ReverseMap();

            CreateMap<BillingItemEntity, BillingItemResponse>().ReverseMap();
        }
    }
}
