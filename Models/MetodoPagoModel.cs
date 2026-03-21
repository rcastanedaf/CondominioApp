namespace Condominio.Models
{
    public class MetodoPagoModel
    {
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public int Activo { get; set; }
    }
}
