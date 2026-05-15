using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ListaNegraCreateRequest
    {
        [Required(ErrorMessage = "El tipo es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo debe tener entre 1 y 50 caracteres")]
        public required string Tipo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de persona debe ser válido")]
        public int? Id_Persona { get; set; }

        [StringLength(20, ErrorMessage = "La placa no puede exceder 20 caracteres")]
        public string? Placa { get; set; }

        [Required(ErrorMessage = "Los nombres son requeridos")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Los nombres deben tener entre 1 y 200 caracteres")]
        public required string Nombres { get; set; }

        [RegularExpression(@"^\d{1,20}$", ErrorMessage = "El DPI debe contener solo números")]
        public string? Dpi { get; set; }

        [Required(ErrorMessage = "El motivo es requerido")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "El motivo debe tener entre 1 y 500 caracteres")]
        public required string Motivo { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;

        [Required(ErrorMessage = "El ID de quien registra es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de quien registra debe ser válido")]
        public required int Registrado_Por { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public required DateOnly Fecha_Inicio { get; set; }

        public DateOnly? Fecha_Fin { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}

