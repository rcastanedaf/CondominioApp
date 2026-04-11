namespace Condominio.Models
{
    public class contratoModel
    {
        public int id_contrato { get; set; }
        public int id_propiedad { get; set; }
        public int id_residente { get; set; }
        public int? id_tipo_contrato { get; set; }
        public string? tipo_contrato { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public decimal? monto { get; set; }
        public int? id_moneda { get; set; }
        public decimal? deposito_garantia { get; set; }
        public string? estado { get; set; }
    }
}