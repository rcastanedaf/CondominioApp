using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class EspacioComunUpdateRequest : EspacioComunCreateRequest
    {
        [Required(ErrorMessage = "El ID del espacio es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del espacio debe ser válido")]
        public required int Id_Espacio { get; set; }
    }
}

