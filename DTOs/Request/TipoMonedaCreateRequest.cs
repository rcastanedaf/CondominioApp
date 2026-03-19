namespace Condominio.DTOs.Request
{
    public class TipoMonedaCreateRequest
    {
        public required string codigo { get; set; }

        public required string nombre { get; set; }

        public string? simbolo { get; set; }

        public required int tipo_cambio_gtq { get; set; }
    }
}
