namespace Condominio.Models
{
    public class CuentaPorCobrarModel
    {
        public int IdCuenta { get; set; }
        public int? IdResidente { get; set; }
        public int? IdFactura { get; set; }
        public decimal? MontoOriginal { get; set; }
        public decimal? MontoPagado { get; set; }
        public decimal? MontoMora { get; set; }
        public decimal? MontoPendiente { get; set; }
        public int? DiasAtraso { get; set; }
        public string? Estado { get; set; }
        public DateTime? UltimaActualizacion { get; set; }
    }
}
