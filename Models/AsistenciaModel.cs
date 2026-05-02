namespace Condominio.Models
{
    public class AsistenciaModel
    {
        public int Id_Asistencia { get; set; } 
        public int Id_Empleado { get; set; } 
        public string Fecha { get; set; } 
        public string Hora_Entrada { get; set; }
        public string Hora_Salida { get; set; }
        public string Estado { get; set; } 
        public int Minutos_Extra { get; set; }
        public int Minutos_Tardanza { get; set; }
        public string Observaciones { get; set; } 
    }
}
