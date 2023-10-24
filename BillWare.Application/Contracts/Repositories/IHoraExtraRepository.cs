using BillWare.Application.HoraExtra.Entities;

namespace BillWare.Application.Contracts.Repositories
{
    public interface IHoraExtraRepository
    {
        Task<List<HoraExtraEntity>> GetHorasExtras();
        Task<bool> CreateSolicitudHoraExtra(HoraExtraEntity solicitudRequest);
        Task<bool> UpdateSolicitudHoraExtra(HoraExtraEntity solicitudRequest);
        Task<bool> DenegarSolicitud(int idSolicitud);
        Task<bool> UpdateStatusHoraExtra(int idSolicitud, int estatusId);
    }
}
