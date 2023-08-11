using BillWare.Application.Vehicle.Entities;

namespace BillWare.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Task<bool> DeleteVehicle(int id);
        Task<VehicleEntity> CreateVehicle(VehicleEntity vehicle);
        Task<VehicleEntity> UpdateVehicle(VehicleEntity vehicle);
    }
}
