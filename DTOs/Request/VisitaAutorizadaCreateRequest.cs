namespace Condominio.DTOs.Request
{
    public class VisitaAutorizadaCreateRequest
    {
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
        public string Tipo { get; set; } = "UNICA";
        public string Estado { get; set; } = "ACTIVA";
        public string Observaciones { get; set; }

    }
}
