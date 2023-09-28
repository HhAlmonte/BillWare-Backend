using AutoMapper;
using BillWare.Application.Features.BillingService.Command;
using BillWare.Application.Features.BillingService.Entities;
using BillWare.Application.Features.BillingService.Models;
using BillWare.Application.Features.Service.Command;

namespace BillWare.Application.Features.BillingService.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<CreateServiceCommand, ServiceEntity>().ReverseMap();
            CreateMap<UpdateServiceCommand, ServiceEntity>().ReverseMap();
            CreateMap<ServiceResponse, ServiceEntity>().ReverseMap();
            CreateMap<PaginationResult<ServiceResponse>, PaginationResult<ServiceEntity>>().ReverseMap();
        }
    }
}
