namespace Condominio.Models
{
    public class HorarioTurnoModel
    {
        public int Id_Turno { get; set; }
        public string Nombre { get; set; }
        public string Hora_Inicio { get; set; }
        public string Hora_Fin { get; set; }
        public string Dias_Semana { get; set; }
        public int Activo { get; set; }
    }
}
