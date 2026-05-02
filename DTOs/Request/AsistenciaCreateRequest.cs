namespace Condominio.DTOs.Request
{
    public class AsistenciaCreateRequest
    {
        public int Id_Empleado { get; set; }
        public string Fecha { get; set; }
        public string Hora_Entrada { get; set; }
        public string Hora_Salida { get; set; }
        public string Estado { get; set; } = "PRESENTE";
        public int Minutos_Extra { get; set; } = 0; 
        public int Minutos_Tardanza { get; set; } = 0; 
        public string Observaciones { get; set; }
        public int? Registrado_Por { get; set; }
    }
}
