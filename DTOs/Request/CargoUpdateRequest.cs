using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class CargoUpdateRequest : CargoCreateRequest
    {
        [Required(ErrorMessage = "El ID del cargo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser un número válido")]
        public int Id_Cargo { get; set; }
    }
}
