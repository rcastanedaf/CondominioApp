namespace Condominio.Models
{
    public class SaldoAFavor
    {
        public SaldoAFavor()
        {

        }
        public SaldoAFavor(int idResidente, int idPagoOirgen, decimal montoOriginal, decimal montoDisponible, string motivo, int estado, DateOnly fechaGeneracion,
            DateOnly fechaVencimeinto, int aplicado, DateOnly fechaAplicacion, int generado, string observaciones)
        {
            Id_residente = idResidente;
            Id_Pago_Origen = idPagoOirgen;
            Monto_Original = montoOriginal;
            Monto_Disponible = montoDisponible;
            Motivo = motivo;
            Estado = estado;
            Fecha_Generacion = fechaGeneracion;
            Fecha_Vencimiento = fechaVencimeinto;
            Aplicado = aplicado;
            Fecha_Aplicacion = fechaAplicacion;
            Generado = generado;
            Observaciones = observaciones;
        }

        public int Id_Saldo { get; set; }
        public int Id_residente { get; set; }
        public int Id_Pago_Origen { get; set; }
        public decimal Monto_Original { get; set; }
        public decimal Monto_Disponible { get; set; }
        public string Motivo { get; set; }
        public int Estado { get; set; }
        public DateOnly Fecha_Generacion { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public int Aplicado { get; set; }
        public DateOnly Fecha_Aplicacion { get; set; }
        public int Generado { get; set; }
        public string Observaciones { get; set; }
    }
}
