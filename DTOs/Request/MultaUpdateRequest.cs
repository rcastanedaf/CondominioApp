namespace Condominio.DTOs.Request
{
    public class MultaUpdateRequest
    {
        public required int Id_Multa { get; set; }
        public required int Id_Residente { get; set; }
        public required int Id_Propiedad { get; set; }
        public required int Id_Tipo_Infraccion { get; set; }
        public required string Descripcion { get; set; }
        public required decimal Monto { get; set; }
        public required DateOnly Fecha_Infraccion { get; set; }
        public required DateOnly Fecha_Vencimiento { get; set; }
        public required int Estado { get; set; }
        public required string Evidencia { get; set; }
        public required int Id_Factura { get; set; }
        public required int Id_Apelacion { get; set; }
        public required int Id_Emitida { get; set; }
        public required int Id_Aprobada { get; set; }
        public required string Observaciones { get; set; }
        public required DateOnly Fecha_Registro { get; set; }
    }
}
