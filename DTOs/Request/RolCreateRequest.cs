using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class RolCreateRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80, ErrorMessage = "El nombre no puede superar 80 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
    }
}