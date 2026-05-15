using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class renovacionContratoRequest
    {
        [Required(ErrorMessage = "El ID del contrato es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del contrato debe ser mayor a 0")]
        public required int id_contrato { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public required DateOnly FECHA_INICIO { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public required DateOnly FECHA_FIN { get; set; }

        [Range(0.01, 9999999999.99, ErrorMessage = "El monto nuevo debe ser mayor a 0")]
        public decimal? MONTO_NUEVO { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de moneda debe ser mayor a 0")]
        public int? id_moneda { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? observaciones { get; set; }
    }
}
