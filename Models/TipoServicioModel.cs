namespace Condominio.Models
{
    public class TipoServicioModel
    {
        public int IdTipoServicio { get; set; }
        public string? Nombre { get; set; }
        public int? IdUnidad { get; set; }
        public string? Periodicidad { get; set; }
        public decimal? MontoBase { get; set; }
        public int? AplicaIva { get; set; }
        public int? AplicaMora { get; set; }
        public decimal? PorcentajeMora { get; set; }
        public int? DiasGracia { get; set; }
    }
}