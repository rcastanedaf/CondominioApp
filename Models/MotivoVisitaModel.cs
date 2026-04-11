namespace Condominio.Models
{
    public class MotivoVisitaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Activo { get; set; } = 1;
    }
}