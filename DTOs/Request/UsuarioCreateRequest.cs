using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class UsuarioCreateRequest
    {
        [Required(ErrorMessage = "El ID de persona es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de persona debe ser válido")]
        public int Id_Persona { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El usuario debe tener entre 3 y 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El rol es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de rol debe ser válido")]
        public int Id_Rol { get; set; }

        [Range(0, 1, ErrorMessage = "El estado activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;

        [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
        public DateOnly Fecha_Vencimiento { get; set; }
    }
}
