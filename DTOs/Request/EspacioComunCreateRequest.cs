using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class EspacioComunCreateRequest
    {
        [Required(ErrorMessage = "El nombre del espacio es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La capacidad es requerida")]
        [Range(1, 1000, ErrorMessage = "La capacidad debe estar entre 1 y 1000 personas")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("^(DISPONIBLE|MANTENIMIENTO|RESERVADO|NO_DISPONIBLE)$",
            ErrorMessage = "Estado inválido. Use: DISPONIBLE, MANTENIMIENTO, RESERVADO o NO_DISPONIBLE")]
        public string Estado { get; set; } = "DISPONIBLE";

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}