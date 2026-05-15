using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class UsuarioUpdateRequest
    {
        [Required(ErrorMessage = "El ID de usuario es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser válido")]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "El rol es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de rol debe ser válido")]
        public int Id_Rol { get; set; }

        [Range(0, 1, ErrorMessage = "El estado activo debe ser 0 o 1")]
        public int Activo { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
        public DateOnly Fecha_Vencimiento { get; set; }
    }
}
