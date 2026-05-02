namespace Condominio.Models
{
    public class ServicioActivoModel
    {
        public int Id_Servicio_Activo { get; set; }
        public int Id_Tipo_Servicio { get; set; }
        public int? Id_Propiedad { get; set; }
        public int? Id_Residente { get; set; }
        public decimal? Monto_Personalizado { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public int Activo { get; set; }
        public string Observaciones { get; set; }
        public string Nombre_Servicio { get; set; }
        public string Codigo_Propiedad { get; set; }
        public string Nombre_Residente { get; set; }
    }
}
