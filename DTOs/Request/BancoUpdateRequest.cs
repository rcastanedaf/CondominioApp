using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class BancoUpdateRequest
    {
        [Required(ErrorMessage = "El ID es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser un número válido")]
        public required int Id { get; set; }

        [Required(ErrorMessage = "El nombre del banco es requerido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public required string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de país debe ser válido")]
        public int? Id_Pais { get; set; }

        [Required(ErrorMessage = "El estado activo es requerido")]
        [Range(0, 1, ErrorMessage = "El estado activo debe ser 0 o 1")]
        public required int Activo { get; set; }
    }
}