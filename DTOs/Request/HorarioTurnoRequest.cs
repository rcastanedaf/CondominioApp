using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class HorarioTurnoRequest
    {
        [Required(ErrorMessage = "El ID del empleado es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del empleado debe ser válido")]
        public required int Id_Empleado { get; set; }

        [Required(ErrorMessage = "El tipo de turno es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo de turno debe tener entre 1 y 50 caracteres")]
        public required string Tipo_Turno { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public required DateOnly Fecha_Inicio { get; set; }

        public DateOnly? Fecha_Fin { get; set; }

        [Required(ErrorMessage = "La hora de entrada es requerida")]
        public required TimeSpan Hora_Entrada { get; set; }

        [Required(ErrorMessage = "La hora de salida es requerida")]
        public required TimeSpan Hora_Salida { get; set; }

        [StringLength(100, ErrorMessage = "Los días de la semana no pueden exceder 100 caracteres")]
        public string? Dias_Semana { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}

