namespace Condominio.Models
{
    public class VehiculoModel
    {
        public int Id_Vehiculo { get; set; }
        public int Id_Residente { get; set; }
        public int Id_Propiedad { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Anio { get; set; }
        public string Color { get; set; }
        public string Tipo { get; set; }
        public string Parqueo_Asignado { get; set; }
        public int Activo { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_Registro { get; set; }

    }
}
