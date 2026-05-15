using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ProveedorUpdateRequest
    {
        [Required(ErrorMessage = "El ID es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser válido")]
        public required int Id_Proveedor { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es requerido")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 200 caracteres")]
        public required string Nombre { get; set; }

        [StringLength(20)] public string? Nit { get; set; }
        [StringLength(20)] public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        [StringLength(120)] public string? Email { get; set; }

        [StringLength(300)] public string? Direccion { get; set; }
        [StringLength(150)] public string? Contacto { get; set; }
        [StringLength(200)] public string? Especialidad { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;
    }
}