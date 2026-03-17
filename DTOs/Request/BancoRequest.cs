namespace Condominio.DTOs.Request
{
    public class BancoRequest
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int Pais { get; set; }
        public required int Activo { get; set; }
    }
}
