namespace Condominio.Models
{
    public class EmpleadoModel
    {
        public int Id_Empleado { get; set; }
        public int Id_Persona { get; set; } 
        public int Id_Cargo { get; set; } 
        public string Codigo_Empleado { get; set; } 
        public string Fecha_Ingreso { get; set; } 
        public string Fecha_Baja { get; set; } 
        public decimal Salario { get; set; } 
        public string Tipo_Jornada { get; set; }
        public string Estado { get; set; } 
        public string Observaciones { get; set; } 
        
    }
}
