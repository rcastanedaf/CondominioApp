using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class MetodoPagoCreateRequest
    {
        [Required(ErrorMessage = "El nombre del método de pago es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public required string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;
    }
}

