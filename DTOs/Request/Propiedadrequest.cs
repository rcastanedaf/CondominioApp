using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class propiedadRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "id_tipo_propiedad debe ser mayor a 0")]
        public int id_tipo_propiedad { get; set; }

        [Required]
        public string codigo { get; set; }

        public int? nivel { get; set; }
        public decimal? area_m2 { get; set; }
        public int? num_habitaciones { get; set; }
        public int? num_parqueos { get; set; }
        public string? estado { get; set; }
    }
}