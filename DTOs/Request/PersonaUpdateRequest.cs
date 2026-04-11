namespace Condominio.DTOs.Request
{
    public class PersonaUpdateRequest
    {
        public required int Id_Persona { get; set; }
        public required string Tipo { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string DPI { get; set; }
        public required string Pasaporte { get; set; }
        public required string Fecha_Nacimiento { get; set; }
        public required int Id_Estado_Civil { get; set; }
        public required int Nacionalidad { get; set; }
        public required string Telefono_Principal { get; set; }
        public required string Telefono_Secundario { get; set; }
        public required string Email { get; set; }
        public required string NIT { get; set; }
        public required int Id_Regimen_Fiscal { get; set; }
        public required string Observaciones { get; set; }
        public required int Activo { get; set; }
        public required string Fecha_Registro { get; set; }
    }
}
