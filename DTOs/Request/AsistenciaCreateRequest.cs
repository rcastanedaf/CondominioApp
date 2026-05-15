using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class AsistenciaCreateRequest
    {
        [Required(ErrorMessage = "El ID del empleado es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del empleado debe ser válido")]
        public required int Id_Empleado { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public required DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "La hora de entrada es requerida")]
        public required TimeSpan Hora_Entrada { get; set; }

        public TimeSpan? Hora_Salida { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El estado debe tener entre 1 y 50 caracteres")]
        public string Estado { get; set; } = "PRESENTE";

        [Range(0, int.MaxValue, ErrorMessage = "Los minutos extra no pueden ser negativos")]
        public int Minutos_Extra { get; set; } = 0;

        [Range(0, int.MaxValue, ErrorMessage = "Los minutos de tardanza no pueden ser negativos")]
        public int Minutos_Tardanza { get; set; } = 0;

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de quien registra debe ser válido")]
        public int? Registrado_Por { get; set; }
    }
}

