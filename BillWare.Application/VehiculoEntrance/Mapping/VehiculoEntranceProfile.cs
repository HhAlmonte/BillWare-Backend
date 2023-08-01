using AutoMapper;
using BillWare.Application.Costumer.Models;
using BillWare.Application.VehiculoEntrance.Entities;
using BillWare.Application.VehiculoEntrance.Models;

namespace BillWare.Application.VehiculoEntrance.Mapping
{
    public class VehiculoEntranceProfile : Profile
    {
        public VehiculoEntranceProfile()
        {
            CreateMap<VehicleEntranceEntity, VehiculoEntranceVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString("D3")))
            .ReverseMap();

            CreateMap<PaginationResult<VehicleEntranceEntity>, PaginationResult<VehiculoEntranceVM>>().ReverseMap();

            CreateMap<VehiculoEntranceCommandModel, VehicleEntranceEntity>().ReverseMap();

            CreateMap<CostumerModel, Entities.Costumer>().ReverseMap();
            CreateMap<VehicleModel, Entities.Vehicle>().ReverseMap();
        }
    }
}
