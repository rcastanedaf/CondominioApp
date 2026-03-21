namespace Condominio.DTOs.Request
{
    public class BancoUpdateRequest
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required int Activo { get; set; }
    }
}
