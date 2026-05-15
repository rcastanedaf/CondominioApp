using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class ListaNegraUpdateRequest : ListaNegraCreateRequest
    {
        [Required(ErrorMessage = "El ID de lista es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de lista debe ser válido")]
        public required int Id_Lista { get; set; }
    }
}

