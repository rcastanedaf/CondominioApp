namespace Condominio.Models
{
    public class RegistroAccesoModel
    {
        public int Id_Acceso { get; set; }
        public string Tipo_Movimiento { get; set; } = string.Empty;
        public string Tipo_Persona { get; set; } = string.Empty;
        public int? Id_Residente { get; set; }
        public int? Id_Visitante { get; set; }
        public int? Id_Empleado { get; set; }
        public string? Nombre_Persona { get; set; }
        public string? Dpi_Persona { get; set; }
        public string? Placa_Vehiculo { get; set; }
        public string? Punto_Acceso { get; set; }
        public int? Autorizado_Por { get; set; }
        public string? Observaciones { get; set; }
        public string? Fecha_Hora { get; set; }
    }
}