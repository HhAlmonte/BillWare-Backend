using BillWare.Application.Shared.Entities;
using MediatR;

namespace BillWare.Application.HoraExtra.Entities
{
    public class HoraExtraEntity : BaseEntity
    {
        public string Code { get; set; }
        public string EmployeeName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Aprobado;
    }

    public class Solicitu
    {

        public int MotidoId { get; set; }
        public Motivos Motivo { get; set; }
    }

    public class Emplooye
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int SupervisorId { get; set; }
        public Supervisor Supervisor { get; set; }
    }

    public class Supervisor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class Motivos
    {
        public string PorqueSi { get; set; }
        public string PorqueNo { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public enum EstadoSolicitud
    {
        Aprobado = 1,
        AprobadoPorGerenteArea,
        AprobadoPorGerenteGeneral,
        Cancelado
    }
}
