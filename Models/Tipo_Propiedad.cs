namespace Condominio.Models
{
    public class Tipo_Propiedad
    {
        public Tipo_Propiedad()
        {

        }
        public Tipo_Propiedad(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public int Id_Tipo_Propiedad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
