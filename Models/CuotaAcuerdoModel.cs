namespace Condominio.Models
{
    public class CuotaAcuerdoModel
    {
        public int IdCuota { get; set; }
        public int IdAcuerdo { get; set; }
        public int NumeroCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; } = "PENDIENTE";
        public int? IdPago { get; set; }
    }
}