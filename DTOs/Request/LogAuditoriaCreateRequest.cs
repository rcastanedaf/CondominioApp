using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class LogAuditoriaCreateRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "El ID de usuario debe ser válido")]
        public int? Id_Usuario { get; set; }

        [StringLength(100, ErrorMessage = "El nombre de usuario no puede exceder 100 caracteres")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "El módulo es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El módulo debe tener entre 1 y 100 caracteres")]
        public required string Modulo { get; set; }

        [Required(ErrorMessage = "La acción es requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La acción debe tener entre 1 y 100 caracteres")]
        public required string Accion { get; set; }

        [Required(ErrorMessage = "La tabla afectada es requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La tabla debe tener entre 1 y 100 caracteres")]
        public required string Tabla_Afectada { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El ID del registro debe ser válido")]
        public int? Id_Registro { get; set; }

        [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
        public string? Descripcion { get; set; }

        [StringLength(5000, ErrorMessage = "Los datos anteriores no pueden exceder 5000 caracteres")]
        public string? Datos_Anteriores { get; set; }

        [StringLength(5000, ErrorMessage = "Los datos nuevos no pueden exceder 5000 caracteres")]
        public string? Datos_Nuevos { get; set; }

        [StringLength(50, ErrorMessage = "La IP de origen no puede exceder 50 caracteres")]
        public string? Ip_Origen { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "El resultado debe tener entre 1 y 50 caracteres")]
        public string Resultado { get; set; } = "EXITO";

        [StringLength(500, ErrorMessage = "El mensaje de error no puede exceder 500 caracteres")]
        public string? Mensaje_Error { get; set; }
    }
}

