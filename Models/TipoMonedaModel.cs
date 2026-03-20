namespace Condominio.Models
{
    public class TipoMonedaModel
    {
        public required int id { get; set; }

        public required string codigo { get; set; }
        
        public required string nombre { get; set; }

        public string? simbolo { get; set; }

        public required string tipo_cambio_gtq { get; set; }

        public required int activo { get; set; }
    }
}
