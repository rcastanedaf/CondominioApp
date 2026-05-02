namespace Condominio.DTOs.Request
{
    public class HorarioTurnoRequest
    {
        public int Id_Empleado { get; set; }
        public string Tipo_Turno { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Hora_Entrada { get; set; }
        public string Hora_Salida { get; set; }
        public string Dias_Semana { get; set; }
        public int Activo { get; set; }
        public string Observaciones { get; set; }
    }
}
