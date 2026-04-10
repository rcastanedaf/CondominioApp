namespace Condominio.Models
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }
        public int? IdTipoDocFiscal { get; set; }
        public string? Serie { get; set; }
        public string? NumeroFactura { get; set; }
        public string? NumeroAutorizacionSat { get; set; }
        public int? IdPropiedad { get; set; }
        public int? IdResidente { get; set; }
        public string? ReceptorNombre { get; set; }
        public string? ReceptorNit { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? PeriodoInicio { get; set; }
        public DateTime? PeriodoFin { get; set; }
        public int? IdMoneda { get; set; }
        public decimal? TipoCambio { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TotalDescuentos { get; set; }
        public decimal? BaseImponible { get; set; }
        public decimal? TotalIva { get; set; }
        public decimal? Total { get; set; }
        public decimal? SaldoPendiente { get; set; }
        public string? Estado { get; set; }
        public int? IdCicloOrigen { get; set; }
        public int? IdContratoOrigen { get; set; }
        public string? MotivoAnulacion { get; set; }
        public int? GeneradoPor { get; set; }
        public string? Observaciones { get; set; }
    }
}
