using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class FamiliarResidenteCreateRequest
    {
        [Required(ErrorMessage = "El residente es obligatorio")]
        public int IdResidente { get; set; }

        [Required(ErrorMessage = "La persona es obligatoria")]
        public int IdPersona { get; set; }

        public int? IdParentesco { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden superar 500 caracteres")]
        public string? Observaciones { get; set; }
    }
}