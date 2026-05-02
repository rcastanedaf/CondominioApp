namespace Condominio.Models
{
    public class ListaNegraModel
    {
        public int Id_Lista { get; set; }
        public string Tipo { get; set; }
        public int? Id_Persona { get; set; }
        public string Placa { get; set; }
        public string Nombres { get; set; }
        public string Dpi { get; set; }
        public string Motivo { get; set; }
        public int Activo { get; set; }
        public int Registrado_Por { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Observaciones { get; set; }

    }
}
