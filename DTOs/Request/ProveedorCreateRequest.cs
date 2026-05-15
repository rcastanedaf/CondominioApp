using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ProveedorCreateRequest
    {
        [Required(ErrorMessage = "El nombre del proveedor es requerido")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 200 caracteres")]
        public required string Nombre { get; set; }

        [StringLength(20, ErrorMessage = "El NIT no puede exceder 20 caracteres")]
        public string? Nit { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        [StringLength(120, ErrorMessage = "El email no puede exceder 120 caracteres")]
        public string? Email { get; set; }

        [StringLength(300, ErrorMessage = "La dirección no puede exceder 300 caracteres")]
        public string? Direccion { get; set; }

        [StringLength(150, ErrorMessage = "El contacto no puede exceder 150 caracteres")]
        public string? Contacto { get; set; }

        [StringLength(200, ErrorMessage = "La especialidad no puede exceder 200 caracteres")]
        public string? Especialidad { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;
    }
}