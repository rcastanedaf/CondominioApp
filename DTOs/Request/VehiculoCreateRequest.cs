using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class VehiculoCreateRequest
    {
        [Required(ErrorMessage = "El ID de residente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de residente debe ser válido")]
        public int Id_Residente { get; set; }

        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser válido")]
        public int Id_Propiedad { get; set; }

        [Required(ErrorMessage = "La placa es requerida")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "La placa debe tener entre 4 y 20 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "La marca es requerida")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "La marca debe tener entre 1 y 50 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El modelo es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El modelo debe tener entre 1 y 50 caracteres")]
        public string Modelo { get; set; }

        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int? Anio { get; set; }

        [StringLength(50, ErrorMessage = "El color no puede exceder 50 caracteres")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El tipo de vehículo es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo debe tener entre 1 y 50 caracteres")]
        public string Tipo { get; set; }

        [StringLength(50, ErrorMessage = "El parqueo asignado no puede exceder 50 caracteres")]
        public string Parqueo_Asignado { get; set; }

        [Range(0, 1, ErrorMessage = "El estado activo debe ser 0 o 1")]
        public int Activo { get; set; } = 1;

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string Observaciones { get; set; }
    }
}
