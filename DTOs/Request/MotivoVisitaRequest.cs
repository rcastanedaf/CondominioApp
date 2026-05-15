using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class MotivoVisitaRequest
    {
        [Required(ErrorMessage = "El nombre del motivo es requerido")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 200 caracteres")]
        public required string Nombre { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }
    }
}
