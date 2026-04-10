namespace Condominio.Models
{
    public class IncidenciaModel
    {
        public int IdIncidencia { get; set; }
        public int? IdPropiedad { get; set; }
        public int? IdEspacio { get; set; }
        public int? IdCategoria { get; set; }
        public string? Titulo { get; set; }
        public string? Prioridad { get; set; }
        public string? Estado { get; set; }
    }
}