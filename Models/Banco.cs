namespace Condominio.Models
{
    public class Banco
    {
        public Banco()
        {

        }
        public Banco(string nombre, string pais, int activo)
        {
            Nombre = nombre;
            Pais = pais;
            Activo = activo;
        }

        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Pais { get; set; }
        public required int Activo { get; set; }
    }
}
