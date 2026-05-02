namespace Condominio.DTOs.Request
{
    public class ServicioActivoCreateRequest
    {
        public int Id_Tipo_Servicio { get; set; }
        public int? Id_Propiedad { get; set; }
        public int? Id_Residente { get; set; }
        public decimal? Monto_Personalizado { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public int Activo { get; set; }
        public string Observaciones { get; set; }
    }
}
