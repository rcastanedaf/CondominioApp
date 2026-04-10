namespace Condominio.Models
{
    public class CicloFacturacionModel
    {
        public int IdCiclo { get; set; }
        public int? IdPropiedad { get; set; }
        public int? IdTipoServicio { get; set; }
        public int? DiaCorte { get; set; }
        public int? DiaVencimiento { get; set; }
        public decimal? MontoOverride { get; set; }
        public int? Activo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
