using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ServicioActivoCreateRequest
    {
        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser válido")]
        public required int IdPropiedad { get; set; }

        [Required(ErrorMessage = "El ID de tipo de servicio es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de tipo de servicio debe ser válido")]
        public required int IdTipoServicio { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public required DateOnly FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }

        [Range(0.01, 999999999.99, ErrorMessage = "El monto personalizado debe ser mayor a 0")]
        public decimal? MontoPersonalizado { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}
