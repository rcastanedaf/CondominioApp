namespace Condominio.DTOs.Request
{
    public class ResidenteUpdateRequest
    {
        public required int Id_Residente { get; set; }
        public required int Id_Persona { get; set; }
        public required int Id_Propiedad { get; set; }
        public required string Tipo_Residente { get; set; }
        public required DateOnly Fecha_Ingreso { get; set; }
        public required DateOnly Fecha_Salida { get; set; }
        public required int Estado { get; set; }
        public required string Observaciones { get; set; }
    }
}
