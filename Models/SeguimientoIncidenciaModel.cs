namespace Condominio.Models
{
    public class SeguimientoIncidenciaModel
    {
        public int IdSeguimiento { get; set; }
        public int? IdIncidencia { get; set; }
        public int? IdUsuario { get; set; }
        public string? Comentario { get; set; }
        public string? EstadoNuevo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}