namespace Condominio.Models
{
    public class Persona
    {
        public Persona()
        {

        }
        public Persona(string tipo, string nombres, string apellidos, string dpi, string pasaporte, string fechaNacimiento,
            int idEstadoCivil, int nacionalidad, string telefonoPrincipal, string telefonoSecundario, string email, string nit,
            int idRegimenFiscal, string observaciones, int activo, string fechaRegistro)
        {
            Tipo = tipo;
            Nombres = nombres;
            Apellidos = apellidos;
            DPI = dpi;
            Pasaporte = pasaporte;
            Fecha_Nacimiento = fechaNacimiento;
            Id_Estado_Civil = idEstadoCivil;
            Nacionalidad = nacionalidad;
            Telefono_Principal = telefonoPrincipal;
            Telefono_Secundario = telefonoSecundario;
            Email = email;
            NIT = nit;
            Id_Regimen_Fiscal = idRegimenFiscal;
            Observaciones = observaciones;
            Activo = activo;
            Fecha_Registro = fechaRegistro;
        }

        public int Id_Persona { get; set; }
        public string Tipo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DPI { get; set; }
        public string Pasaporte { get; set; }  
        public string Fecha_Nacimiento { get; set; }
        public int Id_Estado_Civil { get; set; }
        public int Nacionalidad { get; set; }
        public string Telefono_Principal { get; set; }
        public string Telefono_Secundario { get; set; }
        public string Email { get; set; }
        public string NIT { get; set; }
        public int Id_Regimen_Fiscal { get; set; }
        public string Observaciones { get; set; }
        public int Activo { get; set; }
        public string Fecha_Registro { get; set; }

    }
}
