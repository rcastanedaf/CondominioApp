namespace Condominio.Models
{
    public class RegistroAccesoModel
    {
        public int Id_Acceso { get; set; }
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
        public string Fecha_Hora { get; set; }

    }
}
