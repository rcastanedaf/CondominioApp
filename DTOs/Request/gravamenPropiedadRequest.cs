using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class gravamenPropiedadRequest
    {
        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser mayor a 0")]
        public required int id_propiedad { get; set; }

        [Required(ErrorMessage = "El ID de banco es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de banco debe ser mayor a 0")]
        public required int id_banco { get; set; }

        [Required(ErrorMessage = "El tipo de gravamen es requerido")]
        [RegularExpression("HIPOTECA|EMBARGO|FIDEICOMISO",
            ErrorMessage = "El tipo debe ser HIPOTECA, EMBARGO o FIDEICOMISO")]
        public required string tipo { get; set; }

        [StringLength(50, ErrorMessage = "El número de escritura no puede exceder 50 caracteres")]
        public string? numero_escritura { get; set; }

        [Range(0.01, 9999999999.99, ErrorMessage = "El monto original debe ser mayor a 0")]
        public decimal? monto_original { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de moneda debe ser mayor a 0")]
        public int? id_moneda { get; set; }

        [Required(ErrorMessage = "La fecha de constitución es requerida")]
        public required DateOnly fecha_constitucion { get; set; }

        public DateOnly? fecha_cancelacion { get; set; }

        [StringLength(100, ErrorMessage = "El nombre del notario no puede exceder 100 caracteres")]
        public string? notario { get; set; }

        [StringLength(500, ErrorMessage = "La URL del registro no puede exceder 500 caracteres")]
        public string? registro_url { get; set; }

        [Range(0, 1, ErrorMessage = "Activo debe ser 0 o 1")]
        public int activo { get; set; } = 1;

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? observaciones { get; set; }
    }
}
