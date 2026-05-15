using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class VisitaAutorizadaCreateRequest
    {
        [Required(ErrorMessage = "El ID del residente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del residente debe ser válido")]
        public int Id_Residente { get; set; }

        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser válido")]
        public int Id_Propiedad { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de motivo de visita debe ser válido")]
        public int? Id_Motivo_Visita { get; set; }

        [Required(ErrorMessage = "El nombre del visitante es requerido")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 200 caracteres")]
        [RegularExpression(@"^[a-záéíóúñA-ZÁÉÍÓÚÑ\s]+$", ErrorMessage = "El nombre solo debe contener letras")]
        public string Nombre_Visitante { get; set; } = string.Empty;

        [StringLength(13, MinimumLength = 13, ErrorMessage = "El DPI debe tener exactamente 13 dígitos")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "El DPI debe contener exactamente 13 números")]
        public string? Dpi_Visitante { get; set; }

        [StringLength(20, ErrorMessage = "La placa no puede exceder 20 caracteres")]
        [RegularExpression(@"^[A-Z0-9\-]{4,20}$", ErrorMessage = "La placa solo acepta letras mayúsculas, números y guiones")]
        public string? Placa_Vehiculo { get; set; }

        [Required(ErrorMessage = "La fecha de inicio de vigencia es requerida")]
        public string Fecha_Desde { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de fin de vigencia es requerida")]
        public string Fecha_Hasta { get; set; } = string.Empty;

        [StringLength(5, ErrorMessage = "La hora de inicio no puede exceder 5 caracteres")]
        public string? Hora_Desde { get; set; }

        [StringLength(5, ErrorMessage = "La hora de fin no puede exceder 5 caracteres")]
        public string? Hora_Hasta { get; set; }

        [Required(ErrorMessage = "El tipo de visita es requerido")]
        [RegularExpression("^(UNICA|RECURRENTE|PERMANENTE)$",
            ErrorMessage = "El tipo debe ser: UNICA, RECURRENTE o PERMANENTE")]
        public string Tipo { get; set; } = "UNICA";

        [RegularExpression("^(ACTIVA|USADA|VENCIDA|CANCELADA)$",
            ErrorMessage = "El estado debe ser: ACTIVA, USADA, VENCIDA o CANCELADA")]
        public string Estado { get; set; } = "ACTIVA";

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}