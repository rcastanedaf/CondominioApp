namespace Condominio.DTOs.Request
{
    public class BancoCreateRequest
    {
        public required string Nombre { get; set; }
        public required int Pais { get; set; }
        public required int Activo { get; set; }
    }
}
