namespace Condominio.DTOs.Request
{
    public class ResidenteCreateRequest
    {
        public required int Id_Persona { get; set; }
        public required int Id_Propiedad { get; set; }
        public required string Tipo_Residente { get; set; }
        public required string Fecha_Ingreso { get; set; }
        public string? Fecha_Salida { get; set; }
        public int Activo { get; set; } = 1;
        public string? Observaciones { get; set; }
    }
}
