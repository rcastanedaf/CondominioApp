namespace Condominio.Models
{
    public class DetalleFacturaModel
    {
        public int IdDetalle { get; set; }
        public int? IdFactura { get; set; }
        public int? NumeroLinea { get; set; }
        public int? IdTipoServicio { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? DescuentoPorcentaje { get; set; }
        public decimal? DescuentoMonto { get; set; }
        public decimal? SubtotalBruto { get; set; }
        public decimal? SubtotalNeto { get; set; }
        public int? AplicaIva { get; set; }
        public decimal? PorcentajeIva { get; set; }
        public decimal? MontoIva { get; set; }
        public decimal? TotalLinea { get; set; }
        public DateTime? PeriodoInicio { get; set; }
        public DateTime? PeriodoFin { get; set; }
        public string? Observaciones { get; set; }
    }
}
