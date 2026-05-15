using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ConceptoDescuentoCreateRequest
    {
        [Required(ErrorMessage = "El nombre del concepto es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de concepto es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El tipo debe tener entre 1 y 50 caracteres")]
        public required string Tipo { get; set; }

        [Required(ErrorMessage = "El valor es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a 0")]
        public required decimal Valor { get; set; }

        [Required(ErrorMessage = "La autorización es requerida")]
        [Range(0, 1, ErrorMessage = "La autorización debe ser 0 o 1")]
        public required int Autorizacion { get; set; }
    }
}
