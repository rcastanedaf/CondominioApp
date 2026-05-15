using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class SaldoAFavorUpdateRequest : SaldoAFavorCreateRequest
    {
        [Required(ErrorMessage = "El ID de saldo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de saldo debe ser válido")]
        public required int Id_Saldo { get; set; }
    }
}