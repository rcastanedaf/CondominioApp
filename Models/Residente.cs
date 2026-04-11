using System.Runtime.Intrinsics.Arm;

namespace Condominio.Models
{
    public class Residente
    {
        public Residente()
        {

        }
        public Residente(int idPersona, int idPropiedad, string tipo_Residente, DateTime fechaIngreso, DateTime fechaSalida, int activo,
            string observaciones)
        {
            Id_Persona = idPersona;
            Id_Propiedad = idPropiedad;
            Tipo_Residente = tipo_Residente;
            Fecha_Ingreso = fechaIngreso;
            Fecha_Salida = fechaSalida;
            Activo = activo;
            Observaciones = observaciones;
        }
        public int Id_Residente { get; set; }
        public int Id_Persona { get; set; }
        public int Id_Propiedad { get; set; }
        public string Tipo_Residente { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public int Activo { get; set; }
        public string Observaciones { get; set; }
    }
}
