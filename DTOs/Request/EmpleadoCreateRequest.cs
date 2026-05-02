namespace Condominio.DTOs.Request
{
    public class EmpleadoCreateRequest
    {
        public int Id_Persona { get; set; }
        public int Id_Cargo { get; set; }
        public string Codigo_Empleado { get; set; }
        public string Fecha_Ingreso { get; set; }
        public decimal Salario { get; set; }
        public string Tipo_Jornada { get; set; } = "COMPLETA";
        public string Estado { get; set; } = "ACTIVO"; 
        public string Observaciones { get; set; }
    }
}
