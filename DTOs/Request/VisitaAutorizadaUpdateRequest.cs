using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class VisitaAutorizadaUpdateRequest : VisitaAutorizadaCreateRequest
    {
        [Required(ErrorMessage = "El ID de visita es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de visita debe ser un número válido")]
        public int Id_Visita { get; set; }
    }
}