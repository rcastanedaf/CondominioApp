using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class contratoRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "id_propiedad debe ser mayor a 0")]
        public int id_propiedad { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "id_residente debe ser mayor a 0")]
        public int id_residente { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "id_tipo_contrato debe ser mayor a 0")]
        public int? id_tipo_contrato { get; set; }

        public string? tipo_contrato { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public decimal? monto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "id_moneda debe ser mayor a 0")]
        public int? id_moneda { get; set; }

        public decimal? deposito_garantia { get; set; }
        public string? estado { get; set; }
    }
}