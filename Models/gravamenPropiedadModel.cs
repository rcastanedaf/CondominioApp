namespace Condominio.Models
{
    public class gravamenPropiedadModel
    {
        public int id_gravamen { get; set; }
        public int id_propiedad { get; set; }
        public int id_banco { get; set; }
        public string tipo { get; set; }
        public string numero_escritura { get; set; }
        public decimal? monto_original { get; set; }
        public int? id_moneda { get; set; }
        public DateTime fecha_constitucion { get; set; }
        public DateTime? fecha_cancelacion { get; set; }
        public string notario { get; set; }
        public string registro_url { get; set; }
        public int activo { get; set; }
        public string observaciones { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
