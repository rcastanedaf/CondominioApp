namespace Condominio.Models
{
    public class PagoModel
    {
        public int IdPago { get; set; }
        public int? IdFactura { get; set; }
        public string? NumeroRecibo { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime? FechaValor { get; set; }
        public decimal? MontoPagado { get; set; }
        public int? IdMoneda { get; set; }
        public decimal? TipoCambio { get; set; }
        public decimal? MontoEnGtq { get; set; }
        public int? IdMetodoPago { get; set; }
        public int? IdBancoOrigen { get; set; }
        public int? IdBancoDestino { get; set; }
        public string? Referencia { get; set; }
        public string? ImagenVoucherUrl { get; set; }
        public string? Estado { get; set; }
        public int? RegistradoPor { get; set; }
        public int? AprobadoPor { get; set; }
        public string? Observaciones { get; set; }
    }
}
