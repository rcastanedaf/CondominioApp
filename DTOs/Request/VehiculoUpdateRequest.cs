using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class VehiculoUpdateRequest : VehiculoCreateRequest
    {
        [Required(ErrorMessage = "El ID del vehículo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser válido")]
        public int Id_Vehiculo { get; set; }
    }
}
