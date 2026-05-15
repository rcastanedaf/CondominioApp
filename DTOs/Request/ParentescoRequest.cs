using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ParentescoRequest
    {
        [Required(ErrorMessage = "El nombre del parentesco es requerido")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 80 caracteres")]
        [RegularExpression(@"^[a-záéíóúñA-ZÁÉÍÓÚÑ\s\-]+$", ErrorMessage = "El nombre solo debe contener letras")]
        public required string Nombre { get; set; }
    }
}