using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class EmpleadoUpdateRequest : EmpleadoCreateRequest
    {
        [Required(ErrorMessage = "El ID del empleado es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser válido")]
        public int Id_Empleado { get; set; }

        public DateOnly? Fecha_Baja { get; set; }
    }
}
