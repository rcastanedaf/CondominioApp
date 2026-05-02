namespace Condominio.Models
{
    public class VisitaAutorizadaModel
    {
        public int Id_Visita { get; set; }
        public int Id_Residente { get; set; }
        public int Id_Propiedad { get; set; }
        public int? Id_Motivo_Visita { get; set; }
        public string Nombre_Visitante { get; set; }
        public string Dpi_Visitante { get; set; }
        public string Placa_Vehiculo { get; set; }
        public string Fecha_Desde { get; set; }
        public string Fecha_Hasta { get; set; }
        public string Hora_Desde { get; set; }
        public string Hora_Hasta { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

    }
}
