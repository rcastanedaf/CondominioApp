using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ResidenteCreateRequest
    {
        [Required(ErrorMessage = "El ID de persona es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de persona debe ser un número válido")]
        public required int Id_Persona { get; set; }

        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser un número válido")]
        public required int Id_Propiedad { get; set; }

        [Required(ErrorMessage = "El tipo de residente es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo de residente debe tener entre 1 y 50 caracteres")]
        public required string Tipo_Residente { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es requerida")]
        public required DateOnly Fecha_Ingreso { get; set; }

        public DateOnly? Fecha_Salida { get; set; }

        [Range(0, 1, ErrorMessage = "El estado activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}
