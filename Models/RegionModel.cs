namespace Condominio.Models
{
    public class RegionModel
    {
        public int IdRegion { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int? IdPais { get; set; }
        public string? NombrePais { get; set; }
    }
}