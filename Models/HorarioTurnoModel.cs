namespace Condominio.Models
{
    public class HorarioTurnoModel
    {
        public int IdTurno { get; set; }  
        public string Nombre { get; set; }
        public string HoraInicio { get; set; }  
        public string HoraFin { get; set; }    
        public string DiasSemana { get; set; }
        public int Activo { get; set; }
    }
}