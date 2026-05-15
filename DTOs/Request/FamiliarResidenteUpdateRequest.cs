using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class FamiliarResidenteUpdateRequest
    {
        public int? IdParentesco { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden superar 500 caracteres")]
        public string? Observaciones { get; set; }

        public int Activo { get; set; } = 1;
    }
}