using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Vehicle.Entities;
using BillWare.Application.Vehicle.Models;
using BillWare.Application.VehiculoEntrance.Entities;

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

            CreateMap<CostumerModel, CostumerEntity>().ReverseMap();
            CreateMap<VehicleModel, VehicleEntity>().ReverseMap();
        }
    }
}
