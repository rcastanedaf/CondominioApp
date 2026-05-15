using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class PaisRequest
    {
        [Required(ErrorMessage = "El código del país es requerido")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "El código debe tener entre 2 y 3 caracteres")]
        [RegularExpression(@"^[A-Z]{2,3}$", ErrorMessage = "El código debe ser 2 o 3 letras mayúsculas (ej: GT, USA)")]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del país es requerido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        [RegularExpression(@"^[a-záéíóúñA-ZÁÉÍÓÚÑ\s\-\.]+$", ErrorMessage = "El nombre solo debe contener letras")]
        public required string Nombre { get; set; }
    }
}