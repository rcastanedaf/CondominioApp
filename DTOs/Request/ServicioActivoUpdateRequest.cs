using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ServicioActivoUpdateRequest
    {
        public DateOnly? FechaFin { get; set; }

        // Property para compatibilidad con repository (snake_case)
        public DateOnly? Fecha_Fin => FechaFin;

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;
    }
}
