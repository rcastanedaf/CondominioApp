namespace Condominio.Models
{
    public class propiedadModel
    {
        public int id_propiedad { get; set; }
        public int id_tipo_propiedad { get; set; }
        public string codigo { get; set; }
        public int? nivel { get; set; }
        public decimal? area_m2 { get; set; }
        public int? num_habitaciones { get; set; }
        public int? num_parqueos { get; set; }
        public string? estado { get; set; }
    }
}