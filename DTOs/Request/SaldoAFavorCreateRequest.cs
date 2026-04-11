namespace Condominio.DTOs.Request
{
    public class SaldoAFavorCreateRequest
    {
        public required int Id_residente { get; set; }
        public required int Id_Pago_Origen { get; set; }
        public required decimal Monto_Original { get; set; }
        public required decimal Monto_Disponible { get; set; }
        public required string Motivo { get; set; }
        public required int Estado { get; set; }
        public required DateOnly Fecha_Generacion { get; set; }
        public required DateOnly Fecha_Vencimiento { get; set; }
        public required int Aplicado { get; set; }
        public required DateOnly Fecha_Aplicacion { get; set; }
        public required int Generado { get; set; }
        public required string Observaciones { get; set; }
    }
}
