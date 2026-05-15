using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class AcuerdoPagoCreateRequest
    {
        [Required(ErrorMessage = "El residente es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del residente debe ser válido")]
        public int IdResidente { get; set; }

        [Required(ErrorMessage = "La cuenta por cobrar es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de cuenta debe ser válido")]
        public int IdCuenta { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 300 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto total es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal MontoTotal { get; set; }

        [Required(ErrorMessage = "El monto de cuota es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto de cuota debe ser mayor a 0")]
        public decimal MontoCuota { get; set; }

        [Required(ErrorMessage = "El número de cuotas es obligatorio")]
        [Range(1, 120, ErrorMessage = "El número de cuotas debe estar entre 1 y 120")]
        public int NumCuotas { get; set; }

        [Required(ErrorMessage = "El día de pago es obligatorio")]
        [Range(1, 31, ErrorMessage = "El día de pago debe estar entre 1 y 31")]
        public int DiaPago { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El aprobado por es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de quien aprueba debe ser válido")]
        public int AprobadoPor { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}