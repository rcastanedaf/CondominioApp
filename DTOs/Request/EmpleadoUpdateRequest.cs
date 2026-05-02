namespace Condominio.DTOs.Request
{
    public class EmpleadoUpdateRequest : EmpleadoCreateRequest
    {
        public int Id_Empleado { get; set; }
        public string Fecha_Baja { get; set; }
    }
}
