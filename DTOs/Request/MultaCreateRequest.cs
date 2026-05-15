using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class MultaCreateRequest
    {
        [Required(ErrorMessage = "El ID del residente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del residente debe ser válido")]
        public required int Id_Residente { get; set; }

        [Required(ErrorMessage = "El ID de propiedad es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de propiedad debe ser válido")]
        public required int Id_Propiedad { get; set; }

        [Required(ErrorMessage = "El tipo de infracción es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El tipo de infracción debe ser válido")]
        public required int Id_Tipo_Infraccion { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 500 caracteres")]
        public required string Descripcion { get; set; }

        [Required(ErrorMessage = "El monto es requerido")]
        [Range(0.01, 999999.99, ErrorMessage = "El monto debe estar entre Q0.01 y Q999,999.99")]
        public required decimal Monto_Multa { get; set; }

        [Required(ErrorMessage = "La fecha de infracción es requerida")]
        public required DateOnly Fecha_Infraccion { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
        public required DateOnly Fecha_Vencimiento { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("^(PENDIENTE|PAGADA|APELADA|ANULADA|VENCIDA)$",
            ErrorMessage = "Estado inválido. Use: PENDIENTE, PAGADA, APELADA, ANULADA o VENCIDA")]
        public string Estado { get; set; } = "PENDIENTE";

        [StringLength(500, ErrorMessage = "La evidencia no puede exceder 500 caracteres")]
        public string? Evidencia_Url { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de factura debe ser válido")]
        public int? Id_Factura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de apelación debe ser válido")]
        public int? Id_Apelacion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID emitida debe ser válido")]
        public int? Id_Emitida_Por { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID aprobada debe ser válido")]
        public int? Id_Aprobada_Por { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
        // Fecha_Registro se asigna en backend con SYSDATE, no se recibe del cliente
    }
}