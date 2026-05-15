namespace Condominio.Models
{
    public class AcuerdoPagoModel
    {
        public int IdAcuerdo { get; set; }
        public int IdResidente { get; set; }
        public int IdCuenta { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public decimal MontoCuota { get; set; }
        public int NumCuotas { get; set; }
        public int DiaPago { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Estado { get; set; } = "ACTIVO";
        public int AprobadoPor { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaRegistro { get; set; }

        // Enriquecido
        public string? NombreResidente { get; set; }
    }
}