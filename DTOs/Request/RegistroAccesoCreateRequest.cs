namespace Condominio.DTOs.Request
{
    public class RegistroAccesoCreateRequest
    {
        public string Tipo_Movimiento { get; set; }
        public string Tipo_Persona { get; set; }
        public int? Id_Residente { get; set; }
        public int? Id_Visita { get; set; }
        public int? Id_Vehiculo { get; set; }
        public string Nombre_Persona { get; set; }
        public string Dpi_Persona { get; set; }
        public string Placa_Vehiculo { get; set; }
        public int? Id_Propiedad { get; set; }
        public int? Id_Motivo_Visita { get; set; }
        public string Observaciones { get; set; }
        public int Registrado_Por { get; set; }

    }
}
