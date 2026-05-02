namespace Condominio.DTOs.Request
{
    public class VehiculoCreateRequest
    {
        public int Id_Residente { get; set; }
        public int Id_Propiedad { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Anio { get; set; }
        public string Color { get; set; }
        public string Tipo { get; set; }
        public string Parqueo_Asignado { get; set; }
        public int Activo { get; set; } = 1;
        public string Observaciones { get; set; }

    }
}
