namespace Condominio.DTOs.Request
{
    public class ConceptoDescuentoUpdateRequest
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }
        public required decimal Valor { get; set; }
        public required int Autorizacion { get; set; }
    }
}
