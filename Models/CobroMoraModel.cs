namespace Condominio.Models
{
    public class CobroMoraModel
    {
        public int IdMora { get; set; }
        public int? IdCuenta { get; set; }
        public DateTime? FechaCalculo { get; set; }
        public int? DiasAtraso { get; set; }
        public decimal? SaldoBase { get; set; }
        public decimal? PorcentajeAplicado { get; set; }
        public decimal? MontoMora { get; set; }
        public decimal? AcumuladoTotal { get; set; }
    }
}