using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class TipoMonedaCreateRequest
    {
        [Required(ErrorMessage = "El código es requerido")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El código debe tener entre 1 y 5 caracteres")]
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "El código debe ser 3 letras mayúsculas (ej: USD, GTQ)")]
        public required string codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public required string nombre { get; set; }

        [StringLength(5, ErrorMessage = "El símbolo no puede exceder 5 caracteres")]
        public string? simbolo { get; set; }

        [Required(ErrorMessage = "El tipo de cambio es requerido")]
        [Range(0.01, 999999.99, ErrorMessage = "El tipo de cambio debe ser mayor a 0")]
        public required decimal tipo_cambio_gtq { get; set; }
    }
}

