using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class renovacionContratoRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "id_contrato debe ser mayor a 0")]
        public int id_contrato { get; set; }

        public DateTime? fecha_nueva_vigencia { get; set; }
        public decimal? nuevo_monto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "id_moneda debe ser mayor a 0")]
        public int? id_moneda { get; set; }
    }
}