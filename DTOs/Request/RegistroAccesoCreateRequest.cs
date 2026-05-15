using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class RegistroAccesoCreateRequest
    {
        [Required(ErrorMessage = "El tipo de movimiento es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo de movimiento debe tener entre 1 y 50 caracteres")]
        public required string Tipo_Movimiento { get; set; }

        [Required(ErrorMessage = "El tipo de persona es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo de persona debe tener entre 1 y 50 caracteres")]
        public required string Tipo_Persona { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID del residente debe ser válido")]
        public int? Id_Residente { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de visita debe ser válido")]
        public int? Id_Visita { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID del vehículo debe ser válido")]
        public int? Id_Vehiculo { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "El nombre de la persona debe tener entre 1 y 200 caracteres")]
        public string? Nombre_Persona { get; set; }

        [RegularExpression(@"^\d{1,20}$", ErrorMessage = "El DPI debe contener solo números")]
        public string? Dpi_Persona { get; set; }

        [StringLength(20, ErrorMessage = "La placa del vehículo no puede exceder 20 caracteres")]
        public string? Placa_Vehiculo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser válido")]
        public int? Id_Propiedad { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de motivo de visita debe ser válido")]
        public int? Id_Motivo_Visita { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }

        [Required(ErrorMessage = "El ID de quien registra es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de quien registra debe ser válido")]
        public required int Registrado_Por { get; set; }
    }
}

