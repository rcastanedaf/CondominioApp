using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class AcuerdoPagoUpdateRequest
    {
        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression("^(ACTIVO|COMPLETADO|INCUMPLIDO|CANCELADO)$",
            ErrorMessage = "Estado inválido. Use: ACTIVO, COMPLETADO, INCUMPLIDO o CANCELADO")]
        public string Estado { get; set; } = "ACTIVO";

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}