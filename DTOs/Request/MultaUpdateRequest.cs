namespace Condominio.DTOs.Request
{
    public class MultaUpdateRequest
    {
        public required int Id_Multa { get; set; }
        public required int Id_Residente { get; set; }
        public required int Id_Propiedad { get; set; }
        public required string Descripcion { get; set; }
        public required decimal Monto { get; set; }
        public required DateTime Fecha_Infraccion { get; set; }
        public required DateTime Fecha_Vencimiento { get; set; }
        public required string Estado { get; set; }
        public string? Evidencia { get; set; }
        public int? Id_Factura { get; set; }
        public int? Id_Apelacion { get; set; }
        public int? Id_Emitida { get; set; }
        public int? Id_Aprobada { get; set; }
        public required string Observaciones { get; set; }
    }
}
