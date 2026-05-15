using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class contratoRequest
    {
        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "id_propiedad debe ser mayor a 0")]
        public int id_propiedad { get; set; }

        [Required(ErrorMessage = "El ID de residente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "id_residente debe ser mayor a 0")]
        public int id_residente { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "id_tipo_contrato debe ser mayor a 0")]
        public int? id_tipo_contrato { get; set; }

        [StringLength(50, ErrorMessage = "El tipo de contrato no puede exceder 50 caracteres")]
        [RegularExpression("^(ARRENDAMIENTO|COMODATO|PROPIETARIO|SERVICIO)$",
            ErrorMessage = "Tipo de contrato inválido. Use: ARRENDAMIENTO, COMODATO, PROPIETARIO o SERVICIO")]
        public string? tipo_contrato { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime? fecha_inicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public DateTime? fecha_fin { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal? monto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "id_moneda debe ser mayor a 0")]
        public int? id_moneda { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El depósito de garantía no puede ser negativo")]
        public decimal? deposito_garantia { get; set; }

        [RegularExpression("^(VIGENTE|VENCIDO|RESCINDIDO|PENDIENTE)$",
            ErrorMessage = "Estado inválido. Use: VIGENTE, VENCIDO, RESCINDIDO o PENDIENTE")]
        public string? estado { get; set; }
    }
}