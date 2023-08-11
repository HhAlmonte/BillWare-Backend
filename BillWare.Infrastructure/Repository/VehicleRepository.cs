using BillWare.Application.Interfaces;
using BillWare.Application.Shared;
using BillWare.Application.Vehicle.Entities;
using BillWare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IBillWareDbContext _context;
        private readonly DbSet<VehicleEntity> _dbSet;

        public VehicleRepository(IBillWareDbContext context)
        {
            _context = context;
            _dbSet = _context.GetDbSet<VehicleEntity>();
        }

        public async Task<VehicleEntity> CreateVehicle(VehicleEntity vehicle)
        {
            await _dbSet.AddAsync(vehicle);

            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            var vehicle = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (vehicle == null) throw new Exception("Error deleting vehicle.");

            _dbSet.Remove(vehicle);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<VehicleEntity> UpdateVehicle(VehicleEntity vehicle)
        {
            _dbSet.Update(vehicle);

            await _context.SaveChangesAsync();

            return vehicle;
        }
    }
}
