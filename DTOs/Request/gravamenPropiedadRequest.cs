using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class gravamenPropiedadRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "id_propiedad debe ser mayor a 0")]
        public int id_propiedad { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "id_banco debe ser mayor a 0")]
        public int id_banco { get; set; }

        [Required]
        [RegularExpression("HIPOTECA|EMBARGO|FIDEICOMISO",
            ErrorMessage = "tipo debe ser HIPOTECA, EMBARGO o FIDEICOMISO")]
        public string tipo { get; set; } = "HIPOTECA";

        public string? numero_escritura { get; set; }
        public decimal? monto_original { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "id_moneda debe ser mayor a 0")]
        public int? id_moneda { get; set; }

        [Required]
        public DateTime fecha_constitucion { get; set; }

        public DateTime? fecha_cancelacion { get; set; }
        public string? notario { get; set; }
        public string? registro_url { get; set; }

        [Range(0, 1, ErrorMessage = "activo debe ser 0 o 1")]
        public int activo { get; set; } = 1;

        public string? observaciones { get; set; }
    }
}