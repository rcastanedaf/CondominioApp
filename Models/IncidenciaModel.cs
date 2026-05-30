namespace Condominio.Models
{
    public class IncidenciaModel
    {
        public int IdIncidencia { get; set; }
        public int? IdPropiedad { get; set; }
        public int? IdEspacio { get; set; }
        public int? IdCategoria { get; set; }
        public int IdReportadoPor { get; set; }      // ← OBLIGATORIO!
        public string Titulo { get; set; }            // ← OBLIGATORIO!
        public string? Descripcion { get; set; }
        public string? Prioridad { get; set; }
        public string? Estado { get; set; }
        public int? IdAsignadoA { get; set; }
        public int? IdProveedor { get; set; }
        public decimal? CostoEstimado { get; set; }
        public decimal? CostoReal { get; set; }
        public int? IdFacturaCargo { get; set; }
        public DateTime? FechaApertura { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public string? Observaciones { get; set; }
    }
}