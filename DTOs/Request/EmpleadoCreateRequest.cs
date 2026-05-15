using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class EmpleadoCreateRequest
    {
        [Required(ErrorMessage = "El ID de persona es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de persona debe ser un número válido")]
        public int Id_Persona { get; set; }

        [Required(ErrorMessage = "El ID de cargo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de cargo debe ser un número válido")]
        public int Id_Cargo { get; set; }

        [Required(ErrorMessage = "El código de empleado es requerido")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El código debe tener entre 1 y 20 caracteres")]
        public string Codigo_Empleado { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es requerida")]
        public DateOnly Fecha_Ingreso { get; set; }

        [Required(ErrorMessage = "El salario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser mayor a 0")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "El tipo de jornada es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo de jornada debe tener entre 1 y 50 caracteres")]
        public string Tipo_Jornada { get; set; } = "COMPLETA";

        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El estado debe tener entre 1 y 20 caracteres")]
        public string Estado { get; set; } = "ACTIVO";

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string Observaciones { get; set; }
    }
}
