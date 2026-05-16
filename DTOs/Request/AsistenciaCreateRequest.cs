using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
    public class AsistenciaCreateRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public required int Id_Empleado { get; set; }

        public string Estado { get; set; } = "PRESENTE";
        public int Minutos_Extra { get; set; } = 0;
        public int Minutos_Tardanza { get; set; } = 0;
        public int? Registrado_Por { get; set; }
    }
}

