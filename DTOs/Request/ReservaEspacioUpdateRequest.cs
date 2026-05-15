using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ReservaEspacioUpdateRequest : ReservaEspacioCreateRequest
    {
        [Required(ErrorMessage = "El ID de reserva es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de reserva debe ser válido")]
        public required int Id_Reserva { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "El estado debe tener entre 1 y 50 caracteres")]
        public string? Estado { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de quien aprobó debe ser válido")]
        public int? Aprobado_Por { get; set; }

        [Range(0, 1, ErrorMessage = "Depósito devuelto debe ser 0 o 1")]
        public int Deposito_Devuelto { get; set; }
    }
}

