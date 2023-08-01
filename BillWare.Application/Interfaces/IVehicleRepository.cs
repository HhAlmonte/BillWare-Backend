using BillWare.Application.VehiculoEntrance.Entities;

namespace BillWare.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Task<bool> DeleteVehicle(int id);
        Task<VehiculoEntrance.Entities.Vehicle> CreateVehicle(VehiculoEntrance.Entities.Vehicle vehicle);
        Task<VehiculoEntrance.Entities.Vehicle> UpdateVehicle(VehiculoEntrance.Entities.Vehicle vehicle);
    }
}
