namespace Condominio.Models
{
    public class EspacioComunModel
    {
        public int Id_Espacio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad_Max { get; set; }
        public int Requiere_Reserva { get; set; }
        public int Tiene_Costo { get; set; }
        public decimal Costo_Por_Hora { get; set; }
        public decimal Costo_Por_Dia { get; set; }
        public decimal Deposito_Garantia { get; set; }
        public string Horario_Apertura { get; set; }
        public string Horario_Cierre { get; set; }
        public string Reglas { get; set; }
        public string Estado { get; set; }
        public int Activo { get; set; }

    }
}
