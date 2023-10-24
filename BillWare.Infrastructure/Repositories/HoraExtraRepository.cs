using BillWare.Application.Contracts.Repositories;
using BillWare.Application.Contracts.Service;
using BillWare.Application.Exceptions;
using BillWare.Application.HoraExtra.Entities;
using BillWare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Repositories
{
    public class HoraExtraRepository : IHoraExtraRepository
    {
        private readonly DbSet<HoraExtraEntity> _dbSet;
        private readonly IBillWareDbContext billWareDbContext;

        public HoraExtraRepository(IBillWareDbContext context)
        {
            billWareDbContext = context;
            _dbSet = context.GetDbSet<HoraExtraEntity>();
        }

        public async Task<List<HoraExtraEntity>> GetHorasExtras()
        {
            var result = await _dbSet.ToListAsync();

            return result;
        }

        public async Task<bool> CreateSolicitudHoraExtra(HoraExtraEntity solicitudRequest)
        {
            _dbSet.Add(solicitudRequest);

            await billWareDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DenegarSolicitud(int idSolicitud)
        {
            var solicitud = await _dbSet.FirstOrDefaultAsync(x => x.Id == idSolicitud);

            if (solicitud == null)
                throw new NotFoundException($"Solicitud con id {idSolicitud} no fue encontrada, favor de verificar");

            solicitud.Estado = EstadoSolicitud.Cancelado;

            _dbSet.Update(solicitud);

            await billWareDbContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> UpdateSolicitudHoraExtra(HoraExtraEntity solicitudRequest)
        {
            var solicitud = await _dbSet.FirstOrDefaultAsync(x => x.Id == solicitudRequest.Id);

            if (solicitud == null)
                throw new NotFoundException($"Solicitud con id {solicitudRequest.Id} no fue encontrada, favor de verificar");

            solicitud.CreatedBy = solicitudRequest.CreatedBy;
            solicitud.CreatedDate = solicitudRequest.CreatedDate;
            solicitud.Estado = solicitudRequest.Estado;

            _dbSet.Update(solicitud);

            await billWareDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateStatusHoraExtra(int idSolicitud, int estatusId)
        {
            var solicitudToUpdate = await _dbSet.FindAsync(idSolicitud);

            if(solicitudToUpdate == null)
                throw new NotFoundException($"Solicitud con id {idSolicitud} no fue encontrada, favor de verificar");

            solicitudToUpdate.Estado = (EstadoSolicitud)estatusId;

            _dbSet.Update(solicitudToUpdate);

            await billWareDbContext.SaveChangesAsync();

            return true;
        }
    }
}
