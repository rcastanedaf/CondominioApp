namespace Condominio.Models
{
    public class renovacionContratoModel
    {
        public int id_renovacion { get; set; }
        public int id_contrato { get; set; }
        public DateTime? fecha_nueva_vigencia { get; set; }
        public decimal? nuevo_monto { get; set; }
        public int? id_moneda { get; set; }
    }
}