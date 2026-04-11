using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class tipoPropiedadRequest
    {
        [Required]
        public string nombre { get; set; }
        public string? descripcion { get; set; }
    }
}
