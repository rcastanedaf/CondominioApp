using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class SaldoAFavorCreateRequest
    {
        [Required(ErrorMessage = "El ID del residente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del residente debe ser válido")]
        public required int Id_residente { get; set; }

        [Required(ErrorMessage = "El ID de pago origen es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de pago origen debe ser válido")]
        public required int Id_Pago_Origen { get; set; }

        [Required(ErrorMessage = "El monto original es requerido")]
        [Range(0.01, 999999999.99, ErrorMessage = "El monto original debe ser mayor a 0")]
        public required decimal Monto_Original { get; set; }

        [Required(ErrorMessage = "El monto disponible es requerido")]
        [Range(0.01, 999999999.99, ErrorMessage = "El monto disponible debe ser mayor a 0")]
        public required decimal Monto_Disponible { get; set; }

        [Required(ErrorMessage = "El motivo es requerido")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "El motivo debe tener entre 5 y 500 caracteres")]
        public required string Motivo { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("^(DISPONIBLE|APLICADO|VENCIDO|ANULADO)$",
            ErrorMessage = "Estado inválido. Use: DISPONIBLE, APLICADO, VENCIDO o ANULADO")]
        public string Estado { get; set; } = "DISPONIBLE";

        [Required(ErrorMessage = "La fecha de generación es requerida")]
        public required DateOnly Fecha_Generacion { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
        public required DateOnly Fecha_Vencimiento { get; set; }

        public DateOnly? Fecha_Aplicacion { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
        // Aplicado y Generado los maneja el backend, no el cliente
    }
}