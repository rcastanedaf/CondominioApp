using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class propiedadRequest
    {
        [Required(ErrorMessage = "El ID de tipo de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de tipo de propiedad debe ser mayor a 0")]
        public required int id_tipo_propiedad { get; set; }

        [Required(ErrorMessage = "El código de propiedad es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El código debe tener entre 1 y 50 caracteres")]
        public required string codigo { get; set; }

        [Range(1, 50, ErrorMessage = "El nivel debe estar entre 1 y 50")]
        public int? nivel { get; set; }

        [Range(1, 10000, ErrorMessage = "El área debe estar entre 1 y 10000 metros cuadrados")]
        public decimal? area_m2 { get; set; }

        [Range(0, 20, ErrorMessage = "El número de habitaciones debe estar entre 0 y 20")]
        public int? num_habitaciones { get; set; }

        [Range(0, 20, ErrorMessage = "El número de parqueos debe estar entre 0 y 20")]
        public int? num_parqueos { get; set; }

        [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres")]
        public string? estado { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int activo { get; set; } = 1;

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? observaciones { get; set; }
    }
}
