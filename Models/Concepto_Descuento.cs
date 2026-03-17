namespace Condominio.Models
{
    public class Concepto_Descuento
    {
        public Concepto_Descuento()
        {

        }
        public Concepto_Descuento(string nombre, string tipo, decimal valor, int autorizacion)
        {
            Nombre = nombre;
            Tipo = tipo;
            Valor = valor;
            Autorizacion = autorizacion;
        }

        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }
        public required decimal Valor { get; set; }
        public required int Autorizacion { get; set; }

    }
}
