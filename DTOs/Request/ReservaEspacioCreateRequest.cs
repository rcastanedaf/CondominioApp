using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ReservaEspacioCreateRequest
    {
        [Required(ErrorMessage = "El ID del espacio es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del espacio debe ser válido")]
        public required int Id_Espacio { get; set; }

        [Required(ErrorMessage = "El ID del residente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del residente debe ser válido")]
        public required int Id_Residente { get; set; }

        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser válido")]
        public required int Id_Propiedad { get; set; }

        [Required(ErrorMessage = "La fecha de reserva es requerida")]
        public required DateOnly Fecha_Reserva { get; set; }

        [Required(ErrorMessage = "La hora de inicio es requerida")]
        public required TimeSpan Hora_Inicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es requerida")]
        public required TimeSpan Hora_Fin { get; set; }

        [Required(ErrorMessage = "El número de personas es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de personas debe ser mayor a 0")]
        public required int Num_Personas { get; set; }

        [StringLength(500, ErrorMessage = "El motivo no puede exceder 500 caracteres")]
        public string? Motivo { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "El monto de cobro no puede ser negativo")]
        public decimal Monto_Cobro { get; set; } = 0;

        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "El depósito cobrado no puede ser negativo")]
        public decimal Deposito_Cobrado { get; set; } = 0;

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}

