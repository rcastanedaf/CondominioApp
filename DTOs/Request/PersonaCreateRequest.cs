using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class PersonaCreateRequest
    {
        [Required(ErrorMessage = "El tipo es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo debe tener entre 1 y 50 caracteres")]
        public required string Tipo { get; set; }

        [Required(ErrorMessage = "Los nombres son requeridos")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Los nombres deben tener entre 1 y 100 caracteres")]
        [RegularExpression(@"^[a-záéíóúñA-ZÁÉÍÓÚÑ\s]+$", ErrorMessage = "Los nombres solo deben contener letras")]
        public required string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Los apellidos deben tener entre 1 y 100 caracteres")]
        [RegularExpression(@"^[a-záéíóúñA-ZÁÉÍÓÚÑ\s]+$", ErrorMessage = "Los apellidos solo deben contener letras")]
        public required string Apellidos { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "El DPI debe tener exactamente 13 dígitos")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "El DPI debe contener exactamente 13 números")]
        public string? DPI { get; set; }

        [StringLength(20, ErrorMessage = "El pasaporte no puede exceder 20 caracteres")]
        public required string Pasaporte { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public required DateOnly Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "El estado civil es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El estado civil debe ser un número válido")]
        public required int Id_Estado_Civil { get; set; }

        [Required(ErrorMessage = "La nacionalidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La nacionalidad debe ser un número válido")]
        public required int Nacionalidad { get; set; }

        [Required(ErrorMessage = "El teléfono principal es requerido")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "El teléfono debe tener entre 7 y 20 caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El teléfono solo debe contener números")]
        public required string Telefono_Principal { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono secundario no puede exceder 20 caracteres")]
        [RegularExpression(@"^\d*$", ErrorMessage = "El teléfono solo debe contener números")]
        public required string Telefono_Secundario { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
        public required string Email { get; set; }

        [StringLength(12, ErrorMessage = "El NIT no puede exceder 12 caracteres")]
        [RegularExpression(@"^\d*$", ErrorMessage = "El NIT solo debe contener números")]
        public required string NIT { get; set; }

        [Required(ErrorMessage = "El régimen fiscal es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El régimen fiscal debe ser un número válido")]
        public required int Id_Regimen_Fiscal { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public required string Observaciones { get; set; }

        [Required(ErrorMessage = "El estado activo es requerido")]
        [Range(0, 1, ErrorMessage = "El estado activo debe ser 0 o 1")]
        public required int Activo { get; set; }
    }
}
