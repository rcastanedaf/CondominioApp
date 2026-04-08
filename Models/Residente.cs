using System.Runtime.Intrinsics.Arm;

namespace Condominio.Models
{
    public class Residente
    {
        public Residente()
        {

        }
        public Residente(int idPersona, int idPropiedad, string tipo_Residente, DateOnly fechaIngreso, DateOnly fechaSalida, int estado,
            string observaciones)
        {
            Id_Persona = idPersona;
            Id_Propiedad = idPropiedad;
            Tipo_Residente = tipo_Residente;
            Fecha_Ingreso = fechaIngreso;
            Fecha_Salida = fechaSalida;
            Estado = estado;
            Observaciones = observaciones;
        }
        public int Id_Residente { get; set; }
        public int Id_Persona { get; set; }
        public int Id_Propiedad { get; set; }
        public string Tipo_Residente { get; set; }
        public DateOnly Fecha_Ingreso { get; set; }
        public DateOnly Fecha_Salida { get; set; }
        public int Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
